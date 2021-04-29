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
using WholesaleFirm.Model;

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

      chart.Series["Forecast"].Points.Clear();

      try
      {
        var chartData = GetMainChartData(startDate, endDate, goodId);
        chartData.Add(GetPredictedData(startDate, endDate, goodId));

        foreach (var item in chartData)
        {
          chart.Series["Forecast"].Points.AddXY(item.Date.ToString("dd.MM.yy"), item.Count);
        }
      }
      catch (Exception ex)
      {

      }
    }

    private ChartData GetPredictedData(DateTime start, DateTime end, int goodId)
    {
      var query = "DIAGRAM_FOR_GOOD1";

      using (var command = new OracleCommand(query, conn))
      {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new OracleParameter("dt1", start.ToString("dd.MM.yy")));
        command.Parameters.Add(new OracleParameter("dt2", end.ToString("dd.MM.yy")));
        command.Parameters.Add(new OracleParameter("id", goodId));

        command.Parameters.Add(new OracleParameter("RESULT", OracleDbType.Double)
        {
          Direction = ParameterDirection.Output
        });

        command.ExecuteNonQuery();

        return new ChartData(end.AddDays(1), ((OracleDecimal)command.Parameters["RESULT"].Value).Value);
      }
    }

    private ICollection<ChartData> GetMainChartData(DateTime start, DateTime end, int goodId)
    {
      var result = new List<ChartData>();

      var query = $"SELECT CREATE_DATE, SUM(GOOD_COUNT) " +
        $"FROM SALES " +
        $"WHERE CREATE_DATE >= :dateFrom AND " +
        $"CREATE_DATE <= :dateTo AND " +
        $"GOOD_ID = :goodId " +
        $"GROUP BY CREATE_DATE " +
        $"ORDER BY CREATE_DATE";

      using (var command = new OracleCommand(query, conn))
      {
        command.Parameters.Add(new OracleParameter("dateFrom", start.ToString("dd.MM.yy")));
        command.Parameters.Add(new OracleParameter("dateTo", end.ToString("dd.MM.yy")));
        command.Parameters.Add(new OracleParameter("goodId", goodId));

        using (var reader = command.ExecuteReader())
        {
          while(reader.Read())
          {
            result.Add(new ChartData(reader.GetDateTime(0), reader.GetInt32(1)));
          }
        }

        return result;
      }
    }
  }
}
