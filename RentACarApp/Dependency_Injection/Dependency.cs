using RentACarApp.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RentACarApp.Dependency_Injection
{
    public class Dependency
    {
        private IUnitOfWork unit = null;

        public Dependency()
        {
            
            string fileName = @"\Dependency_Injection\dependency.txt";
            var path = System.IO.Path.GetDirectoryName(
                  System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path += $"{fileName}";
            string localPath = new Uri(path).LocalPath;
            var lines = File.ReadAllLines(localPath);

            switch (lines[0])
            {
                case "EntityFramework":
                    unit = new UnitOfWork(new Models.ApplicationDbContext());
                    break;

            }
        }

        public IUnitOfWork Unit { get => unit; set => unit = value; }
    }
}