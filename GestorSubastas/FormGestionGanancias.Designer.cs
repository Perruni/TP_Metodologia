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
            label1 = new Label();
            GridProductosG = new DataGridView();
            ComboFinalizadas = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            generarpdf = new Button();
            ((System.ComponentModel.ISupportInitialize)GridProductosG).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(333, 9);
            label1.Name = "label1";
            label1.Size = new Size(176, 21);
            label1.TabIndex = 0;
            label1.Text = "Informe de Ganancias";
            // 
            // GridProductosG
            // 
            GridProductosG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridProductosG.Location = new Point(12, 139);
            GridProductosG.Name = "GridProductosG";
            GridProductosG.Size = new Size(685, 299);
            GridProductosG.TabIndex = 1;
            GridProductosG.CellContentClick += GridProductosG_CellContentClick;
            // 
            // ComboFinalizadas
            // 
            ComboFinalizadas.FormattingEnabled = true;
            ComboFinalizadas.Location = new Point(12, 78);
            ComboFinalizadas.Name = "ComboFinalizadas";
            ComboFinalizadas.Size = new Size(203, 23);
            ComboFinalizadas.TabIndex = 2;
            ComboFinalizadas.SelectedIndexChanged += ComboFinalizadas_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(132, 15);
            label2.TabIndex = 4;
            label2.Text = "Seleccione una subasta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(455, 65);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 5;
            label3.Click += label3_Click;
            // 
            // generarpdf
            // 
            generarpdf.Location = new Point(703, 389);
            generarpdf.Name = "generarpdf";
            generarpdf.Size = new Size(79, 41);
            generarpdf.TabIndex = 6;
            generarpdf.Text = "Generar PDF";
            generarpdf.UseVisualStyleBackColor = true;
            generarpdf.Click += generarpdf_Click;
            // 
            // FormGestionGanancias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(generarpdf);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ComboFinalizadas);
            Controls.Add(GridProductosG);
            Controls.Add(label1);
            Name = "FormGestionGanancias";
            Text = "FormGestionGanancias";
            Load += FormGestionGanancias_Load;
            ((System.ComponentModel.ISupportInitialize)GridProductosG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private DataGridView GridProductosG;
        private ComboBox ComboFinalizadas;
        private Label label2;
        private Label label3;
        private Button generarpdf;
    }
}