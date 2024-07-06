using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ThuyTien.CoreBussiness.Services.Interfaces;
using ThuyTien.CoreBussiness.Services;
//using ThuyTien.DataStore.HardCode;
using ThuyTien.DataStore.SQL.Dapper;
using ThuyTien.ShoppingCart.LocalStorage;
using ThuyTien.StateStore.DI;
using ThuyTien.UseCases.PluginInterfaces.DataStore;
using ThuyTien.UseCases.PluginInterfaces.StateStore;
using ThuyTien.UseCases.PluginInterfaces.UI;
using ThuyTien.UseCases.SearchProductScreen;
using ThuyTien.UseCases.ShoppingCartScreen;
using ThuyTien.UseCases.ShoppingCartScreen.Interfaces;
using ThuyTien.UseCases.ShoppingCartUseCase;
using ThuyTien.UseCases.ViewProductScreen;
using ThuyTien.UseCases.ViewProductScreen.Interfaces;
using ThuyTien.Web.Data;
using ThuyTien.UseCases.OrderConfirmationScreen;
using ThuyTien.UseCases.AdminPortal.OutstandingOrdersScreen;
using ThuyTien.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using ThuyTien.UseCases.AdminPortal.OrderDetailScreen;
using ThuyTien.UseCases.AdminPortal.ProcessedOrdersScreen;
using ThuyTien.DataStore.SQL.Dapper.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication("ThuyTien.CookieAuth")
    .AddCookie("ThuyTien.CookieAuth", config =>
    {
        config.Cookie.Name = "ThuyTienCookieAuth";
        config.LoginPath = "/authenticate";
    });


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddTransient<IDataAccess>(sp => new DataAccess(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();
builder.Services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();
builder.Services.AddScoped<IAddProductToCartUseCase, AddProductToCartUseCase>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
builder.Services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
builder.Services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IViewOutstandingOrdersUseCase, ViewOutstandingOrdersUseCase>();
builder.Services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
builder.Services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
