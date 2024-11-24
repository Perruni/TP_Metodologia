namespace GestorSubastas
{
    partial class FormInformes
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
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button5 = new Button();
            label6 = new Label();
            button6 = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(223, 28);
            label1.TabIndex = 0;
            label1.Text = "Seleccione un Informe";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 151);
            button2.Name = "button2";
            button2.Size = new Size(132, 23);
            button2.TabIndex = 5;
            button2.Text = "Ganancias Subasta";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 75);
            button3.Name = "button3";
            button3.Size = new Size(82, 23);
            button3.TabIndex = 6;
            button3.Text = "Ofertantes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 297);
            button4.Name = "button4";
            button4.Size = new Size(140, 23);
            button4.TabIndex = 7;
            button4.Text = "Producto No Ofertados";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 115);
            label2.Name = "label2";
            label2.Size = new Size(217, 15);
            label2.TabIndex = 8;
            label2.Text = "Informe de ofertantes de cada producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 187);
            label3.Name = "label3";
            label3.Size = new Size(279, 15);
            label3.TabIndex = 9;
            label3.Text = "Informe de ganancia de la empresa en cada subasta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 344);
            label4.Name = "label4";
            label4.Size = new Size(315, 15);
            label4.TabIndex = 10;
            label4.Text = "Informe de productos en los que no se ha realizado ofertas";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 426);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 11;
            label5.Text = "Informe extra";
            // 
            // button1
            // 
            button1.Location = new Point(12, 386);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Informe extra";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(12, 223);
            button5.Name = "button5";
            button5.Size = new Size(132, 23);
            button5.TabIndex = 13;
            button5.Text = "Informe de productos vendidos";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 258);
            label6.Name = "label6";
            label6.Size = new Size(240, 15);
            label6.TabIndex = 14;
            label6.Text = "Informe de ganancias por producto vendido";
            // 
            // button6
            // 
            button6.Location = new Point(476, 75);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 15;
            button6.Text = "Informe extra";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(476, 115);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 16;
            label7.Text = "Informe extra";
            // 
            // FormInformes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(button6);
            Controls.Add(label6);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Name = "FormInformes";
            Text = "Informes";
            Load += FormInformes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button5;
        private Label label6;
        private Button button6;
        private Label label7;
    }
}