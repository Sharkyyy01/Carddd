using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardIndex.DataAccess.Postgres.Repositories;
using CardIndex.Core.Entities;
using System.Security.Cryptography;
using System.Numerics;


namespace CardIndex.Business.Services
{
    public class AuthenticationService
    {
        AdminRepository _adminRepository = new AdminRepository();
        PasswordService _passwordService = new PasswordService();
        

        public bool Authenticate(string adminName, string providedPassword)
        {
            Admin? existingAdmin = _adminRepository.SelectByName(adminName);

            if (existingAdmin == null)
                return false;

            return _passwordService.VerifyPassword(providedPassword, existingAdmin.Salt, existingAdmin.Password);
        }
    }
}
