using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD_Produtos_MongoDB.Modelos
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public double PrecoPorUnidade { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
