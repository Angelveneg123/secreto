using Microsoft.Win32;
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
using System.Windows.Shapes;



namespace SaludAp
{
    public partial class Window3 : Window
    {
        private bool modoEdicion = false;

        public Window3()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (!modoEdicion)
            {
                // Activar edición
                txtNombre.IsReadOnly = false;
                txtEmail.IsReadOnly = false;
                txtTelefono.IsReadOnly = false;
                txtDireccion.IsReadOnly = false;
                txtTipoSangre.IsReadOnly = false;

                btnEditar.Content = "Guardar";
                modoEdicion = true;
            }
            else
            {
                // Guardar datos
                string nombre = txtNombre.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                string direccion = txtDireccion.Text;
                string tipoSangre = txtTipoSangre.Text;

                MessageBox.Show($"Perfil actualizado:\nNombre: {nombre}\nEmail: {email}\nTeléfono: {telefono}\nDirección: {direccion}\nTipo de Sangre: {tipoSangre}",
                                "Perfil Guardado", MessageBoxButton.OK, MessageBoxImage.Information);

                // Volver a solo lectura
                txtNombre.IsReadOnly = true;
                txtEmail.IsReadOnly = true;
                txtTelefono.IsReadOnly = true;
                txtDireccion.IsReadOnly = true;
                txtTipoSangre.IsReadOnly = true;

                btnEditar.Content = "Editar Perfil";
                modoEdicion = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Llamando a contacto de emergencia...");
        }

     

        private void btnCambiarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFile.ShowDialog() == true)
            {
                string ruta = openFile.FileName;

                // Mostrar la imagen seleccionada en el perfil
                imgPerfil.Source = new BitmapImage(new Uri(ruta));

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window6 window6 = new Window6();
            window6.Show();
            this.Close();

        }
    }
}
