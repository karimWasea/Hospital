using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;
using Dataaccesslayer;

using hospitalUtilities;

using hospitalVm;

namespace hospitalIrepreatory
{
    public interface IRoleS :IPaginationHelper<RoleVM>
    {
        Task<IEnumerable<RoleVM>> GetAllRolesAsync();
        Task<RoleVM> GetRoleByIdAsync(string id);
        //Task<bool> CreateRoleAsync(RoleVM role);
        //Task<bool> UpdateRoleAsync(RoleVM role);
        Task<bool> Save(RoleVM role);
        Task<bool> DeleteRoleAsync(string id);
    }
   

}