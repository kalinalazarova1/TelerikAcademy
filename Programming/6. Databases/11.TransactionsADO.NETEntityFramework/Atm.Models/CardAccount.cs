namespace Atm.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CardAccount
    {
        public int Id { get; set; }

        [StringLength(10)]
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public int CardPIN { get; set; }

        [Required]
        public decimal CardCash { get; set; }
    }
}
