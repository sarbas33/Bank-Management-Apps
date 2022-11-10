using System.ComponentModel.DataAnnotations;

namespace CustomerWebApp.Models
{
    public class InternetBankingLoginCreds
    {

        [Key]
        public int SerialNumber { get; set; }
        public int AccountNumber { get; set; }
        public int InternetBankingId { get; set; }
        public int InternetBankingPassword { get; set; }

        public InternetBankingLoginCreds()
        {

        }
    }
}
