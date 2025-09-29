using System;
using System.Windows;

namespace SaludAp
{
    public partial class ReprogramarWindow : Window
    {
        public DateTime? NuevaFecha { get; private set; }

        public ReprogramarWindow(DateTime fechaActual)
        {
            InitializeComponent();
            DatePickerNuevaFecha.SelectedDate = fechaActual;
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerNuevaFecha.SelectedDate.HasValue)
            {
                NuevaFecha = DatePickerNuevaFecha.SelectedDate.Value;
                DialogResult = true; // Cierra la ventana y devuelve "true"
            }
            else
            {
                MessageBox.Show("Por favor selecciona una fecha.");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Cierra la ventana sin hacer nada
        }
    }
}
