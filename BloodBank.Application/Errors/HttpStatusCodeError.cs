using BloodBank.Core.Results.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Errors
{
    public record HttpStatusCodeError(string Code, string Message, HttpStatusCode StatusCode) : IError
    {
        public HttpStatusCodeError(IError error, HttpStatusCode StatusCode)
            : this(error.Code, error.Message, StatusCode) { }
    }
}
