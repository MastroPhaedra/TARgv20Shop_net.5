using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.Dtos;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace Targv20Shop.ApplicationServices.Services
{
    public class CarServices : ICarService
    {
        private readonly Targv20ShopDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CarServices
            (
                Targv20ShopDbContext context,
                IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Car
                .Include(x => x.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Car.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }

        public async Task<Car> Add(CarDto dto)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.ModelName = dto.ModelName;
            car.Year = dto.Year;
            car.Engine = dto.Engine;
            car.Fuel = dto.Fuel;
            car.Mileage = dto.Mileage;
            car.Drive = dto.Drive;
            car.Transmission = dto.Transmission;
            car.Color = dto.Color;
            car.VIN = dto.VIN;
            car.Price = dto.Price;
            car.Description = dto.Description;
            car.ModifiedAt = DateTime.Now;
            car.CreatedAt = DateTime.Now;
            ProcessUploadedFile(dto, car);

            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }


        public async Task<Car> Edit(Guid id)
        {
            var result = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.ModelName = dto.ModelName;
            car.Year = dto.Year;
            car.Engine = dto.Engine;
            car.Fuel = dto.Fuel;
            car.Mileage = dto.Mileage;
            car.Drive = dto.Drive;
            car.Transmission = dto.Transmission;
            car.Color = dto.Color;
            car.VIN = dto.VIN;
            car.Price = dto.Price;
            car.Description = dto.Description;
            car.ModifiedAt = dto.ModifiedAt;
            car.CreatedAt = dto.CreatedAt;
            ProcessUploadedFile(dto, car);

            _context.Car.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }


        public async Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto)
        {
            var imageId = await _context.ExistingFilePath
                .FirstOrDefaultAsync(x => x.Id == dto.PhotoId);

            _context.ExistingFilePath.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }

        public string ProcessUploadedFile(CarDto dto, Car car)
        {
            string uniqueFileName = null;

            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_env.WebRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_env.WebRootPath + "\\multipleFileUpload\\");
                }

                foreach (var photo in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "multipleFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);

                        ExistingFilePath paths = new ExistingFilePath
                        {
                            Id = Guid.NewGuid(),
                            FilePath = uniqueFileName,
                            CarId = car.Id
                        };

                        _context.ExistingFilePath.Add(paths);
                    }
                }
            }

            return uniqueFileName;
        }
    }
}
