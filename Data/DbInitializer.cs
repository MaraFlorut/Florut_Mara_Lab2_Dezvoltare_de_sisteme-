using Florut_Mara_Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Florut_Mara_Lab2.Data;
namespace Nume_Pren_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Book.Any())
                {
                    return; // BD a fost creata anterior
                }

                context.Author.AddRange(
                new Author 
                {
                    FirstName = "Mihail", 
                    LastName = "Sadoveanu" },
                new Author 
                { 
                    FirstName = "George", LastName = "Calinescu" },
                new Author 
                { 
                    FirstName = "Mircea", LastName = "Eliade" },
                new Author 
                { 
                    FirstName = "Ion", LastName = "Creangă" }
                );

                context.Book.AddRange(
                new Book
                {
                    Title = "Baltagul"},
               
                new Book
                {
                    Title = "Enigma Otiliei"},
               
                new Book
                {
                    Title = "Maytrei"}
               
                );

                context.Genre.AddRange(
               new Genre { Name = "Roman" },
               new Genre { Name = "Nuvela" },
               new Genre { Name = "Poezie" }
                );
                context.Customer.AddRange(
                new Customer
                {
                    Name = "Popescu Marcela",
                    Adress = "Str. Plopilor, nr. 24",
                    BirthDate = DateTime.Parse("1979-09-01")
                },
                new Customer
                {
                    Name = "Mihailescu Cornel",
                    Adress = "Str. Bucuresti, nr. 45, ap. 2",BirthDate=DateTime.Parse("1969 - 07 - 08")}
               
                );

                context.SaveChanges();
            }
        }
    }
}