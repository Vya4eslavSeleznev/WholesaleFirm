
namespace WholesaleFirm
{
  partial class Authentication
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.loginTextBox = new System.Windows.Forms.TextBox();
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.logInButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(131, 77);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Login:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(131, 135);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(73, 17);
      this.label2.TabIndex = 1;
      this.label2.Text = "Password:";
      // 
      // loginTextBox
      // 
      this.loginTextBox.Location = new System.Drawing.Point(249, 74);
      this.loginTextBox.Name = "loginTextBox";
      this.loginTextBox.Size = new System.Drawing.Size(211, 22);
      this.loginTextBox.TabIndex = 2;
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Location = new System.Drawing.Point(249, 132);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(211, 22);
      this.passwordTextBox.TabIndex = 5;
      this.passwordTextBox.UseSystemPasswordChar = true;
      // 
      // logInButton
      // 
      this.logInButton.Location = new System.Drawing.Point(134, 200);
      this.logInButton.Name = "logInButton";
      this.logInButton.Size = new System.Drawing.Size(326, 31);
      this.logInButton.TabIndex = 6;
      this.logInButton.Text = "Log in";
      this.logInButton.UseVisualStyleBackColor = true;
      this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
      // 
      // Authentication
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(605, 321);
      this.Controls.Add(this.logInButton);
      this.Controls.Add(this.passwordTextBox);
      this.Controls.Add(this.loginTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "Authentication";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Authentication";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox loginTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Button logInButton;
  }
}

