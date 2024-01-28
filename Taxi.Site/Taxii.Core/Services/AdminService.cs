using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Admin;
using Taxii.DataLayer.Context;
using Taxii.DataLayer.Entities;

namespace Taxii.Core.Services
{
    public class AdminService : IAdminService
    {
        private DataBaseContext _context;

        public AdminService(DataBaseContext context)
        {
            _context = context;
        }


        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
        #region Car
        public void AddCar(CarViewModel viewModel)
        {
            Car car = new()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
            };
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public bool DeleteCar(Guid id)
        {
            Car car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<Car> GetCarById(Guid id)
        {
           return await _context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetCars()
        {
            return await _context.Cars.OrderBy(c=>c.Name).ToListAsync();
        }

        public bool UpdateCar(Guid id, CarViewModel viewModel)
        {
            Car car = _context.Cars.Find(id);
            if (car != null)
            {
                car.Name = viewModel.Name;
                _context.SaveChanges();

                return true;
            }
            return false;
        }
        #endregion
    }
}
