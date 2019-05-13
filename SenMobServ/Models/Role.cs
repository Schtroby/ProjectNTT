using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [EnumDataType(typeof(RoleType))]
        public RoleType Roletype { get; set; }
        public string Description { get; set; }


    }
}
