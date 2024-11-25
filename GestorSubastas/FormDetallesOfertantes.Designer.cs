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
            dataGridViewOfertantes = new DataGridView();
            label1 = new Label();
            dataGridViewProductos = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOfertantes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOfertantes
            // 
            dataGridViewOfertantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOfertantes.Location = new Point(12, 288);
            dataGridViewOfertantes.Name = "dataGridViewOfertantes";
            dataGridViewOfertantes.Size = new Size(643, 150);
            dataGridViewOfertantes.TabIndex = 0;
            dataGridViewOfertantes.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 270);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 1;
            label1.Text = "Ofertantes del Producto";
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Location = new Point(12, 117);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductos.Size = new Size(643, 150);
            dataGridViewProductos.TabIndex = 2;
            dataGridViewProductos.CellClick += dataGridView2_CellContentClick;
            dataGridViewProductos.CellContentClick += dataGridView2_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 99);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 3;
            label2.Text = "Productos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.Location = new Point(293, 9);
            label3.Name = "label3";
            label3.Size = new Size(198, 25);
            label3.TabIndex = 5;
            label3.Text = "Control de Ofertantes";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 73);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
            label4.Location = new Point(12, 51);
            label4.Name = "label4";
            label4.Size = new Size(68, 19);
            label4.TabIndex = 7;
            label4.Text = "Subasta:";
            // 
            // FormDetallesOfertantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridViewProductos);
            Controls.Add(label1);
            Controls.Add(dataGridViewOfertantes);
            Name = "FormDetallesOfertantes";
            Text = "FormDetallesOfertantes";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOfertantes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewOfertantes;
        private Label label1;
        private DataGridView dataGridViewProductos;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
    }
}