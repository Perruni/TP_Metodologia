namespace GestorSubastas
{
    partial class FormSolicitudDeProductos
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
            button1 = new Button();
            button2 = new Button();
            txtNombre = new TextBox();
            txtMontoBase = new TextBox();
            txtMetodoEntrega = new TextBox();
            rtxtDescripcion = new TextBox();
            dataGridViewSubastas = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubastas).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 0);
            button1.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(175, 374);
            button1.Name = "button1";
            button1.Size = new Size(183, 54);
            button1.TabIndex = 0;
            button1.Text = "APROBAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_ClickAsync;
            // 
            // button2
            // 
            button2.BackColor = Color.IndianRed;
            button2.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(425, 374);
            button2.Name = "button2";
            button2.Size = new Size(183, 54);
            button2.TabIndex = 1;
            button2.Text = "RECHAZAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(364, 103);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(196, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtMontoBase
            // 
            txtMontoBase.Location = new Point(360, 160);
            txtMontoBase.Name = "txtMontoBase";
            txtMontoBase.Size = new Size(200, 23);
            txtMontoBase.TabIndex = 4;
            // 
            // txtMetodoEntrega
            // 
            txtMetodoEntrega.Location = new Point(364, 231);
            txtMetodoEntrega.Name = "txtMetodoEntrega";
            txtMetodoEntrega.Size = new Size(196, 23);
            txtMetodoEntrega.TabIndex = 5;
            // 
            // rtxtDescripcion
            // 
            rtxtDescripcion.Location = new Point(360, 300);
            rtxtDescripcion.Name = "rtxtDescripcion";
            rtxtDescripcion.Size = new Size(396, 23);
            rtxtDescripcion.TabIndex = 6;
            // 
            // dataGridViewSubastas
            // 
            dataGridViewSubastas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubastas.Location = new Point(12, 114);
            dataGridViewSubastas.Name = "dataGridViewSubastas";
            dataGridViewSubastas.Size = new Size(302, 150);
            dataGridViewSubastas.TabIndex = 8;
            dataGridViewSubastas.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(432, 38);
            label1.TabIndex = 9;
            label1.Text = "DATOS DEL PRODUCTO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(364, 82);
            label2.Name = "label2";
            label2.Size = new Size(71, 18);
            label2.TabIndex = 10;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(360, 129);
            label3.Name = "label3";
            label3.Size = new Size(104, 18);
            label3.TabIndex = 11;
            label3.Text = "Monto Base";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(364, 201);
            label4.Name = "label4";
            label4.Size = new Size(163, 18);
            label4.TabIndex = 12;
            label4.Text = "Metodo de entrega";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(364, 273);
            label5.Name = "label5";
            label5.Size = new Size(101, 18);
            label5.TabIndex = 13;
            label5.Text = "Descripcion";
            // 
            // FormSolicitudDeProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewSubastas);
            Controls.Add(rtxtDescripcion);
            Controls.Add(txtMetodoEntrega);
            Controls.Add(txtMontoBase);
            Controls.Add(txtNombre);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormSolicitudDeProductos";
            Text = "FormSolicitudDeProductos";
            Load += FormSolicitudDeProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubastas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox txtNombre;
        private TextBox txtMontoBase;
        private TextBox txtMetodoEntrega;
        private TextBox rtxtDescripcion;
        private DataGridView dataGridViewSubastas;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}