using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankMap.Models
{
    public interface IModel
    {
        int ID { get; set; }
        DateTime DateCreated { get; set; }
    }
}