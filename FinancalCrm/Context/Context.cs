using FinancalCrm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancalCrm.Context
{
    public class Context: DbContext
    {
        public Context()  : base("FinancalCrmDbEntities")
        { 
        
        }

        public DbSet<Users> Users { get; set; }
    }
}
