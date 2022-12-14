using Microsoft.EntityFrameworkCore;
using logistics_system_back;
using logistics_system_back.Abstractions;
using logistics_system_back.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
    
builder.Services.AddDbContext<ApplicationContext>(options => options
    .UseNpgsql(connection));

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
builder.Services.AddTransient<ILogService, LogService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // ????????, ????? ?? ?????????????? ???????? ??? ????????? ??????
            ValidateIssuer = true,
            // ??????, ?????????????? ????????
            ValidIssuer = AuthOptions.ISSUER,

            // ????? ?? ?????????????? ??????????? ??????
            ValidateAudience = true,
            // ????????? ??????????? ??????
            ValidAudience = AuthOptions.AUDIENCE,
            // ????? ?? ?????????????? ????? ?????????????
            ValidateLifetime = true,

            // ????????? ????? ????????????
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // ????????? ????? ????????????
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

app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
app.MapControllers();

app.Run();


