using CRUD_Produtos_MongoDB.Modelos;
using MongoDB.Driver;

namespace CRUD_Produtos_MongoDB.Conexao
{
    public class ProdutoBDConexao
    {
        private readonly IMongoDatabase _database;
        public ProdutoBDConexao(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionMongoDB");
            var databaseName = configuration.GetConnectionString("DatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

        }
        public IMongoCollection<Produto> Produtos => _database.GetCollection<Produto>("Produtos");
    }
}
