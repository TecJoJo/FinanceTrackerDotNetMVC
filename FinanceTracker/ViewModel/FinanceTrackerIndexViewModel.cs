﻿using FinanceTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinanceTracker.ViewModel
{
    public class FinanceTrackerIndexViewModel
    {   
      

       

        public List<TransactionViewModel> transactionListItems { get; set; }   = new List<TransactionViewModel>();  

       
    }
}
