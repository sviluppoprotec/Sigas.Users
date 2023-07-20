using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sigas.Users.Classes
{
	public class ResponseBase<T>
	{

		[JsonProperty("data")]
		public T? Data { get; set; }
		[JsonProperty("error")]
		public ResponseError? Error { get; set; }

		public ResponseBase(T? data, ResponseError? error = default)
		{
			Data = data;
			Error = error;
		}

		public ResponseBase(T? data, bool isError, bool isWarning, string errorMessage, string userMessage, HttpStatusCode code)
		{
			Data = data;
			Error = new(isError, isWarning, errorMessage, userMessage, code);
		}

		public ResponseBase(T? data, Exception ex)
		{
			Data = data;
			Error = new(ex);
		}
	}

	public class ResponseError
	{
		[JsonProperty("isError")]
		public bool IsError { get; set; } = false;
		[JsonProperty("isWarning")]
		public bool IsWarning { get; set; } = false;
		[JsonProperty("errorMessage")]
		public string ErrorMessage { get; set; } = string.Empty;
		[JsonProperty("userMessage")]
		public string UserMessage { get; set; } = string.Empty;
		[JsonProperty("code")]
		public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;


		public ResponseError(bool isError, bool isWarning, string errorMessage, string userMessage, HttpStatusCode code)
		{
			IsError = isError;
			IsWarning = isWarning;
			ErrorMessage = errorMessage;
			UserMessage = userMessage;
			Code = code;
		}
		internal ResponseError(Exception ex)
		{
			IsError = true;
			IsWarning = false;
			ErrorMessage = ex.Message;
			UserMessage = "Oops.. qualcosa è andato storto";
			Code = HttpStatusCode.InternalServerError;
		}
		public ResponseError()
		{
			IsError = false;
			IsWarning = false;
			ErrorMessage = null;
			UserMessage = null;
			Code = HttpStatusCode.OK;
		}

	}
}
