using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaludAp
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores que el usuario escribe
            string nombre = txtnombre.Text;
            string contraseña = txtcontraseña.Password;
            string confirmarContraseña = txtcomfirmar.Password;
            string telefonoTexto = txttelefono.Text;
            string direccion = txtdireccion.Text;

            // ---- VALIDACIONES ----
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre no puede estar vacío.");
                return;
            }

            if (string.IsNullOrWhiteSpace(contraseña) || contraseña.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.");
                return;
            }

            if (contraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            if (!int.TryParse(telefonoTexto, out int telefono) || telefonoTexto.Length != 8)
            {
                MessageBox.Show("El teléfono debe tener 8 dígitos numéricos.");
                return;
            }

            if (string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("La dirección no puede estar vacía.");
                return;
            }

            // Si todas las validaciones son correctas
            MessageBox.Show("Registro Exitoso");

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow VentanaAnterior = new MainWindow();
            VentanaAnterior.Show();
            this.Close();
        }

        private void txtnombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
