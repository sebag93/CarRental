using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    #region Logowanie
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Adres email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętać Cię?")]
        public bool RememberMe { get; set; }
    }
    #endregion

    #region Rejestracja
    public class RegisterViewModels
    {
        //dane do logowania
        [Required]
        [EmailAddress]
        [Display(Name ="Adres email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [MinLength(6, ErrorMessage = "Hasło musi zawierać co najmniej 6 znaków")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasło i jego potwierdzenie są niezgodne.")]
        public string ConfirmPassword { get; set; }

        //dane personalne
        [Required]
        [Display(Name = "Imię")]
        [MinLength(2, ErrorMessage = "Wprowadź poprawne imię.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        [MinLength(2, ErrorMessage = "Wprowadź poprawne nazwisko.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Miasto")]
        [MinLength(2, ErrorMessage = "Wprowadź poprawne miasto.")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        [MinLength(2, ErrorMessage = "Wprowadź poprawną nazwę ulicy.")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Numer domu/mieszkania")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Kod pocztowy")]
        [RegularExpression(@"^(\d{2}-\d{3})$", ErrorMessage = "Wprowadź prawidłowy kod pocztowy (XX-XXX).")]
        public string ZipCode { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Numer telefonu")]
        [RegularExpression(@"^([0-9\+]{9}|[0-9]{3}-[0-9]{3}-[0-9]{3}|[0-9]{3}\s[0-9]{3}\s[0-9]{3})$", ErrorMessage = "Wprowadź prawidłowy numer telefonu (123123123, 123-123-123, 123 123 123)")]
        public string PhoneNumber { get; set; }
    }
    #endregion
}