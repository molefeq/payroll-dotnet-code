using DotNetCorePayroll.Common.Exceptions;

using DotNetCorePayroll.Data.ViewModels;

using DotNetCorePayroll.DataAccess.Repositories;

using SqsLibraries.Common.Utilities.ResponseObjects;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.Role
{
    public class RoleBusinessRules
    {
        public virtual void CreateCheck(RoleModel roleModel, RoleRepository roleRepository)
        {
            var role = roleRepository.GetById(a => a.Name == roleModel.Name);

            if (role != null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Role you trying to add already exist."));
            }

            role = roleRepository.GetById(a => a.Code == roleModel.Code);

            if (role != null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Role you trying to add already exist."));
            }
        }

        public virtual void UpdateCheck(RoleModel roleModel, RoleRepository roleRepository)
        {
            var role = roleRepository.GetById(a => a.Id == roleModel.Id);

            if (role == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Role you trying to update does not exist."));
            }

            role = roleRepository.GetById(a => a.Name == roleModel.Name && a.Id != roleModel.Id);

            if (role != null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Role you trying to update already exist."));
            }

            role = roleRepository.GetById(a => a.Code == roleModel.Code && a.Id != roleModel.Id);

            if (role != null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Role you trying to update already exist."));
            }
        }

        public virtual void DeleteCheck(long rolId, RoleRepository roleRepository)
        {
            var role = roleRepository.GetById(a => a.Id == rolId);

            if (role == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Role you trying to delete does not exist."));
            }
        }

    }
}
