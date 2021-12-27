﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Targv20Shop.Core.Dtos;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Data;
using Targv20Shop.Models.Files;
using Targv20Shop.Models.Car;

namespace Targv20Shop.Controllers
{
    public class New_CarController : Controller
    {
        private readonly Targv20ShopDbContext _context;
        private readonly INew_CarService _carService;
        public New_CarController
            (
                Targv20ShopDbContext context,
                INew_CarService carService
            )
        {
            _context = context;
            _carService = carService;
        }
        public IActionResult New_Car()
        {
            var result = _context.New_Car
                .Select(x => new Old_CarListViewModel
                {
                    Id = x.Id,
                    ModelName = x.ModelName,
                    Year = x.Year,
                    Engine = x.Engine,
                    Fuel = x.Fuel,
                    Mileage = x.Mileage,
                    Drive = x.Drive,
                    Transmission = x.Transmission,
                    Color = x.Color,
                    VIN = x.VIN,
                    Price = x.Price,
                    Description = x.Description
                });

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carService.Delete(id);

            if (car == null)
            {
                RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            Old_CarViewModel model = new Old_CarViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Old_CarViewModel model)
        {
            var dto = new New_CarDto()
            {
                Id = model.Id,
                ModelName = model.ModelName,
                Year = model.Year,
                Engine = model.Engine,
                Fuel = model.Fuel,
                Mileage = model.Mileage,
                Drive = model.Drive,
                Transmission = model.Transmission,
                Color = model.Color,
                VIN = model.VIN,
                Price = model.Price,
                Description = model.Description,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                    .Select(x => new ExistingFilePathDto
                    {
                        PhotoId = x.PhotoId,
                        FilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
            };

            var result = await _carService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carService.Edit(id);
            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.ExistingFilePath
                .Where(x => x.CarId == id)
                .Select(y => new ExistingFilePathViewModel
                {
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();


            var model = new Old_CarViewModel();

            model.Id = car.Id;
            model.ModelName = car.ModelName;
            model.Year = car.Year;
            model.Engine = car.Engine;
            model.Fuel = car.Fuel;
            model.Mileage = car.Mileage;
            model.Drive = car.Drive;
            model.Transmission = car.Transmission;
            model.Color = car.Color;
            model.VIN = car.VIN;
            model.Price = car.Price;
            model.Description = car.Description;
            model.ModifiedAt = car.ModifiedAt;
            model.CreatedAt = car.CreatedAt;
            model.ExistingFilePaths.AddRange(photos);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Old_CarViewModel model)
        {
            var dto = new New_CarDto()
            {
                Id = model.Id,
                ModelName = model.ModelName,
                Year = model.Year,
                Engine = model.Engine,
                Fuel = model.Fuel,
                Mileage = model.Mileage,
                Drive = model.Drive,
                Transmission = model.Transmission,
                Color = model.Color,
                VIN = model.VIN,
                Price = model.Price,
                Description = model.Description,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                    .Select(x => new ExistingFilePathDto
                    {
                        PhotoId = x.PhotoId,
                        FilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
            };

            var result = await _carService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathViewModel model)
        {
            var dto = new ExistingFilePathDto()
            {
                PhotoId = model.PhotoId
            };

            var image = await _carService.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
