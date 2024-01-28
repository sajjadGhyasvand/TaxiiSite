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
    }
}
