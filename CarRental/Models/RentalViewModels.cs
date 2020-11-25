using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class CarViewModel 
    {
        public string CarName { get; set; }

        [Display(Name = "Rodzaj paliwa")]
        public string FuelType { get; set; }

        [Display(Name = "Skrzynia biegów")]
        public string Transmission { get; set; }

        [Display(Name = "Zużycie (cykl mieszany) [l/100km]")]
        public string ConsumptionCombined { get; set; }

        [Display(Name = "Klimatyzacja")]
        public string AirConditioning { get; set; }

        [Display(Name = "Rodzaj napędu")]
        public string DriveType { get; set; }

        [Display(Name = "Pojemność bagażnika [l]")]
        public string LuggageCapacity { get; set; }

        public string Photo { get; set; }
    }
}