using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.VireModels.Admin;
using Taxii.DataLayer.Entities;

namespace Taxii.Core.Interfaces
{
    public interface IAdminService : IDisposable
    {
        #region Car
        Task<List<Car>> GetCars();
        Task<Car> GetCarById(Guid id);
        void AddCar(CarViewModel viewModel);
        bool UpdateCar(Guid id,CarViewModel viewModel);
        bool DeleteCar(Guid id);
        #endregion

        #region Color
        Task<List<Color>> GetColors();
        Task<Color> GetColorById(Guid id);
        void AddColor(ColorViewModel viewModel);
        bool UpdateColor(Guid id, ColorViewModel viewModel);
        bool DeleteColor(Guid id);
        #endregion

        #region RateType
        Task<List<RateType>> GetRateTypes();
        Task<RateType> GetRateTypeById(Guid id);
        void AddRateType(RateTypeViewModel viewModel);
        bool UpdateRateType(Guid id, RateTypeViewModel viewModel);
        bool DeleteRateType(Guid id);
        #endregion

        #region Setting
        Task<Setting> GetSetting();
        bool UpdateSiteSetting(SiteSettingViewModel viewModel);
        bool UpdatePriceSetting(PriceSettingViewModel viewModel);
        bool UpdateaboutSetting(AboutSettingViewModel viewModel);
        bool UpdateTermSetting(TermSettingViewModel viewModel);

        #endregion

        #region PriceType
        Task<List<PriceType>> GetPriceTypes();
        Task<PriceType> GetPriceTypeById(Guid id);
        void AddPriceType(PriceTypeViewModel viewModel);
        bool UpdatePriceType(Guid id, PriceTypeViewModel viewModel);
        bool DeletePriceType(Guid id);
        #endregion

        #region MonthPriceType
        Task<List<MonthPriceType>> GetMonthPriceTypes();
        Task<MonthPriceType> GetMonthPriceTypeById(Guid id);
        void AddMonthPriceType(PriceMonthViewModel viewModel);
        bool UpdateMonthPriceType(Guid id, PriceMonthViewModel viewModel);
        bool DeleteMonthPriceType(Guid id);
        #endregion

        #region Humidity
        Task<List<Humidity>> GetHumidities();
        Task<Humidity> GetHumidityById(Guid id);
        void AddHumidity(PriceMonthViewModel viewModel);
        bool UpdateHumidity(Guid id, PriceMonthViewModel viewModel);
        bool DeleteHumidity(Guid id);
        #endregion

        #region Temperature
        Task<List<Temperature>> GetTemperatures();
        Task<Temperature> GetTemperatureById(Guid id);
        void AddTemperature(PriceMonthViewModel viewModel);
        bool UpdateTemperature(Guid id, PriceMonthViewModel viewModel);
        bool DeleteTemperature(Guid id);
        #endregion

        #region Role
        Task<List<Role>> GetRoles();
        Task<Role> GetRoleById(Guid id);
        void AddRole(RoleViewModel viewModel);
        bool UpdateRole(Guid id, RoleViewModel viewModel);
        bool DeleteRole(Guid id);
        #endregion

        #region User
        bool CheckUserName(string userName);
        void AddUser(UserViewModel viewModel);
        string GetRoleId(Guid id);
        Task<List<User>> GetUsers();
        void DeleteUser(Guid id);
        void AddDriver( Guid id);
        void DeleteDriver(Guid id);
        bool UpdateUser(Guid id, UserViewModel viewModel);
        bool CheckUserNameForUpdate(string userName,Guid id);
        Task<User> GetUserById(Guid id);
        #endregion
    }
}
