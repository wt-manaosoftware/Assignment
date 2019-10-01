using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Core.Models.Results {

    public class ValidationResult {

        public bool Success { get; set; }
        public string Message { get; set; }
        public string Field { get; set; }

        public ValidationResult(bool success = true, string field = "", string message = "") {
            this.Success = success;
            this.Field = field;
            this.Message = message;
        }
    }
}
