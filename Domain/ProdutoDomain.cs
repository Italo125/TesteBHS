using Data;
using Models;
using Models.Entities;
using Services;
using System;
using System.Collections.Generic;


namespace Domain
{
    public class ProdutoDomain
    {
        private readonly ProdutoEntidade _context;
        public ProdutoDomain(ProdutoEntidade context)
        {
            _context = context;
        }

        public bool Insert(string nome, bool status)
        {
            if (nome != null)
            {
                var produto = new Produto
                {
                    Nome = nome,
                    Status = status
                };

                var retorno = Servicos.Produtos(_context).Insert(produto);
                return retorno;
            }
            return false;
        }

        public Produto Get(int id)
        {
            var retorno = Servicos.Produtos(_context).Get(id);
            return retorno;
        }

        public List<Produto> GetAll()
        {
            var retorno = Servicos.Produtos(_context).GetAll();
            return retorno;
        }

        public bool Update(int id, string nome, bool status)
        {
            if (nome != null)
            {
                var retorno = Servicos.Produtos(_context).Update(id,nome,status);
                return retorno;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var retorno = Servicos.Produtos(_context).Delete(id);
            return retorno;
        }

    }
}
