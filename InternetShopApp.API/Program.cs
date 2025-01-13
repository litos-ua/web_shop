//using InternetShopApp.API.Middleware;
//using InternetShopApp.Data;
//using InternetShopApp.Data.Repositories;
//using InternetShopApp.Data.Repositories.Interfaces;
//using InternetShopApp.Services;
//using InternetShopApp.Services.Auth;
//using InternetShopApp.Services.Interfaces;
//using InternetShopApp.Services.Interfaces.Auth;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//// Configure CORS
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        policy.WithOrigins("http://localhost:3000") // Allow only your frontend
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

//// Configure database context
//builder.Services.AddDbContext<InternetShopContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Configure JSON options
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//    });

//// Configure dependency injection
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ICartRepository, CartRepository>();
//builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
//builder.Services.AddScoped<ICartItemService, CartItemService>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IUserTokenRepository, UserTokenRepository>();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
//builder.Services.AddScoped<IOrderItemService, OrderItemService>();
//builder.Services.AddScoped<IStockRepository, StockRepository>();
//builder.Services.AddScoped<IStockService, StockService>();
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<IEmailService, EmailService>();

//// Configure JWT authentication
//var jwtKey = builder.Configuration["Jwt:Secret"];
//var jwtIssuer = builder.Configuration["Jwt:Issuer"];

//builder.Services.AddHttpContextAccessor();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidIssuer = jwtIssuer,
//            ValidAudience = jwtIssuer,
//            ClockSkew = TimeSpan.Zero // Remove default 5-minute token clock skew
//        };
//    });

//// Enable Swagger for API documentation
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddHttpLogging(options =>
//{
//    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
//    options.RequestBodyLogLimit = 4096; // set a limit for the request body
//    options.ResponseBodyLogLimit = 4096; // set a limit for the response body
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Custom exception handling middleware
//app.UseMiddleware<ExceptionMiddleware>();

//// Enable HTTP logging
//app.UseHttpLogging();

//// Enable HTTPS redirection
//app.UseHttpsRedirection();

//// Enable authentication and authorization
//app.UseAuthentication();
//app.UseAuthorization();

//// Enable CORS
//app.UseCors();

//// Map controllers
//app.MapControllers();

//// Run the application
//app.Run();


using InternetShopApp.API.Middleware;
using InternetShopApp.Data;
using InternetShopApp.Data.Repositories;
using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services;
using InternetShopApp.Services.Auth;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services.Interfaces.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure CORS
var corsPolicyInternetShop = "AllowFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyInternetShop, policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Allow only your frontend
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // If cookies or credentials are used
    });
});


// Configure database context
builder.Services.AddDbContext<InternetShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure JSON options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

// Configure dependency injection
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTokenRepository, UserTokenRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();

// Configure JWT authentication
var jwtKey = builder.Configuration["Jwt:Secret"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            ClockSkew = TimeSpan.Zero // Remove default 5-minute token clock skew
        };
    });

// Enable Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096; // set a limit for the request body
    options.ResponseBodyLogLimit = 4096; // set a limit for the response body
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Custom exception handling middleware
app.UseMiddleware<ExceptionMiddleware>();

// Enable HTTP logging
app.UseHttpLogging();

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Enable CORS
app.UseCors(corsPolicyInternetShop);

// Map controllers
app.MapControllers();

// Run the application
app.Run();