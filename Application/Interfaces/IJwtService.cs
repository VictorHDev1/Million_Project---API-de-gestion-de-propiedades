using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Interfaces
{
    public interface IJwtService
    {
        (string token, DateTime expiration) GenerateToken(string username);
    }
}
