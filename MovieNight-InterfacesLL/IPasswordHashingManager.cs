using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_InterfacesLL
{
    public interface IPasswordHashingManager
    {
        string passSalt(int length);
        string passHash(string password, string passwordSalt);
    }
}
