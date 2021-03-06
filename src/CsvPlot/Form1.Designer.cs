﻿namespace CsvPlot
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.cbFirstColX = new System.Windows.Forms.CheckBox();
            this.cbSignal = new System.Windows.Forms.CheckBox();
            this.nudColumn = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAllColumns = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.formsPlot1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot1.Location = new System.Drawing.Point(12, 39);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(776, 399);
            this.formsPlot1.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(162, 10);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "select";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(12, 12);
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(144, 20);
            this.tbFile.TabIndex = 2;
            // 
            // cbFirstColX
            // 
            this.cbFirstColX.AutoSize = true;
            this.cbFirstColX.Location = new System.Drawing.Point(243, 14);
            this.cbFirstColX.Name = "cbFirstColX";
            this.cbFirstColX.Size = new System.Drawing.Size(89, 17);
            this.cbFirstColX.TabIndex = 4;
            this.cbFirstColX.Text = "first column X";
            this.cbFirstColX.UseVisualStyleBackColor = true;
            this.cbFirstColX.CheckedChanged += new System.EventHandler(this.cbFirstColX_CheckedChanged);
            // 
            // cbSignal
            // 
            this.cbSignal.AutoSize = true;
            this.cbSignal.Checked = true;
            this.cbSignal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSignal.Location = new System.Drawing.Point(338, 14);
            this.cbSignal.Name = "cbSignal";
            this.cbSignal.Size = new System.Drawing.Size(110, 17);
            this.cbSignal.TabIndex = 5;
            this.cbSignal.Text = "evenly spaced Xs";
            this.cbSignal.UseVisualStyleBackColor = true;
            // 
            // nudColumn
            // 
            this.nudColumn.Location = new System.Drawing.Point(524, 12);
            this.nudColumn.Name = "nudColumn";
            this.nudColumn.Size = new System.Drawing.Size(57, 20);
            this.nudColumn.TabIndex = 6;
            this.nudColumn.ValueChanged += new System.EventHandler(this.nudColumn_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Column:";
            // 
            // cbAllColumns
            // 
            this.cbAllColumns.AutoSize = true;
            this.cbAllColumns.Checked = true;
            this.cbAllColumns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllColumns.Location = new System.Drawing.Point(587, 13);
            this.cbAllColumns.Name = "cbAllColumns";
            this.cbAllColumns.Size = new System.Drawing.Size(36, 17);
            this.cbAllColumns.TabIndex = 8;
            this.cbAllColumns.Text = "all";
            this.cbAllColumns.UseVisualStyleBackColor = true;
            this.cbAllColumns.CheckedChanged += new System.EventHandler(this.cbAllColumns_CheckedChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbAllColumns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudColumn);
            this.Controls.Add(this.cbSignal);
            this.Controls.Add(this.cbFirstColX);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.formsPlot1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CsvPlot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.nudColumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.CheckBox cbFirstColX;
        private System.Windows.Forms.CheckBox cbSignal;
        private System.Windows.Forms.NumericUpDown nudColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbAllColumns;
    }
}

