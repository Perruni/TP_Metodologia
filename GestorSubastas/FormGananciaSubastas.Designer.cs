namespace GestorSubastas
{
    partial class FormGananciaSubastas
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
            dateTimePickerInicio = new DateTimePicker();
            dateTimePickerFin = new DateTimePicker();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Buscar = new Button();
            label2 = new Label();
            label3 = new Label();
            generarpdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Location = new Point(12, 133);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(200, 23);
            dateTimePickerInicio.TabIndex = 0;
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Location = new Point(218, 133);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(200, 23);
            dateTimePickerFin.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 101);
            label1.Name = "label1";
            label1.Size = new Size(170, 15);
            label1.TabIndex = 2;
            label1.Text = "Seleccione un rango de fechas:";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 228);
            dataGridView1.TabIndex = 3;
            // 
            // Buscar
            // 
            Buscar.Location = new Point(444, 133);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(75, 23);
            Buscar.TabIndex = 4;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(279, 9);
            label2.Name = "label2";
            label2.Size = new Size(215, 21);
            label2.TabIndex = 5;
            label2.Text = "Informe de Gancias Totales";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 76);
            label3.Name = "label3";
            label3.Size = new Size(617, 15);
            label3.TabIndex = 6;
            label3.Text = "Seleccione 2 fechas como se indica abajo para traer todas las subastas que hayan finalizado en el rango especificado";
            // 
            // generarpdf
            // 
            generarpdf.Location = new Point(673, 396);
            generarpdf.Name = "generarpdf";
            generarpdf.Size = new Size(115, 42);
            generarpdf.TabIndex = 7;
            generarpdf.Text = "Generar PDF";
            generarpdf.UseVisualStyleBackColor = true;
            generarpdf.Click += generarpdf_Click;
            // 
            // FormGananciaSubastas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(generarpdf);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Buscar);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(dateTimePickerFin);
            Controls.Add(dateTimePickerInicio);
            Name = "FormGananciaSubastas";
            Text = "FormGananciaSubastas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFin;
        private Label label1;
        private DataGridView dataGridView1;
        private Button Buscar;
        private Label label2;
        private Label label3;
        private Button generarpdf;
    }
}