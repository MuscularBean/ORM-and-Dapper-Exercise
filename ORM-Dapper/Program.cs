using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);
#region
//var departmentRepo = new DapperDepartmentRepository(conn);

//departmentRepo.InsertDepartment("John's New Department");

//var departments = departmentRepo.GetAllDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine(department.DepartmentID);
//   Console.WriteLine(department.Name);
//}
#endregion

var productRepository = new DapperProductRepository(conn);

var productToUpdate = productRepository.GetProduct(940);

/* productToUpdate.Name = "UPDATED";
productToUpdate.Price = 20.00;
productToUpdate.CategoryID = 1;
productToUpdate.OnSale = false;
productToUpdate.StockLevel = 1;

productRepository.UpdateProduct(productToUpdate); */

productRepository.DeleteProduct(941);
var products = productRepository.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();
}

