using System;
using System.Globalization;
using System.Windows.Forms;

namespace tareagama
{
    public partial class Form1 : Form
    {
        // manejadores de eventos implementados en archivo separado para mantener el diseñador intacto
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryReadFourNotas(out double n1, out double n2, out double n3, out double n4))
            {
                MessageBox.Show("Ingrese las 4 notas válidas (0-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double promedio = (n1 + n2 + n3 + n4) / 4.0; // suma las 4 notas y divide entre 4
            lblPromedio.Text = promedio.ToString("0.##");

            // reset controles
            lblResultado.Text = string.Empty;
            txtCompletivo.Enabled = false;
            btnCompletivo.Enabled = false;
            txtExtraordinario.Enabled = false;
            btnExtra.Enabled = false;

            if (promedio <= 69.0)
            {
                txtCompletivo.Enabled = true;
                btnCompletivo.Enabled = true;
                lblResultado.Text = "Promedio insuficiente. Puede ingresar completivo.";
            }
            else
            {
                lblResultado.Text = "Aprobado. Nota final: " + promedio.ToString("0.##");
            }
        }

        private void btnCompletivo_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtCompletivo.Text, out double completivo)
                || completivo < 0 || completivo > 100)
            {
                MessageBox.Show("Ingrese una nota de completivo válida (0-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(lblPromedio.Text, out double promedio))
            {
                MessageBox.Show("Calcule el promedio primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // completivo: 50% promedio + 50% completivo
            double notaCompleta = (promedio * 0.5) + (completivo * 0.5);

            if (notaCompleta <= 69.0)
            {
                lblResultado.Text = "Resultado: reprobado (tras completivo: " + notaCompleta.ToString("0.##" + ")");
                // permitir extraordinario
                txtExtraordinario.Enabled = true;
                btnExtra.Enabled = true;
                lblResultado.Text += "\nPuede intentar extraordinario.";
            }
            else
            {
                lblResultado.Text = "Resultado: aprobado (tras completivo: " + notaCompleta.ToString("0.##" + ")");
            }
        }

        private void btnExtra_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtExtraordinario.Text, out double extra)
                || extra < 0 || extra > 100)
            {
                MessageBox.Show("Ingrese una nota de extraordinario válida (0-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (double.TryParse(lblPromedio.Text, out double promedio))
            {
                MessageBox.Show("Calcule el promedio primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (double.TryParse(txtCompletivo.Text, out double completivo))
            {
                MessageBox.Show("Ingrese la nota de completivo antes de extraordinario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // extraordinario: 30% del promedio + 70% de la nota de completivo
            double notaExtra = (promedio * 0.3) + (completivo * 0.7);

            if (notaExtra <= 69.0)
                lblResultado.Text = "Resultado: reprobado (nota extraordinario: " + notaExtra.ToString("0.##" + ")");
            else
                lblResultado.Text = "Resultado: aprobado por extraordinario (nota: " + notaExtra.ToString("0.##" + ")");
        }

        private bool TryReadFourNotas(out double n1, out double n2, out double n3, out double n4)
        {
            n1 = n2 = n3 = n4 = 0;
            bool ok1 = double.TryParse(txtNota1.Text, out n1);
            bool ok2 = double.TryParse(txtNota2.Text, out n2);
            bool ok3 = double.TryParse(txtNota3.Text, out n3);
            bool ok4 = double.TryParse(txtNota4.Text, out n4);

            if (!(ok1 && ok2 && ok3 && ok4)) return false;
            if (n1 < 0 || n1 > 100 || n2 < 0 || n2 > 100 || n3 < 0 || n3 > 100 || n4 < 0 || n4 > 100) return false;
            return true;
        }
    }
}