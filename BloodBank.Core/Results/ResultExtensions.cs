using BloodBank.Core.Results.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Results
{
    public static class ResultExtensions
    {
        public static T Match<T>(this Result result, Func<T> onSuccess, Func<IReadOnlyList<IError>, T> onFailure)
        {
            return result.Success ? onSuccess() : onFailure(result.Errors);
        }

        public static T Match<T, TValue>(this Result<TValue> result, Func<TValue?, T> onSuccess, Func<IReadOnlyList<IError>, T> onFailure)
        {
            return result.Success ? onSuccess(result.ValueOrDefault) : onFailure(result.Errors);
        }
    }
}
