using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCoreRelations_Miftiev_.Entities;

namespace EfCoreRelations_Miftiev_
{
    public class RolePermissions
    {
        public int PermissionsId { get; set; }
        public int RoleId { get; set; }
        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}
