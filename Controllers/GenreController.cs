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
    public class GenreController : BaseLibraryController
    {
        public GenreController() : base()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get(
            [FromQuery(Name = "name")] string name)
        {
            return GetGenres(name);
        }

        [HttpGet]
        [Route("simple")]
        public ActionResult<IEnumerable<Genre>> GetSimple(
            [FromQuery(Name = "n")] string name)
        {
            return GetGenres(name);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Genre dto)
        {
            return Update(_dataStorage.GenresKey, nameof(Genre), dto);
        }

        [HttpPost]
        public ActionResult Add([FromBody] SimpleDTO dto)
        {
            return Add(_dataStorage.GenresKey, new Genre() { Name = dto.Name } );
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery(Name = "id")] int? id)
        {
            return Delete(_dataStorage.GenresKey, nameof(Genre), id);
        }


        private ActionResult<IEnumerable<Genre>> GetGenres(string name)
        {
            try
            {
                var list = _dataStorage.Genres.
                    WhereIf(!string.IsNullOrEmpty(name), a => a.Name.Contains(name.ToLower()))
                    .ToList();
                    
                return list;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
