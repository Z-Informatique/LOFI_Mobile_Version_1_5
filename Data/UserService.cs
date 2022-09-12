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

        public UserService()
        {
            dataRestFull = new DataRestFull<User>(url);
        }

        public async Task<User> Login(string telephone, string password)
        {
            User user = await dataRestFull.Login(telephone, password);
            if (user is not null)
            {
                Settings.Token = user.Token;
                Settings.IdUser = user.UserId.ToString();
                Settings.Nom = user.NomUser;
                Settings.Prenom = user.PrenomUser;
                Settings.UserRole = user.UserRole.ToString();

                if (user.UserRole == 0)
                {
                    Compte compte = await CompteService.CompteAsync(Convert.ToInt32(Settings.IdUser));
                    if (compte is not null)
                    {
                        Settings.Compte = serializeClass.Serialize(compte);
                    }
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
