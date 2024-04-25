namespace SistemaHospitalar.View
{
    partial class Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.relaGeral = new System.Windows.Forms.PictureBox();
            this.relaEspecifico = new System.Windows.Forms.PictureBox();
            this.dataGridViewConsulta = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbStatusConsulta = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMedicos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPacientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHorario = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataConsulta = new System.Windows.Forms.DateTimePicker();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.edita = new System.Windows.Forms.PictureBox();
            this.exclui = new System.Windows.Forms.PictureBox();
            this.add = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.relaGeral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relaEspecifico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsulta)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exclui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(97, 25);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(4);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(468, 20);
            this.txtPesquisa.TabIndex = 27;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // relaGeral
            // 
            this.relaGeral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.relaGeral.Image = ((System.Drawing.Image)(resources.GetObject("relaGeral.Image")));
            this.relaGeral.Location = new System.Drawing.Point(573, 20);
            this.relaGeral.Margin = new System.Windows.Forms.Padding(4);
            this.relaGeral.Name = "relaGeral";
            this.relaGeral.Size = new System.Drawing.Size(35, 33);
            this.relaGeral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.relaGeral.TabIndex = 26;
            this.relaGeral.TabStop = false;
            // 
            // relaEspecifico
            // 
            this.relaEspecifico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.relaEspecifico.Image = ((System.Drawing.Image)(resources.GetObject("relaEspecifico.Image")));
            this.relaEspecifico.Location = new System.Drawing.Point(25, 20);
            this.relaEspecifico.Margin = new System.Windows.Forms.Padding(4);
            this.relaEspecifico.Name = "relaEspecifico";
            this.relaEspecifico.Size = new System.Drawing.Size(42, 38);
            this.relaEspecifico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.relaEspecifico.TabIndex = 25;
            this.relaEspecifico.TabStop = false;
            this.relaEspecifico.Click += new System.EventHandler(this.relaEspecifico_Click);
            // 
            // dataGridViewConsulta
            // 
            this.dataGridViewConsulta.AllowUserToAddRows = false;
            this.dataGridViewConsulta.AllowUserToDeleteRows = false;
            this.dataGridViewConsulta.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridViewConsulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsulta.Location = new System.Drawing.Point(25, 375);
            this.dataGridViewConsulta.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewConsulta.Name = "dataGridViewConsulta";
            this.dataGridViewConsulta.ReadOnly = true;
            this.dataGridViewConsulta.Size = new System.Drawing.Size(732, 196);
            this.dataGridViewConsulta.TabIndex = 28;
            this.dataGridViewConsulta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConsulta_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.cbStatusConsulta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbMedicos);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbPacientes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHorario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDataConsulta);
            this.groupBox1.Location = new System.Drawing.Point(25, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 288);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agendar consulta";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(17, 42);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(701, 160);
            this.dgv.TabIndex = 28;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(640, 241);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cbStatusConsulta
            // 
            this.cbStatusConsulta.BackColor = System.Drawing.SystemColors.Window;
            this.cbStatusConsulta.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatusConsulta.FormattingEnabled = true;
            this.cbStatusConsulta.Location = new System.Drawing.Point(485, 237);
            this.cbStatusConsulta.Name = "cbStatusConsulta";
            this.cbStatusConsulta.Size = new System.Drawing.Size(149, 23);
            this.cbStatusConsulta.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(482, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Status da consulta";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Paciente";
            // 
            // cbMedicos
            // 
            this.cbMedicos.BackColor = System.Drawing.SystemColors.Window;
            this.cbMedicos.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicos.FormattingEnabled = true;
            this.cbMedicos.Location = new System.Drawing.Point(304, 237);
            this.cbMedicos.Name = "cbMedicos";
            this.cbMedicos.Size = new System.Drawing.Size(149, 23);
            this.cbMedicos.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(301, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Médico";
            // 
            // cbPacientes
            // 
            this.cbPacientes.BackColor = System.Drawing.SystemColors.Window;
            this.cbPacientes.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPacientes.FormattingEnabled = true;
            this.cbPacientes.Location = new System.Drawing.Point(17, 46);
            this.cbPacientes.Name = "cbPacientes";
            this.cbPacientes.Size = new System.Drawing.Size(149, 23);
            this.cbPacientes.TabIndex = 21;
            this.cbPacientes.Visible = false;
            this.cbPacientes.SelectedIndexChanged += new System.EventHandler(this.cbPacientes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Horário";
            // 
            // txtHorario
            // 
            this.txtHorario.Location = new System.Drawing.Point(184, 241);
            this.txtHorario.Mask = "00:00";
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.Size = new System.Drawing.Size(45, 20);
            this.txtHorario.TabIndex = 19;
            this.txtHorario.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Data da consulta";
            // 
            // txtDataConsulta
            // 
            this.txtDataConsulta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataConsulta.Location = new System.Drawing.Point(17, 241);
            this.txtDataConsulta.Name = "txtDataConsulta";
            this.txtDataConsulta.Size = new System.Drawing.Size(95, 20);
            this.txtDataConsulta.TabIndex = 17;
            this.txtDataConsulta.Value = new System.DateTime(2018, 9, 6, 0, 0, 0, 0);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(793, 287);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(42, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(793, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // edita
            // 
            this.edita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edita.Image = ((System.Drawing.Image)(resources.GetObject("edita.Image")));
            this.edita.Location = new System.Drawing.Point(793, 241);
            this.edita.Margin = new System.Windows.Forms.Padding(4);
            this.edita.Name = "edita";
            this.edita.Size = new System.Drawing.Size(42, 38);
            this.edita.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.edita.TabIndex = 32;
            this.edita.TabStop = false;
            this.edita.Click += new System.EventHandler(this.edita_Click);
            // 
            // exclui
            // 
            this.exclui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exclui.Image = ((System.Drawing.Image)(resources.GetObject("exclui.Image")));
            this.exclui.Location = new System.Drawing.Point(793, 189);
            this.exclui.Margin = new System.Windows.Forms.Padding(4);
            this.exclui.Name = "exclui";
            this.exclui.Size = new System.Drawing.Size(42, 38);
            this.exclui.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exclui.TabIndex = 31;
            this.exclui.TabStop = false;
            this.exclui.Click += new System.EventHandler(this.exclui_Click);
            // 
            // add
            // 
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("add.Image")));
            this.add.Location = new System.Drawing.Point(793, 130);
            this.add.Margin = new System.Windows.Forms.Padding(4);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(42, 38);
            this.add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.add.TabIndex = 30;
            this.add.TabStop = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDocument2
            // 
            this.printDocument2.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument2_BeginPrint);
            this.printDocument2.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument2_EndPrint);
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 582);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.edita);
            this.Controls.Add(this.exclui);
            this.Controls.Add(this.add);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewConsulta);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.relaGeral);
            this.Controls.Add(this.relaEspecifico);
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.relaGeral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relaEspecifico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsulta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exclui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.PictureBox relaGeral;
        private System.Windows.Forms.PictureBox relaEspecifico;
        private System.Windows.Forms.DataGridView dataGridViewConsulta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox edita;
        private System.Windows.Forms.PictureBox exclui;
        private System.Windows.Forms.PictureBox add;
        private System.Windows.Forms.DateTimePicker txtDataConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtHorario;
        private System.Windows.Forms.ComboBox cbPacientes;
        private System.Windows.Forms.ComboBox cbMedicos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbStatusConsulta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Drawing.Printing.PrintDocument printDocument2;
    }
}