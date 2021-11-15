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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panBoard = new System.Windows.Forms.Panel();
            this.tmrFps = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelctrl = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNextPiece = new System.Windows.Forms.Label();
            this.lblHeldPiece = new System.Windows.Forms.Label();
            this.BoardRF = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelscore = new System.Windows.Forms.Label();
            this.labellines = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labellevel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CryoStall_disp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panelctrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBoard
            // 
            this.panBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panBoard.Location = new System.Drawing.Point(280, 137);
            this.panBoard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panBoard.Name = "panBoard";
            this.panBoard.Size = new System.Drawing.Size(388, 436);
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
            this.panel1.Location = new System.Drawing.Point(48, 65);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 105);
            this.panel1.TabIndex = 2;
            // 
            // panelctrl
            // 
            this.panelctrl.BackColor = System.Drawing.Color.Gray;
            this.panelctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelctrl.Controls.Add(this.label13);
            this.panelctrl.Controls.Add(this.label12);
            this.panelctrl.Controls.Add(this.label11);
            this.panelctrl.Controls.Add(this.label10);
            this.panelctrl.Controls.Add(this.label9);
            this.panelctrl.Controls.Add(this.label8);
            this.panelctrl.Controls.Add(this.label7);
            this.panelctrl.Controls.Add(this.label5);
            this.panelctrl.Controls.Add(this.label2);
            this.panelctrl.Location = new System.Drawing.Point(715, 277);
            this.panelctrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelctrl.Name = "panelctrl";
            this.panelctrl.Size = new System.Drawing.Size(194, 247);
            this.panelctrl.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 18);
            this.label12.TabIndex = 4;
            this.label12.Text = "Hard Drop : Up";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 18);
            this.label11.TabIndex = 4;
            this.label11.Text = "Hold Piece : H";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 18);
            this.label10.TabIndex = 5;
            this.label10.Text = "CryoStall : Space";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 18);
            this.label9.TabIndex = 4;
            this.label9.Text = "Rotate Right : X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "Rotate Left : Z";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "Move Right : Right Arrow";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Move Left : Left Arrow";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Controls";
            // 
            // lblNextPiece
            // 
            this.lblNextPiece.AutoSize = true;
            this.lblNextPiece.BackColor = System.Drawing.Color.Transparent;
            this.lblNextPiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextPiece.ForeColor = System.Drawing.Color.Black;
            this.lblNextPiece.Location = new System.Drawing.Point(39, 32);
            this.lblNextPiece.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNextPiece.Name = "lblNextPiece";
            this.lblNextPiece.Size = new System.Drawing.Size(147, 29);
            this.lblNextPiece.TabIndex = 3;
            this.lblNextPiece.Text = "Next Piece:";
            // 
            // lblHeldPiece
            // 
            this.lblHeldPiece.AutoSize = true;
            this.lblHeldPiece.BackColor = System.Drawing.Color.Transparent;
            this.lblHeldPiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeldPiece.ForeColor = System.Drawing.Color.Black;
            this.lblHeldPiece.Location = new System.Drawing.Point(39, 240);
            this.lblHeldPiece.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeldPiece.Name = "lblHeldPiece";
            this.lblHeldPiece.Size = new System.Drawing.Size(149, 29);
            this.lblHeldPiece.TabIndex = 3;
            this.lblHeldPiece.Text = "Held Piece:";
            // 
            // BoardRF
            // 
            this.BoardRF.Enabled = true;
            this.BoardRF.Interval = 1;
            this.BoardRF.Tick += new System.EventHandler(this.BoardRF_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(709, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Score:";
            // 
            // labelscore
            // 
            this.labelscore.BackColor = System.Drawing.Color.Transparent;
            this.labelscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelscore.ForeColor = System.Drawing.Color.Black;
            this.labelscore.Location = new System.Drawing.Point(820, 138);
            this.labelscore.Name = "labelscore";
            this.labelscore.Size = new System.Drawing.Size(151, 32);
            this.labelscore.TabIndex = 5;
            this.labelscore.Text = "0";
            this.labelscore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labellines
            // 
            this.labellines.BackColor = System.Drawing.Color.Transparent;
            this.labellines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellines.ForeColor = System.Drawing.Color.Black;
            this.labellines.Location = new System.Drawing.Point(805, 170);
            this.labellines.Name = "labellines";
            this.labellines.Size = new System.Drawing.Size(68, 32);
            this.labellines.TabIndex = 7;
            this.labellines.Text = "0";
            this.labellines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(709, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lines Cleared:";
            // 
            // labellevel
            // 
            this.labellevel.BackColor = System.Drawing.Color.Transparent;
            this.labellevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellevel.ForeColor = System.Drawing.Color.Black;
            this.labellevel.Location = new System.Drawing.Point(805, 202);
            this.labellevel.Name = "labellevel";
            this.labellevel.Size = new System.Drawing.Size(156, 32);
            this.labellevel.TabIndex = 9;
            this.labellevel.Text = "0";
            this.labellevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(709, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 32);
            this.label6.TabIndex = 8;
            this.label6.Text = "Level:";
            // 
            // CryoStall_disp
            // 
            this.CryoStall_disp.BackColor = System.Drawing.Color.Transparent;
            this.CryoStall_disp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CryoStall_disp.ForeColor = System.Drawing.Color.Black;
            this.CryoStall_disp.Location = new System.Drawing.Point(844, 234);
            this.CryoStall_disp.Name = "CryoStall_disp";
            this.CryoStall_disp.Size = new System.Drawing.Size(49, 32);
            this.CryoStall_disp.TabIndex = 11;
            this.CryoStall_disp.Text = "0";
            this.CryoStall_disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(709, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "CryoStall:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(48, 273);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 105);
            this.panel2.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 18);
            this.label13.TabIndex = 6;
            this.label13.Text = "Soft Drop : Down";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Quadris.Properties.Resources.BGimg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1027, 840);
            this.Controls.Add(this.CryoStall_disp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labellevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labellines);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelscore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNextPiece);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeldPiece);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelctrl);
            this.Controls.Add(this.panBoard);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quadris!";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.panelctrl.ResumeLayout(false);
            this.panelctrl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }



        #endregion
        private System.Windows.Forms.Panel panBoard;
        private System.Windows.Forms.Timer tmrFps;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNextPiece;
        private System.Windows.Forms.Label lblHeldPiece;
        private System.Windows.Forms.Timer BoardRF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelscore;
        private System.Windows.Forms.Label labellines;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labellevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label CryoStall_disp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelctrl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
    }
}

