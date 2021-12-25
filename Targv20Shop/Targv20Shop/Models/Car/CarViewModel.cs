using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Targv20Shop.Models.Files;
// new
//using System.ComponentModel.DataAnnotations;

namespace Targv20Shop.Models.Car
{
    public class CarViewModel
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
        //[Required]
        //[Range(1900, 2050, ErrorMessage = "Year must be between 1900 to 2050")]
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<IFormFile> Files { get; set; }

        public List<ExistingFilePathViewModel> ExistingFilePaths { get; set; } = new List<ExistingFilePathViewModel>();
    }
}
