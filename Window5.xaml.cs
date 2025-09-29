using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SaludAp
{
    public partial class Window5 : Window
    {
        public ObservableCollection<Citas> Citas { get; set; } = new ObservableCollection<Citas>();

        public Window5()
        {
            InitializeComponent();
            CargarCitas(); // Llenamos la lista
            CitasList.ItemsSource = Citas; // La conectamos al ListView
        }

        private void CargarCitas()
        {
            // Limpiamos la colección para evitar duplicados si se llama varias veces
            Citas.Clear();

            // Obtenemos las citas guardadas en CitaManager
            var citasGuardadas = CitaManager.ObtenerCitas();

            // Agregamos cada cita a la ObservableCollection
            foreach (var cita in citasGuardadas)
            {
                Citas.Add((Citas)cita);
            }
        }

        private void BtnReprogramar_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var cita = btn?.Tag as Citas;

            if (cita != null)
            {
                var ventana = new ReprogramarWindow(cita.FechaHora);
                bool? resultado = ventana.ShowDialog();

                if (resultado == true && ventana.NuevaFecha.HasValue)
                {
                    cita.FechaHora = ventana.NuevaFecha.Value;

                    // Refrescar el ListView para que se vea el cambio
                    CitasList.Items.Refresh();

                    MessageBox.Show("La cita ha sido reprogramada.");
                }
            }
        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        
            
        {
            var boton = sender as Button;
            var cita = boton?.DataContext as Citas;

            if (cita != null && cita.Estado != "Cancelada")
            {
                MessageBoxResult result = MessageBox.Show(
                    $"¿Seguro que deseas cancelar la cita de {cita.Cliente}?",
                    "Confirmar cancelación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Eliminar la cita de la colección (desaparecerá del ListView automáticamente)
                    Citas.Remove(cita);

                    MessageBox.Show("La cita ha sido cancelada.");
                }
            }
        }

         
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var cita = button?.Tag as Citas;

            if (cita != null)
            {
                var ventana = new ReprogramarWindow(cita.FechaHora);
                if (ventana.ShowDialog() == true)
                {
                    cita.FechaHora = ventana.NuevaFecha ?? DateTime.Now;


                    // Refrescar ListView si es necesario
                    CitasList.Items.Refresh();

         }           MessageBox.Show("La cita ha sido reprogramada.");
                }   }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 VentanaAnterior = new Window3();
            VentanaAnterior.Show();
            this.Close();
        }
    }
}
