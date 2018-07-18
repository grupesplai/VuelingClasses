using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UnitOfWorkPattern.Models;
using UnitOfWorkPattern.Repository;

namespace UnitOfWorkPattern
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new DataBaseContextcs();
        }
        private readonly DataBaseContextcs context;

        private GenericRepository<Client> clientsRepository;
        public GenericRepository<Client> ClientsRepository
        {
            get
            {
                if (this.clientsRepository == null)
                {
                    this.clientsRepository = new GenericRepository<Client>(this.context);
                }
                return this.clientsRepository;
            }
        }

        private GenericRepository<Sale> salesRepository;
        public GenericRepository<Sale> SalesRepository
        {
            get
            {
                if (this.salesRepository == null)
                {
                    this.salesRepository = new GenericRepository<Sale>(this.context);
                }
                return this.salesRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}