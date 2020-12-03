using CarRental.Models;
using CarRental.Services.Data;

namespace CarRental.Services.Business
{
    public class SecurityService
    {
        readonly SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(LoginViewModel user)
        {
            return daoService.FindByUser(user);
        }

        public bool EmailExist(string email)
        {
            return daoService.FindByEmail(email);
        }
    }
}