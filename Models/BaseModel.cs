using System;
namespace Library_API.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
