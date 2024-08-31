using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api.Infrastructure.Data
{
    public class MyContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer("Server=tcp:una-lab-paradigmas-db-server.database.windows.net,1433;Initial Catalog=Lab1-Paradigmas;Persist Security Info=False;User ID=una-lab-paradigmas-db-server;Password=Mapa*1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
