using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface IOrgRepository
    {
        void AddOrg(Org org);
        void UpdateOrg(Org org);
        IEnumerable<Org> GetAllOrg();
    }
    public class OrgRepository : IOrgRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public OrgRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddOrg(Org org)
        {
            try
            {
                org.CreatedDate = DateTime.Now;
                org.ModifiedDate = DateTime.Now;
                org.IsDeleted = false;
                org.CreatedBy = 0;
                _ = _dbContext.Org.Add(org);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public void UpdateOrg(Org org)
        {
            Org? tempUser = _dbContext.Org.FirstOrDefault(x => x.OrgId == org.OrgId);
            if (tempUser != null)
            {
                tempUser.ModifiedDate = DateTime.Now;
                _ = _dbContext.Org.Update(tempUser);
                _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Org> GetAllOrg()
        {
            return _dbContext.Org.ToList();
        }
    }
}
