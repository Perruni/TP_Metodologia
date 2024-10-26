namespace GestorSubastas
{
    partial class FormInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            BotonCrear = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            subastaIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tituloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaInicioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaFinalizadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoSubastaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            metodosdePagoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subastaBindingSource = new BindingSource(components);
            BotonEditar = new Button();
            BotonSolicitudes = new Button();
            BotonInformes = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subastaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // BotonCrear
            // 
            BotonCrear.Location = new Point(23, 12);
            BotonCrear.Name = "BotonCrear";
            BotonCrear.Size = new Size(102, 44);
            BotonCrear.TabIndex = 0;
            BotonCrear.Text = "Crear subasta";
            BotonCrear.UseVisualStyleBackColor = true;
            BotonCrear.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Activas", "Proximas", "Finalizadas" });
            comboBox1.Location = new Point(12, 109);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(23, 83);
            label1.Name = "label1";
            label1.Size = new Size(77, 21);
            label1.TabIndex = 2;
            label1.Text = "Subastas";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { subastaIDDataGridViewTextBoxColumn, tituloDataGridViewTextBoxColumn, fechaInicioDataGridViewTextBoxColumn, fechaFinalizadoDataGridViewTextBoxColumn, estadoSubastaDataGridViewTextBoxColumn, metodosdePagoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = subastaBindingSource;
            dataGridView1.Location = new Point(12, 138);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 285);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // subastaIDDataGridViewTextBoxColumn
            // 
            subastaIDDataGridViewTextBoxColumn.DataPropertyName = "subastaID";
            subastaIDDataGridViewTextBoxColumn.HeaderText = "ID";
            subastaIDDataGridViewTextBoxColumn.Name = "subastaIDDataGridViewTextBoxColumn";
            subastaIDDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.False;
            subastaIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            tituloDataGridViewTextBoxColumn.DataPropertyName = "titulo";
            tituloDataGridViewTextBoxColumn.HeaderText = "Titulo";
            tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            tituloDataGridViewTextBoxColumn.Width = 122;
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "fechaInicio";
            fechaInicioDataGridViewTextBoxColumn.HeaderText = "Inicio";
            fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            fechaInicioDataGridViewTextBoxColumn.Width = 122;
            // 
            // fechaFinalizadoDataGridViewTextBoxColumn
            // 
            fechaFinalizadoDataGridViewTextBoxColumn.DataPropertyName = "fechaFinalizado";
            fechaFinalizadoDataGridViewTextBoxColumn.HeaderText = "Fin";
            fechaFinalizadoDataGridViewTextBoxColumn.Name = "fechaFinalizadoDataGridViewTextBoxColumn";
            fechaFinalizadoDataGridViewTextBoxColumn.Width = 123;
            // 
            // estadoSubastaDataGridViewTextBoxColumn
            // 
            estadoSubastaDataGridViewTextBoxColumn.DataPropertyName = "estadoSubasta";
            estadoSubastaDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoSubastaDataGridViewTextBoxColumn.Name = "estadoSubastaDataGridViewTextBoxColumn";
            estadoSubastaDataGridViewTextBoxColumn.Width = 122;
            // 
            // metodosdePagoDataGridViewTextBoxColumn
            // 
            metodosdePagoDataGridViewTextBoxColumn.DataPropertyName = "metodosdePago";
            metodosdePagoDataGridViewTextBoxColumn.HeaderText = "Metodo de Pago";
            metodosdePagoDataGridViewTextBoxColumn.Name = "metodosdePagoDataGridViewTextBoxColumn";
            metodosdePagoDataGridViewTextBoxColumn.Width = 122;
            // 
            // subastaBindingSource
            // 
            subastaBindingSource.DataSource = typeof(Core.Entities.Subasta);
            // 
            // BotonEditar
            // 
            BotonEditar.Location = new Point(131, 12);
            BotonEditar.Name = "BotonEditar";
            BotonEditar.Size = new Size(102, 44);
            BotonEditar.TabIndex = 4;
            BotonEditar.Text = "Editar";
            BotonEditar.UseVisualStyleBackColor = true;
            BotonEditar.Click += BotonEditar_Click;
            // 
            // BotonSolicitudes
            // 
            BotonSolicitudes.Location = new Point(239, 12);
            BotonSolicitudes.Name = "BotonSolicitudes";
            BotonSolicitudes.Size = new Size(102, 44);
            BotonSolicitudes.TabIndex = 5;
            BotonSolicitudes.Text = "Solicitudes de Productos";
            BotonSolicitudes.UseVisualStyleBackColor = true;
            BotonSolicitudes.Click += button2_Click;
            // 
            // BotonInformes
            // 
            BotonInformes.Location = new Point(347, 12);
            BotonInformes.Name = "BotonInformes";
            BotonInformes.Size = new Size(102, 44);
            BotonInformes.TabIndex = 6;
            BotonInformes.Text = "Informes";
            BotonInformes.UseVisualStyleBackColor = true;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(BotonInformes);
            Controls.Add(BotonSolicitudes);
            Controls.Add(BotonEditar);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(BotonCrear);
            Name = "FormInicio";
            Text = "M.E.W Subastas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)subastaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BotonCrear;
        private ComboBox comboBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private BindingSource subastaBindingSource;
        private Button BotonEditar;
        private Button BotonSolicitudes;
        private Button BotonInformes;
        private DataGridViewTextBoxColumn subastaIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaFinalizadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoSubastaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn metodosdePagoDataGridViewTextBoxColumn;
    }
}
