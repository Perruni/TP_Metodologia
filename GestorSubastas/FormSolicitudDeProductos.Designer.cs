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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            button2 = new Button();
            dataGridViewSubastas = new DataGridView();
            nombreProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaSolicitudDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productoBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ProductoNombre = new Label();
            ProductoPrecio = new Label();
            ProductoEntrega = new Label();
            ImagenProducto = new PictureBox();
            ProductoDescripcion = new TextBox();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubastas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImagenProducto).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 0);
            button1.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(171, 429);
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
            button2.Location = new Point(444, 429);
            button2.Name = "button2";
            button2.Size = new Size(183, 54);
            button2.TabIndex = 1;
            button2.Text = "RECHAZAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dataGridViewSubastas
            // 
            dataGridViewSubastas.AutoGenerateColumns = false;
            dataGridViewSubastas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubastas.Columns.AddRange(new DataGridViewColumn[] { nombreProductoDataGridViewTextBoxColumn, fechaSolicitudDataGridViewTextBoxColumn });
            dataGridViewSubastas.DataSource = productoBindingSource;
            dataGridViewSubastas.Location = new Point(25, 82);
            dataGridViewSubastas.Name = "dataGridViewSubastas";
            dataGridViewSubastas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSubastas.Size = new Size(329, 275);
            dataGridViewSubastas.TabIndex = 8;
            dataGridViewSubastas.CellContentClick += dataGridView1_CellContentClick;
            // 
            // nombreProductoDataGridViewTextBoxColumn
            // 
            nombreProductoDataGridViewTextBoxColumn.DataPropertyName = "nombreProducto";
            nombreProductoDataGridViewTextBoxColumn.HeaderText = "Producto";
            nombreProductoDataGridViewTextBoxColumn.Name = "nombreProductoDataGridViewTextBoxColumn";
            // 
            // fechaSolicitudDataGridViewTextBoxColumn
            // 
            fechaSolicitudDataGridViewTextBoxColumn.DataPropertyName = "fechaSolicitud";
            fechaSolicitudDataGridViewTextBoxColumn.HeaderText = "Solicitud";
            fechaSolicitudDataGridViewTextBoxColumn.Name = "fechaSolicitudDataGridViewTextBoxColumn";
            // 
            // productoBindingSource
            // 
            productoBindingSource.DataSource = typeof(Core.Entities.Producto);
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
            label2.Location = new Point(360, 82);
            label2.Name = "label2";
            label2.Size = new Size(78, 18);
            label2.TabIndex = 10;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(360, 138);
            label3.Name = "label3";
            label3.Size = new Size(110, 18);
            label3.TabIndex = 11;
            label3.Text = "Precio Base:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(360, 192);
            label4.Name = "label4";
            label4.Size = new Size(170, 18);
            label4.TabIndex = 12;
            label4.Text = "Metodo de entrega:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(360, 246);
            label5.Name = "label5";
            label5.Size = new Size(108, 18);
            label5.TabIndex = 13;
            label5.Text = "Descripcion:";
            // 
            // ProductoNombre
            // 
            ProductoNombre.AutoSize = true;
            ProductoNombre.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductoNombre.Location = new Point(362, 107);
            ProductoNombre.Name = "ProductoNombre";
            ProductoNombre.Size = new Size(79, 18);
            ProductoNombre.TabIndex = 14;
            ProductoNombre.Text = "Producto";
            // 
            // ProductoPrecio
            // 
            ProductoPrecio.AutoSize = true;
            ProductoPrecio.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductoPrecio.Location = new Point(362, 160);
            ProductoPrecio.Name = "ProductoPrecio";
            ProductoPrecio.Size = new Size(57, 18);
            ProductoPrecio.TabIndex = 15;
            ProductoPrecio.Text = "Precio";
            // 
            // ProductoEntrega
            // 
            ProductoEntrega.AutoSize = true;
            ProductoEntrega.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductoEntrega.Location = new Point(362, 216);
            ProductoEntrega.Name = "ProductoEntrega";
            ProductoEntrega.Size = new Size(71, 18);
            ProductoEntrega.TabIndex = 16;
            ProductoEntrega.Text = "Entrega";
            // 
            // ImagenProducto
            // 
            ImagenProducto.Location = new Point(570, 176);
            ImagenProducto.Name = "ImagenProducto";
            ImagenProducto.Size = new Size(224, 247);
            ImagenProducto.TabIndex = 18;
            ImagenProducto.TabStop = false;
            // 
            // ProductoDescripcion
            // 
            ProductoDescripcion.Location = new Point(132, 271);
            ProductoDescripcion.Name = "ProductoDescripcion";
            ProductoDescripcion.Size = new Size(168, 23);
            ProductoDescripcion.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(549, 82);
            label6.Name = "label6";
            label6.Size = new Size(81, 18);
            label6.TabIndex = 20;
            label6.Text = "Subasta:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(549, 107);
            label7.Name = "label7";
            label7.Size = new Size(74, 18);
            label7.TabIndex = 21;
            label7.Text = "Subasta";
            // 
            // FormSolicitudDeProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 495);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(ImagenProducto);
            Controls.Add(ProductoEntrega);
            Controls.Add(ProductoPrecio);
            Controls.Add(ProductoNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewSubastas);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ProductoDescripcion);
            Name = "FormSolicitudDeProductos";
            Text = "FormSolicitudDeProductos";
            Load += FormSolicitudDeProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubastas).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImagenProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridView dataGridViewSubastas;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label ProductoNombre;
        private Label ProductoPrecio;
        private Label ProductoEntrega;
        private PictureBox ImagenProducto;
        private TextBox ProductoDescripcion;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaSolicitudDataGridViewTextBoxColumn;
        private BindingSource productoBindingSource;
        private Label label6;
        private Label label7;
    }
}