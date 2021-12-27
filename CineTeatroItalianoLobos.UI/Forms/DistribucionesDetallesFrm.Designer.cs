
namespace CineTeatroItalianoLobos.UI.Forms
{
    partial class DistribucionesDetallesFrm
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
            this.PalcosTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DistribucionLbl = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.ButacasPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PalcosTxt
            // 
            this.PalcosTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.PalcosTxt.Enabled = false;
            this.PalcosTxt.Location = new System.Drawing.Point(116, 72);
            this.PalcosTxt.Name = "PalcosTxt";
            this.PalcosTxt.ReadOnly = true;
            this.PalcosTxt.Size = new System.Drawing.Size(102, 20);
            this.PalcosTxt.TabIndex = 41;
            this.PalcosTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 28);
            this.label2.TabIndex = 19;
            this.label2.Text = "Palcos :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(14, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 28);
            this.label1.TabIndex = 21;
            this.label1.Text = "Butacas ";
            // 
            // DistribucionLbl
            // 
            this.DistribucionLbl.AutoSize = true;
            this.DistribucionLbl.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DistribucionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DistribucionLbl.Location = new System.Drawing.Point(12, 9);
            this.DistribucionLbl.Name = "DistribucionLbl";
            this.DistribucionLbl.Size = new System.Drawing.Size(206, 37);
            this.DistribucionLbl.TabIndex = 23;
            this.DistribucionLbl.Text = "Distribucion";
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Image = global::CineTeatroItalianoLobos.UI.Properties.Resources.ok_50px;
            this.OkButton.Location = new System.Drawing.Point(129, 111);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 53);
            this.OkButton.TabIndex = 0;
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ButacasPanel
            // 
            this.ButacasPanel.AutoScroll = true;
            this.ButacasPanel.Location = new System.Drawing.Point(12, 170);
            this.ButacasPanel.Name = "ButacasPanel";
            this.ButacasPanel.Size = new System.Drawing.Size(206, 268);
            this.ButacasPanel.TabIndex = 55;
            // 
            // DistribucionesDetallesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(234, 450);
            this.ControlBox = false;
            this.Controls.Add(this.PalcosTxt);
            this.Controls.Add(this.ButacasPanel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DistribucionLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(234, 450);
            this.MinimumSize = new System.Drawing.Size(234, 450);
            this.Name = "DistribucionesDetallesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DistribucionesDetallesFrm";
            this.Load += new System.EventHandler(this.DistribucionesDetallesFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PalcosTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DistribucionLbl;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Panel ButacasPanel;
    }
}