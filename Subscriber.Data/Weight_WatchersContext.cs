using Microsoft.EntityFrameworkCore;
using Subscriber.Data.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data
{
    public  class Weight_WatchersContext:DbContext
    {

        public Weight_WatchersContext(DbContextOptions<Weight_WatchersContext> options) : base(options)
        {
            
        }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<SubscribeCard> Cards { get; set; }
       
    }
}
