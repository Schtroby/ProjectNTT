using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SenMobServ.Models
{
    public enum StatusType
    {
        Opened,
        Pending,
        Completed,
        Invoiced
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(StatusType))]
        public StatusType StatusType { get; set; }
    }
}
