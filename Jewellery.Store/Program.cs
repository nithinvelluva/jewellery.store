using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Hosting;
using Jewellery.Store.DAL.Entity;
using System.Collections.Generic;
using System.Linq;
using Jewellery.Store.DAL.DBContext;
using Jewellery.Store;

namespace Jewellery.Sore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BootstrapData();
            CreateHostBuilder(args).Build().Run();
        }

        private static void BootstrapData()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./dolittle.db";

            using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            connection.Open();
            SetupDB(connection);
            CreateUserTypeTable(connection);
            CreateUsersTable(connection);
            CreateDiscountTable(connection);
        }

        private static void SetupDB(SqliteConnection connection)
        {
            var createTable = connection.CreateCommand();
            createTable.CommandText = @"  PRAGMA foreign_keys = ON;";
        }

        private static void CreateUserTypeTable(SqliteConnection connection)
        {
            var createTable = connection.CreateCommand();
            createTable.CommandText = @"
            CREATE TABLE IF NOT EXISTS usertypes
            (
              id INTEGER PRIMARY KEY
              , type VARCHAR(50) NOT NULL
            )
          ";
            createTable.ExecuteNonQuery();
            createTable.Dispose();

            // Seeding data
            var userTypes = new List<UserTypeEntity>(new[] {
        new UserTypeEntity{id =1, type = "NormalUser"},
        new UserTypeEntity{id =2, type = "PrivilegedUser"}
      });
            using (var dbcontext = new MainDbContext())
            {
                var dbValues = dbcontext.UserTypes.ToList();
                var userTypesToInsert = userTypes.Where(p => !dbValues.Any(p2 => p2.id == p.id));
                dbcontext.UserTypes.AddRange(userTypesToInsert);
                dbcontext.SaveChanges();
            }
        }

        private static void CreateDiscountTable(SqliteConnection connection)
        {
            var createTable = connection.CreateCommand();
            createTable.CommandText = @"
            CREATE TABLE IF NOT EXISTS discounts
            (
                id INTEGER PRIMARY KEY
                , usertype INTEGER NOT NULL
               , discount INTEGER NULL
            )
          ";
            createTable.ExecuteNonQuery();
            createTable.Dispose();

            // Seeding data
            var discounts = new List<DiscountEntity>(new[] {
        new DiscountEntity{id =1, usertype = 1,discount = null},
        new DiscountEntity{id =2, usertype = 2,discount = 2}
      });
            using (var dbcontext = new MainDbContext())
            {
                var dbValues = dbcontext.Discounts.ToList();
                var discountsToInsert = discounts.Where(p => !dbValues.Any(p2 => p2.id == p.id));
                dbcontext.Discounts.AddRange(discountsToInsert);
                dbcontext.SaveChanges();
            }
        }

        private static void CreateUsersTable(SqliteConnection connection)
        {
            var createTable = connection.CreateCommand();
            createTable.CommandText = @"
            CREATE TABLE IF NOT EXISTS users
            (
                id INTEGER PRIMARY KEY
              , first_name VARCHAR(50) NOT NULL
              , last_name VARCHAR(50) NOT NULL
              , usertype INTEGER NOT NULL
               , user_name VARCHAR(50) NOT NULL
              , password VARCHAR(50) NOT NULL
            )
          ";
            createTable.ExecuteNonQuery();
            createTable.Dispose();

            // Seeding data
            var users = new List<UserEntity>(new[] {
        new UserEntity{id =1, first_name = "Normal", last_name = "User",usertype = 1,user_name="user1",password ="password"},
        new UserEntity{id =2, first_name = "Privileged", last_name = "User",usertype = 2,user_name="user2",password ="password"}
      });
            using (var dbcontext = new MainDbContext())
            {
                var dbValues = dbcontext.Users.ToList();
                var usersToInsert = users.Where(p => !dbValues.Any(p2 => p2.id == p.id));
                dbcontext.Users.AddRange(usersToInsert);
                dbcontext.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
