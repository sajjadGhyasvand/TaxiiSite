using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.VireModels.Panel;
using Taxii.DataLayer.Entities;
using Taxii.DataLayer.Enum;

namespace Taxii.Core.Interfaces
{
    public interface IPanelService : IDisposable
    {

        #region User
        Task<UserDetail> GetUserDetail(string username);
        string GetRoleName(string userName);
        bool UpdateUserDetailsProfile(Guid id, UserDetailProfileViewModel viewModel);
        #endregion

        #region Payment
        void AddFactor(Factor factor);
        bool UpdateFactor(Guid userid, string orderNumber, long price);
        Guid GetFactorById(string orderNumber);
        Task<UserDetail> GetUserDetails(string username);
        User GetUser(string username);
        Guid GetUserId(string username);
        User GetUserById(Guid id);
        Driver GetDriverById(Guid id);

        void UpdatePayment(Guid id, string date, string time, string desc, string bank, string trace, string refId);
        Task<Factor> GetFactor(Guid id);
        #endregion

        #region Address
        Task<List<UserAddress>> GetUserAddresses(Guid id);
        void AddAddress(Guid id, UserAddressViewModel address);
        #endregion

        #region Price
        long GetPriceType(double id);
        float GetTempPercent(double id);
        float GetHumidityPercent(double id);
        #endregion

        #region Transact
        void AddTransactModel(Transact model);
        Transact AddTransact(TransactViewModel viewModel);
        void UpdatePayments(Guid id);
        void UpdateRate(Guid id, int rate);
        Task<Transact> GetTransactById(Guid id);
        Task<List<Transact>> GetUserTransacts(Guid id);
        Task<List<Transact>> GetDriverTransacts(Guid id);
        void UpdateDriver(Guid id, Guid driverId);
        void UpdateDriverRate(Guid id, bool rate);
        void UpdateStatus(Guid id, TransactStatus status);
        Guid? ExistsUserTransact(Guid id);
        Transact GetUserTransact(Guid id);
        Transact GetUserConfrimTransact(Guid id);
        //driver 
        Transact GetDriverConfrimTransact(Guid id);
        List<Transact> GetTransactsNotAccept();
        void EndRequest(Guid id);
        void UpdateDrtiverStatus(Guid id, Guid? driverId, TransactStatus status);
        #endregion
        void AddRate(Guid id, int rate);

    }

}
