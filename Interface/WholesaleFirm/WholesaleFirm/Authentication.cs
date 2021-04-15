using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WholesaleFirm.Utils;
using WholesaleFirm.Exceptions;
using Oracle.ManagedDataAccess.Client;

namespace WholesaleFirm
{
  public partial class Authentication : Form
  {
    private OracleConnection conn;

    public Authentication()
    {
      this.conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
      "(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=c##test;Password=MyPass");

      InitializeComponent();
    }

    private PasswordSaltPair GetOldPasswordSaltPair(string login)
    {
      var query = "SELECT PASSWORD, SALT FROM AUTHENTICATION WHERE LOGIN = :lg";

      using (var cmd = new OracleCommand(query, conn))
      {
        cmd.Parameters.Add(new OracleParameter("lg", login));

        using (var reader = cmd.ExecuteReader())
        {
          if (reader.Read())
            return new PasswordSaltPair(reader.GetString(0), reader.GetString(1));
        }
      }

      throw new InvalidCredentialsException();
    }

    private void logInButton_Click(object sender, EventArgs e)
    {
      var login = loginTextBox.Text;
      var password = passwordTextBox.Text;

      if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
      {
        MessageBox.Show("Values are required!", "Authentication", MessageBoxButtons.OK);
        return;
      }

      try
      {
        var passwordSaltPair = GetOldPasswordSaltPair(login);
        var credentialsManager = new CredentialsManager();

        if (!credentialsManager.VerifyHashedPassword(passwordSaltPair, password))
          throw new InvalidCredentialsException();

          var manager = new ManagerForm(this);
          manager.Show();
          Visible = false;
      }
      catch (InvalidCredentialsException ex)
      {
        MessageBox.Show(ex.Message, "Authentication", MessageBoxButtons.OK);
        return;
      }
      catch
      {
        MessageBox.Show("Incorrect parameters!", "Authentication", MessageBoxButtons.OK);
      }
    }
  }
}
