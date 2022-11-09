using Microsoft.EntityFrameworkCore;
using logistics_system_back;
using logistics_system_back.Abstractions;
using logistics_system_back.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
builder.Services.AddTransient<IPurchaseInvoiceService, PurchaseInvoiceService>();
builder.Services.AddTransient<ISalesInvoiceService, SalesInvoiceService>();
builder.Services.AddTransient<ITransferInvoiceService, TransferInvoiceService>();
builder.Services.AddTransient<IInvoicePositionService, InvoicePositionService>();
builder.Services.AddTransient<IPurchasesPlanService, PurchasesPlanService>();
builder.Services.AddTransient<ISalesPlanService, SalesPlanService>();
builder.Services.AddTransient<ISalesPlanPositionService, SalesPlanPositionService>();
builder.Services.AddTransient<IPurchasesPlanPositionService, PurchasesPlanPositionService>();
builder.Services.AddTransient<IUnitService, UnitService>();
builder.Services.AddTransient<IPurchasesPlanRealizationService, PurchasesPlanRealizationService>();
builder.Services.AddTransient<IRemainingService, RemainingService>();
builder.Services.AddTransient<ISalesPlanRealizationService, SalesPlanRealizationService>();
builder.Services.AddTransient<IUserService, UserService>();

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
    options.EnrichDiagnosticContext = PushSeriLogProperties;
});

static void PushSeriLogProperties(IDiagnosticContext diagnosticContext, HttpContext httpContext)
{
    diagnosticContext.Set("SomePropertyName", httpContext.User.Identity.Name);
}


app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
app.MapControllers();


app.Run();


