using CardIndex.DataAccess.Postgres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardIndex.Core.Entities;


namespace CardIndex.Business.Services
{
    public class AdminService
    {
        AdminRepository _adminRepository = new AdminRepository();
        PasswordService _passwordService = new PasswordService();

        public void Save(string name, string password)
        {
            Admin admin = new Admin();
            admin.Name = name;
            admin.Salt = _passwordService.GenerateSalt();
            admin.Password = _passwordService.HashPassword(password, admin.Salt);

            _adminRepository.Insert(admin);
        }
    }
}
