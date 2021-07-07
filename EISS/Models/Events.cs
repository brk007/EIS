using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EISS.Models
{
    public class Events
    {
       public int id { get; set; }
       public string name { get; set; }
       public string description { get; set; }
       public DateTime eventDate { get; set; }
    }
}
