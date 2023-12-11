using MovieNight_InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_InterfacesLL;
using Amazon.Runtime.Internal.Util;

namespace MovieNight_BusinessLogic
{
    public class PasswordHashingManager : IPasswordHashingManager
    {
        IPasswordHashing hashing;
        public PasswordHashingManager(IPasswordHashing hashing)
        {
            this.hashing = hashing;
        }

        public string passSalt(int length)
        {
            return hashing.GenerateRandomSalt(length);
        }
        public string passHash(string password, string passwordSalt)
        {
            return hashing.GenerateSHA256Hash(password, passwordSalt);
        }
    }
}
