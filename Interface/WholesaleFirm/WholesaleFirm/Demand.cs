using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WholesaleFirm
{
  public partial class Demand : Form
  {
    private OracleConnection conn;

    public Demand(OracleConnection conn)
    {
      InitializeComponent();
      this.conn = conn;
      setDataIntoGoodCombobox(goodCB);
    }

    private void setDataIntoGoodCombobox(ComboBox cb)
    {
      OracleCommand cmd = new OracleCommand("SELECT ID, NAME, PRIORITY FROM GOODS", conn);
      OracleDataReader dr = cmd.ExecuteReader();

      while (dr.Read())
      {
        cb.Items.Add(new Model.Good(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2)));
      }
    }
  }
}
