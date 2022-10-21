using Microsoft.EntityFrameworkCore;
using logistics_system_back;
using logistics_system_back.Abstractions;
using logistics_system_back.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
    
builder.Services.AddDbContext<ApplicationContext>
    (options => options.UseNpgsql(connection));

builder.Services.AddTransient<IDivisionService, DivisionService>();
builder.Services.AddTransient<IPartnerService, PartnerService>();
builder.Services.AddTransient<IWorkerService, WorkerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPurchaseInvoiceService, PurchaseInvoiceService>();
builder.Services.AddTransient<ISalesInvoiceService, SalesInvoiceService>();
builder.Services.AddTransient<IInOutInvoiceService, InOutInvoiceService>();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


