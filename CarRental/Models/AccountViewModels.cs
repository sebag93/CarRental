namespace CarRental.Models
{

    #region Rejestracja
    public class RegisterViewModels
    {
        //dane do logowania
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //dane personalne
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
    }
    #endregion
}