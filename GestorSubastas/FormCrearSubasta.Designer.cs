namespace GestorSubastas
{
    partial class FormCrearSubasta
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
            textBoxTitulo = new TextBox();
            dateTimePickerInicio = new DateTimePicker();
            button1 = new Button();
            dateTimePickerFin = new DateTimePicker();
            comboBoxMetodosPago = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // textBoxTitulo
            // 
            textBoxTitulo.Location = new Point(212, 117);
            textBoxTitulo.Name = "textBoxTitulo";
            textBoxTitulo.Size = new Size(318, 23);
            textBoxTitulo.TabIndex = 0;
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Location = new Point(212, 182);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(315, 23);
            dateTimePickerInicio.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(281, 378);
            button1.Name = "button1";
            button1.Size = new Size(142, 45);
            button1.TabIndex = 5;
            button1.Text = "CREAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Location = new Point(212, 247);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(315, 23);
            dateTimePickerFin.TabIndex = 4;
            // 
            // comboBoxMetodosPago
            // 
            comboBoxMetodosPago.FormattingEnabled = true;
            comboBoxMetodosPago.Location = new Point(212, 326);
            comboBoxMetodosPago.Name = "comboBoxMetodosPago";
            comboBoxMetodosPago.Size = new Size(315, 23);
            comboBoxMetodosPago.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(212, 79);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 7;
            label1.Text = "Titulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 9);
            label2.Name = "label2";
            label2.Size = new Size(451, 38);
            label2.TabIndex = 8;
            label2.Text = "CREAR NUEVA SUBASTA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(212, 156);
            label3.Name = "label3";
            label3.Size = new Size(154, 23);
            label3.TabIndex = 9;
            label3.Text = "Fecha de inicio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(212, 221);
            label4.Name = "label4";
            label4.Size = new Size(211, 23);
            label4.TabIndex = 10;
            label4.Text = "Fecha de finalizacion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(212, 291);
            label5.Name = "label5";
            label5.Size = new Size(164, 23);
            label5.TabIndex = 11;
            label5.Text = "Metodo de pago";
            // 
            // FormCrearSubasta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxMetodosPago);
            Controls.Add(button1);
            Controls.Add(dateTimePickerFin);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(textBoxTitulo);
            Name = "FormCrearSubasta";
            Text = "FormCrearSubasta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTitulo;
        private DateTimePicker dateTimePickerInicio;
        private Button button1;
        private DateTimePicker dateTimePickerFin;
        private ComboBox comboBoxMetodosPago;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}