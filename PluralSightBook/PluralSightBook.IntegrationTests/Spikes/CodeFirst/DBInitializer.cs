using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.IntegrationTests.Spikes.CodeFirst
{
    /// <summary>
    /// http://www.andrewconnell.com/blog/archive/2012/05/02/isolating-integration-tests-with-ef4-x-code-first-amp-mstest.aspx
    /// </summary>
    [TestClass]
    public class TestRunDatabaseCreator
    {
        public const string DATABASE_NAME_TEMPLATE = "CPT_CDS_{0}";

        //[AssemblyInitialize]
        //public static void AssemblyInitialize(TestContext testContext)
        //{
        //    string projectName = GetCurrentProjectName();

        //    Console.Out.WriteLine("Test assembly init: creating unseeded DB...");
        //    CreateUnSeededDb(projectName);

        //    Console.Out.WriteLine("Test assembly init: creating seeded DB...");
        //    CreateSeededDb(projectName);
        //}

        //private static void CreateUnSeededDb(string projectName)
        //{
        //    Database.SetInitializer(new SmokeTestCreateDbWithNoDataIfNotExists());
        //    Database.SetInitializer(new SmokeTestDropCreateDbWithNoDataAlways());

        //    // create new DB connection to local SQL Server
        //    string dbName = string.Format(DATABASE_NAME_TEMPLATE + "_UnSeeded", projectName);
        //    string connectionString = string.Format(TestGlobals.CONNECTION_STRING_TEMPLATE, dbName);
        //    var dbfactory = new DatabaseFactory(connectionString);

        //    // connect to DB to auto generate it
        //    var customerContext = dbfactory.GetDataContext();
        //    customerContext.Database.Initialize(true);
        //}

        //private static void CreateSeededDb(string projectName)
        //{
        //    Database.SetInitializer(new SmokeTestCreateDbWithDataIfNotExists());
        //    Database.SetInitializer(new SmokeTestDropCreateDbWithDataAlways());

        //    // create new DB connection to local SQL Server
        //    string dbName = string.Format(DATABASE_NAME_TEMPLATE + "_Seeded", projectName);
        //    string connectionString = string.Format(TestGlobals.CONNECTION_STRING_TEMPLATE, dbName);
        //    var dbfactory = new DatabaseFactory(connectionString);

        //    // connect to DB to auto generate it
        //    var customerContext = dbfactory.GetDataContext();
        //    customerContext.Database.Initialize(true);
        //}
    }
}
