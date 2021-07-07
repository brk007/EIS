using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIS.Context
{
    public class AppRole:IdentityRole<int>
    {
        public string PictureUrl { get; set; }
    }
}
