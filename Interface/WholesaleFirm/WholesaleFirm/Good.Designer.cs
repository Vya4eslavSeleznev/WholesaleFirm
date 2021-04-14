
namespace WholesaleFirm
{
  partial class Good
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
      this.goodPriorityNUD = new System.Windows.Forms.NumericUpDown();
      this.editGoodButton = new System.Windows.Forms.Button();
      this.goodNameTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.goodPriorityNUD)).BeginInit();
      this.SuspendLayout();
      // 
      // goodPriorityNUD
      // 
      this.goodPriorityNUD.Location = new System.Drawing.Point(182, 75);
      this.goodPriorityNUD.Name = "goodPriorityNUD";
      this.goodPriorityNUD.Size = new System.Drawing.Size(152, 22);
      this.goodPriorityNUD.TabIndex = 15;
      // 
      // editGoodButton
      // 
      this.editGoodButton.Location = new System.Drawing.Point(87, 119);
      this.editGoodButton.Name = "editGoodButton";
      this.editGoodButton.Size = new System.Drawing.Size(247, 28);
      this.editGoodButton.TabIndex = 13;
      this.editGoodButton.Text = "Edit good";
      this.editGoodButton.UseVisualStyleBackColor = true;
      this.editGoodButton.Click += new System.EventHandler(this.editGoodButton_Click);
      // 
      // goodNameTextBox
      // 
      this.goodNameTextBox.Location = new System.Drawing.Point(182, 45);
      this.goodNameTextBox.Name = "goodNameTextBox";
      this.goodNameTextBox.Size = new System.Drawing.Size(152, 22);
      this.goodNameTextBox.TabIndex = 12;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(84, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 17);
      this.label2.TabIndex = 11;
      this.label2.Text = "Priority:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(84, 48);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 17);
      this.label1.TabIndex = 10;
      this.label1.Text = "Name:";
      // 
      // Good
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(417, 205);
      this.Controls.Add(this.goodPriorityNUD);
      this.Controls.Add(this.editGoodButton);
      this.Controls.Add(this.goodNameTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "Good";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Good";
      ((System.ComponentModel.ISupportInitialize)(this.goodPriorityNUD)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NumericUpDown goodPriorityNUD;
    private System.Windows.Forms.Button editGoodButton;
    private System.Windows.Forms.TextBox goodNameTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}