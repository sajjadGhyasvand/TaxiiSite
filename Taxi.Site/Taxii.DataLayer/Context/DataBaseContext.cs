using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.DataLayer.Entities;

namespace Taxii.DataLayer.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<RateType> RateTypes { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<MonthPriceType> MonthPriceTypes { get; set; }
        public DbSet<Humidity> Humidities { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Transact> Transacts { get; set; }
        public DbSet<TransactRate> TransactRates { get; set; }
    }
}
