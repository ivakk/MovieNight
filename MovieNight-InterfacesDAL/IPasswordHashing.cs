using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_InterfacesDAL
{
    public interface IPasswordHashing
    {
        string GenerateSHA256Hash(string password, string salt);
        string GenerateRandomSalt(int length);
    }
}
