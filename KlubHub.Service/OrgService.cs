using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlubHub.Model;
using KlubHub.Repository;

namespace KlubHub.Service
{
    public interface IOrgService
    {
        void AddOrg(Org member);
        void UpdateOrg(Org member);
        IEnumerable<Org> GetAllOrg();
    }
    public class OrgService : IOrgService
    {
        private readonly IOrgRepository _orgRepository;

        public OrgService(IOrgRepository orgRepository)
        {
            _orgRepository = orgRepository;
        }
        public void AddOrg(Org member)
        {
            member.CreatedDate = DateTime.Now;
            member.ModifiedDate = DateTime.Now;
            member.IsDeleted = false;
            member.CreatedBy = 0;
            _orgRepository.AddOrg(member);
        }

        public void UpdateOrg(Org member)
        {
            try
            {
                _orgRepository.UpdateOrg(member);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Org> GetAllOrg()
        {
            return _orgRepository.GetAllOrg();
        }
    }
}
