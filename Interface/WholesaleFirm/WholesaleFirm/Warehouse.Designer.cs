
namespace WholesaleFirm
{
  partial class Warehouse
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
      this.warehouseCountCB = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.warehouseGoodCB = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.warehousesButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // warehouseCountCB
      // 
      this.warehouseCountCB.Location = new System.Drawing.Point(189, 87);
      this.warehouseCountCB.Name = "warehouseCountCB";
      this.warehouseCountCB.Size = new System.Drawing.Size(127, 22);
      this.warehouseCountCB.TabIndex = 14;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(75, 90);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 17);
      this.label4.TabIndex = 13;
      this.label4.Text = "Count:";
      // 
      // warehouseGoodCB
      // 
      this.warehouseGoodCB.FormattingEnabled = true;
      this.warehouseGoodCB.Location = new System.Drawing.Point(189, 38);
      this.warehouseGoodCB.Name = "warehouseGoodCB";
      this.warehouseGoodCB.Size = new System.Drawing.Size(127, 24);
      this.warehouseGoodCB.TabIndex = 12;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(77, 41);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 17);
      this.label3.TabIndex = 11;
      this.label3.Text = "Good:";
      // 
      // warehousesButton
      // 
      this.warehousesButton.Location = new System.Drawing.Point(78, 134);
      this.warehousesButton.Name = "warehousesButton";
      this.warehousesButton.Size = new System.Drawing.Size(238, 26);
      this.warehousesButton.TabIndex = 10;
      this.warehousesButton.Text = "Edit";
      this.warehousesButton.UseVisualStyleBackColor = true;
      this.warehousesButton.Click += new System.EventHandler(this.warehousesButton_Click);
      // 
      // Warehouse
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(417, 205);
      this.Controls.Add(this.warehouseCountCB);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.warehouseGoodCB);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.warehousesButton);
      this.Name = "Warehouse";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Warehouse";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox warehouseCountCB;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox warehouseGoodCB;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button warehousesButton;
  }
}