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
    /// <summary>
    /// Lógica de interacción para Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private DateTime horaSeleccionada;

        public Window4()
        {
            InitializeComponent();

            List<Doctor> doctores = new List<Doctor>
            {
                new Doctor { Nombre = "Dr. Juan Morales", Especialidad = "Cardiología" },
                new Doctor { Nombre = "Dra. Laura Vasquez", Especialidad = "Pediatría" },
                new Doctor { Nombre = "Dr. Carlos Mendoza", Especialidad = "Dermatología" }
            };

            comboDoctores.ItemsSource = doctores;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Aquí puedes filtrar doctores según la especialidad seleccionada si quieres
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboDoctores.SelectedItem == null || calendarioCitas.SelectedDate == null || horaSeleccionada == default)
            {
                MessageBox.Show("Selecciona especialidad, fecha y hora.");
                return;
            }

            var doctorSeleccionado = (Doctor)comboDoctores.SelectedItem;

            var nuevaCita = new Citas
            {
                Especialidad = doctorSeleccionado.Especialidad,
                FechaHora = calendarioCitas.SelectedDate.Value.Date.Add(horaSeleccionada.TimeOfDay)
            };

            CitaManager.AgendarCita(nuevaCita);

            MessageBox.Show("Cita agendada correctamente.");

            var window5 = new Window5();
            window5.Show();
            this.Close();
        }

        //Evento para los botones de horario
        private void Horario_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            if (boton == null) return;

            // Guardamos la hora seleccionada
            horaSeleccionada = DateTime.Parse(boton.Content.ToString());

            // Resetear colores de todos los botones de horarios dentro del Grid
            foreach (var child in ((Grid)this.Content).Children)
            {
                if (child is Button btn && btn.Content.ToString().Contains(":"))
                {
                    btn.Background = Brushes.LightGray;
                }
            }

            // Marcar el botón presionado en verde
            boton.Background = Brushes.LightGreen;
        }
    }
}

