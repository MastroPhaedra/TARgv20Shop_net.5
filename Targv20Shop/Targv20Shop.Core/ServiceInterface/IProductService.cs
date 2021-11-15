using System;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;


namespace Targv20Shop.Core.ServiceInterface
{
    public interface IProductService
    {
        Task<Product> Delete(Guid id);
    }
}
