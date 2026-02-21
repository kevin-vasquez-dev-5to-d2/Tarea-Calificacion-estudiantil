namespace tareagamanotaestudiante
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Declarar los controles como campos privados para accederlos desde Form1.cs
        private Label label1;
        private TextBox txt_nota1;
        private Label label2;
        private TextBox txt_nota2;
        private Label label3;
        private TextBox txt_nota3;
        private Label label4;
        private TextBox txt_nota4;
        private Label labelPromedio;
        private TextBox txt_promedio;
        private Label labelCompletivo;
        private TextBox txt_completivo;
        private Label labelExtraordinario;
        private TextBox txt_extraordinario;
        private Button btnCalcular;
        private Label labelResultado;

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
            label1 = new Label();
            txt_nota1 = new TextBox();
            label2 = new Label();
            txt_nota2 = new TextBox();
            label3 = new Label();
            txt_nota3 = new TextBox();
            label4 = new Label();
            txt_nota4 = new TextBox();
            labelPromedio = new Label();
            txt_promedio = new TextBox();
            labelCompletivo = new Label();
            txt_completivo = new TextBox();
            labelExtraordinario = new Label();
            txt_extraordinario = new TextBox();
            btnCalcular = new Button();
            labelResultado = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(70, 25);
            label1.TabIndex = 0;
            label1.Text = "Nota 1:";
            // 
            // txt_nota1
            // 
            txt_nota1.Location = new Point(100, 20);
            txt_nota1.Name = "txt_nota1";
            txt_nota1.Size = new Size(150, 31);
            txt_nota1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 60);
            label2.Name = "label2";
            label2.Size = new Size(70, 25);
            label2.TabIndex = 2;
            label2.Text = "Nota 2:";
            // 
            // txt_nota2
            // 
            txt_nota2.Location = new Point(100, 60);
            txt_nota2.Name = "txt_nota2";
            txt_nota2.Size = new Size(150, 31);
            txt_nota2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 100);
            label3.Name = "label3";
            label3.Size = new Size(70, 25);
            label3.TabIndex = 4;
            label3.Text = "Nota 3:";
            // 
            // txt_nota3
            // 
            txt_nota3.Location = new Point(100, 100);
            txt_nota3.Name = "txt_nota3";
            txt_nota3.Size = new Size(150, 31);
            txt_nota3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 140);
            label4.Name = "label4";
            label4.Size = new Size(70, 25);
            label4.TabIndex = 6;
            label4.Text = "Nota 4:";
            // 
            // txt_nota4
            // 
            txt_nota4.Location = new Point(100, 140);
            txt_nota4.Name = "txt_nota4";
            txt_nota4.Size = new Size(150, 31);
            txt_nota4.TabIndex = 7;
            // 
            // labelPromedio
            // 
            labelPromedio.AutoSize = true;
            labelPromedio.Location = new Point(20, 190);
            labelPromedio.Name = "labelPromedio";
            labelPromedio.Size = new Size(99, 25);
            labelPromedio.TabIndex = 8;
            labelPromedio.Text = "Promedio: ";
            // 
            // txt_promedio
            // 
            txt_promedio.Location = new Point(100, 190);
            txt_promedio.Name = "txt_promedio";
            txt_promedio.ReadOnly = true;
            txt_promedio.Size = new Size(150, 31);
            txt_promedio.TabIndex = 9;
            // 
            // labelCompletivo
            // 
            labelCompletivo.AutoSize = true;
            labelCompletivo.Location = new Point(20, 230);
            labelCompletivo.Name = "labelCompletivo";
            labelCompletivo.Size = new Size(152, 25);
            labelCompletivo.TabIndex = 10;
            labelCompletivo.Text = "Nota Completivo:";
            labelCompletivo.Visible = false;
            // 
            // txt_completivo
            // 
            txt_completivo.Location = new Point(100, 230);
            txt_completivo.Name = "txt_completivo";
            txt_completivo.Size = new Size(150, 31);
            txt_completivo.TabIndex = 11;
            txt_completivo.Visible = false;
            // 
            // labelExtraordinario
            // 
            labelExtraordinario.AutoSize = true;
            labelExtraordinario.Location = new Point(20, 270);
            labelExtraordinario.Name = "labelExtraordinario";
            labelExtraordinario.Size = new Size(170, 25);
            labelExtraordinario.TabIndex = 12;
            labelExtraordinario.Text = "Nota Extraordinario:";
            labelExtraordinario.Visible = false;
            // 
            // txt_extraordinario
            // 
            txt_extraordinario.Location = new Point(100, 270);
            txt_extraordinario.Name = "txt_extraordinario";
            txt_extraordinario.ReadOnly = true;
            txt_extraordinario.Size = new Size(150, 31);
            txt_extraordinario.TabIndex = 13;
            txt_extraordinario.Visible = false;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(100, 320);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(150, 23);
            btnCalcular.TabIndex = 14;
            btnCalcular.Text = "Calcular";
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Font = new Font("Arial", 12F, FontStyle.Bold);
            labelResultado.Location = new Point(20, 370);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(143, 29);
            labelResultado.TabIndex = 15;
            labelResultado.Text = "Resultado: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 450);
            Controls.Add(label1);
            Controls.Add(txt_nota1);
            Controls.Add(label2);
            Controls.Add(txt_nota2);
            Controls.Add(label3);
            Controls.Add(txt_nota3);
            Controls.Add(label4);
            Controls.Add(txt_nota4);
            Controls.Add(labelPromedio);
            Controls.Add(txt_promedio);
            Controls.Add(labelCompletivo);
            Controls.Add(txt_completivo);
            Controls.Add(labelExtraordinario);
            Controls.Add(txt_extraordinario);
            Controls.Add(btnCalcular);
            Controls.Add(labelResultado);
            Name = "Form1";
            Text = "Calificaciones del Estudiante";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
