using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IrbidsAPI.Models;

namespace IrbidsAPI.Models
{
    public class IrbidsAPIContext : DbContext
    {
        public IrbidsAPIContext (DbContextOptions<IrbidsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<IrbidsAPI.Models.Word> Word { get; set; }

        public DbSet<IrbidsAPI.Models.Attempt> Attempt { get; set; }
    }
}
