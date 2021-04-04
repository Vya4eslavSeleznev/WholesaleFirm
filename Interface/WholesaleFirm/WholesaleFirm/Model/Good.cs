using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleFirm.Model
{
  class Good : IEntity
  {
    public int Id { get; }

    public string Name { get; }

    public int Priority { get; }

    public Good(int id, string name, int priority)
    {
      Id = id;
      Name = name;
      Priority = priority;
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
