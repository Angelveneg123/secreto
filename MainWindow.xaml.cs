using MahApps.Metro.Controls;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        bool mostrarcontraseña = false;

        // Diccionarios de traducción
        private Dictionary<string, string> espanolAMiskito;
        private Dictionary<string, string> miskitoAEspanol;

        public MainWindow()
        {
            InitializeComponent();

            // Diccionario Español → Miskito
            espanolAMiskito = new Dictionary<string, string>
            {
                { "Iniciar Sesion", "Pain sa" },
                { "Correo Electronico", "Yamni karna" },
                { "Contraseña", "Siknis" },
                { "Olvidaste tu Contraseña", "Pahra siknis" },
                { "Accede a tu cuenta de paciente", "Nani akali a'nin jama Yamka" }
            };

            // Diccionario Miskito → Español
            miskitoAEspanol = new Dictionary<string, string>
            {
                { "Pain sa", "Iniciar Sesion" },
                { "Yamni karna", "Correo Electronico" },
                { "Siknis", "Contraseña" },
                { "Pahra siknis", "Olvidaste tu Contraseña" },
                { "Nani akali a'nin jama Yamka", "Accede a tu cuenta de paciente" }
            };
        }

        // Botón de login
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string usuarioPermitido = "admin@salud.com";
            string contraseñaPermitida = "1234";

            string correoIngresado = txtcorreo.Text.Trim();
            string contraseñaIngresada = txtcontraseña.Password.Trim();

            if (correoIngresado == usuarioPermitido && contraseñaIngresada == contraseñaPermitida)
            {
                var window3 = new Window3();
                window3.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void txtcorreo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(txtcorreo.Text);
        }

        // Botón de traducción
        private void BtnTraducirLogin_Click(object sender, RoutedEventArgs e)
        {
            string origen = ((cmbOrigenLogin.SelectedItem as ComboBoxItem)?.Content.ToString()) ?? "";
            string destino = ((cmbDestinoLogin.SelectedItem as ComboBoxItem)?.Content.ToString()) ?? "";

            if (origen == "Español" && destino == "Miskito")
            {
                TraducirInterfaz(espanolAMiskito);
            }
            else if (origen == "Miskito" && destino == "Español")
            {
                TraducirInterfaz(miskitoAEspanol);
            }
            else
            {
                MessageBox.Show("Seleccione idiomas válidos", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Método principal de traducción
        private void TraducirInterfaz(Dictionary<string, string> diccionario)
        {
            // Traducir botón de login
            if (diccionario.TryGetValue(btniniciarsesion.Content.ToString(), out string traducido))
                btniniciarsesion.Content = traducido;

            // Traducir todos los controles recursivamente
            TraducirControles(this.Content as DependencyObject, diccionario);
        }

        // Método recursivo que recorre todos los controles
        private void TraducirControles(DependencyObject parent, Dictionary<string, string> diccionario)
        {
            if (parent == null) return;

            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is Label lbl)
                {
                    if (diccionario.TryGetValue(lbl.Content.ToString(), out string textoTraducido))
                        lbl.Content = textoTraducido;
                }
                else if (child is TextBlock tb)
                {
                    if (diccionario.TryGetValue(tb.Text, out string textoTraducido))
                        tb.Text = textoTraducido;
                }
                else if (child is Button btn)
                {
                    if (diccionario.TryGetValue(btn.Content.ToString(), out string textoTraducido))
                        btn.Content = textoTraducido;
                }

                // Llamada recursiva para hijos
                TraducirControles(child, diccionario);
            }
        }
    }
}
