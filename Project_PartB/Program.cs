using Project_PartB.Migrations;
using Project_PartB.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PartB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Model1 model1 = new Model1();
            //Configuration.RunSeed(model1);

            //var configuration = new Configuration();
            //var migrator = new DbMigrator(configuration);
            //migrator.Update();
            //configuration.RunSeed();
            MenuService menuService = new MenuService();
            menuService.start();
        }
    }
}
