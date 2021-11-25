using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;


namespace userApi.Data
{
    [DbConfigurationType(typeof(ApiDbConfiguration))]
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

    }
}
