using System.Threading.Tasks;

namespace DotNetCorePayroll.DataAccess
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Save();
    }
}
