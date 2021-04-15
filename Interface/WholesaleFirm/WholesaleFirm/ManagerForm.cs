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
using System.Configuration;
using WholesaleFirm.Helper;
using WholesaleFirm.Model;

namespace WholesaleFirm
{
  public partial class ManagerForm : Form
  {
    OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
      "(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=c##test;Password=MyPass");

    private Form authentication;

    public ManagerForm(Form authentication)
    {
      this.authentication = authentication;
      InitializeComponent();

      try
      {
        conn.Open();
      }
      catch
      {
        MessageBox.Show("Server closed!");
        return;
      }

      setData(warehouseQuery("WAREHOUSE1"), warehouse1DGV);
      setData(warehouseQuery("WAREHOUSE2"), warehouse2DGV);
      setData(goodQuery(), goodDGV);
      setData(saleQuery(), salesDGV);
      addButtons();
      saleDTP.Value.ToShortDateString();

      setDataIntoGoodComboboxes(warehouseGoodCB);
      setDataIntoGoodComboboxes(saleGoodCB);
      typeOfWarehouseCB.Items.Add("First warehouse");
      typeOfWarehouseCB.Items.Add("Second warehouse");
      setData(topGoods(), top5goodsDGV);
    }

    private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      conn.Close();
      authentication.Visible = true;
    }

    private void setData(string query, DataGridView dgv)
    {
      OracleDataAdapter dataAdapter = new OracleDataAdapter(query, conn);
      DataTable dataTable = new DataTable();
      dataAdapter.Fill(dataTable);
      dgv.DataSource = dataTable;
      dgv.Columns[0].Visible = false;
    }

    private void setDataIntoGoodComboboxes(ComboBox cb)
    {
      OracleCommand cmd = new OracleCommand("SELECT ID, NAME, PRIORITY FROM GOODS", conn);
      OracleDataReader dr = cmd.ExecuteReader();

      while(dr.Read())
      {
        cb.Items.Add(new Model.Good(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2)));
      }
    }

    private string warehouseQuery(string warehouse)
    {
      return
        $"SELECT {warehouse}.GOOD_ID, GOODS.NAME, SUM(GOOD_COUNT) AS Total " +
        $"FROM {warehouse} " +
        $"JOIN GOODS ON {warehouse}.GOOD_ID = GOODS.ID " +
        $"GROUP BY {warehouse}.GOOD_ID, GOODS.NAME " +
        "ORDER BY Total DESC";
    }

    private void insertIntoWarehouse(string warehouse, int id, int count)
    {
      string query =
        $"INSERT INTO {warehouse}(GOOD_ID, GOOD_COUNT) VALUES(:id, :count)";

      OracleCommand command = new OracleCommand(query, conn);
      command.Parameters.Add(new OracleParameter("id", id));
      command.Parameters.Add(new OracleParameter("count", count));
      command.ExecuteNonQuery();
    }

    private void warehousesButton_Click(object sender, EventArgs e)
    {
      if (warehouseGoodCB.SelectedItem == null || typeOfWarehouseCB.SelectedItem == null
          || warehouseCountTextBox.Text == "")
      {
        MessageBox.Show("Invalid data!");
        return;
      }

      int goodId = Helpers.GetSelectedId(warehouseGoodCB);
      string typeOfWarehouse = typeOfWarehouseCB.Text;
      int count = -1;

      try
      {
        count = int.Parse(warehouseCountTextBox.Text);
      }
      catch
      {
        MessageBox.Show("Invalid count!");
        return;
      }

      if (typeOfWarehouse == "First warehouse")
      {
        insertIntoWarehouse("WAREHOUSE1", goodId, count);
        MessageBox.Show("Delivered to the warehouse1!");
        setData(warehouseQuery("WAREHOUSE1"), warehouse1DGV);
        addCheckBoxInDataGrid("Select to delete", warehouse1DGV);
      }
      else if (typeOfWarehouse == "Second warehouse")
      {
        insertIntoWarehouse("WAREHOUSE2", goodId, count);
        MessageBox.Show("Delivered to the warehouse2!");
        setData(warehouseQuery("WAREHOUSE2"), warehouse2DGV);
        addCheckBoxInDataGrid("Select to delete", warehouse2DGV);
      }
      else
      {
        MessageBox.Show("Select the warehouse!");
      }
    }

    private string goodQuery()
    {
      return
        "SELECT ID, NAME, PRIORITY FROM GOODS";
    }

    private string saleQuery()
    {
      return
        "SELECT SALES.ID, GOODS.NAME, SALES.GOOD_COUNT, SALES.CREATE_DATE " +
        "FROM SALES " +
        "JOIN GOODS ON SALES.GOOD_ID = GOODS.ID";
    }

    private void addGoodButton_Click(object sender, EventArgs e)
    {
      if (goodNameTextBox.Text == "")
      {
        MessageBox.Show("Empty name field!");
        return;
      }

      string name = goodNameTextBox.Text;
      int priority = Convert.ToInt32(goodPriorityNUD.Value);

      string query =
        "INSERT INTO GOODS(NAME, PRIORITY) VALUES(:name, :priority)";

      OracleCommand command = new OracleCommand(query, conn);
      command.Parameters.Add(new OracleParameter("name", name));
      command.Parameters.Add(new OracleParameter("priority", priority));
      command.ExecuteNonQuery();

      setData(goodQuery(), goodDGV);
      addCheckBoxInDataGrid("Select to delete", goodDGV);
      RefreshCombobox(warehouseGoodCB);
      RefreshCombobox(saleGoodCB);

      MessageBox.Show("The good was successfully added!");
    }

    private void RefreshCombobox(ComboBox comboBox)
    {
      comboBox.Items.Clear();
      setDataIntoGoodComboboxes(comboBox);
    }

    private void addSaleButton_Click(object sender, EventArgs e)
    {
      if (saleGoodCB.SelectedItem == null || saleCountTB.Text == ""
          || saleDTP.Text == "")
      {
        MessageBox.Show("Invalid data!");
        return;
      }

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
        "INSERT INTO SALES(GOOD_ID, GOOD_COUNT, CREATE_DATE) VALUES(:id, :count, :dt)";

      OracleCommand command = new OracleCommand(query, conn);
      command.Parameters.Add(new OracleParameter("id", goodId));
      command.Parameters.Add(new OracleParameter("count", count));
      command.Parameters.Add(new OracleParameter("dt", date));

      try
      {
        command.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Not enough goods!");
        return;
      }

      var warehouse1 = GetGoods(1, goodId);
      var warehouse2 = GetGoods(2, goodId);

      var updates = CalculateWarehouseGoodsToUpdate(warehouse1.Concat(warehouse2), count);

      UpdateWarehouseGoods(updates);

      MessageBox.Show("Sale added successfully!");

      setData(saleQuery(), salesDGV);
      setData(warehouseQuery("WAREHOUSE1"), warehouse1DGV);
      setData(warehouseQuery("WAREHOUSE2"), warehouse2DGV);
      addCheckBoxInDataGrid("Select to delete", warehouse1DGV);
      addCheckBoxInDataGrid("Select to delete", warehouse2DGV);
      addCheckBoxInDataGrid("Select to delete", salesDGV);
      setData(topGoods(), top5goodsDGV);
    }

    public IList<WarehouseGood> CalculateWarehouseGoodsToUpdate(IEnumerable<WarehouseGood> goods, int count)
    {
      var goodsToUpdate = new List<WarehouseGood>();
      
      foreach(var good in goods)
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
        while(reader.Read())
        {
          result.Add(new WarehouseGood(reader.GetInt32(0), reader.GetInt32(1), warehouseId));
        }
      }

      return result;
    }

    private void addButtonInDataGrid(DataGridView dataGrid, string headerText, string buttonText, string buttonName)
    {
      DataGridViewButtonColumn button = new DataGridViewButtonColumn();
      dataGrid.Columns.Add(button);
      button.HeaderText = headerText;
      button.Text = buttonText;
      button.Name = buttonName;
      button.UseColumnTextForButtonValue = true;
    }

    private void addButtons()
    {
      addCheckBoxInDataGrid("Select to delete", warehouse1DGV);
      addCheckBoxInDataGrid("Select to delete", warehouse2DGV);

      addButtonInDataGrid(goodDGV, "Click to edit", "Edit", "editButton");
      addCheckBoxInDataGrid("Select to delete", goodDGV);

      addButtonInDataGrid(salesDGV, "Click to edit", "Edit", "editButton");
      addCheckBoxInDataGrid("Select to delete", salesDGV);
    }

    private void addCheckBoxInDataGrid(string headerText, DataGridView dataGrid)
    {
      DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
      check.HeaderText = headerText;
      check.FalseValue = "0";
      check.TrueValue = "1";
      dataGrid.Columns.Insert(0, check);
    }

    private void deleteRecord(DataGridView dgv, string column, string message,
                              string title, string table, string queryMethod)
    {
      List<int> ids = null;

      try
      {
        ids = (from DataGridViewRow r in dgv.Rows
               where (string)r.Cells[0].Value == "1"
               select int.Parse(r.Cells[column].Value.ToString())).ToList();
      }
      catch
      {
        MessageBox.Show(message, title, MessageBoxButtons.OK);
        return;
      }

      string query =
        "DELETE FROM " + table +
        " WHERE " + column + $" IN ({string.Join(",", ids)})";

      try
      {
        using (var cmd = new OracleCommand(query, conn))
        {
          cmd.ExecuteNonQuery();
        }
      }
      catch
      {
        MessageBox.Show(message, title, MessageBoxButtons.OK);
        return;
      }

      setData(queryMethod, dgv);
      addCheckBoxInDataGrid("Select to delete", dgv);
    }

    private void deleteSalesButton_Click(object sender, EventArgs e)
    {
      deleteRecord(salesDGV, "ID", "Incorrect sale!", "Sales", "SALES", saleQuery());
      setData(topGoods(), top5goodsDGV);
    }

    private void deleteGoodsButton_Click(object sender, EventArgs e)
    {
      deleteRecord(goodDGV, "ID", "Incorrect good!", "Goods", "GOODS", goodQuery());
      RefreshCombobox(warehouseGoodCB);
      RefreshCombobox(saleGoodCB);
    }

    private void forecastButton_Click(object sender, EventArgs e)
    {
      using (var demand = new Demand(conn))
      {
        demand.ShowDialog();
      }
    }

    private void goodDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        try
        {
          var goodId = int.Parse(goodDGV.Rows[e.RowIndex].Cells["ID"].Value.ToString());

          using (var good = new Good(goodId, conn))
          {
            good.ShowDialog();
          }
        }
        catch
        {
          MessageBox.Show("Incorrect parameters!", "Good", MessageBoxButtons.OK);
        }

        setData(goodQuery(), goodDGV);
        addCheckBoxInDataGrid("Select to delete", goodDGV);
        RefreshCombobox(warehouseGoodCB);
        RefreshCombobox(saleGoodCB);
        setData(warehouseQuery("WAREHOUSE1"), warehouse1DGV);
        setData(warehouseQuery("WAREHOUSE2"), warehouse2DGV);
        setData(saleQuery(), salesDGV);
      }
    }

    private void deleteWarehouse1Button_Click(object sender, EventArgs e)
    {
      deleteRecord(warehouse1DGV, "GOOD_ID", "Incorrect good in warehouse 1!", "Warehouse 1",
                  "WAREHOUSE1", warehouseQuery("WAREHOUSE1"));
    }

    private void deleteWarehouse2Button_Click(object sender, EventArgs e)
    {
      deleteRecord(warehouse2DGV, "GOOD_ID", "Incorrect good in warehouse 2!", "Warehouse 2",
                  "WAREHOUSE2", warehouseQuery("WAREHOUSE2"));
    }

    private void salesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        try
        {
          var salesId = int.Parse(salesDGV.Rows[e.RowIndex].Cells["ID"].Value.ToString());

          using (var sale = new Sale(salesId, conn))
          {
            sale.ShowDialog();
          }
        }
        catch
        {
          MessageBox.Show("Incorrect parameters!", "Sales", MessageBoxButtons.OK);
        }

        setData(saleQuery(), salesDGV);
        addCheckBoxInDataGrid("Select to delete", salesDGV);
        setData(topGoods(), top5goodsDGV);
      }
    }

    private string topGoods()
    {
      return
        "SELECT * " +
        "FROM " +
        "(" +
        "SELECT SALES.GOOD_ID, GOODS.NAME, SUM(GOOD_COUNT) AS GOOD_COUNT " +
        "FROM SALES " +
        "JOIN GOODS ON SALES.GOOD_ID = GOODS.ID " +
        "GROUP BY SALES.GOOD_ID, GOODS.NAME " +
        "ORDER BY GOOD_COUNT DESC" +
        ") " +
        "WHERE ROWNUM <= 5";
    }
  }
}
