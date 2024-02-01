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
    }
}
