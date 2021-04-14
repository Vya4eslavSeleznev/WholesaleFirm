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
  public partial class Good : Form
  {
    private int goodId;
    private OracleConnection conn;

    public Good(int goodId, OracleConnection conn)
    {
      InitializeComponent();
      this.goodId = goodId;
      this.conn = conn;
      setData();
    }

    private void setData()
    {
      string query =
        "SELECT NAME, PRIORITY FROM GOODS WHERE ID = " + goodId;

      using (OracleCommand command = new OracleCommand(query, conn))
      using (var rdr = command.ExecuteReader())
      {
        while (rdr.Read())
        {
          goodNameTextBox.Text = rdr.GetString(0);
          goodPriorityNUD.Value = rdr.GetInt32(1);
        }
      }
    }

    private void editGoodButton_Click(object sender, EventArgs e)
    {
      var name = goodNameTextBox.Text;
      int priority = Convert.ToInt32(goodPriorityNUD.Value);

      string query =
        "UPDATE GOODS SET NAME = :name, PRIORITY = :priority WHERE ID = " + goodId;

      OracleCommand command = new OracleCommand(query, conn);
      command.Parameters.Add(new OracleParameter("name", name));
      command.Parameters.Add(new OracleParameter("priority", priority));
      command.ExecuteNonQuery();

      MessageBox.Show("The good was successfully updated!");
    }
  }
}
