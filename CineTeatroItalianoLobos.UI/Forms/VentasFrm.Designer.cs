
namespace CineTeatroItalianoLobos.UI.Forms
{
    partial class VentasFrm
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
            this.FormaDePagoCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FormaDeVentaCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EmpleadoCmb = new System.Windows.Forms.ComboBox();
            this.VenderBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ImporteTotalTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CantidadLocalidadesTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // FormaDePagoCmb
            // 
            this.FormaDePagoCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormaDePagoCmb.FormattingEnabled = true;
            this.FormaDePagoCmb.Location = new System.Drawing.Point(198, 62);
            this.FormaDePagoCmb.Name = "FormaDePagoCmb";
            this.FormaDePagoCmb.Size = new System.Drawing.Size(184, 21);
            this.FormaDePagoCmb.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 19);
            this.label3.TabIndex = 49;
            this.label3.Text = "Forma de Pago :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 19);
            this.label1.TabIndex = 49;
            this.label1.Text = "Forma de Venta :";
            // 
            // FormaDeVentaCmb
            // 
            this.FormaDeVentaCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormaDeVentaCmb.FormattingEnabled = true;
            this.FormaDeVentaCmb.Location = new System.Drawing.Point(198, 112);
            this.FormaDeVentaCmb.Name = "FormaDeVentaCmb";
            this.FormaDeVentaCmb.Size = new System.Drawing.Size(184, 21);
            this.FormaDeVentaCmb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 49;
            this.label2.Text = "Empleado :";
            // 
            // EmpleadoCmb
            // 
            this.EmpleadoCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpleadoCmb.FormattingEnabled = true;
            this.EmpleadoCmb.Location = new System.Drawing.Point(198, 161);
            this.EmpleadoCmb.Name = "EmpleadoCmb";
            this.EmpleadoCmb.Size = new System.Drawing.Size(184, 21);
            this.EmpleadoCmb.TabIndex = 2;
            // 
            // VenderBtn
            // 
            this.VenderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.VenderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VenderBtn.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VenderBtn.Location = new System.Drawing.Point(92, 214);
            this.VenderBtn.Name = "VenderBtn";
            this.VenderBtn.Size = new System.Drawing.Size(127, 44);
            this.VenderBtn.TabIndex = 0;
            this.VenderBtn.Text = "Vender ";
            this.VenderBtn.UseVisualStyleBackColor = false;
            this.VenderBtn.Click += new System.EventHandler(this.VenderBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 49;
            this.label4.Text = "Importe Total :";
            // 
            // ImporteTotalTxt
            // 
            this.ImporteTotalTxt.Enabled = false;
            this.ImporteTotalTxt.Location = new System.Drawing.Point(150, 23);
            this.ImporteTotalTxt.MaxLength = 10;
            this.ImporteTotalTxt.Name = "ImporteTotalTxt";
            this.ImporteTotalTxt.Size = new System.Drawing.Size(102, 20);
            this.ImporteTotalTxt.TabIndex = 8;
            this.ImporteTotalTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(258, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 19);
            this.label5.TabIndex = 49;
            this.label5.Text = "Cant.Localidades :";
            // 
            // CantidadLocalidadesTxt
            // 
            this.CantidadLocalidadesTxt.Enabled = false;
            this.CantidadLocalidadesTxt.Location = new System.Drawing.Point(420, 23);
            this.CantidadLocalidadesTxt.MaxLength = 10;
            this.CantidadLocalidadesTxt.Name = "CantidadLocalidadesTxt";
            this.CantidadLocalidadesTxt.Size = new System.Drawing.Size(90, 20);
            this.CantidadLocalidadesTxt.TabIndex = 6;
            this.CantidadLocalidadesTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.VenderBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 286);
            this.panel1.TabIndex = 68;
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Image = global::CineTeatroItalianoLobos.UI.Properties.Resources.cancel_50px;
            this.CancelButton.Location = new System.Drawing.Point(332, 211);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 53);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // VentasFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(525, 286);
            this.ControlBox = false;
            this.Controls.Add(this.CantidadLocalidadesTxt);
            this.Controls.Add(this.ImporteTotalTxt);
            this.Controls.Add(this.EmpleadoCmb);
            this.Controls.Add(this.FormaDeVentaCmb);
            this.Controls.Add(this.FormaDePagoCmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(525, 286);
            this.MinimumSize = new System.Drawing.Size(525, 286);
            this.Name = "VentasFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentasFrm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FormaDePagoCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FormaDeVentaCmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox EmpleadoCmb;
        private System.Windows.Forms.Button VenderBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ImporteTotalTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CantidadLocalidadesTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}