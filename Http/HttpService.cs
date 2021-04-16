using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Anki.Vector.Http
{
#pragma warning disable CS1591
	public class HttpService
	{
		public delegate void HttpResponseDelegate(IHttpResponse response);
		public delegate bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors);

		private Dictionary<string, ServerCertificateValidationCallback> _ServerCertHandlers = new Dictionary<string, ServerCertificateValidationCallback>();

		public const string JsonContentType = "application/json";
		public const string JsonType = "json";

		public HttpClient BaseHttpClient { get; set; }
		public bool Initialized { get; set; }

		public HttpService(string userAgent)
		{
			this.Initialize(userAgent);
		}

		public void DeInitialize()
		{
			this.BaseHttpClient.Dispose();
			this.BaseHttpClient = null;
		}

		public void Initialize(string userAgent)
		{
			HttpClientHandler httpClientHandler = new HttpClientHandler();
			//httpClientHandler.Timeout = new TimeSpan?(new TimeSpan(0, 0, 30));
			this.BaseHttpClient = new HttpClient(httpClientHandler);
			if (this.BaseHttpClient == null)
				throw new InvalidOperationException("Failed to create HttpClient!");

			ServicePointManager.Expect100Continue = true;
			//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.HandleRemoteCertificateValidationCallback);

			this.BaseHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", userAgent);
			this.Initialized = true;
		}

		public async Task<HttpResponse> Get(Uri uri, IEnumerable<KeyValuePair<string, string>> headers = null, Tuple<string, string> authorization = null)
		{
			if (!this.Initialized)
				throw new InvalidOperationException("Trying to perform HTTP GET when service is not initialized!");

			HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
			this.AddAuthorization(requestMessage, authorization);
			this.AddHeaders(requestMessage, headers);

			return await this.DoSharedRequestLogic(requestMessage).ConfigureAwait(false);
		}

		public async Task<HttpResponse> Post(Uri uri, JToken request, IEnumerable<KeyValuePair<string, string>> headers = null, Tuple<string, string> authorization = null)
		{
			if (!this.Initialized)
				throw new InvalidOperationException("Trying to perform HTTP POST when service is not initialized!");

			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
			this.AddAuthorization(httpRequestMessage, authorization);
			this.AddHeaders(httpRequestMessage, headers);
			HttpContent content = new StringContent(request.ToString(Formatting.None, Array.Empty<JsonConverter>()), Encoding.UTF8, "application/json");
			httpRequestMessage.Content = content;

			return await this.DoSharedRequestLogic(httpRequestMessage).ConfigureAwait(false);
		}

		public async Task<HttpResponse> Post(Uri uri, IEnumerable<KeyValuePair<string, string>> request, IEnumerable<KeyValuePair<string, string>> headers = null, Tuple<string, string> authorization = null)
		{
			if (!this.Initialized)
				throw new InvalidOperationException("Trying to perform HTTP POST when service is not initialized!");

			if (request == null)
				request = new Dictionary<string, string>();

			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
			this.AddAuthorization(httpRequestMessage, authorization);
			this.AddHeaders(httpRequestMessage, headers);
			HttpContent content = new FormUrlEncodedContent(request);
			httpRequestMessage.Content = content;

			return await this.DoSharedRequestLogic(httpRequestMessage).ConfigureAwait(false);
		}

		internal async Task<HttpResponse> DoSharedRequestLogic(HttpRequestMessage requestMessage)
		{
			try
			{
				using (HttpResponseMessage response = await this.BaseHttpClient.SendAsync(requestMessage).ConfigureAwait(false))
				{
					response.EnsureSuccessStatusCode();
					string contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					if (response.Content.Headers.ContentType.ToString().Contains("json"))
						return new HttpResponse(response, JToken.Parse(contentString), contentString);
					else
						return new HttpResponse(response, contentString);
				}
			}
			catch (Exception exception)
			{
				return new HttpResponse(exception, requestMessage);
			}
		}

		public void RegisterServerCertificateValidationCallback(string host, ServerCertificateValidationCallback callback)
		{
			if (this._ServerCertHandlers.ContainsKey(host))
			{
				this._ServerCertHandlers[host] = callback;
				return;
			}
			this._ServerCertHandlers.Add(host, callback);
		}

		protected bool HandleRemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			string text = sender as string;
			if (!string.IsNullOrEmpty(text) && this._ServerCertHandlers.ContainsKey(text))
				return this._ServerCertHandlers[text](sender, certificate, chain, sslPolicyErrors);

			return sslPolicyErrors == SslPolicyErrors.None;
		}

		public Task<string> GetStringAsync(string url)
		{
			return this.BaseHttpClient.GetStringAsync(url);
		}

		internal void AddAuthorization(HttpRequestMessage requestMessage, Tuple<string, string> authorization)
		{
			if (authorization != null)
				requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorization.Item1, authorization.Item2);
		}

		internal void AddHeaders(HttpRequestMessage requestMessage, IEnumerable<KeyValuePair<string, string>> headers)
		{
			if (headers != null)
				foreach (KeyValuePair<string, string> keyValuePair in headers)
					requestMessage.Headers.Add(keyValuePair.Key, keyValuePair.Value);
		}
	}

	#pragma warning restore CS1591
}