namespace GestorSubastas
{
    partial class FormGestionGanancias
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
            label1 = new Label();
            GridProductosG = new DataGridView();
            ComboFinalizadas = new ComboBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            productoBindingSource = new BindingSource(components);
            ofertaBindingSource = new BindingSource(components);
            montoOfertaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaOfertaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioBaseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)GridProductosG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ofertaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 0;
            label1.Text = "Informe de Ganancias";
            // 
            // GridProductosG
            // 
            GridProductosG.AutoGenerateColumns = false;
            GridProductosG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridProductosG.Columns.AddRange(new DataGridViewColumn[] { nombreProductoDataGridViewTextBoxColumn, precioBaseDataGridViewTextBoxColumn });
            GridProductosG.DataSource = productoBindingSource;
            GridProductosG.Location = new Point(12, 139);
            GridProductosG.Name = "GridProductosG";
            GridProductosG.Size = new Size(443, 299);
            GridProductosG.TabIndex = 1;
            GridProductosG.CellContentClick += GridProductosG_CellContentClick;
            // 
            // ComboFinalizadas
            // 
            ComboFinalizadas.FormattingEnabled = true;
            ComboFinalizadas.Location = new Point(12, 93);
            ComboFinalizadas.Name = "ComboFinalizadas";
            ComboFinalizadas.Size = new Size(203, 23);
            ComboFinalizadas.TabIndex = 2;
            ComboFinalizadas.SelectedIndexChanged += ComboFinalizadas_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { montoOfertaDataGridViewTextBoxColumn, fechaOfertaDataGridViewTextBoxColumn });
            dataGridView1.DataSource = ofertaBindingSource;
            dataGridView1.Location = new Point(454, 139);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(243, 299);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(454, 93);
            label2.Name = "label2";
            label2.Size = new Size(136, 15);
            label2.TabIndex = 4;
            label2.Text = "Ganancias de la Subasta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(621, 93);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 5;
            label3.Click += label3_Click;
            // 
            // productoBindingSource
            // 
            productoBindingSource.DataSource = typeof(Core.Entities.Producto);
            // 
            // ofertaBindingSource
            // 
            ofertaBindingSource.DataSource = typeof(Core.Entities.Oferta);
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
            // FormGestionGanancias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(ComboFinalizadas);
            Controls.Add(GridProductosG);
            Controls.Add(label1);
            Name = "FormGestionGanancias";
            Text = "FormGestionGanancias";
            Load += FormGestionGanancias_Load;
            ((System.ComponentModel.ISupportInitialize)GridProductosG).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ofertaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private DataGridView GridProductosG;
        private ComboBox ComboFinalizadas;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioBaseDataGridViewTextBoxColumn;
        private BindingSource productoBindingSource;
        private DataGridViewTextBoxColumn montoOfertaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaOfertaDataGridViewTextBoxColumn;
        private BindingSource ofertaBindingSource;
    }
}