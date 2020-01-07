using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugZapper.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using static BugZapper.Database;

namespace BugZapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //MongoCRUD db = new MongoCRUD("BZBugs");
            //var recs = db.ReadRecords<BugsModel>("Bugs");

            //foreach(var rec in recs)
            //{
            //    Console.WriteLine($" { rec.Id }: { rec.BugID } { rec.Status } { rec.Info } { rec.Date } ");
            //}
            //Console.ReadLine();
            CreateHostBuilder(args).Build().Run();
         
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
