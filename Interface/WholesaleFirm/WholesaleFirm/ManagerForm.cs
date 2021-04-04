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
    OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=c##test;Password=MyPass");

    public ManagerForm()
    {
      InitializeComponent();
      conn.Open();
      /*try
      {
        conn.Open();
      }
      catch
      {
        MessageBox.Show("Server closed!");
        return;
      }*/

      setDataInWarehouses(warehouseQuery("WAREHOUSE1"), warehouse1DGV);
      setDataInWarehouses(warehouseQuery("WAREHOUSE2"), warehouse2DGV);
      setDataIntoWarehouseComboboxes();
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
    }

    private void setDataInWarehouses(string warehouseQuery, DataGridView dgv)
    {
      setData(warehouseQuery, dgv);
      dgv.Columns[0].Visible = false;
    }

    private void setDataIntoWarehouseComboboxes()
    {
      OracleCommand cmd = new OracleCommand("SELECT ID, NAME, PRIORITY FROM GOODS", conn);
      OracleDataReader dr = cmd.ExecuteReader();

      while(dr.Read())
      {
        warehouseGoodCB.Items.Add(new Model.Good(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2)));
      }

      typeOfWarehouseCB.Items.Add("First warehouse");
      typeOfWarehouseCB.Items.Add("Second warehouse");
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

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      //TEST CODE

      switch ((sender as TabControl).SelectedIndex)
      {
        case 0:
          //MessageBox.Show("TEST1");
          break;

        case 1:
          setData(goodQuery(), goodDGV);
          //MessageBox.Show("TEST2");
          break;

        case 2:
          setData(saleQuery(), salesDGV);
          break;
      }
    }

    private void insertIntoWarehouse(string warehouse)
    {
      string query =
        $"INSERT INTO {warehouse}(GOOD_ID, GOOD_COUNT) VALUES(:id, :count)";

      OracleCommand command = new OracleCommand(query, conn);
      command.Parameters.Add(new OracleParameter("id", 1));
      command.Parameters.Add(new OracleParameter("count", 99));
      command.ExecuteNonQuery();
    }

    private void warehousesButton_Click(object sender, EventArgs e)
    {
      var goodId = Helpers.GetSelectedId(warehouseGoodCB);
      string typeOfWarehouse = typeOfWarehouseCB.Text;

      try
      {
        int count = int.Parse(warehouseCountCB.Text);
      }
      catch
      {
        MessageBox.Show("Invalid count!");
        return;
      }

      if (typeOfWarehouse == "First warehouse")
      {

      }
      else if (typeOfWarehouse == "Second warehouse")
      {

      }
      else
      {
        MessageBox.Show("Select the warehouse!");
      }
    }

    private string goodQuery()
    {
      return
        "SELECT NAME, PRIORITY " +
        "FROM GOODS";
    }

    private string saleQuery()
    {
      return
        "SELECT GOODS.NAME, SALES.GOOD_COUNT, SALES.CREATE_DATE " +
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
      MessageBox.Show("The good was successfully added!");
    }

    private void addSaleButton_Click(object sender, EventArgs e)
    {



    }
  }
}
