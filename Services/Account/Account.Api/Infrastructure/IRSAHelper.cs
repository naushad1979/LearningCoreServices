using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Api.Infrastructure
{
    public interface IRSAHelper
    {
        string Encrypt(string text);
        string Decrypt(string encrypted);
    }
}
