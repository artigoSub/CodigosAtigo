using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Produtos_MongoDB.Conexao;
using CRUD_Produtos_MongoDB.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CRUD_Produtos_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoBDConexao _conexao;
        public ProdutoController(ProdutoBDConexao conexao)
        {
            _conexao = conexao;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<Produto>> Get()
        {
            var produtos = _conexao.Produtos.Find(_ => true).ToList();
            return Ok(produtos);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Produto> Post([FromBody] Produto produto)
        {
            _conexao.Produtos.InsertOne(produto);
            return Ok(produto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public ActionResult Put(string id, [FromBody] Produto produto)
        {
            try
            {
                var filter = Builders<Produto>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Produto>.Update
                    .Set("Nome", produto.Nome)
                    .Set("PrecoPorUnidade", produto.PrecoPorUnidade)
                    .Set("Quantidade", produto.Quantidade)
                    .Set("DataValidade", produto.DataValidade);

                var result = _conexao.Produtos.UpdateOne(filter, update);

                if (result.ModifiedCount == 0)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public ActionResult DeleteById(string id)
        {
            try
            {
                var filter = Builders<Produto>.Filter.Eq("_id", ObjectId.Parse(id));
                var result = _conexao.Produtos.DeleteOne(filter);

                if (result.DeletedCount == 0)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
