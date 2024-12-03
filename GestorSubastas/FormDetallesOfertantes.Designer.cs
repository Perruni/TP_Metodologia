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
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOfertantes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // pictureBox1
            // 
            pictureBox1.Location = new Point(661, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 180);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(661, 270);
            label5.Name = "label5";
            label5.Size = new Size(115, 15);
            label5.TabIndex = 9;
            label5.Text = "Cantidad de Ofertas:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(661, 288);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 10;
            label6.Text = "Cantidad";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(661, 323);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 12;
            label7.Text = "Descripción:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(661, 338);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 13;
            label8.Text = "Descripción";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(86, 55);
            label9.Name = "label9";
            label9.Size = new Size(48, 15);
            label9.TabIndex = 14;
            label9.Text = "Subasta";
            // 
            // FormDetallesOfertantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 455);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridViewProductos);
            Controls.Add(label1);
            Controls.Add(dataGridViewOfertantes);
            Name = "FormDetallesOfertantes";
            Text = "FormDetallesOfertantes";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOfertantes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewOfertantes;
        private Label label1;
        private DataGridView dataGridViewProductos;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}