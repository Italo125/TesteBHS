using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IProdutos
    {
        bool Insert(Produto produto);

        Produto Get(int id);

        List<Produto> GetAll();

        bool Update(int id, string nome, bool status);

        bool Delete(int id);
    }
}
