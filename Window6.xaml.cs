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
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnVerDetalles_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí se mostrarán más detalles de la consulta seleccionada.",
                            "Detalles de Consulta",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
    }
}

