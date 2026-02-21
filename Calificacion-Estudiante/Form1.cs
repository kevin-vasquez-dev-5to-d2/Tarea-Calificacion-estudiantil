namespace tareagamanotaestudiante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            TextBox txt_nota1 = Controls["txt_nota1"] as TextBox;
            TextBox txt_nota2 = Controls["txt_nota2"] as TextBox;
            TextBox txt_nota3 = Controls["txt_nota3"] as TextBox;
            TextBox txt_nota4 = Controls["txt_nota4"] as TextBox;
            TextBox txt_completivo = Controls["txt_completivo"] as TextBox;
            Button btnCalcular = Controls["btnCalcular"] as Button;

            txt_nota1.TextChanged += (s, e) => CalcularPromedio();
            txt_nota2.TextChanged += (s, e) => CalcularPromedio();
            txt_nota3.TextChanged += (s, e) => CalcularPromedio();
            txt_nota4.TextChanged += (s, e) => CalcularPromedio();
            txt_completivo.TextChanged += (s, e) => CalcularExtraordinario();
            btnCalcular.Click += (s, e) => MostrarResultado();
        }

        private void CalcularPromedio()
        {
            try
            {
                TextBox txt_nota1 = Controls["txt_nota1"] as TextBox;
                TextBox txt_nota2 = Controls["txt_nota2"] as TextBox;
                TextBox txt_nota3 = Controls["txt_nota3"] as TextBox;
                TextBox txt_nota4 = Controls["txt_nota4"] as TextBox;
                TextBox txt_promedio = Controls["txt_promedio"] as TextBox;
                Label labelCompletivo = Controls["labelCompletivo"] as Label;
                TextBox txt_completivo = Controls["txt_completivo"] as TextBox;
                Label labelExtraordinario = Controls["labelExtraordinario"] as Label;
                TextBox txt_extraordinario = Controls["txt_extraordinario"] as TextBox;

                if (double.TryParse(txt_nota1.Text, out double nota1) &&
                    double.TryParse(txt_nota2.Text, out double nota2) &&
                    double.TryParse(txt_nota3.Text, out double nota3) &&
                    double.TryParse(txt_nota4.Text, out double nota4))
                {
                    double promedio = (nota1 + nota2 + nota3 + nota4) / 4;
                    txt_promedio.Text = promedio.ToString("F2");

                    if (promedio <= 69)
                    {
                        labelCompletivo.Visible = true;
                        txt_completivo.Visible = true;
                        labelExtraordinario.Visible = true;
                        txt_extraordinario.Visible = true;
                    }
                    else
                    {
                        labelCompletivo.Visible = false;
                        txt_completivo.Visible = false;
                        labelExtraordinario.Visible = false;
                        txt_extraordinario.Visible = false;
                        txt_completivo.Text = "";
                        txt_extraordinario.Text = "";
                    }
                }
                else
                {
                    txt_promedio.Text = "";
                    labelCompletivo.Visible = false;
                    txt_completivo.Visible = false;
                    labelExtraordinario.Visible = false;
                    txt_extraordinario.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void CalcularExtraordinario()
        {
            try
            {
                TextBox txt_promedio = Controls["txt_promedio"] as TextBox;
                TextBox txt_completivo = Controls["txt_completivo"] as TextBox;
                TextBox txt_extraordinario = Controls["txt_extraordinario"] as TextBox;

                if (double.TryParse(txt_promedio.Text, out double promedio) &&
                    double.TryParse(txt_completivo.Text, out double completivo))
                {
                    // Calcula: 30% del promedio + 70% del completivo
                    double extraordinario = (promedio * 0.30) + (completivo * 0.70);
                    txt_extraordinario.Text = extraordinario.ToString("F2");
                }
                else
                {
                    txt_extraordinario.Text = "";
                }
            }
            catch
            {
            }
        }

        private void MostrarResultado()
        {
            try
            {
                TextBox txt_promedio = Controls["txt_promedio"] as TextBox;
                Label labelResultado = Controls["labelResultado"] as Label;
                
                if (double.TryParse(txt_promedio.Text, out double promedio))
                {
                    if (promedio > 69)
                    {
                        labelResultado.Text = "Resultado: APROBADO";
                        labelResultado.ForeColor = Color.Green;
                    }
                    else
                    {
                        TextBox txt_extraordinario = Controls["txt_extraordinario"] as TextBox;
                        
                        if (double.TryParse(txt_extraordinario.Text, out double extraordinario))
                        {
                            if (extraordinario > 69)
                            {
                                labelResultado.Text = "Resultado: APROBADO";
                                labelResultado.ForeColor = Color.Green;
                            }
                            else
                            {
                                labelResultado.Text = "Resultado: REPROBADO";
                                labelResultado.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            labelResultado.Text = "Resultado: Por favor ingresa la nota del completivo";
                            labelResultado.ForeColor = Color.Orange;
                        }
                    }
                }
            }
            catch
            {
                labelResultado.Text = "Resultado: Error en el cálculo";
            }
        }
    }
}
