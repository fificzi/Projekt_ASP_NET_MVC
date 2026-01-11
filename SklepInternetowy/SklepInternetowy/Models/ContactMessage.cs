using System.ComponentModel.DataAnnotations;

namespace SklepInternetowy.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Display(Name = "Adres Email")]
        [Required(ErrorMessage = "Proszę podać email")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email")]
        public string Email { get; set; }

        [Display(Name = "Numer telefonu")]
        [Phone(ErrorMessage = "Niepoprawny numer telefonu")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tytuł wiadomości")]
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        public string Subject { get; set; }

        [Display(Name = "Treść wiadomości")]
        [Required(ErrorMessage = "Treść wiadomości jest wymagana")]
        public string MessageBody { get; set; }

        [Display(Name = "Data wysłania")]
        public DateTime SentDate { get; set; } = DateTime.Now;
    }
}