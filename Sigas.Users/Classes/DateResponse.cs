using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sigas.Users.Classes
{
    public class DataResponse<T> : ResponseBase<T> where T : class
	{

		[JsonConstructor]
		public DataResponse(T? data, ResponseError? error = default) : base(data, error)
		{
		}

        public DataResponse(T? data, Exception ex) : base(data, ex)
		{
		}

        public DataResponse(T? data, bool isError, bool isWarning, string errorMessage, string userMessage, HttpStatusCode code) : base(data, isError, isWarning, errorMessage, userMessage, code)
		{
		}
	}
}
