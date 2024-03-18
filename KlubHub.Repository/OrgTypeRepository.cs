using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface IOrgTypeRepository
    {
        void AddOrgType(OrgType orgType);
        void UpdateOrgType(OrgType orgType);
        IEnumerable<OrgType> GetAllOrgType();
    }
    public class OrgTypeRepository : IOrgTypeRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public OrgTypeRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddOrgType(OrgType orgType)
        {
            try
            {
                orgType.CreatedDate = DateTime.Now;
                orgType.ModifiedDate = DateTime.Now;
                orgType.IsDeleted = false;
                orgType.CreatedBy = 0;
                _ = _dbContext.OrgType.Add(orgType);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public void UpdateOrgType(OrgType orgType)
        {
            OrgType? tempUser = _dbContext.OrgType.FirstOrDefault(x => x.OrgTypeId == orgType.OrgTypeId);
            if (tempUser != null)
            {
                tempUser.ModifiedDate = DateTime.Now;
                _ = _dbContext.OrgType.Update(tempUser);
                _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<OrgType> GetAllOrgType()
        {
            return _dbContext.OrgType.ToList();
        }
    }
}
