using System;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.Dtos;

namespace Targv20Shop.Core.ServiceInterface
{
    public interface IOld_CarService
    {
        Task<Old_Car> Delete(Guid id);

        Task<Old_Car> Add(Old_CarDto dto);

        Task<Old_Car> Edit(Guid id);

        Task<Old_Car> Update(Old_CarDto dto);

        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);

    }
}
