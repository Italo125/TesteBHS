using Data;
using Models.Entities;
using Models.Interfaces;
using System;

namespace Services
{
    public class Servicos
    {
        public static IProdutos Produtos(ProdutoEntidade context)
        {
            return new ProdutoData(context);
        }
    }
}
