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
    public partial class InicioWindow : Window
    {
        private Dictionary<string, string> traduccionesMiskito;
        private Dictionary<string, string> traduccionesEspanol;

        public InicioWindow()
        {
            InitializeComponent();

            // Diccionario Español → Miskito
            traduccionesMiskito = new Dictionary<string, string>
            {
                { "Doctor", "Aihta" },
                { "Paciente", "Yamka nani" },
                { "Bienvenido", "Nakisma" },
                { "Salud Add", "Salud Add" },
                { "Sistema de Gestion Hospitalaria ", "Hospital Bilwi Sistem" },
                { "Acceso ", "Yawan Aiska" },
                { "Iniciar Sesion", "Yawan Bila" },
                { "Necesitas ayuda", "Mairin aiwan yamni" },
                { "Contactar servicio Tecnico", "Téknika servisi yamni" },
                { "Registrarse", "Yawan taka" }
            };

            // Diccionario Miskito → Español (para regresar)
            traduccionesEspanol = new Dictionary<string, string>();
            foreach (var kvp in traduccionesMiskito)
            {
                traduccionesEspanol[kvp.Value] = kvp.Key;
            }

            // Lista de cargos
            List<Cargo> cargos = new List<Cargo>
            {
                new Cargo { Nombre = "Doctor" },
                new Cargo { Nombre = "Paciente" },
            };

            combocargo.ItemsSource = cargos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new Window2();
            window.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        // Método para traducir cargos
        private void TraducirCargos(Dictionary<string, string> diccionario)
        {
            List<Cargo> cargosTraducidos = new List<Cargo>();

            foreach (Cargo cargo in (List<Cargo>)combocargo.ItemsSource)
            {
                string? traduccion;
                if (diccionario.TryGetValue(cargo.Nombre, out traduccion))
                {
                    cargosTraducidos.Add(new Cargo { Nombre = traduccion });
                }
                else
                {
                    cargosTraducidos.Add(cargo);
                }
            }

            combocargo.ItemsSource = cargosTraducidos;
        }

        // Método para traducir labels y botones
        private void TraducirTextos(Dictionary<string, string> diccionario)
        {
            foreach (var child in LogicalTreeHelper.GetChildren(this))
            {
                TraducirRecursivo(child, diccionario);
            }
        }

        private void TraducirRecursivo(object child, Dictionary<string, string> diccionario)
        {
            if (child is Label lbl)
            {
                var content = lbl.Content?.ToString();
                if (!string.IsNullOrEmpty(content) && diccionario.ContainsKey(content))
                {
                    lbl.Content = diccionario[content];
                }
            }
            else if (child is Button btn)
            {
                var content = btn.Content?.ToString();
                if (!string.IsNullOrEmpty(content) && diccionario.ContainsKey(content))
                {
                    btn.Content = diccionario[content];
                }
            }
            else if (child is DependencyObject dep)
            {
                foreach (var c in LogicalTreeHelper.GetChildren(dep))
                {
                    TraducirRecursivo(c, diccionario);
                }
            }
        }

        // Evento del botón "Traducir"
        private void BtnTraducir_Click(object sender, RoutedEventArgs e)
        {
            string origen = ((ComboBoxItem)cmbOrigen.SelectedItem).Content.ToString()!;
            string destino = ((ComboBoxItem)cmbDestino.SelectedItem).Content.ToString()!;

            if (origen == "Español" && destino == "Miskito")
            {
                TraducirCargos(traduccionesMiskito);
                TraducirTextos(traduccionesMiskito);
            }
            else if (origen == "Miskito" && destino == "Español")
            {
                TraducirCargos(traduccionesEspanol);
                TraducirTextos(traduccionesEspanol);
            }
        }
    }

    internal class Cargo
    {
        public string Nombre { get; set; } = "";
    }
}
