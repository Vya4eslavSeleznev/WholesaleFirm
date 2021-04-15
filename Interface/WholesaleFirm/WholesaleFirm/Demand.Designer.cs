
namespace WholesaleFirm
{
  partial class Demand
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.goodCB = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.chartButton = new System.Windows.Forms.Button();
      this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.date = new System.Windows.Forms.DateTimePicker();
      this.label6 = new System.Windows.Forms.Label();
      this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // goodCB
      // 
      this.goodCB.FormattingEnabled = true;
      this.goodCB.Location = new System.Drawing.Point(113, 16);
      this.goodCB.Name = "goodCB";
      this.goodCB.Size = new System.Drawing.Size(257, 24);
      this.goodCB.TabIndex = 14;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(23, 19);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 17);
      this.label3.TabIndex = 13;
      this.label3.Text = "Good:";
      // 
      // chartButton
      // 
      this.chartButton.Location = new System.Drawing.Point(430, 52);
      this.chartButton.Name = "chartButton";
      this.chartButton.Size = new System.Drawing.Size(340, 31);
      this.chartButton.TabIndex = 15;
      this.chartButton.Text = "Show chart";
      this.chartButton.UseVisualStyleBackColor = true;
      // 
      // chart
      // 
      chartArea1.Name = "ChartArea1";
      this.chart.ChartAreas.Add(chartArea1);
      legend1.Name = "Legend1";
      this.chart.Legends.Add(legend1);
      this.chart.Location = new System.Drawing.Point(18, 21);
      this.chart.Name = "chart";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      this.chart.Series.Add(series1);
      this.chart.Size = new System.Drawing.Size(744, 321);
      this.chart.TabIndex = 16;
      this.chart.Text = "chart1";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.chart);
      this.groupBox1.Location = new System.Drawing.Point(8, 87);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(788, 358);
      this.groupBox1.TabIndex = 17;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Demand chart";
      // 
      // date
      // 
      this.date.Location = new System.Drawing.Point(519, 14);
      this.date.Name = "date";
      this.date.Size = new System.Drawing.Size(251, 22);
      this.date.TabIndex = 19;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(427, 19);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(74, 17);
      this.label6.TabIndex = 18;
      this.label6.Text = "Date from:";
      // 
      // dateTimePicker1
      // 
      this.dateTimePicker1.Location = new System.Drawing.Point(113, 54);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new System.Drawing.Size(257, 22);
      this.dateTimePicker1.TabIndex = 21;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(23, 59);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 17);
      this.label1.TabIndex = 20;
      this.label1.Text = "Date to:";
      // 
      // Demand
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.dateTimePicker1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.date);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.chartButton);
      this.Controls.Add(this.goodCB);
      this.Controls.Add(this.label3);
      this.Name = "Demand";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Demand";
      ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox goodCB;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button chartButton;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DateTimePicker date;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.Label label1;
  }
}