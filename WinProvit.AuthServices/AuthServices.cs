using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WinProvit.Core.Interfaces;
using WinProvit.DTO;
using WinProvit.Entities;

namespace WinProvit.AuthServices
{
    public class AuthServices : IAuthServices
    {
        public AuthServices(WPContext context)
        {
            Context = context;
        }

        public WPContext Context { get; }

        public async Task<LoginOutput> AuthAsync(LoginInput login)
        {
            try
            {
                var userFounded = await Context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == login.Username.ToLower());

                if (userFounded != null)
                { 
                    if (await VerifyPassword(userFounded, login.Password)) { 
                        var result = new LoginOutput()
                        {
                            UserName = userFounded.UserName,
                            Role = userFounded.Role.ToString()
                        };

                        return result;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                //Gerar log
                throw;
            }
        }

        public async Task<UserOutput> Register(UserInput user)
        {
            //Verify new user
            var userfound = await Context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName);
            if (userfound != null)
            {
                return null;
            }
            //Poderia usar um mapper aqui
            var newUser = new User()
            {
                UserName = user.UserName,
                Role = user.Role,
            };
            newUser.Password = GetPasswordAsync(newUser, user.Password);

            await Context.Users.AddAsync(newUser);
            await Context.SaveChangesAsync();

            //Mapper para o output
            return new UserOutput() { Id = newUser.Id, UserName = newUser.UserName, Role = newUser.Role };
        }

        private string GetPasswordAsync(User user, string newPass)
        {
            var passwordHash = new PasswordHasher<User>();
            return passwordHash.HashPassword(user, string.IsNullOrWhiteSpace(newPass) ? user.Password : newPass);
        }

        private Task<bool> VerifyPassword(User userFound, string pass)
        {
            try
            {
                var passwordHasher = new PasswordHasher<User>();
                var statusValidate = passwordHasher.VerifyHashedPassword(userFound, userFound.Password, pass);
                switch (statusValidate)
                {
                    case PasswordVerificationResult.Failed:
                        return Task.FromResult(false);

                    case PasswordVerificationResult.Success:
                        return Task.FromResult(true);

                    case PasswordVerificationResult.SuccessRehashNeeded:
                        return Task.FromResult(true);

                    default:
                        throw new InvalidOperationException();
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw new InvalidOperationException();
            }
        }

    }
}
