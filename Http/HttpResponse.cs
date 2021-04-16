using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Anki.Vector.Http
{
#pragma warning disable CS1591
	public interface IHttpResponse
	{
		IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; }

		string ContentAsString { get; }

		JToken ContentAsJson { get; }

		HttpStatusCode StatusCode { get; }

		bool Success { get; }

		HttpRequestMessage OriginalRequest { get; }

		Exception Exception { get; }
	}

	public class HttpResponse : IHttpResponse
	{
		public HttpResponse(HttpResponseMessage res, JToken content, string contentStr)
		{
			this._ResponseMessage = res;
			this.ContentAsJson = content;
			this.ContentAsString = contentStr;
			this.OriginalRequest = res.RequestMessage;
		}

		public HttpResponse(HttpResponseMessage res, string content)
		{
			this._ResponseMessage = res;
			this.ContentAsJson = null;
			this.ContentAsString = content;
			this.OriginalRequest = res.RequestMessage;
		}

		public HttpResponse(Exception exception, HttpRequestMessage originalRequest)
		{
			this.Exception = exception;
			this.OriginalRequest = originalRequest;
			this.ContentAsJson = null;
			this.ContentAsString = null;
			this._ResponseMessage = null;
		}

		public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers
		{
			get { return (this._ResponseMessage != null) ? this._ResponseMessage.Headers : null; }
		}

		public HttpStatusCode StatusCode
		{
			get
			{
				if (this._ResponseMessage != null)
					return this._ResponseMessage.StatusCode;
				throw new InvalidOperationException("Cannot request the HTTP status of a failed request");
			}
		}

		public bool Success
		{
			get { return this._ResponseMessage != null && this._ResponseMessage.IsSuccessStatusCode; }
		}

		private readonly HttpResponseMessage _ResponseMessage;
		public HttpRequestMessage OriginalRequest { get; set; }
		public Exception Exception { get; set; }
		public JToken ContentAsJson { get; }
		public string ContentAsString { get; }
	}

#pragma warning restore CS1591
}