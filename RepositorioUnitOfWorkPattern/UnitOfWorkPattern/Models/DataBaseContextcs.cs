using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UnitOfWorkPattern.Models
{
    public class DataBaseContextcs : DbContext
    {//Con esto se añade la conectionString
        public DataBaseContextcs()
            : base("UnitOfWork")
        { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}