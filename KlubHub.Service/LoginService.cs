﻿using KlubHub.Model;
using KlubHub.Repository;


namespace KlubHub.Service
{
    public interface ILoginService
    {
        MemberVM ValidateMember(Member member);
    }
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private static bool _ensureCreated { get; set; } = false;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public MemberVM ValidateMember(Member member)
        {
            try
            {
                return _loginRepository.ValidateMember(member);                
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
