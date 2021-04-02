using Anki.Vector.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Anki.Vector
{
    public class AccountApiError
	{
		public string Code;
		public string Field;
		public string Status;
		public string Message;		
		public Exception Exception;


		public static AccountApiError GetErrorFromResponse(JObject responseJson)
		{
			AccountApiError accountApiError = new AccountApiError();
			JToken jtokenCode = responseJson.SelectToken("code");
			accountApiError.Code = (jtokenCode != null) ? jtokenCode.ToString() : null;
			JToken jtokenStatus = responseJson.SelectToken("status");
			accountApiError.Status = (jtokenStatus != null) ? jtokenStatus.ToString() : null;
			JToken jtokenMessage = responseJson.SelectToken("message");
			accountApiError.Message = (jtokenMessage != null) ? jtokenMessage.ToString() : null;
			JToken jtokenField = responseJson.SelectToken("field");
			accountApiError.Field = (jtokenField != null) ? jtokenField.ToString() : null;
			return accountApiError;
		}

		public static AccountApiError GetErrorFromException(Exception exception)
		{
			AccountApiError accountApiError = new AccountApiError();
			accountApiError.Exception = exception;
			accountApiError.Message = ProcessExceptionMessage(exception);
			return accountApiError;
		}

		private static string ProcessExceptionMessage(Exception error)
		{
			string resultMessage = string.Empty;
			if (error != null)
				resultMessage += string.Format("{0}\r\n", error.Message);

			if (error is AggregateException)
			{
				foreach (Exception e in (error as AggregateException).Flatten().InnerExceptions)
					resultMessage += ProcessExceptionMessage(e);
			}

			if (error.InnerException != null)
				resultMessage += ProcessExceptionMessage(error.InnerException);

			return resultMessage;
		}
    }

	public class AccountApiResponse
	{
		public bool Success;
		public AccountApiError Error;
		public IHttpResponse RawResponse;

		public AccountApiResponse(IHttpResponse httpResponse)
		{
			if (httpResponse != null)
			{
				this.RawResponse = httpResponse;
				this.Success = httpResponse.Success;

				JObject jObject = this.TryGetResponseContentAsJson();
				if (jObject == null)
				{
					if (httpResponse.Exception != null)
						this.Error = AccountApiError.GetErrorFromException(httpResponse.Exception);
					this.Success = false;
				}
				else if (!this.Success)
					this.Error = AccountApiError.GetErrorFromResponse(jObject);
			}

			if ((!this.Success) && (this.Error != null))
				throw new WebException(this.Error.Message);
		}

		public JObject TryGetResponseContentAsJson()
		{
			if (this.RawResponse == null)
				return null;

			JToken jtoken = this.RawResponse.ContentAsJson;
			if (jtoken == null && this.RawResponse.ContentAsString != null)
				jtoken = JToken.Parse(this.RawResponse.ContentAsString);

			return jtoken as JObject;
		}
	}

	public class AnkiService
	{
		private HttpService _HttpService;

		internal static string AnkiApiEndPoint = "https://accounts.api.anki.com";
		internal static string AnkiAppKeyHeader = "Anki-App-Key";
		internal static string AnkiAppKeyValue = "aung2ieCho3aiph7Een3Ei";

		internal static string AuthSchemeAnki = "Anki";
	
		private Dictionary<string, string> RequestHeaders
		{
			get
			{
				Dictionary<string, string> headers = new Dictionary<string, string>();
				headers.Add(AnkiService.AnkiAppKeyHeader, AnkiService.AnkiAppKeyValue);
				return headers;
			}
		}

		public AnkiService(string userAgent)
		{
			this._HttpService = new HttpService(userAgent);
		}

		public int GetPasswordComplexityMissingFlags(string password)
		{
			int complexityBits = 0;
			if (password.Length < 8 || password.Length > 32)
				complexityBits |= 1;
			if (!Enumerable.Any<char>(password, new Func<char, bool>(char.IsDigit)))
				complexityBits |= 8;
			if (!Enumerable.Any<char>(password, new Func<char, bool>(char.IsUpper)))
				complexityBits |= 4;
			if (!Enumerable.Any<char>(password, new Func<char, bool>(char.IsLower)))
				complexityBits |= 2;
			return complexityBits;
		}

		public bool IsPasswordValid(string password)
		{
			if (string.IsNullOrEmpty(password))
				return false;

			int passwordComplexityMissingFlags = this.GetPasswordComplexityMissingFlags(password);
			return passwordComplexityMissingFlags == 0;
		}

		public async Task<AccountApiResponse> UserCreateAccount(JObject request)
		{
			Uri uri = this.MakeUriForRequest("/1/users");
			IHttpResponse response = await this._HttpService.Post(uri, request, this.RequestHeaders, null).ConfigureAwait(false);
			return new AccountApiResponse(response);
		}

		public async Task<AccountApiResponse> UserRequestEmailVerification(string sessionToken, string userId)
		{
			Tuple<string, string> authorization = new Tuple<string, string>(AnkiService.AuthSchemeAnki, sessionToken);

			Uri uri = this.MakeUriForRequest(string.Format("/1/users/{0}/verify_email", userId));
			IHttpResponse response = await this._HttpService.Post(uri, new Dictionary<string, string>(), this.RequestHeaders, authorization).ConfigureAwait(false);
			return new AccountApiResponse(response);
		}

		public async Task<AccountApiResponse> UserCheckForEmailVerification(string sessionToken, string userId)
		{
			Tuple<string, string> authorization = new Tuple<string, string>(AnkiService.AuthSchemeAnki, sessionToken);

			Uri uri = this.MakeUriForRequest(string.Format("/1/users/{0}", userId));
			IHttpResponse response = await this._HttpService.Get(uri, this.RequestHeaders, authorization).ConfigureAwait(false);
			return new AccountApiResponse(response);
		}

		public async Task<AccountApiResponse> UserResetPassword(string email)
		{
			Dictionary<string, string> reqquest = new Dictionary<string, string>();
			reqquest.Add("email", email);

			Uri uri = this.MakeUriForRequest("/1/reset_user_password");
			IHttpResponse response = await this._HttpService.Post(uri, reqquest, this.RequestHeaders, null).ConfigureAwait(false);
			return new AccountApiResponse(response);
		}

		public async Task<AccountApiResponse> UserUpdatePassword(string sessionToken, string userId, string newPassword)
		{
			Tuple<string, string> authorization = new Tuple<string, string>(AnkiService.AuthSchemeAnki, sessionToken);
			JObject request = new JObject();
			request.Add("password", newPassword);

			Uri uri = this.MakeUriForRequest(string.Format("/1/users/{0}/patch", userId));
			IHttpResponse response = await this._HttpService.Post(uri, request, this.RequestHeaders, authorization).ConfigureAwait(false);
			return new AccountApiResponse(response);
		}

		public async Task<AccountApiResponse> SessionLogin(string email, string password)
		{
			Dictionary<string, string> request = new Dictionary<string, string>();
			request.Add("username", email);
			request.Add("password", password);

			Uri uri = this.MakeUriForRequest("/1/sessions");
			IHttpResponse response = await this._HttpService.Post(uri, request, this.RequestHeaders, null).ConfigureAwait(false);
			return new AccountApiResponse(response);
		}

		public async Task<AccountApiResponse> SessionLogout(string sessionToken)
		{
			Tuple<string, string> authorization = new Tuple<string, string>(AnkiService.AuthSchemeAnki, sessionToken);
			Dictionary<string, string> request = new Dictionary<string, string>();
			request.Add("session_token", sessionToken);

			Uri uri = this.MakeUriForRequest("/1/sessions/delete");
			IHttpResponse response = await this._HttpService.Post(uri, request, this.RequestHeaders, authorization).ConfigureAwait(false);
			return new AccountApiResponse(response);
		}

		public async Task<AccountApiResponse> GetUserInfo(string sessionToken, string userId)
		{
			Tuple<string, string> authorization = new Tuple<string, string>(AnkiService.AuthSchemeAnki, sessionToken);
			Uri uri = this.MakeUriForRequest("/1/users/" + userId);
			IHttpResponse response = await this._HttpService.Get(uri, this.RequestHeaders, authorization).ConfigureAwait(false);
			return new AccountApiResponse(response);
		}

		private Uri MakeUriForRequest(string requestName)
		{
			return new Uri(string.Format("{0}{1}", AnkiService.AnkiApiEndPoint, requestName));
		}
	}
}