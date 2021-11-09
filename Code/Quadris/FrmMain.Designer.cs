# pragma warning disable 1591
using System;

namespace Quadris {
  partial class FrmMain {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panBoard = new System.Windows.Forms.Panel();
            this.tmrFps = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNextPiece = new System.Windows.Forms.Label();
            this.BoardRF = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelscore = new System.Windows.Forms.Label();
            this.labellines = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labellevel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panBoard
            // 
            this.panBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panBoard.Location = new System.Drawing.Point(315, 171);
            this.panBoard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panBoard.Name = "panBoard";
            this.panBoard.Size = new System.Drawing.Size(436, 544);
            this.panBoard.TabIndex = 1;
            // 
            // tmrFps
            // 
            this.tmrFps.Enabled = true;
            this.tmrFps.Interval = 200;
            this.tmrFps.Tick += new System.EventHandler(this.tmrFps_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(54, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 130);
            this.panel1.TabIndex = 2;
            // 
            // lblNextPiece
            // 
            this.lblNextPiece.AutoSize = true;
            this.lblNextPiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextPiece.ForeColor = System.Drawing.Color.White;
            this.lblNextPiece.Location = new System.Drawing.Point(44, 40);
            this.lblNextPiece.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNextPiece.Name = "lblNextPiece";
            this.lblNextPiece.Size = new System.Drawing.Size(175, 33);
            this.lblNextPiece.TabIndex = 3;
            this.lblNextPiece.Text = "Next Piece:";
            // 
            // BoardRF
            // 
            this.BoardRF.Enabled = true;
            this.BoardRF.Interval = 1;
            this.BoardRF.Tick += new System.EventHandler(this.BoardRF_Tick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(798, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "Score:";
            // 
            // labelscore
            // 
            this.labelscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelscore.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelscore.Location = new System.Drawing.Point(906, 171);
            this.labelscore.Name = "labelscore";
            this.labelscore.Size = new System.Drawing.Size(176, 40);
            this.labelscore.TabIndex = 5;
            this.labelscore.Text = "0";
            this.labelscore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labellines
            // 
            this.labellines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellines.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labellines.Location = new System.Drawing.Point(1005, 213);
            this.labellines.Name = "labellines";
            this.labellines.Size = new System.Drawing.Size(77, 40);
            this.labellines.TabIndex = 7;
            this.labellines.Text = "0";
            this.labellines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(798, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lines Cleared:";
            // 
            // labellevel
            // 
            this.labellevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellevel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labellevel.Location = new System.Drawing.Point(906, 253);
            this.labellevel.Name = "labellevel";
            this.labellevel.Size = new System.Drawing.Size(176, 40);
            this.labellevel.TabIndex = 9;
            this.labellevel.Text = "0";
            this.labellevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(798, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 40);
            this.label6.TabIndex = 8;
            this.label6.Text = "Level:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1155, 1050);
            this.Controls.Add(this.labellevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labellines);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelscore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNextPiece);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panBoard);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quadris!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

    }



        #endregion
        private System.Windows.Forms.Panel panBoard;
    private System.Windows.Forms.Timer tmrFps;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblNextPiece;
        private System.Windows.Forms.Timer BoardRF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelscore;
        private System.Windows.Forms.Label labellines;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labellevel;
        private System.Windows.Forms.Label label6;
    }
}

