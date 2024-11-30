namespace GestorSubastas
{
    partial class FormAportesUsuario
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            generarPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 226);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 113);
            label1.Name = "label1";
            label1.Size = new Size(293, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccione un usuario para ver su Aporte a la empresa:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 131);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(278, 39);
            label2.Name = "label2";
            label2.Size = new Size(243, 21);
            label2.TabIndex = 3;
            label2.Text = "Informe de Aporte de Usuarios";
            // 
            // generarPDF
            // 
            generarPDF.Location = new Point(662, 404);
            generarPDF.Name = "generarPDF";
            generarPDF.Size = new Size(109, 34);
            generarPDF.TabIndex = 4;
            generarPDF.Text = "Generar DPF";
            generarPDF.UseVisualStyleBackColor = true;
            generarPDF.Click += generarPDF_Click;
            // 
            // FormAportesUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(generarPDF);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "FormAportesUsuario";
            Text = "FormAportesUsuario";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Button generarPDF;
    }
}