using System;
using System.Linq;
using System.Reflection;
using Library_API.Data;
using Library_API.Models;
using MatrixApi.Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    public class BaseLibraryController : ControllerBase
    {
        protected readonly DataStorage _dataStorage;

        public BaseLibraryController()
        {
            _dataStorage = Injection.Resolve<DataStorage>();
        }


        protected string CannotFindById(string objectName, int? id)
        {
            if (id.HasValue)
                return $"Can not find {objectName} with id:{id.Value}";

            return $"Id:{id.Value} is not correct";
        }


        protected ActionResult Delete(string collectionName, string entityName, int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest(CannotFindById(entityName, id));

                var collection = _dataStorage.GetCoolectionByKey(collectionName);


                var item = collection.FirstOrDefault(c => c.Id == id.Value);

                if (item == null)
                    return BadRequest(CannotFindById(entityName, id));

                collection.Remove(item);
                _dataStorage.SetCollection(collectionName, collection);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Update(string collectionName, string entityName, BaseModel updateObj)
        {
            try
            {
                var collection = _dataStorage.GetCoolectionByKey(collectionName);

                var item = collection.FirstOrDefault(c => c.Id == updateObj.Id);

                if (item == null)
                    return BadRequest(CannotFindById(entityName, updateObj.Id));

                var properties = updateObj.GetType().GetProperties();


                foreach (PropertyInfo propInfo in properties)
                {
                    propInfo.SetValue(item, propInfo.GetValue(updateObj, null), null);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult Add(string collectionName, BaseModel addObj)
        {
            var collection = _dataStorage.GetCoolectionByKey(collectionName);


            if (!collection.
                Any(c => c.Name == addObj.Name.ToLower()))
            {
                var maxId = collection.Max(c => c.Id);
                addObj.Id = maxId +1;

                collection.Add(addObj);
                _dataStorage.SetCollection(collectionName, collection);

                return Ok();
            }

            return BadRequest($"{addObj.GetType()} with value:{addObj.Name} already exist");
        }

    }
}
