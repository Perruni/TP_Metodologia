namespace GestorSubastas
{
    partial class FormProductosVendidos
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
            dataGridView1 = new DataGridView();
            productoIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioBaseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoProducto = new DataGridViewTextBoxColumn();
            productoBindingSource = new BindingSource(components);
            label1 = new Label();
            dataGridView3 = new DataGridView();
            ofertaBindingSource = new BindingSource(components);
            button1 = new Button();
            estadoOfertaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productoIDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ofertaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { productoIDDataGridViewTextBoxColumn, nombreProductoDataGridViewTextBoxColumn, precioBaseDataGridViewTextBoxColumn, estadoProducto });
            dataGridView1.DataSource = productoBindingSource;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(444, 256);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // productoIDDataGridViewTextBoxColumn
            // 
            productoIDDataGridViewTextBoxColumn.DataPropertyName = "productoID";
            productoIDDataGridViewTextBoxColumn.HeaderText = "productoID";
            productoIDDataGridViewTextBoxColumn.Name = "productoIDDataGridViewTextBoxColumn";
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
            // estadoProducto
            // 
            estadoProducto.DataPropertyName = "estadoProducto";
            estadoProducto.HeaderText = "estadoProducto";
            estadoProducto.Name = "estadoProducto";
            // 
            // productoBindingSource
            // 
            productoBindingSource.DataSource = typeof(Core.Entities.Producto);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 1;
            label1.Text = "Informe Productos Vendidos";
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(462, 307);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(243, 131);
            dataGridView3.TabIndex = 3;
            dataGridView3.CellContentClick += dataGridView3_CellContentClick;
            // 
            // ofertaBindingSource
            // 
            ofertaBindingSource.DataSource = typeof(Core.Entities.Oferta);
            // 
            // button1
            // 
            button1.Location = new Point(349, 408);
            button1.Name = "button1";
            button1.Size = new Size(107, 30);
            button1.TabIndex = 4;
            button1.Text = "Generar PDF";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // estadoOfertaDataGridViewTextBoxColumn
            // 
            estadoOfertaDataGridViewTextBoxColumn.DataPropertyName = "estadoOferta";
            estadoOfertaDataGridViewTextBoxColumn.HeaderText = "estadoOferta";
            estadoOfertaDataGridViewTextBoxColumn.Name = "estadoOfertaDataGridViewTextBoxColumn";
            // 
            // productoIDDataGridViewTextBoxColumn1
            // 
            productoIDDataGridViewTextBoxColumn1.DataPropertyName = "productoID";
            productoIDDataGridViewTextBoxColumn1.HeaderText = "productoID";
            productoIDDataGridViewTextBoxColumn1.Name = "productoIDDataGridViewTextBoxColumn1";
            // 
            // dataGridView2
            // 
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { productoIDDataGridViewTextBoxColumn1, estadoOfertaDataGridViewTextBoxColumn });
            dataGridView2.DataSource = ofertaBindingSource;
            dataGridView2.Location = new Point(462, 45);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(243, 256);
            dataGridView2.TabIndex = 2;
            // 
            // FormProductosVendidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "FormProductosVendidos";
            Text = "FormProductosVendidos";
            Load += FormProductosVendidos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)ofertaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private DataGridViewTextBoxColumn productoIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioBaseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoProducto;
        private BindingSource productoBindingSource;
        private BindingSource ofertaBindingSource;
        private DataGridView dataGridView3;
        private Button button1;
        private DataGridViewTextBoxColumn estadoOfertaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productoIDDataGridViewTextBoxColumn1;
        private DataGridView dataGridView2;
    }
}