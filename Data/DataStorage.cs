using System;
using System.Collections.Generic;
using System.Linq;
using Library_API.Models;
using Library_API.Models.DTO;

namespace Library_API.Data
{
    public class DataStorage
    {
        public List<Book> Books { get; private set; }
        public List<Author> Authors { get; private set; }
        public List<Genre> Genres { get; private set; }
        public List<Country> Countries { get; private set; }

        public string BooksKey = nameof(Books);
        public string AuthorsKey = nameof(Authors);
        public string GenresKey = nameof(Genres);
        public string CountriesKey = nameof(Countries);

        public DataStorage()
        {
            var generator = new DataGenerator();

            Books = generator.GenerateBooks();
            Authors = generator.GenerateAuthors();
            Genres = generator.GenerateGenres();
            Countries = generator.GenerateCountries();

        }

        public List<BookDTO> BooksDTO
        {
            get
            {
                return Books.Select(b => new BookDTO()
                {
                    Id = b.Id,
                    Year = b.Year,
                    Name = b.Name,
                    Author = Authors.FirstOrDefault(a => a.Id == b.AuthorId)?.Name,
                    Genre = Genres.FirstOrDefault(g => g.Id == b.GenreId)?.Name,
                }).ToList();
            }
        }

        public List<AuthorDTO> AuthorsDTO
        {
            get
            {
                return Authors.Select(a => new AuthorDTO()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Country = Countries.FirstOrDefault(c => c.Id == a.CountryId)?.Name,
                }).ToList();
            }
        }


        public void SetCollection(string collectionName, List<BaseModel> collection)
        {
            switch (collectionName)
            {
                case nameof(Books):
                    Books = collection.ConvertAll(instance => (Book)instance);
                    break;

                case nameof(Authors):
                    Authors = collection.ConvertAll(instance => (Author)instance);
                    break;

                case nameof(Countries):
                    Countries = collection.ConvertAll(instance => (Country)instance);
                    break;

                case nameof(Genres):
                    Genres = collection.ConvertAll(instance => (Genre)instance);
                    break;

                default:
                    throw new ArgumentException($"do not have case for {collectionName} in method {nameof(SetCollection)}");
            }
        }

        public List<BaseModel> GetCoolectionByKey(string collectionName)
        {
            //different option to cast collection
            //List<BaseModel> r1 =
            //    Books.ConvertAll(instance => (BaseModel)instance);

            //List<BaseModel> r2 =
            //    Books.Cast<BaseModel>().ToList();

            //List<BaseModel> r3 =
            //    Books.OfType<BaseModel>().ToList();


            switch (collectionName)
            {
                case nameof(Books):
                    return Books.ConvertAll(instance => (BaseModel)instance);

                case nameof(Authors):
                    return Authors.ConvertAll(instance => (BaseModel)instance);

                case nameof(Countries):
                    return Countries.ConvertAll(instance => (BaseModel)instance);

                case nameof(Genres):
                    return Genres.ConvertAll(instance => (BaseModel)instance);

                default:
                    throw new ArgumentException($"do not have case for {collectionName} in method {nameof(GetCoolectionByKey)}");
            }

        }

    }
}
