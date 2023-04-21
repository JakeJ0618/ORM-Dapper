using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
namespace ORM_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            #region Department Section
            //var repo = new DapperDepartmentRepository(conn);

            //Console.WriteLine("Type a new Department name");

            //var newDepartment = Console.ReadLine();

            //repo.InsertDepartment(newDepartment);

            //var departments = repo.GetAllDepartments();

            //Console.WriteLine("All Departments\n");
            //foreach (var dept in departments)
            //{
            //    Console.WriteLine(dept.Name);
            //}
            #endregion

            var prodRepo = new DapperProductRepository(conn);

            var products = prodRepo.GetAllProducts();

            Console.WriteLine("All Products\n");
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Name} {prod.ProductID} {prod.Price}");
            }
            Console.WriteLine();

            Console.WriteLine("What is the name of the new product?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is its price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is its Category ID?");
            var prodCat = int.Parse(Console.ReadLine());

            prodRepo.CreateProduct(prodName, prodPrice, prodCat);

            products = prodRepo.GetAllProducts();
        }
    }
}