using Dapper;
using DemoDapper;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;
using ThuyTien.CoreBussiness.Models;

Console.WriteLine("Hello, World!");

var connectstr = "Data Source=TIENTRAN;Initial Catalog=ThuyTien_CarrotHouse;Integrated Security=True";
var da = new DataAccess(connectstr);
var results1 = da.Query<Product, dynamic>("Select * from Product", new { });
var results2 = da.QuerySingle<Product, dynamic>("Select * from Product where ProductId = @ProductId",
    new { ProductId = "286" });

var sql = "";