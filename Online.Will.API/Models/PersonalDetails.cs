using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online.Will.API.Models
{
    public class PersonalDetails
    {
        [Key]
        public int ID { get; set; }
        public string IdentificationNo { get; set; }
        public string Title { get; set; }
        public string Fullnames { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cellphone { get; set; }
        public string PostalAddress { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal EstateValue { get; set; }

        public string MaritalStatus { get; set; }

        public Marriage Marriages { get; set; }

        public List<Cohabit> Cohabits { get; set; }
        public string BurialPreference { get; set; }

        [MaxLength(20000)]
        public string LastWishes { get; set; }

        public int NumberOfChildren { get; set; }

        public List<Children> Childrens { get; set; }

        public List<PrefferedHeir> PrefferedHeirs { get; set; }

        public List<Charity> Charities { get; set; }
    }

    public class Marriage
    {
        public int ID { get; set; }
        public string TypeOfMarriage { get; set; }
        public string Fullname { get; set; }
        public string Surname { get; set; }
        public string IdentificationNo { get; set; }
    }

    public class Cohabit
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Surname { get; set; }
        public string IdentificationNo { get; set; }
    }

    public class Children
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Surname { get; set; }
        [NotMapped]
        public DateOnly DOB { get; set; }
    }

    public class PrefferedHeir
    {
        public int ID { get; set; }
        public string Relationship { get; set; }
        public string Fullname { get; set; }
        public string Surname { get; set; }
    }

    public class Charity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
    }
}
