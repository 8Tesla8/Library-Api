using System;
namespace Library_API.Models.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Author { get; set; }
        public string Genre { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }
    }
}
