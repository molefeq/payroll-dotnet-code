using DotNetCorePayroll.DataAccess.Repositories;
using System.Threading.Tasks;

namespace DotNetCorePayroll.DataAccess
{
    public interface IUnitOfWork
    {
        #region Repositories Properties

        AccountRepository Account { get; }
        OrganisationRepository Organisation { get; }

        #endregion

        Task SaveAsync();
        void Save();
    }
}
