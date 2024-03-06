using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface ILoginRepository
    {
        MemberVM ValidateMember(Member member);
    }
    public class LoginRepository: ILoginRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public LoginRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;           
        }
        public MemberVM ValidateMember(Member member)
        {
            try
            {
                var response = new MemberVM();
                var result = _dbContext.Member.FirstOrDefault(x => (x.MemberUserName == member.MemberEmail || x.MemberEmail == member.MemberEmail) && x.Password == member.Password);
                if (result == null)
                {
                    throw new Exception("User Not Found.!");
                }
                else
                {
                    response.MemberEmail = result.MemberEmail;
                    response.MemberUserName = result.MemberUserName;
                    response.MemberFullName = result.MemberFullName;
                    response.Id = result.Id;
                    response.MemberRoleId = result.MemberRoleId;
                    response.MemberContactNumber = result.MemberContactNumber;
                    return response;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
