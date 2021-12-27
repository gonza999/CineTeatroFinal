
namespace CineTeatroItalianoLobos.UI.Forms
{
    partial class LocalidadesAEFrm
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
            this.PlantaCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UbicacionCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NumeroNud = new System.Windows.Forms.NumericUpDown();
            this.FilaNud = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NumeroNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilaNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // PlantaCmb
            // 
            this.PlantaCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlantaCmb.FormattingEnabled = true;
            this.PlantaCmb.Location = new System.Drawing.Point(180, 22);
            this.PlantaCmb.Name = "PlantaCmb";
            this.PlantaCmb.Size = new System.Drawing.Size(184, 21);
            this.PlantaCmb.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 56;
            this.label3.Text = "Planta :";
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Image = global::CineTeatroItalianoLobos.UI.Properties.Resources.cancel_50px;
            this.CancelButton.Location = new System.Drawing.Point(259, 169);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 53);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Image = global::CineTeatroItalianoLobos.UI.Properties.Resources.ok_50px;
            this.OkButton.Location = new System.Drawing.Point(56, 169);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 53);
            this.OkButton.TabIndex = 4;
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 56;
            this.label1.Text = "Ubicación :";
            // 
            // UbicacionCmb
            // 
            this.UbicacionCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UbicacionCmb.FormattingEnabled = true;
            this.UbicacionCmb.Location = new System.Drawing.Point(180, 60);
            this.UbicacionCmb.Name = "UbicacionCmb";
            this.UbicacionCmb.Size = new System.Drawing.Size(184, 21);
            this.UbicacionCmb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 56;
            this.label2.Text = "Número :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 19);
            this.label4.TabIndex = 56;
            this.label4.Text = "Fila :";
            // 
            // NumeroNud
            // 
            this.NumeroNud.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NumeroNud.Location = new System.Drawing.Point(180, 92);
            this.NumeroNud.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.NumeroNud.Name = "NumeroNud";
            this.NumeroNud.Size = new System.Drawing.Size(120, 20);
            this.NumeroNud.TabIndex = 2;
            this.NumeroNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumeroNud.ThousandsSeparator = true;
            this.NumeroNud.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // FilaNud
            // 
            this.FilaNud.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FilaNud.Location = new System.Drawing.Point(180, 130);
            this.FilaNud.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.FilaNud.Name = "FilaNud";
            this.FilaNud.Size = new System.Drawing.Size(120, 20);
            this.FilaNud.TabIndex = 3;
            this.FilaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FilaNud.ThousandsSeparator = true;
            this.FilaNud.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LocalidadesAEFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(405, 246);
            this.ControlBox = false;
            this.Controls.Add(this.FilaNud);
            this.Controls.Add(this.NumeroNud);
            this.Controls.Add(this.UbicacionCmb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlantaCmb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(405, 246);
            this.MinimumSize = new System.Drawing.Size(405, 246);
            this.Name = "LocalidadesAEFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocalidadesAEFrm";
            ((System.ComponentModel.ISupportInitialize)(this.NumeroNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilaNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PlantaCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UbicacionCmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumeroNud;
        private System.Windows.Forms.NumericUpDown FilaNud;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}