using WholesaleFirm.Model;
using System.Windows.Forms;

namespace WholesaleFirm.Helper
{
  class Helpers
  {
    public static int GetSelectedId(ComboBox cb)
    {
      return ((IEntity)cb.SelectedItem).Id;
    }
  }
}
