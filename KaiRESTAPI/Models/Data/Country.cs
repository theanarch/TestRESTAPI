using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KaiRESTAPI.Models.Data
{
    public partial class Country
    {
        public string Name { get; set; }
        [Key]
        public string Code { get; set; }

        internal static Country ReadDB(StaffyloContext context, string countryCode)
        {
            return context.Countries.Where(c => c.Code == countryCode).FirstOrDefault();
        }

        // Eventuellt korta ner koderna 
        internal static bool AddCountry(StaffyloContext context, Country country)
        {
            bool countryAdded = false;
            var countryToAdd = context.Countries.Where(c => c.Code == country.Code).Select(c => c);

            if (countryToAdd == null)
            {
                context.Countries.Add(country);
                context.SaveChanges();
                countryAdded = true;
            }

            return countryAdded;
        }

        internal static bool DeleteCountry(StaffyloContext context, string code)
        {
            bool countryDeleted = false;
            Country countryToDelete = context.Countries.Where(c => c.Code == code).FirstOrDefault();

            if (countryToDelete != null)
            {
                context.Remove(countryToDelete);
                context.SaveChanges();
                countryDeleted = true;
            }

            return countryDeleted;
        }

        internal static bool UpdateCountry(StaffyloContext context, Country country)
        {
            bool countryUpdated = false;
            Country countryToUpdate = context.Countries.Where(c => c.Code == country.Code).FirstOrDefault();

            if (countryToUpdate != null)
            {
                countryToUpdate.Name = country.Name;
                context.Update(countryToUpdate);
                context.SaveChanges();
                countryUpdated = true;
            }

            return countryUpdated;
        }
    }
}