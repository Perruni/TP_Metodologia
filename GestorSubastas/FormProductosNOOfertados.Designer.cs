namespace GestorSubastas
{
    partial class FormProductosNOOfertados
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
            nombreProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioBaseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaSolicitudDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productoBindingSource = new BindingSource(components);
            label1 = new Label();
            button1 = new Button();
            dataGridView2 = new DataGridView();
            subastaIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tituloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaInicioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaFinalizadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoSubastaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subastaBindingSource = new BindingSource(components);
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subastaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nombreProductoDataGridViewTextBoxColumn, precioBaseDataGridViewTextBoxColumn, fechaSolicitudDataGridViewTextBoxColumn });
            dataGridView1.DataSource = productoBindingSource;
            dataGridView1.Location = new Point(12, 290);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(654, 204);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // nombreProductoDataGridViewTextBoxColumn
            // 
            nombreProductoDataGridViewTextBoxColumn.DataPropertyName = "nombreProducto";
            nombreProductoDataGridViewTextBoxColumn.HeaderText = "Producto";
            nombreProductoDataGridViewTextBoxColumn.Name = "nombreProductoDataGridViewTextBoxColumn";
            // 
            // precioBaseDataGridViewTextBoxColumn
            // 
            precioBaseDataGridViewTextBoxColumn.DataPropertyName = "precioBase";
            precioBaseDataGridViewTextBoxColumn.HeaderText = "PrecioBase";
            precioBaseDataGridViewTextBoxColumn.Name = "precioBaseDataGridViewTextBoxColumn";
            // 
            // fechaSolicitudDataGridViewTextBoxColumn
            // 
            fechaSolicitudDataGridViewTextBoxColumn.DataPropertyName = "fechaSolicitud";
            fechaSolicitudDataGridViewTextBoxColumn.HeaderText = "FechaSolicitud";
            fechaSolicitudDataGridViewTextBoxColumn.Name = "fechaSolicitudDataGridViewTextBoxColumn";
            // 
            // productoBindingSource
            // 
            productoBindingSource.DataSource = typeof(Core.Entities.Producto);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(310, 9);
            label1.Name = "label1";
            label1.Size = new Size(219, 25);
            label1.TabIndex = 1;
            label1.Text = "Productos No Ofertados";
            // 
            // button1
            // 
            button1.Location = new Point(705, 471);
            button1.Name = "button1";
            button1.Size = new Size(83, 23);
            button1.TabIndex = 2;
            button1.Text = "Generar PDF";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { subastaIDDataGridViewTextBoxColumn, tituloDataGridViewTextBoxColumn, fechaInicioDataGridViewTextBoxColumn, fechaFinalizadoDataGridViewTextBoxColumn, estadoSubastaDataGridViewTextBoxColumn });
            dataGridView2.DataSource = subastaBindingSource;
            dataGridView2.Location = new Point(12, 84);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(654, 150);
            dataGridView2.TabIndex = 3;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // subastaIDDataGridViewTextBoxColumn
            // 
            subastaIDDataGridViewTextBoxColumn.DataPropertyName = "subastaID";
            subastaIDDataGridViewTextBoxColumn.HeaderText = "ID";
            subastaIDDataGridViewTextBoxColumn.Name = "subastaIDDataGridViewTextBoxColumn";
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            tituloDataGridViewTextBoxColumn.DataPropertyName = "titulo";
            tituloDataGridViewTextBoxColumn.HeaderText = "Titulo";
            tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "fechaInicio";
            fechaInicioDataGridViewTextBoxColumn.HeaderText = "Inicio";
            fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            // 
            // fechaFinalizadoDataGridViewTextBoxColumn
            // 
            fechaFinalizadoDataGridViewTextBoxColumn.DataPropertyName = "fechaFinalizado";
            fechaFinalizadoDataGridViewTextBoxColumn.HeaderText = "Finalizado";
            fechaFinalizadoDataGridViewTextBoxColumn.Name = "fechaFinalizadoDataGridViewTextBoxColumn";
            // 
            // estadoSubastaDataGridViewTextBoxColumn
            // 
            estadoSubastaDataGridViewTextBoxColumn.DataPropertyName = "estadoSubasta";
            estadoSubastaDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoSubastaDataGridViewTextBoxColumn.Name = "estadoSubastaDataGridViewTextBoxColumn";
            // 
            // subastaBindingSource
            // 
            subastaBindingSource.DataSource = typeof(Core.Entities.Subasta);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(65, 19);
            label2.TabIndex = 4;
            label2.Text = "Subasta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(12, 268);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 5;
            label3.Text = "Productos:";
            // 
            // FormProductosNOOfertados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 506);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "FormProductosNOOfertados";
            Text = "FormProductosNOOfertados";
            Load += FormProductosNOOfertados_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)subastaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private BindingSource productoBindingSource;
        private DataGridView dataGridView2;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn subastaIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaFinalizadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoSubastaDataGridViewTextBoxColumn;
        private BindingSource subastaBindingSource;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioBaseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaSolicitudDataGridViewTextBoxColumn;
    }
}