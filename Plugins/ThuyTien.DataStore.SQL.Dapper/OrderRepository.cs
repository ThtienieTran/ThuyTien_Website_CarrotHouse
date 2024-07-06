using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.CoreBussiness.Models;
using ThuyTien.DataStore.SQL.Dapper.Helpers;
using ThuyTien.UseCases.PluginInterfaces.DataStore;

namespace ThuyTien.DataStore.SQL.Dapper
{

    public class OrderRepository : IOrderRepository
    {
        private readonly IDataAccess dataAccess;
        public OrderRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public int CreateOrder(Order order)
        {
            var sql =
                @"INSERT INTO [dbo].[Order]
                   ([DatePlaced]
                  ,[DateProcessing]
                  ,[DateProcessed]
                  ,[CustomerName]
                  ,[CustomerAddress]
                  ,[CustomerCity]
                  ,[CustomerStateProvince]
                  ,[CustomerCountry]
                  ,[AdminUser]
                  ,[UniqueId])
                OUTPUT INSERTED.OrderId
                    VALUES
                  (@DatePlaced
                  ,@DateProcessing
                  ,@DateProcessed
                  ,@CustomerName
                  ,@CustomerAddress
                  ,@CustomerCity
                  ,@CustomerStateProvince
                  ,@CustomerCountry
                  ,@AdminUser
                  ,@UniqueId)";
            var orderId = dataAccess.QuerySingle<int, Order>(sql, order);
            sql = @"INSERT INTO [dbo].[OrderLineItem]
                              ([ProductId]
                              ,[OrderId]
                              ,[Quantity]
                              ,[Price])
                    VALUES
                            (@ProductId
                            ,@OrderId
                            ,@Quantity
                            ,@Price)";
            order.LineItems.ForEach(x => x.OrderId = orderId);
            dataAccess.ExecuteCommand(sql, order.LineItems);
            return orderId;
        }

        public IEnumerable<OrderLineItem> GetLineItemByOrderId(int orderId)
        {
            var sql = @"SELECT * FROM OrderLineItem WHERE OrderId = @OrderId";
            var lineItems = dataAccess.Query<OrderLineItem, dynamic>(sql, new { orderId = orderId });
            sql = @"SELECT * FROM Product WHERE ProductId = @ProductId";
            lineItems.ForEach(x => x.Product = dataAccess.QuerySingle<Product, dynamic>(sql, new { ProductId = x.ProductId }));
            return lineItems;
        }
        public Order GetOrder(int id)
        {
            var sql = "SELECT * FROM [ORDER] WHERE OrderId = @OrderId";
            var order = dataAccess.QuerySingle<Order, dynamic>(sql, new { OrderId = id });
            order.LineItems = GetLineItemByOrderId(order.OrderId.Value).ToList();
            return order;
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            var sql = "SELECT * FROM [ORDER] WHERE UniqueId = @UniqueId";
            var order = dataAccess.QuerySingle<Order, dynamic>(sql, new { uniqueId = uniqueId });
            order.LineItems = GetLineItemByOrderId (order.OrderId.Value).ToList();
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return dataAccess.Query<Order, dynamic>("SELECT * FROM [ORDER]", new { });
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var sql = "SELECT * FROM [ORDER] WHERE DateProcessed is null";
            return dataAccess.Query<Order, dynamic>(sql, new { });
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var sql = "SELECT * FROM [ORDER] WHERE DateProcessed is not null";
            return dataAccess.Query<Order, dynamic>(sql, new { });
        }

        public void UpdateOrder(Order order)
        {
            var sql = @"UPDATE [Order]
                SET  [DatePlaced] = @DatePlaced
                  ,[DateProcessing] = @DateProcessing
                  ,[DateProcessed] = @DateProcessed
                  ,[CustomerName] = @CustomerName
                  ,[CustomerAddress] = @CustomerAddress
                  ,[CustomerCity] = @CustomerCity
                  ,[CustomerStateProvince] = @CustomerStateProvince
                  ,[CustomerCountry] = @CustomerCountry
                  ,[AdminUser] = @AdminUser
                  ,[UniqueId] = @UniqueId
                    WHERE OrderId = @OrderId";
            dataAccess.ExecuteCommand(sql, order);
            sql = @"UPDATE [OrderLineItem]
                    SET [ProductId] = @ProductId
                         ,[OrderId] = @OrderId
                         ,[Quantity] = @Quantity
                         ,[Price] = @Price
                   WHERE LineItemId = @LineItemId";
            dataAccess.ExecuteCommand<List<OrderLineItem>>(sql, order.LineItems);
        }
    }
}
