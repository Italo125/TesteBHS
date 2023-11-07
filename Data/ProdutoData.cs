using Microsoft.Extensions.Configuration;
using Models;
using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Data
{
    public class ProdutoData : IProdutos
    {

        private readonly ProdutoEntidade _context;
        public ProdutoData(ProdutoEntidade context)
        {
            _context = context;
        }

        public bool Insert(Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Produto Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            return produto;
        }

        public List<Produto> GetAll()
        {
            var produtos = _context.Produtos.ToList();
            return produtos;
        }

        public bool Update(int id, string nome, bool status)
        {
            var produto = _context.Produtos.Where(p => p.Id == id).FirstOrDefault();

            if (produto != null)
            {
                produto.Nome = nome;
                produto.Status = status;

                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                var produto = _context.Produtos.Where(p => p.Id == id).FirstOrDefault();
                if (produto != null)
                {
                    _context.Produtos.Remove(produto);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
