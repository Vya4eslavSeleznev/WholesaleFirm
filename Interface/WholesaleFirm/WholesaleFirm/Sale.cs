﻿using System;
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
      OracleCommand cmd = new OracleCommand("SELECT ID, NAME, PRIORITY FROM GOODS", conn);
      OracleDataReader dr = cmd.ExecuteReader();

      while (dr.Read())
      {
        saleGoodCB.Items.Add(new Model.Good(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2)));
      }
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

      MessageBox.Show("The sale was successfully updated!");
    }
  }
}
