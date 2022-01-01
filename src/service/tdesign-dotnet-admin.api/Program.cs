var builder = WebApplication.CreateBuilder(args);
const string _appName = "tdesign-dotnet-admin";
const string _appDesc = "tdesign dotnet admin";

#region configuration
IConfigurationBuilder GetConfigurationBuild()
    => (new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .TryAddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true) // 尝试把多环境配置文件一同加载进来
        .TryAddJsonFile("appsettings.Staging.json", optional: false, reloadOnChange: true)
        .TryAddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables());
#endregion

var configurationBuild = GetConfigurationBuild();
var configuration = configurationBuild.Build();

#region serilog
Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
    => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("ApplicationContext", _appName)
        .Enrich.FromLogContext()
        .WriteTo.Console()
#if RELEASE // 本地开发环境中不存储日志到ES，而是将日志保存到文件中
        .WriteTo.Http(configuration["LogSave:LogstashUrl"])
#else
        .WriteTo.File( // 日志输出至文件
            path: Path.Combine(configuration["LogSave:LogFileSavePath"], "log.txt"),
            rollingInterval: RollingInterval.Day)
#endif
        .ReadFrom.Configuration(configuration) // 从配置文件中加载serilog配置
        .CreateLogger();
#endregion

Log.Logger = CreateSerilogLogger(configuration);

#region Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // 小驼峰    
        options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm:ss" });
    });
builder.Services.AddAutoMapper( // automapper
    typeof(AutoMapperProfile)
    );
builder.Services.AddDbContext<TDesignDotnetAdminDbContext>(options => // ef core
    options.UseMySql(ServerVersion.AutoDetect(configuration.GetConnectionString("AppDbConnStr")),
        mySqlOptionsAction: sqlOptions =>
        {
            // sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
        }),
        ServiceLifetime.Scoped);  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)

builder.Services.AddHttpContextAccessor(); // 注册 httpcontext
/* config autofac */
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(container =>
{
    container.RegisterModule<DomainAutofacModule>();
    container.RegisterModule<ApplicationAutofacModule>();
}));
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.MapGet("/", _ => _.Response.WriteAsync(_appDesc));
#endregion

app.Run();