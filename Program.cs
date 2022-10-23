using Microsoft.EntityFrameworkCore;
using logistics_system_back;
using logistics_system_back.Abstractions;
using logistics_system_back.Services;

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
builder.Services.AddTransient<IInvoicePositionService, InvoicePositionService>();
builder.Services.AddTransient<IPurchasesPlanService, PurchasesPlanService>();
builder.Services.AddTransient<ISalesPlanService, SalesPlanService>();
builder.Services.AddTransient<ISalesPlanPositionService, SalesPlanPositionService>();
builder.Services.AddTransient<IPurchasesPlanPositionService, PurchasesPlanPositionService>();
builder.Services.AddTransient<IUnitService, UnitService>();
builder.Services.AddTransient<IPurchasesPlanRealizationService, PurchasesPlanRealizationService>();
builder.Services.AddTransient<IRemainingService, RemainingService>();
builder.Services.AddTransient<ISalesPlanRealizationService, SalesPlanRealizationService>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


