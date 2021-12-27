using System;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.Dtos;

namespace Targv20Shop.Core.ServiceInterface
{
    interface INew_CarService
    {
        Task<New_Car> Delete(Guid id);

        Task<New_Car> Add(New_CarDto dto);

        Task<New_Car> Edit(Guid id);

        Task<New_Car> Update(New_CarDto dto);

        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);

    }
}
