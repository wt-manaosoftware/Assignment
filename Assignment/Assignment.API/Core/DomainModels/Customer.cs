using Assignment.API.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Core.DomainModels {

    public class Customer : EntityBase {

        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public CustomerDTO ToDTO() {
            CustomerDTO result = new CustomerDTO() {
                Id = this.Id,
                Name = this.Name,
                ContactEmail = this.ContactEmail,
                MobileNo = this.MobileNo,
                Transactions = new List<TransactionDTO>()
            };

            foreach (var transaction in this.Transactions) {
                TransactionDTO DTO = transaction.ToDTO();
                result.Transactions.Add(DTO);
            }

            return result;
        }
    }
}
