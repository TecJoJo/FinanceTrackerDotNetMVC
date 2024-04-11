using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.ViewModel
{
    public class TransactionEditFormViewModel
    {
        [DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public decimal amount { get; set; }


        public string? description { get; set; } = string.Empty;




        public int CategoryId { get; set; }

        public List<SelectListItem> selectListItems { get; set; } = new List<SelectListItem>();

        public int TransactionId { get; set; }  
    }
}
