using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TareaManejodeArchivos_de_txt_y_validaciones
{
    /// <summary>
    /// Formulario principal de gestión de empleados con validación de datos.
    /// </summary>
    public partial class Form1 : Form
    {
        private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private const string NumericPattern = @"^\d+(\.\d{1,2})?$";
        private const string PhonePattern = @"^\d{7,15}$";

        public Form1()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            SuscribirEventosValidacion();
        }

        private void ConfigurarDataGridView()
        {
            dgvEmpleados.Columns.Clear();

            var columnas = new[]
            {
                ("ID", 40),
                ("Nombre", 90),
                ("Apellidos", 100),
                ("Dirección", 110),
                ("Teléfono", 90),
                ("Email", 130),
                ("Salario", 80),
                ("Cargo", 90),
                ("Género", 75),
                ("Fecha Ingreso", 100)
            };

            foreach (var (columna, ancho) in columnas)
            {
                dgvEmpleados.Columns.Add(columna, columna);
                dgvEmpleados.Columns[dgvEmpleados.Columns.Count - 1].Width = ancho;
            }

            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.ReadOnly = false;
        }

        private void SuscribirEventosValidacion()
        {
            txtTelefono.KeyPress += (s, e) => ValidarSoloNumeros(e);
            txtSalario.KeyPress += (s, e) => ValidarSoloNumerosConDecimal(e);
            txtID.KeyPress += (s, e) => ValidarSoloNumeros(e);
        }

        private void ValidarSoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void ValidarSoloNumerosConDecimal(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Maneja el evento de click del botón guardar.
        /// Valida, guarda en tabla y archivo, luego limpia el formulario.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarTodosDatos())
                return;

            try
            {
                AgregarEmpleadoATabla();
                GuardarEnArchivo();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MostrarError($"Error inesperado al guardar: {ex.Message}");
            }
        }

        private bool ValidarTodosDatos()
        {
            if (!ValidarID())
            {
                EnfocarYMostrarError(txtID, "El ID debe contener solo números");
                return false;
            }

            if (!ValidarNombre())
            {
                EnfocarYMostrarError(txtNombre, "El nombre no puede estar vacío y debe tener al menos 2 caracteres");
                return false;
            }

            if (!ValidarApellidos())
            {
                EnfocarYMostrarError(txtApellidos, "Los apellidos no pueden estar vacíos y deben tener al menos 2 caracteres");
                return false;
            }

            if (!ValidarTelefono())
            {
                EnfocarYMostrarError(txtTelefono, "El teléfono debe contener 7-15 dígitos");
                return false;
            }

            if (!ValidarEmail())
            {
                EnfocarYMostrarError(txtEmail, "El email debe ser válido (ej: usuario@dominio.com)");
                return false;
            }

            if (!ValidarSalario())
            {
                EnfocarYMostrarError(txtSalario, "El salario debe ser un número válido");
                return false;
            }

            if (!ValidarCargoyGenero())
                return false;

            return true;
        }

        private bool ValidarID()
        {
            return !string.IsNullOrWhiteSpace(txtID.Text) &&
                   int.TryParse(txtID.Text, out _);
        }

        private bool ValidarNombre()
        {
            return !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                   txtNombre.Text.Trim().Length >= 2;
        }

        private bool ValidarApellidos()
        {
            return !string.IsNullOrWhiteSpace(txtApellidos.Text) &&
                   txtApellidos.Text.Trim().Length >= 2;
        }

        private bool ValidarTelefono()
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                return true;

            return Regex.IsMatch(txtTelefono.Text, PhonePattern);
        }

        private bool ValidarEmail()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return true;

            return Regex.IsMatch(txtEmail.Text, EmailPattern);
        }

        private bool ValidarSalario()
        {
            if (string.IsNullOrWhiteSpace(txtSalario.Text))
                return true;

            return decimal.TryParse(txtSalario.Text, out var salario) && salario >= 0;
        }

        private bool ValidarCargoyGenero()
        {
            if (cbCargo.SelectedIndex == -1)
            {
                EnfocarYMostrarError(cbCargo, "Debe seleccionar un cargo");
                return false;
            }

            return true;
        }

        private void AgregarEmpleadoATabla()
        {
            dgvEmpleados.Rows.Add(
                txtID.Text,
                txtNombre.Text,
                txtApellidos.Text,
                txtDireccion.Text,
                txtTelefono.Text,
                txtEmail.Text,
                txtSalario.Text,
                cbCargo.Text,
                cbGenero.Text,
                dtpFechaIngreso.Value.ToShortDateString()
            );
        }

        /// <summary>
        /// Abre un diálogo para guardar el registro del empleado en archivo de texto.
        /// </summary>
        private void GuardarEnArchivo()
        {
            using (var dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Archivos de Texto (*.txt)|*.txt";
                dialogo.Title = "Guardar Registro de Empleado";
                dialogo.FileName = $"Empleado_{txtID.Text}_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (var escritor = new StreamWriter(dialogo.FileName, false, System.Text.Encoding.UTF8))
                    {
                        EscribirRegistroEmpleado(escritor);
                    }

                    MostrarExito($"Empleado registrado exitosamente.{Environment.NewLine}Archivo guardado en: {dialogo.FileName}");
                    AbrirArchivo(dialogo.FileName);
                }
                catch (Exception ex)
                {
                    MostrarError($"Error al guardar el archivo: {ex.Message}");
                }
            }
        }

        private void EscribirRegistroEmpleado(StreamWriter escritor)
        {
            var linea = new string('=', 70);

            escritor.WriteLine(linea);
            escritor.WriteLine("REGISTRO DE EMPLEADO".PadLeft(42));
            escritor.WriteLine(linea);
            escritor.WriteLine();

            var datos = new Dictionary<string, string>
            {
                { "ID", txtID.Text },
                { "Nombre", txtNombre.Text },
                { "Apellidos", txtApellidos.Text },
                { "Dirección", txtDireccion.Text },
                { "Teléfono", txtTelefono.Text },
                { "Email", txtEmail.Text },
                { "Salario", "$" + txtSalario.Text },
                { "Cargo", cbCargo.Text },
                { "Género", cbGenero.Text },
                { "Fecha de Ingreso", dtpFechaIngreso.Value.ToShortDateString() }
            };

            foreach (KeyValuePair<string, string> item in datos)
            {
                escritor.WriteLine(item.Key.PadRight(20) + ": " + item.Value);
            }

            escritor.WriteLine();
            escritor.WriteLine(linea);
            escritor.WriteLine("Registrado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            escritor.WriteLine(linea);
        }

        private void AbrirArchivo(string ruta)
        {
            try
            {
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch
            {
            }
        }

        private void LimpiarFormulario()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtSalario.Clear();
            cbCargo.SelectedIndex = -1;
            cbGenero.SelectedIndex = -1;
            dtpFechaIngreso.Value = DateTime.Now;
            txtID.Focus();
        }

        private void EnfocarYMostrarError(Control control, string mensaje)
        {
            control.Focus();
            MostrarError(mensaje);
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "⚠️ Error de Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void MostrarExito(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "✓ Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Estás seguro de que deseas salir de la aplicación?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            e.Cancel = resultado == DialogResult.No;
        }
    }
}