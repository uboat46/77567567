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

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private String username;

        public Window1(String username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            lb_welcome.Content = lb_welcome.Content.ToString() + " " + username;
            ConexionBD con = new ConexionBD();
            con.TraeUsers(dataGrid1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
