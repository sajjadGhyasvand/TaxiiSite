﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
            return await _context.Cars.OrderBy(c => c.Name).ToListAsync();
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






        public async Task<List<Color>> GetColors()
        {
            return await _context.Colors.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Color> GetColorById(Guid id)
        {
            return await _context.Colors.FindAsync(id);
        }

        public void AddColor(ColorViewModel viewModel)
        {
            Color color = new Color()
            {
                Id = CodeGenerators.GetId(),
                ColorCode = viewModel.ColorCode,
                Name = viewModel.Name
            };
            _context.Colors.Add(color);
            _context.SaveChanges();
        }

        public bool UpdateColor(Guid id, ColorViewModel viewModel)
        {
            Color color = _context.Colors.Find(id);
            if (color != null)
            {
                color.Name = viewModel.Name;
                color.ColorCode = viewModel.ColorCode;

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteColor(Guid id)
        {
            Color color = _context.Colors.Find(id);
            if (color != null)
            {
                _context.Colors.Remove(color);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<RateType>> GetRateTypes()
        {
            return await _context.RateTypes.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<RateType> GetRateTypeById(Guid id)
        {
            return await _context.RateTypes.FindAsync(id);
        }

        public void AddRateType(RateTypeViewModel viewModel)
        {
            RateType rate = new()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                OK = viewModel.OK,
                ViewOrder = viewModel.ViewOrder
            };
            _context.RateTypes.Add(rate);
            _context.SaveChanges();
        }

        public bool UpdateRateType(Guid id, RateTypeViewModel viewModel)
        {
            RateType rate = _context.RateTypes.Find(id);
            if (rate != null)
            {
                rate.Name = viewModel.Name;
                rate.OK = viewModel.OK;
                rate.ViewOrder = viewModel.ViewOrder;

                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteRateType(Guid id)
        {
            RateType rate = _context.RateTypes.Find(id);

            if (rate != null)
            {
                _context.RateTypes.Remove(rate);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<Setting> GetSetting()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }

        public bool UpdateSiteSetting(SiteSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();
            if (setting != null)
            {
                setting.Name = viewModel.Name;
                setting.Tel = viewModel.Tel;
                setting.Fax = viewModel.Fax;
                setting.Desc = viewModel.Desc;
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public bool UpdatePriceSetting(PriceSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();
            if (setting != null)
            {
                setting.IsDistancePrice = viewModel.IsDistancePrice;
                setting.IsWeatherPrice = viewModel.IsWeatherPrice;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateaboutSetting(AboutSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();
            if (setting != null)
            {
                setting.About = viewModel.About;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateTermSetting(TermSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();
            if (setting != null)
            {
                setting.About = viewModel.Terms;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<PriceType>> GetPriceTypes()
        {
            return await _context.PriceTypes.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<PriceType> GetPriceTypeById(Guid id)
        {
            return await _context.PriceTypes.FindAsync(id);
        }

        public void AddPriceType(PriceTypeViewModel viewModel)
        {
            PriceType price = new()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                End = viewModel.End,
                Start = viewModel.Start,
                Price = viewModel.Price,
            };
            _context.PriceTypes.Add(price);
            _context.SaveChanges();
        }

        public bool UpdatePriceType(Guid id, PriceTypeViewModel viewModel)
        {
            PriceType price = _context.PriceTypes.Find(id);
            if (price != null)
            {
                price.Name = viewModel.Name;
                price.Start = viewModel.Start;
                price.End = viewModel.End;
                price.Price = viewModel.Price;
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeletePriceType(Guid id)
        {
            PriceType priceType = _context.PriceTypes.Find(id);

            if (priceType != null)
            {
                _context.PriceTypes.Remove(priceType);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<MonthPriceType>> GetMonthPriceTypes()
        {
            return await _context.MonthPriceTypes.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<MonthPriceType> GetMonthPriceTypeById(Guid id)
        {
            return await _context.MonthPriceTypes.FindAsync(id);
        }

        public void AddMonthPriceType(PriceMonthViewModel viewModel)
        {
            MonthPriceType price = new()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                End = viewModel.End,
                Start = viewModel.Start,
                Percent = viewModel.Percent,
            };
            _context.MonthPriceTypes.Add(price);
            _context.SaveChanges();
        }

        public bool UpdateMonthPriceType(Guid id, PriceMonthViewModel viewModel)
        {
            MonthPriceType price = _context.MonthPriceTypes.Find(id);
            if (price != null)
            {
                price.Name = viewModel.Name;
                price.Start = viewModel.Start;
                price.End = viewModel.End;
                price.Percent = viewModel.Percent;
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteMonthPriceType(Guid id)
        {
            MonthPriceType priceType = _context.MonthPriceTypes.Find(id);

            if (priceType != null)
            {
                _context.MonthPriceTypes.Remove(priceType);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
