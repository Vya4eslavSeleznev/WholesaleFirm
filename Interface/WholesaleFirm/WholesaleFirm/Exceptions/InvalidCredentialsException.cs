using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleFirm.Exceptions
{
  public class InvalidCredentialsException : Exception
  {
    public InvalidCredentialsException() : base("Invalid login or password")
    {
    }
  }
}
