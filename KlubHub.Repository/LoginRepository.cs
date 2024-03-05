using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface ILoginRepository
    {
        UserVM ValidateMember(Member member);
    }
    public class LoginRepository: ILoginRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public LoginRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;           
        }
        public UserVM ValidateMember(Member member)
        {
            try
            {
                var response = new UserVM();
                var result = _dbContext.Member.FirstOrDefault(x => (x.MemberUserName == member.MemberEmail || x.MemberEmail == member.MemberEmail) && x.Password == member.Password);
                if (result == null)
                {
                    throw new Exception("User Not Found.!");
                }
                else
                {
                    response.UserEmail = result.MemberEmail;
                    response.UserName = result.MemberUserName;
                    response.UserFullName = result.MemberFullName;
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
