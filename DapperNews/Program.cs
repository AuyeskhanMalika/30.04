using DbUp;
using System;
using System.Configuration;
using System.Reflection;

namespace DapperNews
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionStringConfiguration = ConfigurationManager.ConnectionStrings["appConnection"];
            var connectionString = connectionStringConfiguration.ConnectionString;

            #region NewsMigration
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
           .SqlDatabase(connectionString)
           .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
           .LogToConsole()
           .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful) throw new Exception("I am sorry. Not working");
            #endregion

            Menu menu = new Menu();
            menu.Choices();
        }
    }
}
