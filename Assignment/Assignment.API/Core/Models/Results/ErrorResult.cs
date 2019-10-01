using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Core.Models.Results {

    public class ErrorResult {

        public string Field { get; set; }
        public string Message { get; set; }

        public ErrorResult(string field, string message) {
            this.Field = field;
            this.Message = message;
        }
    }
}
