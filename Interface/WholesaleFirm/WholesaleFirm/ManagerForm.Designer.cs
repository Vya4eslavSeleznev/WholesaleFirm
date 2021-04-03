
namespace WholesaleFirm
{
  partial class ManagerForm
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.addGoodButton = new System.Windows.Forms.Button();
      this.goodPriorityTextBox = new System.Windows.Forms.TextBox();
      this.goodNameTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.goodDGV = new System.Windows.Forms.DataGridView();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.warehouse1DGV = new System.Windows.Forms.DataGridView();
      this.warehousesButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.warehouse2DGV = new System.Windows.Forms.DataGridView();
      this.label3 = new System.Windows.Forms.Label();
      this.warehouseGoodCB = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.warehouseCountCB = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.typeOfWarehouseCB = new System.Windows.Forms.ComboBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.forecastButton = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.goodDGV)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.warehouse1DGV)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.warehouse2DGV)).BeginInit();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Controls.Add(this.tabPage4);
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(931, 571);
      this.tabControl1.TabIndex = 0;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.typeOfWarehouseCB);
      this.tabPage1.Controls.Add(this.label5);
      this.tabPage1.Controls.Add(this.warehouseCountCB);
      this.tabPage1.Controls.Add(this.label4);
      this.tabPage1.Controls.Add(this.warehouseGoodCB);
      this.tabPage1.Controls.Add(this.label3);
      this.tabPage1.Controls.Add(this.groupBox2);
      this.tabPage1.Controls.Add(this.groupBox1);
      this.tabPage1.Controls.Add(this.warehousesButton);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(923, 542);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Warehouses";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.forecastButton);
      this.tabPage2.Controls.Add(this.groupBox3);
      this.tabPage2.Controls.Add(this.addGoodButton);
      this.tabPage2.Controls.Add(this.goodPriorityTextBox);
      this.tabPage2.Controls.Add(this.goodNameTextBox);
      this.tabPage2.Controls.Add(this.label2);
      this.tabPage2.Controls.Add(this.label1);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(923, 542);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Goods";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // addGoodButton
      // 
      this.addGoodButton.Location = new System.Drawing.Point(602, 7);
      this.addGoodButton.Name = "addGoodButton";
      this.addGoodButton.Size = new System.Drawing.Size(277, 34);
      this.addGoodButton.TabIndex = 5;
      this.addGoodButton.Text = "Add good";
      this.addGoodButton.UseVisualStyleBackColor = true;
      // 
      // goodPriorityTextBox
      // 
      this.goodPriorityTextBox.Location = new System.Drawing.Point(134, 49);
      this.goodPriorityTextBox.Name = "goodPriorityTextBox";
      this.goodPriorityTextBox.Size = new System.Drawing.Size(368, 22);
      this.goodPriorityTextBox.TabIndex = 4;
      // 
      // goodNameTextBox
      // 
      this.goodNameTextBox.Location = new System.Drawing.Point(134, 19);
      this.goodNameTextBox.Name = "goodNameTextBox";
      this.goodNameTextBox.Size = new System.Drawing.Size(368, 22);
      this.goodNameTextBox.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(36, 54);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "Priority:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(36, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Name:";
      // 
      // goodDGV
      // 
      this.goodDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.goodDGV.Location = new System.Drawing.Point(93, 21);
      this.goodDGV.Name = "goodDGV";
      this.goodDGV.RowHeadersWidth = 51;
      this.goodDGV.RowTemplate.Height = 24;
      this.goodDGV.Size = new System.Drawing.Size(676, 404);
      this.goodDGV.TabIndex = 0;
      // 
      // tabPage3
      // 
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(923, 542);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Sales";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // tabPage4
      // 
      this.tabPage4.Location = new System.Drawing.Point(4, 25);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new System.Drawing.Size(923, 542);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "Statistic";
      this.tabPage4.UseVisualStyleBackColor = true;
      // 
      // warehouse1DGV
      // 
      this.warehouse1DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.warehouse1DGV.Location = new System.Drawing.Point(6, 21);
      this.warehouse1DGV.Name = "warehouse1DGV";
      this.warehouse1DGV.RowHeadersWidth = 51;
      this.warehouse1DGV.RowTemplate.Height = 24;
      this.warehouse1DGV.Size = new System.Drawing.Size(400, 420);
      this.warehouse1DGV.TabIndex = 0;
      // 
      // warehousesButton
      // 
      this.warehousesButton.Location = new System.Drawing.Point(473, 39);
      this.warehousesButton.Name = "warehousesButton";
      this.warehousesButton.Size = new System.Drawing.Size(400, 26);
      this.warehousesButton.TabIndex = 1;
      this.warehousesButton.Text = "Deliver to the warehouse";
      this.warehousesButton.UseVisualStyleBackColor = true;
      this.warehousesButton.Click += new System.EventHandler(this.warehousesButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.warehouse1DGV);
      this.groupBox1.Location = new System.Drawing.Point(31, 71);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(415, 447);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Warehouse 1:";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.warehouse2DGV);
      this.groupBox2.Location = new System.Drawing.Point(467, 71);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(416, 447);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Warehouse 2:";
      // 
      // warehouse2DGV
      // 
      this.warehouse2DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.warehouse2DGV.Location = new System.Drawing.Point(6, 21);
      this.warehouse2DGV.Name = "warehouse2DGV";
      this.warehouse2DGV.RowHeadersWidth = 51;
      this.warehouse2DGV.RowTemplate.Height = 24;
      this.warehouse2DGV.Size = new System.Drawing.Size(400, 420);
      this.warehouse2DGV.TabIndex = 0;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(34, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 17);
      this.label3.TabIndex = 4;
      this.label3.Text = "Good:";
      // 
      // warehouseGoodCB
      // 
      this.warehouseGoodCB.FormattingEnabled = true;
      this.warehouseGoodCB.Location = new System.Drawing.Point(146, 6);
      this.warehouseGoodCB.Name = "warehouseGoodCB";
      this.warehouseGoodCB.Size = new System.Drawing.Size(291, 24);
      this.warehouseGoodCB.TabIndex = 5;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(470, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 17);
      this.label4.TabIndex = 6;
      this.label4.Text = "Count:";
      // 
      // warehouseCountCB
      // 
      this.warehouseCountCB.Location = new System.Drawing.Point(582, 6);
      this.warehouseCountCB.Name = "warehouseCountCB";
      this.warehouseCountCB.Size = new System.Drawing.Size(291, 22);
      this.warehouseCountCB.TabIndex = 7;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(34, 44);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(148, 17);
      this.label5.TabIndex = 8;
      this.label5.Text = "Select the warehouse:";
      // 
      // typeOfWarehouseCB
      // 
      this.typeOfWarehouseCB.FormattingEnabled = true;
      this.typeOfWarehouseCB.Location = new System.Drawing.Point(188, 41);
      this.typeOfWarehouseCB.Name = "typeOfWarehouseCB";
      this.typeOfWarehouseCB.Size = new System.Drawing.Size(249, 24);
      this.typeOfWarehouseCB.TabIndex = 9;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.goodDGV);
      this.groupBox3.Location = new System.Drawing.Point(33, 81);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(852, 431);
      this.groupBox3.TabIndex = 6;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Goods";
      // 
      // forecastButton
      // 
      this.forecastButton.Location = new System.Drawing.Point(602, 45);
      this.forecastButton.Name = "forecastButton";
      this.forecastButton.Size = new System.Drawing.Size(277, 34);
      this.forecastButton.TabIndex = 7;
      this.forecastButton.Text = "Forecast demand";
      this.forecastButton.UseVisualStyleBackColor = true;
      // 
      // ManagerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(930, 569);
      this.Controls.Add(this.tabControl1);
      this.Name = "ManagerForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ManagerForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManagerForm_FormClosing);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.goodDGV)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.warehouse1DGV)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.warehouse2DGV)).EndInit();
      this.groupBox3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.DataGridView goodDGV;
    private System.Windows.Forms.Button addGoodButton;
    private System.Windows.Forms.TextBox goodPriorityTextBox;
    private System.Windows.Forms.TextBox goodNameTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView warehouse1DGV;
    private System.Windows.Forms.Button warehousesButton;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DataGridView warehouse2DGV;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox typeOfWarehouseCB;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox warehouseCountCB;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox warehouseGoodCB;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button forecastButton;
    private System.Windows.Forms.GroupBox groupBox3;
  }
}