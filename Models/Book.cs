using System;
namespace Library_API.Models
{
    public class Book : BaseModel
    {
        public int AuthorId { get; set; } 
        public int GenreId { get; set; }
        public int Year { get; set; }
    }
}
