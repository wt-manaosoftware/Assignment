using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Core.DomainModels {

    public class Customer : EntityBase {

        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }
    }
}
