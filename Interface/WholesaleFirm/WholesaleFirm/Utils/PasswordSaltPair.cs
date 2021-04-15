using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleFirm.Utils
{
  public class PasswordSaltPair
  {
    public string Password { get; }

    public string Salt { get; }

    public PasswordSaltPair(string password, string salt)
    {
      Password = password;
      Salt = salt;
    }
  }
}
