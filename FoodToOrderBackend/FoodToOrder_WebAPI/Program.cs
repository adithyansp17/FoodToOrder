using FoodToOrder_WebAPI.Repositories;
using FoodToOrder_WebAPI;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using FoodToOrder_WebAPI.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRestaurant, RestaurantRepository>();
//builder.Services.AddScoped<IRestaurant, RestaurantService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddSwaggerGen(options => {
//    options.MapType<DateOnly>(() => new OpenApiSchema
//    {
//        Type = "string",
//        Format = "date"
//    });
//});

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddDbContext<FoodToOrderWpfPraveenContext>(options =>
{
    Console.WriteLine("Service : User Service Running");
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.MaxDepth = 0;
});

JsonSerializerSettings serializerSettings = new JsonSerializerSettings()

{

    PreserveReferencesHandling = PreserveReferencesHandling.None,

    Formatting = Formatting.Indented

};

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Whilebackend Connecting - In Program.cs
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("corsapp");

app.Run();
