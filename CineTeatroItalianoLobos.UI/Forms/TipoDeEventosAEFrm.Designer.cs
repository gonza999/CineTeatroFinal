﻿
namespace CineTeatroItalianoLobos.UI.Forms
{
    partial class TipoDeEventosAEFrm
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
            this.TipoDeEventoTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TipoDeEventoTxt
            // 
            this.TipoDeEventoTxt.Location = new System.Drawing.Point(141, 45);
            this.TipoDeEventoTxt.MaxLength = 50;
            this.TipoDeEventoTxt.Name = "TipoDeEventoTxt";
            this.TipoDeEventoTxt.Size = new System.Drawing.Size(166, 20);
            this.TipoDeEventoTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tipo de evento :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Image = global::CineTeatroItalianoLobos.UI.Properties.Resources.cancel_50px;
            this.CancelButton.Location = new System.Drawing.Point(224, 77);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 53);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Image = global::CineTeatroItalianoLobos.UI.Properties.Resources.ok_50px;
            this.OkButton.Location = new System.Drawing.Point(21, 77);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 53);
            this.OkButton.TabIndex = 1;
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // TipoDeEventosAEFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(337, 176);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TipoDeEventoTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(337, 176);
            this.MinimumSize = new System.Drawing.Size(337, 176);
            this.Name = "TipoDeEventosAEFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TipoDeEventosAEFrm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TipoDeEventoTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
    }
}