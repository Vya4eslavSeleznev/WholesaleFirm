
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
      ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // goodCB
      // 
      this.goodCB.FormattingEnabled = true;
      this.goodCB.Location = new System.Drawing.Point(198, 16);
      this.goodCB.Name = "goodCB";
      this.goodCB.Size = new System.Drawing.Size(244, 24);
      this.goodCB.TabIndex = 14;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(86, 19);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 17);
      this.label3.TabIndex = 13;
      this.label3.Text = "Good:";
      // 
      // chartButton
      // 
      this.chartButton.Location = new System.Drawing.Point(527, 12);
      this.chartButton.Name = "chartButton";
      this.chartButton.Size = new System.Drawing.Size(183, 31);
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
      this.chart.Location = new System.Drawing.Point(18, 38);
      this.chart.Name = "chart";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      this.chart.Series.Add(series1);
      this.chart.Size = new System.Drawing.Size(736, 340);
      this.chart.TabIndex = 16;
      this.chart.Text = "chart1";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.chart);
      this.groupBox1.Location = new System.Drawing.Point(8, 49);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(788, 396);
      this.groupBox1.TabIndex = 17;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Demand chart";
      // 
      // Demand
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
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
  }
}