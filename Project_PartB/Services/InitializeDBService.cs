using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PartB.Services
{
    public class InitializeDBService
    {
        public static void Initialize()
        {

            var configuration = new Project_PartB.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
            configuration.RunSeed();
        }
    }
}
