using System.ComponentModel.DataAnnotations;
namespace CustomerWebApp.Models
{
    public class LoginCustomer
    {

        [Key]
        public int SerialNumber { get; set; }
        public int AccountNumber { get; set; }
        public int InternetBankingId { get; set; }
        public string InternetBankingPassword { get; set; }

        public LoginCustomer()
        {

        }
    }
}
