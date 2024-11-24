namespace GestorSubastas
{
    partial class FormDetallesOfertantes
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
            dataGridViewOfertantes = new DataGridView();
            ofertaIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            montoOfertaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaOfertaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioIDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            estadoOferta = new DataGridViewTextBoxColumn();
            usuarioDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            listaOfertasBindingSource = new BindingSource(components);
            productoBindingSource = new BindingSource(components);
            label1 = new Label();
            dataGridViewProductos = new DataGridView();
            nombreProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioBaseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subastaIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subastaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subastaBindingSource = new BindingSource(components);
            label2 = new Label();
            ofertaBindingSource = new BindingSource(components);
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOfertantes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)listaOfertasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subastaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ofertaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOfertantes
            // 
            dataGridViewOfertantes.AutoGenerateColumns = false;
            dataGridViewOfertantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOfertantes.Columns.AddRange(new DataGridViewColumn[] { ofertaIDDataGridViewTextBoxColumn, montoOfertaDataGridViewTextBoxColumn, fechaOfertaDataGridViewTextBoxColumn, usuarioIDDataGridViewTextBoxColumn1, estadoOferta, usuarioDataGridViewTextBoxColumn1 });
            dataGridViewOfertantes.DataSource = listaOfertasBindingSource;
            dataGridViewOfertantes.Location = new Point(12, 272);
            dataGridViewOfertantes.Name = "dataGridViewOfertantes";
            dataGridViewOfertantes.Size = new Size(643, 150);
            dataGridViewOfertantes.TabIndex = 0;
            dataGridViewOfertantes.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ofertaIDDataGridViewTextBoxColumn
            // 
            ofertaIDDataGridViewTextBoxColumn.DataPropertyName = "ofertaID";
            ofertaIDDataGridViewTextBoxColumn.HeaderText = "ofertaID";
            ofertaIDDataGridViewTextBoxColumn.Name = "ofertaIDDataGridViewTextBoxColumn";
            // 
            // montoOfertaDataGridViewTextBoxColumn
            // 
            montoOfertaDataGridViewTextBoxColumn.DataPropertyName = "montoOferta";
            montoOfertaDataGridViewTextBoxColumn.HeaderText = "montoOferta";
            montoOfertaDataGridViewTextBoxColumn.Name = "montoOfertaDataGridViewTextBoxColumn";
            // 
            // fechaOfertaDataGridViewTextBoxColumn
            // 
            fechaOfertaDataGridViewTextBoxColumn.DataPropertyName = "fechaOferta";
            fechaOfertaDataGridViewTextBoxColumn.HeaderText = "fechaOferta";
            fechaOfertaDataGridViewTextBoxColumn.Name = "fechaOfertaDataGridViewTextBoxColumn";
            // 
            // usuarioIDDataGridViewTextBoxColumn1
            // 
            usuarioIDDataGridViewTextBoxColumn1.DataPropertyName = "usuarioID";
            usuarioIDDataGridViewTextBoxColumn1.HeaderText = "usuarioID";
            usuarioIDDataGridViewTextBoxColumn1.Name = "usuarioIDDataGridViewTextBoxColumn1";
            // 
            // estadoOferta
            // 
            estadoOferta.DataPropertyName = "estadoOferta";
            estadoOferta.HeaderText = "estadoOferta";
            estadoOferta.Name = "estadoOferta";
            // 
            // usuarioDataGridViewTextBoxColumn1
            // 
            usuarioDataGridViewTextBoxColumn1.DataPropertyName = "usuario";
            usuarioDataGridViewTextBoxColumn1.HeaderText = "usuario";
            usuarioDataGridViewTextBoxColumn1.Name = "usuarioDataGridViewTextBoxColumn1";
            // 
            // listaOfertasBindingSource
            // 
            listaOfertasBindingSource.DataMember = "listaOfertas";
            listaOfertasBindingSource.DataSource = productoBindingSource;
            // 
            // productoBindingSource
            // 
            productoBindingSource.DataSource = typeof(Core.Entities.Producto);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 243);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 1;
            label1.Text = "Ofertantes del Producto";
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.AutoGenerateColumns = false;
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Columns.AddRange(new DataGridViewColumn[] { nombreProductoDataGridViewTextBoxColumn, precioBaseDataGridViewTextBoxColumn, usuarioIDDataGridViewTextBoxColumn, usuarioDataGridViewTextBoxColumn, subastaIDDataGridViewTextBoxColumn, subastaDataGridViewTextBoxColumn });
            dataGridViewProductos.DataSource = productoBindingSource;
            dataGridViewProductos.Location = new Point(12, 79);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductos.Size = new Size(643, 150);
            dataGridViewProductos.TabIndex = 2;
            dataGridViewProductos.CellClick += dataGridView2_CellContentClick;
            dataGridViewProductos.CellContentClick += dataGridView2_CellContentClick;
            // 
            // nombreProductoDataGridViewTextBoxColumn
            // 
            nombreProductoDataGridViewTextBoxColumn.DataPropertyName = "nombreProducto";
            nombreProductoDataGridViewTextBoxColumn.HeaderText = "nombreProducto";
            nombreProductoDataGridViewTextBoxColumn.Name = "nombreProductoDataGridViewTextBoxColumn";
            // 
            // precioBaseDataGridViewTextBoxColumn
            // 
            precioBaseDataGridViewTextBoxColumn.DataPropertyName = "precioBase";
            precioBaseDataGridViewTextBoxColumn.HeaderText = "precioBase";
            precioBaseDataGridViewTextBoxColumn.Name = "precioBaseDataGridViewTextBoxColumn";
            // 
            // usuarioIDDataGridViewTextBoxColumn
            // 
            usuarioIDDataGridViewTextBoxColumn.DataPropertyName = "usuarioID";
            usuarioIDDataGridViewTextBoxColumn.HeaderText = "usuarioID";
            usuarioIDDataGridViewTextBoxColumn.Name = "usuarioIDDataGridViewTextBoxColumn";
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            // 
            // subastaIDDataGridViewTextBoxColumn
            // 
            subastaIDDataGridViewTextBoxColumn.DataPropertyName = "subastaID";
            subastaIDDataGridViewTextBoxColumn.HeaderText = "subastaID";
            subastaIDDataGridViewTextBoxColumn.Name = "subastaIDDataGridViewTextBoxColumn";
            // 
            // subastaDataGridViewTextBoxColumn
            // 
            subastaDataGridViewTextBoxColumn.DataPropertyName = "Subasta";
            subastaDataGridViewTextBoxColumn.HeaderText = "Subasta";
            subastaDataGridViewTextBoxColumn.Name = "subastaDataGridViewTextBoxColumn";
            // 
            // subastaBindingSource
            // 
            subastaBindingSource.DataSource = typeof(Core.Entities.Subasta);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 3;
            label2.Text = "Productos";
            // 
            // ofertaBindingSource
            // 
            ofertaBindingSource.DataSource = typeof(Core.Entities.Oferta);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(305, 23);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 5;
            label3.Text = "Control de Ofertantes";
            // 
            // FormDetallesOfertantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridViewProductos);
            Controls.Add(label1);
            Controls.Add(dataGridViewOfertantes);
            Name = "FormDetallesOfertantes";
            Text = "FormDetallesOfertantes";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOfertantes).EndInit();
            ((System.ComponentModel.ISupportInitialize)listaOfertasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)subastaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ofertaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewOfertantes;
        private Label label1;
        private DataGridView dataGridViewProductos;
        private Label label2;
        private BindingSource ofertaBindingSource;
        private BindingSource subastaBindingSource;
        private BindingSource productoBindingSource;
        private DataGridViewTextBoxColumn ofertaIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn montoOfertaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaOfertaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioIDDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn estadoOferta;
        private DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn1;
        private BindingSource listaOfertasBindingSource;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioBaseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subastaIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subastaDataGridViewTextBoxColumn;
        private Label label3;
    }
}