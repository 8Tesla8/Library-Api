using System;
using System.Collections.Generic;
using System.Linq;
using Library_API.Data;
using Library_API.Models;
using Library_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : BaseLibraryController
    {
        public AuthorController() : base()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> Get(
            [FromQuery(Name = "name")] string name,
            [FromQuery(Name = "country")] string country)
        {
            return GetAuthors(name, country);
        }

        [HttpGet]
        [Route("simple")]
        public ActionResult<IEnumerable<AuthorDTO>> GetSimple(
            [FromQuery(Name = "n")] string name,
            [FromQuery(Name = "c")] string country)
        {
            return GetAuthors(name, country);
        }


        [HttpPut]
        public ActionResult Update([FromBody] Author dto)
        {
            return Update(_dataStorage.AuthorsKey, nameof(Author), dto);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Author dto)
        {
            return Add(_dataStorage.AuthorsKey, dto);
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery(Name = "id")] int? id)
        {
            return Delete(_dataStorage.AuthorsKey, nameof(Author), id);
        }

        private ActionResult<IEnumerable<AuthorDTO>> GetAuthors(
            string name, string country)
        {
            try
            {
                var list = _dataStorage.AuthorsDTO.
                    WhereIf(!string.IsNullOrEmpty(name), a => a.Name.Contains(name.ToLower())).
                    WhereIf(!string.IsNullOrEmpty(country), a => a.Country.Contains(country.ToLower())).
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
