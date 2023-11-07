using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities
{
    public class ProdutoEntidade : DbContext
    {
        public ProdutoEntidade(DbContextOptions<ProdutoEntidade> options) : base(options) 
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
