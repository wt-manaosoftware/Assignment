using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Core.Models.Results {

    public class Result<T> where T : class {

        public T Data { get; set; }
        public bool Success { get; set; }
        public List<ErrorResult> Errors { get; set; }

        public static Result<T> ResultSuccess(T data) {
            return new Result<T>() {
                Data = data,
                Success = true,
                Errors = new List<ErrorResult>()
            };
        }

        public static Result<T> ResultFail(ValidationResult validationResult) {
            var errorResults = new List<ErrorResult>();
            var errorResult = new ErrorResult(validationResult.Field, validationResult.Message);
            errorResults.Add(errorResult);

            return new Result<T>() {
                Success = false,
                Errors = errorResults
            };
        }

    }
}
