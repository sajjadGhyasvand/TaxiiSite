using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.Securities;
using Taxii.Core.VireModels.Admin;
using Taxii.DataLayer.Context;
using Taxii.DataLayer.Entities;
using Taxii.DataLayer.Enum;

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

        public async Task<List<Humidity>> GetHumidities()
        {
            return await _context.Humidities.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<Humidity> GetHumidityById(Guid id)
        {
            return await _context.Humidities.FindAsync(id);
        }

        public void AddHumidity(PriceMonthViewModel viewModel)
        {
            Humidity Humid = new()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                End = viewModel.End,
                Start = viewModel.Start,
                Percent = viewModel.Percent,
            };
            _context.Humidities.Add(Humid);
            _context.SaveChanges();
        }

        public bool UpdateHumidity(Guid id, PriceMonthViewModel viewModel)
        {
            Humidity Humid = _context.Humidities.Find(id);
            if (Humid != null)
            {
                Humid.Name = viewModel.Name;
                Humid.Start = viewModel.Start;
                Humid.End = viewModel.End;
                Humid.Percent = viewModel.Percent;
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteHumidity(Guid id)
        {
            Humidity Humid = _context.Humidities.Find(id);

            if (Humid != null)
            {
                _context.Humidities.Remove(Humid);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Temperature>> GetTemperatures()
        {
            return await _context.Temperatures.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<Temperature> GetTemperatureById(Guid id)
        {
            return await _context.Temperatures.FindAsync(id);
        }

        public void AddTemperature(PriceMonthViewModel viewModel)
        {
            Temperature temp = new()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                End = viewModel.End,
                Start = viewModel.Start,
                Percent = viewModel.Percent,
            };
            _context.Temperatures.Add(temp);
            _context.SaveChanges();
        }

        public bool UpdateTemperature(Guid id, PriceMonthViewModel viewModel)
        {
            Temperature temperature = _context.Temperatures.Find(id);
            if (temperature != null)
            {
                temperature.Name = viewModel.Name;
                temperature.Start = viewModel.Start;
                temperature.End = viewModel.End;
                temperature.Percent = viewModel.Percent;
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteTemperature(Guid id)
        {
            Temperature temperature = _context.Temperatures.Find(id);

            if (temperature != null)
            {
                _context.Temperatures.Remove(temperature);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _context.Roles.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<Role> GetRoleById(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public void AddRole(RoleViewModel viewModel)
        {
            Role role = new()
            {
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Title = viewModel.Title,
            };
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public bool UpdateRole(Guid id, RoleViewModel viewModel)
        {
            Role role = _context.Roles.Find(id);
            if (role != null)
            {
                role.Name = viewModel.Name;
                role.Title = viewModel.Title;
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteRole(Guid id)
        {
            Role role = _context.Roles.Find(id);

            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public void AddUser(UserViewModel viewModel)
        {
            User user = new()
            {
                Id = CodeGenerators.GetId(),
                UserName = viewModel.UserName,
                IsActive = true,
                Password = HashEncode.GetHashCode(HashEncode.GetHashCode(CodeGenerators.GetActiveCode())),
                RoleId = viewModel.RoleId,
                Token = null,
                Wallet = 0,
            };
            _context.Users.Add(user);
            UserDetail userDetail = new UserDetail()
            {
                UserId = user.Id,
                Date = DateTimeGenerators.GetShamsiDate(),
                Time = DateTimeGenerators.GetShamsiTime(),
            };
            _context.UserDetails.Add(userDetail);

            if (GetRoleId(viewModel.RoleId) == "driver")
            {
                Driver driver = new Driver()
                {
                    IsConfirm = true,
                    UserId = user.Id

                };
                _context.Drivers.Add(driver);
            }
            _context.SaveChanges();
        }

        public string GetRoleId(Guid id)
        {
            return _context.Roles.Find(id).Name;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.Include(u => u.Role).OrderBy(r => r.UserName).ToListAsync();

        }

        public void DeleteUser(Guid id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();

        }

        public void AddDriver(Guid id)
        {
            Driver driver = new Driver()
            {
                IsConfirm = true,
                UserId = id
            };
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }

        public void DeleteDriver(Guid id)
        {
            Driver driver = _context.Drivers.Find(id);
            _context.Drivers.Remove(driver);
            _context.SaveChanges();
        }

        public bool UpdateUser(Guid id, UserEditViewModel viewModel)
        {
            User user = _context.Users.Find(id);
            UserDetail userDetail = _context.UserDetails.Find(id);
            if (user != null)
            {
                user.RoleId = viewModel.RoleId;
                user.IsActive = viewModel.IsActive;
                user.UserName = viewModel.UserName;
                userDetail.FullName = viewModel.FullName;
                userDetail.BirthDate = viewModel.BirthDate;
                if (GetRoleId(viewModel.RoleId) == "driver")
                {
                    if (!_context.Drivers.Any(d => d.UserId == id))
                    {
                        AddDriver(id);
                    }
                }
                else
                {
                    if (_context.Drivers.Any(d => d.UserId == id))
                    {
                        DeleteDriver(id);
                    }
                }

                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool CheckUserNameForUpdate(string userName, Guid id)
        {
            return _context.Users.Any(u => u.UserName == userName && u.Id != id);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public bool UpdateDriverProp(Guid id, DriverPropViewModel driverProp)
        {
            Driver driver = _context.Drivers.Find(id);
            if (driverProp.Avatar.FileName != null)
            {
                string strExt = Path.GetExtension(driverProp.Avatar.FileName);
                if (strExt != ".jpg")
                {
                    return false;
                }
                string filePath = "";
                driverProp.AvatarName = CodeGenerators.GetFileName() + strExt;
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/driver", driverProp.AvatarName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    driverProp.Avatar.CopyTo(stream);
                }
                if (driver.Avatar != null)
                {
                    File.Delete("wwwroot/img/driver" + driver.Avatar);
                }
                driver.Avatar = driverProp.AvatarName;
                driver.NationalCOde = driverProp.NationalCode;
                driver.Address = driverProp.Address;
                driver.Tel = driverProp.Tel;

                _context.SaveChanges();


                return true;
            }
            else
            {
                if (driver.Avatar != null)
                {
                    driver.NationalCOde = driverProp.NationalCode;
                    driver.Address = driverProp.Address;
                    driver.Tel = driverProp.Tel;

                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
        }

        public async Task<Driver> GetDriver(Guid id)
        {
            return await _context.Drivers.FindAsync(id);
        }

        public bool UpdateDriverCertificated(Guid id, DriverimgViewModel viewModel)
        {
            Driver driver = _context.Drivers.Find(id);
            if (viewModel.Img != null)
            {
                string strExt = Path.GetExtension(viewModel.Img.FileName);
                if (strExt != ".jpg")
                {
                    return false;
                }
                string filePath = "";
                viewModel.ImgNAme = CodeGenerators.GetFileName() + strExt;
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/driver", viewModel.ImgNAme);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Img.CopyTo(stream);
                }
                driver.CarImg = viewModel.ImgNAme;
                driver.IsConfirm = viewModel.IsConfirm;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateDriverCar(Guid id, DriverCarViewModel viewModel)
        {
            Driver driver = _context.Drivers.Find(id);


            driver.CarCode = viewModel.CarCode;
            driver.ColorId = viewModel.ColorId;
            driver.CarId = viewModel.CarId;

            _context.SaveChanges();

            return true;
        }

        public async Task<UserDetail> GetUserDetail(Guid id)
        {
            return await _context.UserDetails.FindAsync(id);
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            return await _context.Discounts.OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Discount> GetDiscountById(Guid id)
        {
            return await _context.Discounts.FindAsync(id);
        }

        public void AddDiscount(DiscountAdminViewModel viewModel)
        {
            Discount discount = new Discount()
            {
                Code = viewModel.Code,
                Description = viewModel.Description,
                Expire = viewModel.Expire,
                Id = CodeGenerators.GetId(),
                Name = viewModel.Name,
                Percent = viewModel.Percent,
                Price = viewModel.Price,
                Start = viewModel.Start,
            };
            _context.Discounts.Add(discount);
            _context.SaveChanges();
        }

        public bool UpdateDiscount(Guid id, DiscountAdminViewModel viewModel)
        {
            Discount discount = _context.Discounts.Find(id);


            if (discount != null)
            {
                discount.Name = viewModel.Name;
                discount.Price = viewModel.Price;
                discount.Start = viewModel.Start;
                discount.Expire = viewModel.Expire;
                discount.Code = viewModel.Code;
                discount.Description = viewModel.Description;
                discount.Price = viewModel.Price;
                discount.Percent = viewModel.Percent;

                _context.SaveChanges();
                return true;
            }

            return false;

        }

        public bool DeleteDiscount(Guid id)
        {
            Discount discount = _context.Discounts.Find(id);
            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public int? WeeklyFactor(string date)
        {
            if (!_context.Factors.Any(f => f.RefNumber != null && f.Date == date))
                return 0;

            return _context.Factors.Where(f => f.RefNumber != null && f.Date == date).ToList().Sum(f=>f.Price);
        }

        public int? MonthlyFactor(string month)
        {
            string strYear = DateTimeGenerators.GetShamsiDate().Substring(0, 4);
            if (_context.Factors.Any(f=>f.RefNumber != null && f.Date.Substring(5,2) == month && f.Date.Substring(0,4) == strYear))
                return 0;
            return _context.Factors.Where(f => f.RefNumber != null && f.Date.Substring(5, 2) == month && f.Date.Substring(0, 4) == strYear).Sum(f => f.Price);
        }

        public int? WeeklyRegister(string date)
        {
            if (!_context.Users.Include(u=>u.UserDetail).Any(f => f.IsActive == true && f.UserDetail.Date == date))
                return 0;

            return _context.Users.Include(u => u.UserDetail).Where(f => f.IsActive == true && f.UserDetail.Date == date).ToList().Count();
        }

        public int? MonthlyRegister(string month)
        {
            string strYear = DateTimeGenerators.GetShamsiDate().Substring(0, 4);
            if (_context.Users.Include(u=>u.UserDetail).Any(f => f.IsActive == true && f.UserDetail.Date.Substring(5, 2) == month && f.UserDetail.Date.Substring(0, 4) == strYear))
                return 0;
            return  _context.Users.Include(u => u.UserDetail).Where(f => f.IsActive == true && f.UserDetail.Date.Substring(5, 2) == month && f.UserDetail.Date.Substring(0, 4) == strYear).Count();
        }

        public async Task<List<Transact>> GetTransacts()
        {
            return await _context.Transacts.OrderByDescending(x => x.Date).ThenByDescending(x => x.StartTime).ToListAsync();
        }

        public void DeleteTransact(Guid id)
        {
            var transact = _context.Transacts.Find(id);

            _context.Transacts.Remove(transact);
            _context.SaveChanges();
        }
        public async Task<List<TransactRate>> GetTransactRates(Guid id)
        {
            return await _context.TransactRates.Where(x => x.TransactId == id).ToListAsync();
        }

        public int? WeeklyTransact(string date)
        {
            if (!_context.Transacts.Any(x => x.Status == TransactStatus.Success && x.Date == date))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(_context.Transacts.Where(x => x.Status == TransactStatus.Success && x.Date == date).Sum(x => x.Total));
            }
        }

        public async Task<List<Transact>> LastTransact()
        {
            return await _context.Transacts.Include(x => x.User).Where(x => x.Status == TransactStatus.Success).OrderByDescending(x => x.Date).ThenByDescending(x => x.EndTime).Take(5).ToListAsync();
        }

        public async Task<List<Transact>> FillTransactInProcess(string date)
        {
            return await _context.Transacts.Include(x => x.User).Where(x => x.Status == TransactStatus.UpdateDriver && x.Date == date)
                .OrderByDescending(x => x.StartTime).ToListAsync();
        }

        public async Task<List<Transact>> FillCancelTransact(string date)
        {
            return await _context.Transacts.Include(x => x.User).Where(x => x.Status == TransactStatus.Canceled && x.Date == date)
                .OrderByDescending(x => x.StartTime).ToListAsync();
        }
    }
}
