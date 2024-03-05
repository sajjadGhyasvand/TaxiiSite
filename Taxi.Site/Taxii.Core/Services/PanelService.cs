using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Generatiors;
using Taxii.Core.Interfaces;
using Taxii.Core.VireModels.Panel;
using Taxii.DataLayer.Context;
using Taxii.DataLayer.Entities;
using Taxii.DataLayer.Enum;

namespace Taxii.Core.Services
{
    public class PanelService : IPanelService
    {
        private DataBaseContext _context;

        public PanelService(DataBaseContext context)
        {
            _context = context;
        }

        public PanelService()
        {
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public string GetRoleName(string userName)
        {
            return _context.Users.Include(u => u.Role).SingleOrDefault(u => u.UserName == userName).Role.Name;
        }

        public async Task<UserDetail> GetUserDetail(string username)
        {
            return await _context.UserDetails.Include(u => u.User).SingleOrDefaultAsync(u => u.User.UserName == username);
        }

        public bool UpdateUserDetailsProfile(Guid id, UserDetailProfileViewModel viewModel)
        {
            UserDetail userDetail = _context.UserDetails.Find(id);
            if (userDetail != null)
            {
                userDetail.FullName = viewModel.FullName;
                userDetail.BirthDate = viewModel.BirthDate;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateFactor(Guid userid, string orderNumber, long price)
        {
            Factor factor = _context.Factors.SingleOrDefault(f => f.UserId == userid && f.BankName == null);

            if (factor != null)
            {
                factor.OrderNumber = orderNumber;
                factor.Price = Convert.ToInt32(price);

                _context.SaveChanges();

                return true;
            }

            return false;
        }
        public void AddFactor(Factor factor)
        {
            _context.Factors.Add(factor);
            _context.SaveChanges();
        }
        public async Task<Factor> GetFactor(Guid id)
        {
            return await _context.Factors.FindAsync(id);
        }

        public Guid GetFactorById(string orderNumber)
        {
            return _context.Factors.SingleOrDefault(f => f.OrderNumber == orderNumber).Id;
        }
        public void UpdatePayment(Guid id, string date, string time, string desc, string bank, string trace, string refId)
        {
            Factor factor = _context.Factors.Find(id);
            User user = _context.Users.Find(factor.UserId);

            factor.Date = DateTimeGenerators.GetShamsiDate();
            factor.Time = DateTimeGenerators.GetShamsiTime();
            factor.Desc = desc;
            factor.TraceNumber = trace;
            factor.BankName = bank;
            factor.RefNumber = refId;

            user.Wallet += factor.Price;

            _context.SaveChanges();
        }

        public async Task<List<UserAddress>> GetUserAddresses(Guid id)
        {
            return await _context.UserAddresses.Where(a => a.UserId == id).ToListAsync();
        }
        public void AddAddress(Guid id, UserAddressViewModel viewModel)
        {
            UserAddress addresse = new UserAddress()
            {
                Desc = viewModel.Desc,
                Id = CodeGenerators.GetId(),
                Lat = viewModel.Lat,
                Lng = viewModel.Lng,
                Title = viewModel.Title,
                UserId = id
            };

            _context.UserAddresses.Add(addresse);
            _context.SaveChanges();
        }

        public float GetHumidityPercent(double id)
        {
            var hum = _context.Humidities.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (hum == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(hum.Percent / 100);
            }
        }
        public float GetTempPercent(double id)
        {
            var temp = _context.Temperatures.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (temp == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(temp.Percent / 100);
            }
        }
        public void AddTransactModel(Transact model)
        {
            _context.Transacts.Add(model);
            _context.SaveChanges();
        }

        public Transact AddTransact(TransactViewModel viewModel)
        {
            Transact transact = new Transact()
            {
                Id = CodeGenerators.GetId(),
                Date = DateTimeGenerators.GetShamsiDate(),
                StartTime = DateTimeGenerators.GetShamsiTime(),
                Discount = 0,
                DriverId = null,
                DriverRate = false,
                EndAddress = viewModel.EndAddress,
                EndLat = viewModel.EndLat,
                EndLng = viewModel.EndLng,
                EndTime = null,
                Fee = viewModel.Fee,
                Total = viewModel.Fee,
                IsCash = false,
                Rate = 0,
                StartAddress = viewModel.StartAddress,
                StartLat = viewModel.StartLat,
                StartLng = viewModel.StartLng,
                Status = 0,
                UserId = viewModel.UserId
            };

            _context.Transacts.Add(transact);
            _context.SaveChanges();

            return transact;
        }
        public async Task<List<Transact>> GetDriverTransacts(Guid id)
        {
            return await _context.Transacts.Where(x => x.DriverId == id && x.Status == TransactStatus.Success).OrderByDescending(x => x.Date)
                .ToListAsync();
        }
        public async Task<Transact> GetTransactById(Guid id)
        {
            return await _context.Transacts.FindAsync(id);
        }
        public async Task<List<Transact>> GetUserTransacts(Guid id)
        {
            return await _context.Transacts.Where(x => x.UserId == id && x.Status == TransactStatus.Success).OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public void UpdateRate(Guid id, int rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Rate = rate;
            _context.SaveChanges();
        }


        public long GetPriceType(double id)
        {
            var priceType = _context.PriceTypes.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (priceType == null)
            {
                return 0;
            }
            else
            {
                return priceType.Price;
            }
        }



        public void UpdateStatus(Guid id, TransactStatus status)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Status = status;
            _context.SaveChanges();
        }
        public void UpdateDrtiverStatus(Guid id, Guid? driverId, TransactStatus status)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Status = status;

            if (driverId != null)
            {
                transact.DriverId = driverId;
            }

            _context.SaveChanges();
        }

        public void UpdateDriver(Guid id, Guid driverId)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.DriverId = driverId;
            _context.SaveChanges();
        }

        public void UpdateDriverRate(Guid id, bool rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.DriverRate = rate;
            _context.SaveChanges();
        }


        public void UpdatePayments(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Transact> GetTransactsNotAccept()
        {
            return _context.Transacts.Where(x => x.Status == TransactStatus.Create).OrderByDescending(x => x.Date).ToList();
        }

        public async Task<UserDetail> GetUserDetails(string username)
        {
            return await _context.UserDetails.Include(u => u.User).SingleOrDefaultAsync(u => u.User.UserName == username);
        }

        public User GetUser(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public Guid GetUserId(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username).Id;
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public Driver GetDriverById(Guid id)
        {
            return _context.Drivers.Find(id);
        }

        public Guid? ExistsUserTransact(Guid id)
        {
            // 0 == Create
            // 1 == Driver
            // 2 == Success
            // 3 == Cancel

            Transact transact = _context.Transacts.FirstOrDefault(x => x.UserId == id && (x.Status == TransactStatus.Create || x.Status == TransactStatus.UpdateDriver));

            if (transact != null)
            {
                return transact.Id;
            }
            else
            {
                return null;
            }
        }
        public Transact GetUserTransact(Guid id)
        {
            return _context.Transacts.Find(id);
        }

        public Transact GetDriverConfrimTransact(Guid id)
        {
            return _context.Transacts.FirstOrDefault(x => x.DriverId == id && x.Status == TransactStatus.UpdateDriver);
        }

        public void EndRequest(Guid id)
        {
            Transact transact = _context.Transacts.Find(id);

            if (transact.IsCash == false)
            {
                User user = _context.Users.Find(transact.UserId);

                user.Wallet -= transact.Total;

            }

            transact.Status = TransactStatus.Success;
            _context.SaveChanges();
        }

        public Transact GetUserConfrimTransact(Guid id)
        {
            return _context.Transacts.FirstOrDefault(x => x.UserId == id && x.Status == TransactStatus.UpdateDriver);
        }

        public void AddRate(Guid id, int rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Rate = rate;
            _context.SaveChanges();
        }
    }
}
