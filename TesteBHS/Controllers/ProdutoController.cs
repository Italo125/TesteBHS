using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;

namespace TesteBHS.Controllers
{
    [Route("API/Produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoEntidade _context;

        public ProdutoController(ProdutoEntidade context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("Insert")]
        public bool Create(string nome, bool status)
        {
            var produtoDomain = new ProdutoDomain(_context);
            var retorno = produtoDomain.Insert(nome, status);
            return retorno;
        }

        [HttpGet]
        [Route("Get")]
        public Produto Get(int id)
        {
            var produtoDomain = new ProdutoDomain(_context);
            var retorno = produtoDomain.Get(id);
            return retorno;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Produto> GetAll()
        {
            return new ProdutoDomain(_context).GetAll().OrderByDescending(x => x.Id).ToList();
        }

        [HttpPost]
        [Route("Update")]
        public bool Update(int id, string nome, bool status)
        {
            var produtoDomain = new ProdutoDomain(_context);
            var retorno = produtoDomain.Update(id, nome, status);
            return retorno;           
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(int id)
        {
            var produtoDomain = new ProdutoDomain(_context);
            var retorno = produtoDomain.Delete(id);
            return retorno;
        }
    }
}
