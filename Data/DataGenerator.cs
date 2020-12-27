using System;
using System.Collections.Generic;
using Library_API.Models;

namespace Library_API.Data
{
    public class DataGenerator
    {
        public DataGenerator()
        {
        }

        public List<Country> GenerateCountries()
        {
            return new List<Country>()
            {
                new Country
                {
                    Id = 1,
                    Name = "england",
                },
                new Country
                {
                    Id = 2,
                    Name = "russia",
                },
                new Country
                {
                    Id = 3,
                    Name = "usa",
                },
            };
        }

        public List<Author> GenerateAuthors()
        {
            return new List<Author>()
            {
                new Author
                {
                    Id = 1,
                    Name = "joanne rowling",
                    CountryId = 1,

                },
                new Author
                {
                    Id = 2,
                    Name = "lev nikolayevich tolstoy",
                    CountryId = 2
                },
                new Author
                {
                    Id = 3,
                    Name = "agatha christie",
                    CountryId = 2
                },


            };
        }

        public List<Book> GenerateBooks()
        {
            return new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Name = "war and peace",
                    AuthorId = 2,
                    GenreId = 1,
                    Year = 1869,
                },
                new Book
                {
                    Id = 2,
                    Name = "anna karenina",
                    AuthorId = 2,
                    GenreId = 1,
                    Year = 1878,
                },
                new Book
                {
                    Id = 3,
                    Name = "harry potter and the philosopher's stone",
                    AuthorId = 1,
                    GenreId = 2,
                    Year = 1997,
                },
                new Book
                {
                    Id = 4,
                    Name = "harry potter and the chamber of secrets",
                    AuthorId = 1,
                    GenreId = 2,
                    Year = 1998,
                },
                new Book
                {
                    Id = 5,
                    Name = "the mystery of the blue train",
                    AuthorId = 3,
                    GenreId = 3,
                    Year = 1928,
                },
                new Book
                {
                    Id = 6,
                    Name = "the body in the library",
                    AuthorId = 3,
                    GenreId = 4,
                    Year = 1942,
                },
            };
        }

        public List<Genre> GenerateGenres()
        {
            return new List<Genre>()
            {
                new Genre
                {
                    Id = 1,
                    Name = "novel",
                },
                new Genre
                {
                    Id = 2,
                    Name = "fantasy",
                },
                new Genre
                {
                    Id = 3,
                    Name = "mystery",
                },
                new Genre
                {
                    Id = 4,
                    Name = "crime novel",
                },
            };
        }

    }
}
