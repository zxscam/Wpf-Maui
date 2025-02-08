using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCoreRelations_Miftiev_.Entities;

namespace EfCoreRelations_Miftiev_
{
    public class Permission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Role> Roles { get; set; }

        public Permission() { }
        public Permission(
            string title,
            string description)
        {
            Title = title;
            Description = description;
        }
    }
}
