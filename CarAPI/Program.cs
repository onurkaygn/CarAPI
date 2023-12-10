using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var cars = new List<Car>
{
    new Car { Id = 1, Year = 2021, Brand="Volkswagen", Model="Polo", EngineDisplacement=1.0},
    new Car { Id = 2, Year = 2005, Brand="Opel", Model="Astra", EngineDisplacement=1.6},
    new Car { Id = 3, Year = 2023, Brand="Mercedes-Benz", Model="SL 43 AMG", EngineDisplacement=2.0},
    new Car { Id = 4, Year = 2013, Brand="BMW", Model="3.20D", EngineDisplacement=2.0}


};


app.MapGet("/car", () =>
{
    return cars;
});

app.MapGet("/car/{id}", (int id) =>
{
    return cars.Find(c => c.Id == id);
});


app.Run();

class Car
{
    public int Id { get; set; }
    public required int Year { get; set; }

    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required double EngineDisplacement { get; set; }
}
