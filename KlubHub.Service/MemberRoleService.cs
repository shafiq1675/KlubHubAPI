using KlubHub.Data;
using KlubHub.Model;
using KlubHub.Repository;

namespace KlubHub.Service
{
    public interface IMemberRoleService
    {
        void AddMemberRole(MemberRole MemberRole);
        IEnumerable<MemberRole> GetAllMemberRole();
    }
    public class MemberRoleService : IMemberRoleService
    {
        private readonly IMemberRoleRepository _MemberRoleRepository;
        private static bool _ensureCreated { get; set; } = false;


        public MemberRoleService(IMemberRoleRepository MemberRoleRepository)
        {
            _MemberRoleRepository = MemberRoleRepository;

        }
        public void AddMemberRole(MemberRole MemberRole)
        {
            try
            {
                MemberRole.CreatedDate = DateTime.Now;
                MemberRole.ModifiedDate = DateTime.Now;
                MemberRole.IsDeleted = false;
                MemberRole.CreatedBy = 0;

                _MemberRoleRepository.AddMemberRole(MemberRole);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<MemberRole> GetAllMemberRole()
        {
            return _MemberRoleRepository.GetAllMemberRole();
        }
    }
}
