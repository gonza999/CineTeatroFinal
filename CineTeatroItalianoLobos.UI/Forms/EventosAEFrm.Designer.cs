
namespace CineTeatroItalianoLobos.UI.Forms
{
    partial class EventosAEFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmnBorrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmnHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatosDgv = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.HoraPicker = new System.Windows.Forms.DateTimePicker();
            this.FechaPicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AgregarFechaBtn = new System.Windows.Forms.Button();
            this.DescripcionTxt = new System.Windows.Forms.TextBox();
            this.DistribucionCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ClasificacionCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TipoEventoCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.EventoTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DatosDgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 225);
            this.panel1.TabIndex = 69;
            // 
            // cmnBorrar
            // 
            this.cmnBorrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnBorrar.HeaderText = "Borrar";
            this.cmnBorrar.Name = "cmnBorrar";
            this.cmnBorrar.ReadOnly = true;
            // 
            // cmnHorario
            // 
            this.cmnHorario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnHorario.HeaderText = "Horario";
            this.cmnHorario.Name = "cmnHorario";
            this.cmnHorario.ReadOnly = true;
            // 
            // cmnFecha
            // 
            this.cmnFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnFecha.HeaderText = "Fecha";
            this.cmnFecha.Name = "cmnFecha";
            this.cmnFecha.ReadOnly = true;
            // 
            // DatosDgv
            // 
            this.DatosDgv.AllowUserToAddRows = false;
            this.DatosDgv.AllowUserToDeleteRows = false;
            this.DatosDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DatosDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnFecha,
            this.cmnHorario,
            this.cmnBorrar});
            this.DatosDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosDgv.Location = new System.Drawing.Point(0, 0);
            this.DatosDgv.MultiSelect = false;
            this.DatosDgv.Name = "DatosDgv";
            this.DatosDgv.ReadOnly = true;
            this.DatosDgv.RowHeadersVisible = false;
            this.DatosDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDgv.Size = new System.Drawing.Size(604, 225);
            this.DatosDgv.TabIndex = 0;
            this.DatosDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatosDgv_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 485);
            this.panel2.TabIndex = 70;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.HoraPicker);
            this.panel3.Controls.Add(this.FechaPicker);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.AgregarFechaBtn);
            this.panel3.Controls.Add(this.DescripcionTxt);
            this.panel3.Controls.Add(this.DistribucionCmb);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.ClasificacionCmb);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.TipoEventoCmb);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.CancelButton);
            this.panel3.Controls.Add(this.OkButton);
            this.panel3.Controls.Add(this.EventoTxt);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(604, 260);
            this.panel3.TabIndex = 70;
            // 
            // HoraPicker
            // 
            this.HoraPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.HoraPicker.Location = new System.Drawing.Point(463, 54);
            this.HoraPicker.Name = "HoraPicker";
            this.HoraPicker.ShowUpDown = true;
            this.HoraPicker.Size = new System.Drawing.Size(113, 20);
            this.HoraPicker.TabIndex = 82;
            // 
            // FechaPicker
            // 
            this.FechaPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaPicker.Location = new System.Drawing.Point(463, 10);
            this.FechaPicker.Name = "FechaPicker";
            this.FechaPicker.Size = new System.Drawing.Size(113, 20);
            this.FechaPicker.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(400, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 24);
            this.label8.TabIndex = 84;
            this.label8.Text = "Hora :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(390, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 24);
            this.label6.TabIndex = 85;
            this.label6.Text = "Fecha :";
            // 
            // AgregarFechaBtn
            // 
            this.AgregarFechaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AgregarFechaBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AgregarFechaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AgregarFechaBtn.Location = new System.Drawing.Point(432, 95);
            this.AgregarFechaBtn.Name = "AgregarFechaBtn";
            this.AgregarFechaBtn.Size = new System.Drawing.Size(104, 28);
            this.AgregarFechaBtn.TabIndex = 83;
            this.AgregarFechaBtn.Text = "Agregar";
            this.AgregarFechaBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AgregarFechaBtn.UseVisualStyleBackColor = false;
            this.AgregarFechaBtn.Click += new System.EventHandler(this.AgregarFechaBtn_Click);
            // 
            // DescripcionTxt
            // 
            this.DescripcionTxt.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.DescripcionTxt.Location = new System.Drawing.Point(179, 43);
            this.DescripcionTxt.Multiline = true;
            this.DescripcionTxt.Name = "DescripcionTxt";
            this.DescripcionTxt.Size = new System.Drawing.Size(184, 92);
            this.DescripcionTxt.TabIndex = 80;
            // 
            // DistribucionCmb
            // 
            this.DistribucionCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DistribucionCmb.FormattingEnabled = true;
            this.DistribucionCmb.Location = new System.Drawing.Point(179, 220);
            this.DistribucionCmb.Name = "DistribucionCmb";
            this.DistribucionCmb.Size = new System.Drawing.Size(184, 21);
            this.DistribucionCmb.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 19);
            this.label5.TabIndex = 75;
            this.label5.Text = "Distribucion :";
            // 
            // ClasificacionCmb
            // 
            this.ClasificacionCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClasificacionCmb.FormattingEnabled = true;
            this.ClasificacionCmb.Location = new System.Drawing.Point(179, 180);
            this.ClasificacionCmb.Name = "ClasificacionCmb";
            this.ClasificacionCmb.Size = new System.Drawing.Size(184, 21);
            this.ClasificacionCmb.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 19);
            this.label4.TabIndex = 74;
            this.label4.Text = "Clasificacion :";
            // 
            // TipoEventoCmb
            // 
            this.TipoEventoCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoEventoCmb.FormattingEnabled = true;
            this.TipoEventoCmb.Location = new System.Drawing.Point(179, 143);
            this.TipoEventoCmb.Name = "TipoEventoCmb";
            this.TipoEventoCmb.Size = new System.Drawing.Size(184, 21);
            this.TipoEventoCmb.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 19);
            this.label3.TabIndex = 73;
            this.label3.Text = "Tipo de Evento. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 76;
            this.label2.Text = "Descripcion :";
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Image = global::CineTeatroItalianoLobos.UI.Properties.Resources.cancel_50px;
            this.CancelButton.Location = new System.Drawing.Point(494, 166);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 53);
            this.CancelButton.TabIndex = 71;
            this.CancelButton.UseVisualStyleBackColor = false;
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Image = global::CineTeatroItalianoLobos.UI.Properties.Resources.ok_50px;
            this.OkButton.Location = new System.Drawing.Point(394, 166);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 53);
            this.OkButton.TabIndex = 72;
            this.OkButton.UseVisualStyleBackColor = false;
            // 
            // EventoTxt
            // 
            this.EventoTxt.Location = new System.Drawing.Point(179, 7);
            this.EventoTxt.MaxLength = 100;
            this.EventoTxt.Name = "EventoTxt";
            this.EventoTxt.Size = new System.Drawing.Size(184, 20);
            this.EventoTxt.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 69;
            this.label1.Text = "Evento :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EventosAEFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(604, 485);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EventosAEFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventosAEFrm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DatosDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnHorario;
        private System.Windows.Forms.DataGridViewImageColumn cmnBorrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker HoraPicker;
        private System.Windows.Forms.DateTimePicker FechaPicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AgregarFechaBtn;
        private System.Windows.Forms.TextBox DescripcionTxt;
        private System.Windows.Forms.ComboBox DistribucionCmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ClasificacionCmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TipoEventoCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox EventoTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}