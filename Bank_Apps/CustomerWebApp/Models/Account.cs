using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApp.Models
{
    public partial class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Ifsc { get; set; }
        public string? AccountSummary { get; set; }
        public string? AadharNumber { get; set; }
        public string? MobileNumber { get; set; }
    }
}
