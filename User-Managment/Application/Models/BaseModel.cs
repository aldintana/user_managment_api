using System;

namespace Application.Models
{
    public class BaseModel <T>
    {
        public T Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
