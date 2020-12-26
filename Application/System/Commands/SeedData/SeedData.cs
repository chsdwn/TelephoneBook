using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.System.Commands.SeedData
{
    public static class SeedData
    {
        public static void Seed(ITelephoneBookDbContext dbContext)
        {
            SeedPersons(dbContext);
        }

        private static void SeedPersons(ITelephoneBookDbContext dbContext)
        {
            if (!dbContext.Persons.Any())
            {
                dbContext.Persons.Add(new Person
                {
                    FirstName = "Ali",
                    LastName = "Veli",
                    Country = "Turkey",
                    City = "Konya",
                    District = "Meram",
                    Street = "Taş mermer",
                    ZipCode = "42000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Ayşe",
                    LastName = "Fatma",
                    Country = "Turkey",
                    City = "İstanbul",
                    District = "Kadıköy",
                    Street = "Taş ocak",
                    ZipCode = "34000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Hasan",
                    LastName = "Hüseyin",
                    Country = "Turkey",
                    City = "Ankara",
                    District = "Balgat",
                    Street = "Kırık kiremit",
                    ZipCode = "35000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Hatice",
                    LastName = "Yılmaz",
                    Country = "Turkey",
                    City = "Adana",
                    District = "Seyhan",
                    Street = "Kilim",
                    ZipCode = "01000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Fatih",
                    LastName = "Şahin",
                    Country = "Turkey",
                    City = "Bilecik",
                    District = "Osmaneli",
                    Street = "Sarıyele",
                    ZipCode = "11000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Akın",
                    LastName = "Metin",
                    Country = "Turkey",
                    City = "Sivas",
                    District = "Divriği",
                    Street = "Kardaşlık",
                    ZipCode = "58000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Erdal",
                    LastName = "Selim",
                    Country = "Turkey",
                    City = "Bursa",
                    District = "İnegöl",
                    Street = "Sinek kanadı",
                    ZipCode = "16000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Merve",
                    LastName = "Deniz",
                    Country = "Turkey",
                    City = "Eskişehir",
                    District = "Odunpazarı",
                    Street = "Soluk gül",
                    ZipCode = "26000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Selin",
                    LastName = "Serdar",
                    Country = "Turkey",
                    City = "Aksaray",
                    District = "Sultanhanı",
                    Street = "Kayalar",
                    ZipCode = "68000"
                });

                dbContext.Persons.Add(new Person
                {
                    FirstName = "Yavuz",
                    LastName = "Yalın",
                    Country = "Turkey",
                    City = "Yozgat",
                    District = "Saraykent",
                    Street = "Yıkık baca",
                    ZipCode = "66000"
                });

                dbContext.SaveChanges();

                SeedPhoneNumbers(dbContext);
            }
        }

        private static void SeedPhoneNumbers(ITelephoneBookDbContext dbContext)
        {
            var lastThreeDigit = 99;
            foreach (var person in dbContext.Persons)
            {
                dbContext.PhoneNumbers.Add(new PhoneNumber
                {
                    PersonId = person.Id,
                    Type = "Home",
                    Number = $"5555555{++lastThreeDigit}"
                });

                dbContext.PhoneNumbers.Add(new PhoneNumber
                {
                    PersonId = person.Id,
                    Type = "Work",
                    Number = $"5555555{++lastThreeDigit}"
                });

                dbContext.PhoneNumbers.Add(new PhoneNumber
                {
                    PersonId = person.Id,
                    Type = "Self",
                    Number = $"5555555{++lastThreeDigit}"
                });
            }

            dbContext.SaveChanges();
        }
    }
}