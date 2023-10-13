using LOFI.Helpers;
using LOFI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Data
{
    public class UserService
    {
        private readonly DataRestFull<User> dataRestFull;
        private readonly string url = Links.users;
        private readonly CompteService CompteService = new CompteService();
        private readonly SerializeClass<Compte> serializeClass = new SerializeClass<Compte>();
        private readonly SerializeClass<User> serializeUser = new SerializeClass<User>();

        public UserService()
        {
            dataRestFull = new DataRestFull<User>(url);
        }

        public async Task<User> Login(string telephone, string password)
        {
            User user = await dataRestFull.Login(telephone, password);
            if (user != null)
            {
                Settings.Token = user.Token;
                Settings.User = serializeUser.Serialize(user);
                if (user.UserRole == 0)
                {
                    var CompteUser = await CompteService.CompteAsync(user.UserId);
                    Settings.Compte = serializeClass.Serialize(CompteUser);
                }
            }
            return user;
        }

        public async Task<User> Register(User user)
        {
            return await dataRestFull.PostAsync(user);
        }
    }
}
