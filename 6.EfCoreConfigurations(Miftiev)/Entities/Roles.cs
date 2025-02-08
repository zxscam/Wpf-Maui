using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreConfigurations_Miftiev_.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public Roles() { }

        public Roles(
            int id,
            string title,
            string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
