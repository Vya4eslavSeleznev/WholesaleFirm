
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
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.goodDGV = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.nameTextBox = new System.Windows.Forms.TextBox();
      this.priorityTextBox = new System.Windows.Forms.TextBox();
      this.addGoodButton = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.goodDGV)).BeginInit();
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
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(923, 542);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Demand";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.addGoodButton);
      this.tabPage2.Controls.Add(this.priorityTextBox);
      this.tabPage2.Controls.Add(this.nameTextBox);
      this.tabPage2.Controls.Add(this.label2);
      this.tabPage2.Controls.Add(this.label1);
      this.tabPage2.Controls.Add(this.goodDGV);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(923, 542);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Goods";
      this.tabPage2.UseVisualStyleBackColor = true;
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
      // goodDGV
      // 
      this.goodDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.goodDGV.Location = new System.Drawing.Point(2, 70);
      this.goodDGV.Name = "goodDGV";
      this.goodDGV.RowHeadersWidth = 51;
      this.goodDGV.RowTemplate.Height = 24;
      this.goodDGV.Size = new System.Drawing.Size(920, 471);
      this.goodDGV.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 31);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Name:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(351, 31);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "Priority:";
      // 
      // nameTextBox
      // 
      this.nameTextBox.Location = new System.Drawing.Point(101, 28);
      this.nameTextBox.Name = "nameTextBox";
      this.nameTextBox.Size = new System.Drawing.Size(217, 22);
      this.nameTextBox.TabIndex = 3;
      // 
      // priorityTextBox
      // 
      this.priorityTextBox.Location = new System.Drawing.Point(435, 28);
      this.priorityTextBox.Name = "priorityTextBox";
      this.priorityTextBox.Size = new System.Drawing.Size(217, 22);
      this.priorityTextBox.TabIndex = 4;
      // 
      // addGoodButton
      // 
      this.addGoodButton.Location = new System.Drawing.Point(704, 22);
      this.addGoodButton.Name = "addGoodButton";
      this.addGoodButton.Size = new System.Drawing.Size(210, 34);
      this.addGoodButton.TabIndex = 5;
      this.addGoodButton.Text = "Add good";
      this.addGoodButton.UseVisualStyleBackColor = true;
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
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.goodDGV)).EndInit();
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
    private System.Windows.Forms.TextBox priorityTextBox;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}