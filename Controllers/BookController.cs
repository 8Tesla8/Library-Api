using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_API.Data;
using Library_API.Models;
using Library_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : BaseLibraryController
    {

        public BookController() : base()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> Get(
           [FromQuery(Name = "author")] string author,
           [FromQuery(Name = "name")] string name,
           [FromQuery(Name = "genre")] string genre,
           [FromQuery(Name = "year")] int? year)
        {
            return GetBooks(author, name, genre, year);
        }

        //https://localhost:5001/book/simple
        //https://localhost:5001/book/simple?a=joanne&y=1997
        [HttpGet]
        [Route("simple")]
        public ActionResult<IEnumerable<BookDTO>> GetSimple(
            [FromQuery(Name = "a")] string author,
            [FromQuery(Name = "n")] string name,
            [FromQuery(Name = "g")] string genre,
            [FromQuery(Name = "y")] int? year)
        {
            return GetBooks(author, name, genre, year);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Book dto)
        {
            return Update(_dataStorage.BooksKey, nameof(Book), dto);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Book dto)
        {
            return Add(_dataStorage.BooksKey, dto);
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery(Name = "id")] int? id)
        {
           return Delete(_dataStorage.BooksKey, nameof(Book), id);
        }


        private ActionResult<IEnumerable<BookDTO>> GetBooks(
            string author, string name, string genre, int? year)
        {
            try
            {
                var list = _dataStorage.BooksDTO.
                    WhereIf(!string.IsNullOrEmpty(author), b => b.Author.Contains(author.ToLower())).
                    WhereIf(!string.IsNullOrEmpty(name), b => b.Name.Contains(name.ToLower())).
                    WhereIf(!string.IsNullOrEmpty(genre), b => b.Genre.Contains(genre.ToLower())).
                    WhereIf(year != null, b => b.Year == year.Value).
                    ToList();

                return list;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
