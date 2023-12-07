using CRUD_Produtos_MongoDB.Conexao;

var builder = WebApplication.CreateBuilder(args);

// Add database Configuration
var connectionStringMongo = builder.Configuration.GetConnectionString("ConnectionMongoDB");
var databaseNameMongo = builder.Configuration.GetConnectionString("DatabaseName");

builder.Services.AddSingleton(new ProdutoBDConexao(builder.Configuration));
builder.Services.AddControllers();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();