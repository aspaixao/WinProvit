using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinProvit.Entities;

namespace WinProvit.DTO.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginOutput> AuthAsync(LoginInput login);

        Task<UserOutput> Register(UserInput user);
    }
}
