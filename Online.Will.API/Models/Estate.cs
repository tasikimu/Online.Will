using System.ComponentModel.DataAnnotations;

namespace Online.Will.API.Models
{
    public class Estate
    {
        /*Banking Details Page*/
        [Key]
        public int ID { get; set; }
        public string IdentificationNo { get; set; }
        public string Title { get; set; }
        public string Fullnames { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public Bank Banks { get; set; }
    }

    public class Bank
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string BranchCode { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string Deductions { get; set; }
    }
}
