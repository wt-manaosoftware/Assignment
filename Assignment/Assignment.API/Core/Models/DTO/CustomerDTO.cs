using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Core.Models.DTO {

    public class CustomerDTO {

        public long Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }
        public ICollection<TransactionDTO> Transactions { get; set; }
    }
}
