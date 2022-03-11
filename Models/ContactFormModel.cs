using System.ComponentModel.DataAnnotations;

namespace shredhousepage.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MinLength(8)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [MinLength(8)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [MinLength(8)]
        public string Message { get; set; }
    }
}