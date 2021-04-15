
namespace WholesaleFirm
{
  partial class Sale
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
      this.saleCountTB = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.saleDTP = new System.Windows.Forms.DateTimePicker();
      this.saleGoodCB = new System.Windows.Forms.ComboBox();
      this.editSaleButton = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // saleCountTB
      // 
      this.saleCountTB.Location = new System.Drawing.Point(123, 94);
      this.saleCountTB.Name = "saleCountTB";
      this.saleCountTB.Size = new System.Drawing.Size(238, 22);
      this.saleCountTB.TabIndex = 25;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(55, 97);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(49, 17);
      this.label8.TabIndex = 24;
      this.label8.Text = "Count:";
      // 
      // saleDTP
      // 
      this.saleDTP.Location = new System.Drawing.Point(123, 57);
      this.saleDTP.Name = "saleDTP";
      this.saleDTP.Size = new System.Drawing.Size(238, 22);
      this.saleDTP.TabIndex = 23;
      // 
      // saleGoodCB
      // 
      this.saleGoodCB.FormattingEnabled = true;
      this.saleGoodCB.Location = new System.Drawing.Point(123, 18);
      this.saleGoodCB.Name = "saleGoodCB";
      this.saleGoodCB.Size = new System.Drawing.Size(238, 24);
      this.saleGoodCB.TabIndex = 22;
      // 
      // editSaleButton
      // 
      this.editSaleButton.Location = new System.Drawing.Point(58, 138);
      this.editSaleButton.Name = "editSaleButton";
      this.editSaleButton.Size = new System.Drawing.Size(303, 26);
      this.editSaleButton.TabIndex = 21;
      this.editSaleButton.Text = "Edit sale";
      this.editSaleButton.UseVisualStyleBackColor = true;
      this.editSaleButton.Click += new System.EventHandler(this.editSaleButton_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(55, 62);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(42, 17);
      this.label6.TabIndex = 20;
      this.label6.Text = "Date:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(55, 21);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(47, 17);
      this.label7.TabIndex = 19;
      this.label7.Text = "Good:";
      // 
      // Sale
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(417, 205);
      this.Controls.Add(this.saleCountTB);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.saleDTP);
      this.Controls.Add(this.saleGoodCB);
      this.Controls.Add(this.editSaleButton);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label7);
      this.Name = "Sale";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Sale";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox saleCountTB;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.DateTimePicker saleDTP;
    private System.Windows.Forms.ComboBox saleGoodCB;
    private System.Windows.Forms.Button editSaleButton;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
  }
}