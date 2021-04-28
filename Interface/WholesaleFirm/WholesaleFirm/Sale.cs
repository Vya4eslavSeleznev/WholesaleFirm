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
using WholesaleFirm.Model;

namespace WholesaleFirm
{
  public partial class Sale : Form
  {
    private int saleId;
    private OracleConnection conn;

    public Sale(int saleId, OracleConnection conn)
    {
      InitializeComponent();
      this.saleId = saleId;
      this.conn = conn;
      setDataInForm();
      setDataInCB();
    }

    private void setDataInForm()
    {
      string query =
        "SELECT GOODS.NAME, SALES.GOOD_COUNT, SALES.CREATE_DATE " +
        "FROM SALES " +
        "JOIN GOODS ON SALES.GOOD_ID = GOODS.ID " +
        "WHERE SALES.ID = " + saleId;

      using (OracleCommand command = new OracleCommand(query, conn))
      using (var rdr = command.ExecuteReader())
      {
        while (rdr.Read())
        {
          saleGoodCB.Text = rdr.GetString(0);
          saleCountTB.Text = rdr.GetInt32(1).ToString();
          saleDTP.Value = rdr.GetDateTime(2);
        }
      }
    }

    private void setDataInCB()
    {
      var goodId = GetGoodId();
      
      OracleCommand cmd = new OracleCommand("SELECT ID, NAME, PRIORITY FROM GOODS", conn);
      OracleDataReader dr = cmd.ExecuteReader();

      var index = 0;
      var goodIndex = 0;

      while (dr.Read())
      {
        var id = dr.GetInt32(0);

        if (goodId == id)
          goodIndex = index;

        index++;

        saleGoodCB.Items.Add(new Model.Good(id, dr.GetString(1), dr.GetInt32(2)));
      }

      saleGoodCB.SelectedIndex = goodIndex;
    }

    private int GetGoodId()
    {
      var query = $"SELECT GOOD_ID FROM SALES WHERE ID={this.saleId}";

      using (var command = new OracleCommand(query, conn))
      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
          return reader.GetInt32(0);
      }

      throw new Exception("Good was not found");
    }

    private void editSaleButton_Click(object sender, EventArgs e)
    {
      var date = saleDTP.Value.Date.ToString("dd.MM.yy");
      int goodId = Helpers.GetSelectedId(saleGoodCB);
      int count = -1;

      try
      {
        count = int.Parse(saleCountTB.Text);
      }
      catch
      {
        MessageBox.Show("Invalid count!");
        return;
      }

      string query =
        "UPDATE SALES SET GOOD_ID = :id, GOOD_COUNT = :count, CREATE_DATE = :dt WHERE ID = " + saleId;

      OracleCommand command = new OracleCommand(query, conn);
      command.Parameters.Add(new OracleParameter("id", goodId));
      command.Parameters.Add(new OracleParameter("count", count));
      command.Parameters.Add(new OracleParameter("dt", date));
      command.ExecuteNonQuery();

      var warehouse1 = GetGoods(1, goodId);
      var warehouse2 = GetGoods(2, goodId);
      var updates = CalculateWarehouseGoodsToUpdate(warehouse1.Concat(warehouse2), count);

      UpdateWarehouseGoods(updates);

      MessageBox.Show("The sale was successfully updated!");
    }

    public IList<WarehouseGood> CalculateWarehouseGoodsToUpdate(IEnumerable<WarehouseGood> goods, int count)
    {
      var goodsToUpdate = new List<WarehouseGood>();

      foreach (var good in goods)
      {
        goodsToUpdate.Add(good);

        if (good.Count >= count)
        {
          good.Count -= count;
          count = 0;
          break;
        }
        else
        {
          count -= good.Count;
          good.Count = 0;
        }
      }

      if (count > 0)
        throw new Exception("Invalid count");

      return goodsToUpdate;
    }

    public void UpdateWarehouseGoods(IEnumerable<WarehouseGood> goods)
    {
      foreach (var good in goods)
      {
        var query = good.Count > 0
          ? $"UPDATE WAREHOUSE{good.WarehouseId} SET GOOD_COUNT={good.Count} WHERE ID={good.Id}"
          : $"DELETE FROM WAREHOUSE{good.WarehouseId} WHERE ID={good.Id}";

        using (var command = new OracleCommand(query, conn))
        {
          command.ExecuteNonQuery();
        }
      }
    }

    public IEnumerable<WarehouseGood> GetGoods(int warehouseId, int goodId)
    {
      var result = new List<WarehouseGood>();

      var query = $"SELECT ID, GOOD_COUNT FROM WAREHOUSE{warehouseId} WHERE GOOD_ID={goodId}";

      using (var command = new OracleCommand(query, conn))
      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          result.Add(new WarehouseGood(reader.GetInt32(0), reader.GetInt32(1), warehouseId));
        }
      }

      return result;
    }
  }
}
