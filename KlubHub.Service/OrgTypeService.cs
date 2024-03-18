using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlubHub.Model;
using KlubHub.Repository;

namespace KlubHub.Service
{
    public interface IOrgTypeService
    {
        void AddOrgType(OrgType orgType);
        void UpdateOrgType(OrgType orgType);
        IEnumerable<OrgType> GetAllOrgType();
    }
    public class OrgTypeService : IOrgTypeService
    {
        private readonly IOrgTypeRepository _orgRepository;

        public OrgTypeService(IOrgTypeRepository orgRepository)
        {
            _orgRepository = orgRepository;
        }
        public void AddOrgType(OrgType orgType)
        {
            orgType.CreatedDate = DateTime.Now;
            orgType.ModifiedDate = DateTime.Now;
            orgType.IsDeleted = false;
            orgType.CreatedBy = 0;
            _orgRepository.AddOrgType(orgType);
        }

        public void UpdateOrgType(OrgType orgType)
        {
            try
            {
                _orgRepository.UpdateOrgType(orgType);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<OrgType> GetAllOrgType()
        {
            return _orgRepository.GetAllOrgType();
        }
    }
}
