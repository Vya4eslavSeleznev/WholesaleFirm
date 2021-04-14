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

namespace WholesaleFirm
{
  public partial class ManagerForm : Form
  {
    OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
      "(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=c##test;Password=MyPass");

    public ManagerForm()
    {
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

      setDataInWarehouses(warehouseQuery("WAREHOUSE1"), warehouse1DGV);
      setDataInWarehouses(warehouseQuery("WAREHOUSE2"), warehouse2DGV);
      setData(goodQuery(), goodDGV);
      setData(saleQuery(), salesDGV);
      addButtons();
      saleDTP.Value.ToShortDateString();

      setDataIntoGoodComboboxes(warehouseGoodCB);
      setDataIntoGoodComboboxes(saleGoodCB);
      typeOfWarehouseCB.Items.Add("First warehouse");
      typeOfWarehouseCB.Items.Add("Second warehouse");
    }

    private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      conn.Close();
    }

    private void setData(string query, DataGridView dgv)
    {
      OracleDataAdapter dataAdapter = new OracleDataAdapter(query, conn);
      DataTable dataTable = new DataTable();
      dataAdapter.Fill(dataTable);
      dgv.DataSource = dataTable;
      dgv.Columns[0].Visible = false;
    }

    private void setDataInWarehouses(string query, DataGridView dgv)
    {
      setData(query, dgv);
      //dgv.Columns[1].Visible = false;
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
          || warehouseCountCB.Text == "")
      {
        MessageBox.Show("Invalid data!");
        return;
      }

      int goodId = Helpers.GetSelectedId(warehouseGoodCB);
      string typeOfWarehouse = typeOfWarehouseCB.Text;
      int count = -1;

      try
      {
        count = int.Parse(warehouseCountCB.Text);
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
      }
      else if (typeOfWarehouse == "Second warehouse")
      {
        insertIntoWarehouse("WAREHOUSE2", goodId, count);
        MessageBox.Show("Delivered to the warehouse2!");
        setData(warehouseQuery("WAREHOUSE2"), warehouse2DGV);
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
      //VALIDATION

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
      command.ExecuteNonQuery();

      MessageBox.Show("Sale added successfully!");

      setData(saleQuery(), salesDGV);
      addCheckBoxInDataGrid("Select to delete", salesDGV);
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
      //addButtonInDataGrid(warehouse1DGV, "Click to edit", "Edit", "editButton");
      //addButtonInDataGrid(warehouse2DGV, "Click to edit", "Edit", "editButton");
      //addButtonInDataGrid(warehouse1DGV, "Click to delete", "Delete", "deleteButton");
      //addButtonInDataGrid(warehouse2DGV, "Click to delete", "Delete", "deleteButton");

      addButtonInDataGrid(goodDGV, "Click to edit", "Edit", "editButton");
      //addButtonInDataGrid(goodDGV, "Click to delete", "Delete", "deleteButton");
      addCheckBoxInDataGrid("Select to delete", goodDGV);

      addButtonInDataGrid(salesDGV, "Click to edit", "Edit", "editButton");
      //addButtonInDataGrid(salesDGV, "Click to delete", "Delete", "deleteButton");
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

    private void deleteSalesButton_Click(object sender, EventArgs e)
    {

    }

    private void deleteGoodsButton_Click(object sender, EventArgs e)
    {
      List<int> goodIds = null;

      try
      {
        goodIds = (from DataGridViewRow r in goodDGV.Rows
                      where (string)r.Cells[0].Value == "1"
                      select int.Parse(r.Cells["ID"].Value.ToString())).ToList();
      }
      catch
      {
        MessageBox.Show("Incorrect good111111111111!", "Goods", MessageBoxButtons.OK);
        return;
      }

      string query =
        "DELETE FROM GOODS " +
        $"WHERE ID IN ({string.Join(",", goodIds)})";

      try
      {
        using (var cmd = new OracleCommand(query, conn))
        {
          cmd.ExecuteNonQuery();
        }
      }
      catch
      {
        MessageBox.Show("Incorrect good222222222222222!", "Goods", MessageBoxButtons.OK);
        return;
      }

      setData(goodQuery(), goodDGV);
      addCheckBoxInDataGrid("Select to delete", goodDGV);
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
          MessageBox.Show(goodDGV.Rows[e.RowIndex].Cells["ID"].Value.ToString(), "Good", MessageBoxButtons.OK);

          using (var good = new Good(goodId, conn))
          {
            good.ShowDialog();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Incorrect parameters!", "Good", MessageBoxButtons.OK);
        }
      }
    }
  }
}
