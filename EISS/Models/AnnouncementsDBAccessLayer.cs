using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EIS.Models
{
    public class AnnouncementsDBAccessLayer:DbContext
    {
        public AnnouncementsDBAccessLayer(DbContextOptions<AnnouncementsDBAccessLayer>options):base(options)
        {
           
        }
        
    }
}
