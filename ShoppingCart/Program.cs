using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShoppingCartDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ProductService,ProductService>();

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<UserService,UserService>();

builder.Services.AddScoped<IAuthRepository,AuthRepository>();
builder.Services.AddScoped<AuthService,AuthService>();

builder.Services.AddScoped<IAddressRepository,AddressRepository>();
builder.Services.AddScoped<AddressService,AddressService>();

builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<CategoryService,CategoryService>();

builder.Services.AddScoped<ICartRepository,CartRepository>();
builder.Services.AddScoped<CartService,CartService>();

builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<OrderService,OrderService>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "yourIssuer",
        ValidAudience = "yourAudience",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKey"))
    };
});


var app = builder.Build();
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:3000")
           .AllowAnyMethod()
           .AllowAnyHeader()
);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
