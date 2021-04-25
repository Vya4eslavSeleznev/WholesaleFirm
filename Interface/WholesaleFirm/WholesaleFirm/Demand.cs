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
using WholesaleFirm.Helper;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

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

    private void chartButton_Click(object sender, EventArgs e)
    {
      if (goodCB.SelectedItem == null)
      {
        MessageBox.Show("Empty field!");
        return;
      }

      var startDate = dateFromDTP.Value.Date;
      var endDate = dateToDTP.Value.Date;
      int goodId = Helpers.GetSelectedId(goodCB);

      var result = new List<decimal>();

      chart.Series["Forecast"].Points.Clear();

      //while (startDate <= endDate)
      //{
        string query = "DIAGRAM_FOR_GOOD";

      /*using (var command = new OracleCommand(query, conn))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new OracleParameter("dt1", startDate.ToString("dd.MM.yy")));
        command.Parameters.Add(new OracleParameter("dt2", endDate.ToString("dd.MM.yy")));
        command.Parameters.Add(new OracleParameter("id", goodId));

        command.Parameters.Add(new OracleParameter("RESULT", OracleDbType.Double)
        {
          Direction = ParameterDirection.Output
        });

        command.Parameters.Add(new OracleParameter("DATA_CURSOR", OracleDbType.RefCursor)
        {
          Direction = ParameterDirection.Output
        });

        command.ExecuteNonQuery();

        OracleDataAdapter da = new OracleDataAdapter(command);
        DataTable dataTable = new DataTable();
        da.Fill(dataTable);

        //result.Add(((OracleDecimal)command.Parameters["RESULT"].Value).Value);

        OracleDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
          ///cmd.ExecuteNonQuery();

          result.Add(((OracleDecimal)command.Parameters["RESULT"].Value).Value);

        }



        chart.Series["Forecast"].Points.AddXY(
          startDate.ToString("dd.MM.yy"),
          ((OracleDecimal)command.Parameters["RESULT"].Value).Value);
      }*/

      using (var command = new OracleCommand(query, conn))
      {

        DataSet dataset = new DataSet();
        
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new OracleParameter("dt1", startDate.ToString("dd.MM.yy")));
        command.Parameters.Add(new OracleParameter("dt2", endDate.ToString("dd.MM.yy")));
        command.Parameters.Add(new OracleParameter("id", goodId));

        command.Parameters.Add(new OracleParameter("RESULT", OracleDbType.Double)
        {
          Direction = ParameterDirection.Output
        });

        command.Parameters.Add(new OracleParameter("DATA_CURSOR", OracleDbType.RefCursor)
        {
          Direction = ParameterDirection.Output
        });

        try
        {
          //command.ExecuteNonQuery();
          //OracleDataAdapter da = new OracleDataAdapter(command);
          //da.Fill(dataset);

          var reader = command.ExecuteReader();

          while (reader.Read())
          {
            var date = reader.GetDateTime(0);
            var count = reader.GetInt32(1);

            //CHART
          }
        }
        catch (Exception ex)
        {
          System.Console.WriteLine("Exception: {0}", ex.ToString());
        }
      }

      //  startDate = startDate.AddDays(1);
      //}
    }
  }
}
