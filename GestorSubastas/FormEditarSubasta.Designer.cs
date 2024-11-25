namespace GestorSubastas
{
    partial class FormEditarSubasta
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
            comboBoxMetodosPago = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBoxEstadodeSubasta = new ComboBox();
            label6 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Location = new Point(198, 152);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(200, 23);
            dateTimePickerInicio.TabIndex = 1;
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Location = new Point(198, 231);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(200, 23);
            dateTimePickerFin.TabIndex = 2;
            // 
            // comboBoxMetodosPago
            // 
            comboBoxMetodosPago.FormattingEnabled = true;
            comboBoxMetodosPago.Location = new Point(198, 304);
            comboBoxMetodosPago.Name = "comboBoxMetodosPago";
            comboBoxMetodosPago.Size = new Size(200, 23);
            comboBoxMetodosPago.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSalmon;
            button1.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(544, 86);
            button1.Name = "button1";
            button1.Size = new Size(197, 37);
            button1.TabIndex = 4;
            button1.Text = "ACTUALIZAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(198, 74);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 5;
            label1.Text = "Titulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(198, 126);
            label2.Name = "label2";
            label2.Size = new Size(154, 23);
            label2.TabIndex = 6;
            label2.Text = "Fecha de inicio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(198, 192);
            label3.Name = "label3";
            label3.Size = new Size(211, 23);
            label3.TabIndex = 7;
            label3.Text = "Fecha de finalizacion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(198, 268);
            label4.Name = "label4";
            label4.Size = new Size(164, 23);
            label4.TabIndex = 8;
            label4.Text = "Metodo de pago";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 19);
            label5.Name = "label5";
            label5.Size = new Size(334, 38);
            label5.TabIndex = 9;
            label5.Text = "EDITAR SUBASTA";
            // 
            // comboBoxEstadodeSubasta
            // 
            comboBoxEstadodeSubasta.FormattingEnabled = true;
            comboBoxEstadodeSubasta.Location = new Point(198, 370);
            comboBoxEstadodeSubasta.Name = "comboBoxEstadodeSubasta";
            comboBoxEstadodeSubasta.Size = new Size(200, 23);
            comboBoxEstadodeSubasta.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(198, 330);
            label6.Name = "label6";
            label6.Size = new Size(184, 23);
            label6.TabIndex = 11;
            label6.Text = "Estado de subasta";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(198, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 23);
            textBox1.TabIndex = 12;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // FormEditarSubasta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(comboBoxEstadodeSubasta);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(comboBoxMetodosPago);
            Controls.Add(dateTimePickerFin);
            Controls.Add(dateTimePickerInicio);
            Name = "FormEditarSubasta";
            Text = "FormEditarSubasta";
            Load += FormEditarSubasta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFin;
        private ComboBox comboBoxMetodosPago;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxEstadodeSubasta;
        private Label label6;
        private TextBox textBox1;
    }
}