using CarRental.Models;
using CarRental.Services.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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