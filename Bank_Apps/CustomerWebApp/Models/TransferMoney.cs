using System.ComponentModel.DataAnnotations;
namespace CustomerWebApp.Models
{
    public class TransferMoney
    {
        [Key]
        public int SerialNumber { get; set; }
        public int FromAccountNumber { get; set; }
        public int ToAccountNumber { get; set; }
        public int Amount { get; set; }
        public string TransactionId { get; set; }   

        public TransferMoney()
        {

        }
    }
}
