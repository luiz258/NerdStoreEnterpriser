using NSE.Core.Data;
using NSE.Core.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Models
{
    public interface IProdutoRepository :IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterToodos();
        Task<Produto> ObterPorId(Guid id);

        void Adcionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
