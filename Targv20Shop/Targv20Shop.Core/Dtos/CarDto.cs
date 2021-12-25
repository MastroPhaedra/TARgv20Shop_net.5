using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targv20Shop.Core.Dtos
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public string Engine { get; set; }
        public string Fuel { get; set; }
        public int Mileage { get; set; }
        public string Drive { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<IFormFile> Files { get; set; }

        public IEnumerable<ExistingFilePathDto> ExistingFilePaths { get; set; } = new List<ExistingFilePathDto>();
    }
}
