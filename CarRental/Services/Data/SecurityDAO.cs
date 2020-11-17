using CarRental.Models;
using System.Linq;

namespace CarRental.Services.Data
{
    public class SecurityDAO
    {
        internal bool FindByUser(LoginViewModel user)
        {
            using (CarRentalEntities db = new CarRentalEntities())
            {
                return db.Users.Where(x => x.email == user.Email && x.password == user.Password).FirstOrDefault() != null;
            }
        }

        internal bool FindByEmail(string email)
        {
            using (CarRentalEntities db = new CarRentalEntities())
            {
                return db.Users.Where(x => x.email == email).FirstOrDefault() != null;
            }
        }
    }
}