using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Models
{
    public class Role
    {

        public enum RoleType
        {
           Admin,
           Receptionist,
           ServiceStuff,
           Other
        }

        public int RoleId { get; set; }
        public RoleType Roletype { get; set; }
        public string Description { get; set; }


    }
}
