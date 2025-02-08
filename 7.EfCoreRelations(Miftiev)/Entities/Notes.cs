using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreRelations_Miftiev_.Entities
{
    public class Notes
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User User { get; set; }

        public Notes() { }
        public Notes(
            int userid,
            string title,
            string? description)
        {
            UserId = userid;
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
        }




    }
}
