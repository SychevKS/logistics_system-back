using Microsoft.EntityFrameworkCore;
using logistics_system_back;
using logistics_system_back.Abstractions;
using logistics_system_back.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog.Sinks.PostgreSQL;
using NpgsqlTypes;
using Serilog;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
    
builder.Services.AddDbContext<ApplicationContext>
    (options => options.UseNpgsql(connection));

builder.Services.AddTransient<IDivisionService, DivisionService>();
builder.Services.AddTransient<IPartnerService, PartnerService>();
builder.Services.AddTransient<IWorkerService, WorkerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IInvoicePurchaseService, InvoicePurchaseService>();
builder.Services.AddTransient<IInvoiceSaleService, InvoiceSaleService>();
builder.Services.AddTransient<ITransferInvoiceService, TransferInvoiceService>();
builder.Services.AddTransient<IPlanPurchasesService, PlanPurchasesService>();
builder.Services.AddTransient<IPlanSalesService, PlanSalesService>();
builder.Services.AddTransient<IUnitService, UnitService>();
builder.Services.AddTransient<IRemainingService, RemainingService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // укзывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,

            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,

            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });
builder.Services.AddControllersWithViews();

IDictionary<string, ColumnWriterBase> colums = new Dictionary<string, ColumnWriterBase>
{
    { "message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
    { "date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
    { "UserName", new SinglePropertyColumnWriter(
        "UserName", PropertyWriteMethod.ToString, NpgsqlDbType.Text) },
};

builder.Host
    .UseSerilog((context, config) => config
    .MinimumLevel.Override(
        "Microsoft.EntityFrameworkCore.Database.Transaction", 
        Serilog.Events.LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Fatal)
    .WriteTo.PostgreSQL(connection, "Logs", colums, needAutoCreateTable: true ));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();


app.UseSerilogRequestLogging(options =>
{
    options.EnrichDiagnosticContext = 
        (IDiagnosticContext diagnosticContext, HttpContext httpContext) => 
            diagnosticContext.Set(
                "UserName", httpContext.User.Identity.Name);
});

app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
app.MapControllers();

app.Run();


