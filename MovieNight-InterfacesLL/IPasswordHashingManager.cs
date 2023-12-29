using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_InterfacesLL
{
    public interface IPasswordHashingManager
    {
        string PassSalt(int length);
        string PassHash(string password, string passwordSalt);
    }
}
