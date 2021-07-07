using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIS.Context
{
    public class EISContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BIMEMRES\\BIMSTAJER;database=EISIdentity; user id=sa; password=q1w2e3r4;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
