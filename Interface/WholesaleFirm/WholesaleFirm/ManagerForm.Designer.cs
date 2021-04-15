
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
      this.deleteWarehouse2Button = new System.Windows.Forms.Button();
      this.deleteWarehouse1Button = new System.Windows.Forms.Button();
      this.typeOfWarehouseCB = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.warehouseCountTextBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.warehouseGoodCB = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.warehouse2DGV = new System.Windows.Forms.DataGridView();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.warehouse1DGV = new System.Windows.Forms.DataGridView();
      this.warehousesButton = new System.Windows.Forms.Button();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.deleteGoodsButton = new System.Windows.Forms.Button();
      this.goodPriorityNUD = new System.Windows.Forms.NumericUpDown();
      this.forecastButton = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.goodDGV = new System.Windows.Forms.DataGridView();
      this.addGoodButton = new System.Windows.Forms.Button();
      this.goodNameTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.deleteSalesButton = new System.Windows.Forms.Button();
      this.saleCountTB = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.saleDTP = new System.Windows.Forms.DateTimePicker();
      this.saleGoodCB = new System.Windows.Forms.ComboBox();
      this.addSaleButton = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.salesDGV = new System.Windows.Forms.DataGridView();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.top5goodsDGV = new System.Windows.Forms.DataGridView();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.warehouse2DGV)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.warehouse1DGV)).BeginInit();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.goodPriorityNUD)).BeginInit();
      this.groupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.goodDGV)).BeginInit();
      this.tabPage3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.salesDGV)).BeginInit();
      this.tabPage4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.top5goodsDGV)).BeginInit();
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
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.deleteWarehouse2Button);
      this.tabPage1.Controls.Add(this.deleteWarehouse1Button);
      this.tabPage1.Controls.Add(this.typeOfWarehouseCB);
      this.tabPage1.Controls.Add(this.label5);
      this.tabPage1.Controls.Add(this.warehouseCountTextBox);
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
      // deleteWarehouse2Button
      // 
      this.deleteWarehouse2Button.Location = new System.Drawing.Point(473, 495);
      this.deleteWarehouse2Button.Name = "deleteWarehouse2Button";
      this.deleteWarehouse2Button.Size = new System.Drawing.Size(400, 37);
      this.deleteWarehouse2Button.TabIndex = 11;
      this.deleteWarehouse2Button.Text = "Delete selected from warehouse 2";
      this.deleteWarehouse2Button.UseVisualStyleBackColor = true;
      this.deleteWarehouse2Button.Click += new System.EventHandler(this.deleteWarehouse2Button_Click);
      // 
      // deleteWarehouse1Button
      // 
      this.deleteWarehouse1Button.Location = new System.Drawing.Point(37, 495);
      this.deleteWarehouse1Button.Name = "deleteWarehouse1Button";
      this.deleteWarehouse1Button.Size = new System.Drawing.Size(400, 37);
      this.deleteWarehouse1Button.TabIndex = 10;
      this.deleteWarehouse1Button.Text = "Delete selected from warehouse 1";
      this.deleteWarehouse1Button.UseVisualStyleBackColor = true;
      this.deleteWarehouse1Button.Click += new System.EventHandler(this.deleteWarehouse1Button_Click);
      // 
      // typeOfWarehouseCB
      // 
      this.typeOfWarehouseCB.FormattingEnabled = true;
      this.typeOfWarehouseCB.Location = new System.Drawing.Point(188, 41);
      this.typeOfWarehouseCB.Name = "typeOfWarehouseCB";
      this.typeOfWarehouseCB.Size = new System.Drawing.Size(249, 24);
      this.typeOfWarehouseCB.TabIndex = 9;
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
      // warehouseCountTextBox
      // 
      this.warehouseCountTextBox.Location = new System.Drawing.Point(582, 6);
      this.warehouseCountTextBox.Name = "warehouseCountTextBox";
      this.warehouseCountTextBox.Size = new System.Drawing.Size(291, 22);
      this.warehouseCountTextBox.TabIndex = 7;
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
      // warehouseGoodCB
      // 
      this.warehouseGoodCB.FormattingEnabled = true;
      this.warehouseGoodCB.Location = new System.Drawing.Point(146, 6);
      this.warehouseGoodCB.Name = "warehouseGoodCB";
      this.warehouseGoodCB.Size = new System.Drawing.Size(291, 24);
      this.warehouseGoodCB.TabIndex = 5;
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
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.warehouse2DGV);
      this.groupBox2.Location = new System.Drawing.Point(467, 71);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(416, 418);
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
      this.warehouse2DGV.Size = new System.Drawing.Size(400, 390);
      this.warehouse2DGV.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.warehouse1DGV);
      this.groupBox1.Location = new System.Drawing.Point(31, 71);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(415, 418);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Warehouse 1:";
      // 
      // warehouse1DGV
      // 
      this.warehouse1DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.warehouse1DGV.Location = new System.Drawing.Point(6, 21);
      this.warehouse1DGV.Name = "warehouse1DGV";
      this.warehouse1DGV.RowHeadersWidth = 51;
      this.warehouse1DGV.RowTemplate.Height = 24;
      this.warehouse1DGV.Size = new System.Drawing.Size(400, 390);
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
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.deleteGoodsButton);
      this.tabPage2.Controls.Add(this.goodPriorityNUD);
      this.tabPage2.Controls.Add(this.forecastButton);
      this.tabPage2.Controls.Add(this.groupBox3);
      this.tabPage2.Controls.Add(this.addGoodButton);
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
      // deleteGoodsButton
      // 
      this.deleteGoodsButton.Location = new System.Drawing.Point(132, 502);
      this.deleteGoodsButton.Name = "deleteGoodsButton";
      this.deleteGoodsButton.Size = new System.Drawing.Size(676, 34);
      this.deleteGoodsButton.TabIndex = 10;
      this.deleteGoodsButton.Text = "Delete selected";
      this.deleteGoodsButton.UseVisualStyleBackColor = true;
      this.deleteGoodsButton.Click += new System.EventHandler(this.deleteGoodsButton_Click);
      // 
      // goodPriorityNUD
      // 
      this.goodPriorityNUD.Location = new System.Drawing.Point(134, 49);
      this.goodPriorityNUD.Name = "goodPriorityNUD";
      this.goodPriorityNUD.Size = new System.Drawing.Size(368, 22);
      this.goodPriorityNUD.TabIndex = 9;
      // 
      // forecastButton
      // 
      this.forecastButton.Location = new System.Drawing.Point(602, 45);
      this.forecastButton.Name = "forecastButton";
      this.forecastButton.Size = new System.Drawing.Size(277, 34);
      this.forecastButton.TabIndex = 7;
      this.forecastButton.Text = "Forecast demand";
      this.forecastButton.UseVisualStyleBackColor = true;
      this.forecastButton.Click += new System.EventHandler(this.forecastButton_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.goodDGV);
      this.groupBox3.Location = new System.Drawing.Point(39, 81);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(840, 415);
      this.groupBox3.TabIndex = 6;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Goods";
      // 
      // goodDGV
      // 
      this.goodDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.goodDGV.Location = new System.Drawing.Point(93, 21);
      this.goodDGV.Name = "goodDGV";
      this.goodDGV.RowHeadersWidth = 51;
      this.goodDGV.RowTemplate.Height = 24;
      this.goodDGV.Size = new System.Drawing.Size(676, 380);
      this.goodDGV.TabIndex = 0;
      this.goodDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.goodDGV_CellContentClick);
      // 
      // addGoodButton
      // 
      this.addGoodButton.Location = new System.Drawing.Point(602, 7);
      this.addGoodButton.Name = "addGoodButton";
      this.addGoodButton.Size = new System.Drawing.Size(277, 34);
      this.addGoodButton.TabIndex = 5;
      this.addGoodButton.Text = "Add good";
      this.addGoodButton.UseVisualStyleBackColor = true;
      this.addGoodButton.Click += new System.EventHandler(this.addGoodButton_Click);
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
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.deleteSalesButton);
      this.tabPage3.Controls.Add(this.saleCountTB);
      this.tabPage3.Controls.Add(this.label8);
      this.tabPage3.Controls.Add(this.saleDTP);
      this.tabPage3.Controls.Add(this.saleGoodCB);
      this.tabPage3.Controls.Add(this.addSaleButton);
      this.tabPage3.Controls.Add(this.label6);
      this.tabPage3.Controls.Add(this.label7);
      this.tabPage3.Controls.Add(this.groupBox4);
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(923, 542);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Sales";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // deleteSalesButton
      // 
      this.deleteSalesButton.Location = new System.Drawing.Point(130, 500);
      this.deleteSalesButton.Name = "deleteSalesButton";
      this.deleteSalesButton.Size = new System.Drawing.Size(676, 32);
      this.deleteSalesButton.TabIndex = 19;
      this.deleteSalesButton.Text = "Delete selected";
      this.deleteSalesButton.UseVisualStyleBackColor = true;
      this.deleteSalesButton.Click += new System.EventHandler(this.deleteSalesButton_Click);
      // 
      // saleCountTB
      // 
      this.saleCountTB.Location = new System.Drawing.Point(578, 10);
      this.saleCountTB.Name = "saleCountTB";
      this.saleCountTB.Size = new System.Drawing.Size(299, 22);
      this.saleCountTB.TabIndex = 18;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(480, 17);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(49, 17);
      this.label8.TabIndex = 17;
      this.label8.Text = "Count:";
      // 
      // saleDTP
      // 
      this.saleDTP.Location = new System.Drawing.Point(130, 44);
      this.saleDTP.Name = "saleDTP";
      this.saleDTP.Size = new System.Drawing.Size(300, 22);
      this.saleDTP.TabIndex = 16;
      // 
      // saleGoodCB
      // 
      this.saleGoodCB.FormattingEnabled = true;
      this.saleGoodCB.Location = new System.Drawing.Point(130, 10);
      this.saleGoodCB.Name = "saleGoodCB";
      this.saleGoodCB.Size = new System.Drawing.Size(300, 24);
      this.saleGoodCB.TabIndex = 15;
      // 
      // addSaleButton
      // 
      this.addSaleButton.Location = new System.Drawing.Point(483, 40);
      this.addSaleButton.Name = "addSaleButton";
      this.addSaleButton.Size = new System.Drawing.Size(394, 26);
      this.addSaleButton.TabIndex = 14;
      this.addSaleButton.Text = "Add sale";
      this.addSaleButton.UseVisualStyleBackColor = true;
      this.addSaleButton.Click += new System.EventHandler(this.addSaleButton_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(34, 49);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(42, 17);
      this.label6.TabIndex = 11;
      this.label6.Text = "Date:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(34, 17);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(47, 17);
      this.label7.TabIndex = 10;
      this.label7.Text = "Good:";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.salesDGV);
      this.groupBox4.Location = new System.Drawing.Point(37, 84);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(840, 410);
      this.groupBox4.TabIndex = 7;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Sales";
      // 
      // salesDGV
      // 
      this.salesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.salesDGV.Location = new System.Drawing.Point(93, 21);
      this.salesDGV.Name = "salesDGV";
      this.salesDGV.RowHeadersWidth = 51;
      this.salesDGV.RowTemplate.Height = 24;
      this.salesDGV.Size = new System.Drawing.Size(676, 375);
      this.salesDGV.TabIndex = 0;
      this.salesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.salesDGV_CellContentClick);
      // 
      // tabPage4
      // 
      this.tabPage4.Controls.Add(this.groupBox6);
      this.tabPage4.Controls.Add(this.groupBox5);
      this.tabPage4.Location = new System.Drawing.Point(4, 25);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new System.Drawing.Size(923, 542);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "Statistic";
      this.tabPage4.UseVisualStyleBackColor = true;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.top5goodsDGV);
      this.groupBox5.Location = new System.Drawing.Point(4, 2);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(461, 539);
      this.groupBox5.TabIndex = 0;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Top 5 goods";
      // 
      // groupBox6
      // 
      this.groupBox6.Location = new System.Drawing.Point(471, 0);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(449, 539);
      this.groupBox6.TabIndex = 1;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "groupBox6";
      // 
      // top5goodsDGV
      // 
      this.top5goodsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.top5goodsDGV.Location = new System.Drawing.Point(6, 21);
      this.top5goodsDGV.Name = "top5goodsDGV";
      this.top5goodsDGV.RowHeadersWidth = 51;
      this.top5goodsDGV.RowTemplate.Height = 24;
      this.top5goodsDGV.Size = new System.Drawing.Size(449, 509);
      this.top5goodsDGV.TabIndex = 0;
      // 
      // ManagerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(930, 569);
      this.Controls.Add(this.tabControl1);
      this.Name = "ManagerForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Manager";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManagerForm_FormClosing);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.warehouse2DGV)).EndInit();
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.warehouse1DGV)).EndInit();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.goodPriorityNUD)).EndInit();
      this.groupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.goodDGV)).EndInit();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.salesDGV)).EndInit();
      this.tabPage4.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.top5goodsDGV)).EndInit();
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
    private System.Windows.Forms.TextBox warehouseCountTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox warehouseGoodCB;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button forecastButton;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.NumericUpDown goodPriorityNUD;
    private System.Windows.Forms.TextBox saleCountTB;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.DateTimePicker saleDTP;
    private System.Windows.Forms.ComboBox saleGoodCB;
    private System.Windows.Forms.Button addSaleButton;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.DataGridView salesDGV;
    private System.Windows.Forms.Button deleteSalesButton;
    private System.Windows.Forms.Button deleteGoodsButton;
    private System.Windows.Forms.Button deleteWarehouse2Button;
    private System.Windows.Forms.Button deleteWarehouse1Button;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.DataGridView top5goodsDGV;
  }
}