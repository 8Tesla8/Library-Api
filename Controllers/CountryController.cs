using System;
using System.Collections.Generic;
using System.Linq;
using Library_API.Data;
using Library_API.Models;
using Library_API.Models.DTO;
using MatrixApi.Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CountryController : BaseLibraryController
    {
        public CountryController() : base()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<Country>> Get(
            [FromQuery(Name = "name")] string name)
        {
            return GetCountries(name);
        }

        [HttpGet]
        [Route("simpple")]
        public ActionResult<IEnumerable<Country>> GetSimple(
            [FromQuery(Name = "n")] string name)
        {
            return GetCountries(name);
        }


        [HttpPost]
        public ActionResult Add([FromBody] SimpleDTO dto)
        {
            return Add(_dataStorage.CountriesKey, new Country() { Name = dto.Name});
        }

        [HttpPut]
        public ActionResult Update([FromBody] Country dto)
        {
            return Update(_dataStorage.CountriesKey, nameof(Country), dto);
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery(Name = "id")] int? id)
        {
            return Delete(_dataStorage.CountriesKey, nameof(Country), id);
        }


        private ActionResult<IEnumerable<Country>> GetCountries(string name)
        {
            try
            {
                var list = _dataStorage.Countries.
                    WhereIf(!string.IsNullOrEmpty(name), c => c.Name.Contains(name.ToLower())).
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
