using FinanceTracker.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.ViewModel
{
    public class TransactionCreateFormViewModel
    {

        [DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }

        public decimal amount { get; set; }

        public string description { get; set; }




        public int CategoryId { get; set; }


    }
}
