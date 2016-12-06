using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            String username = txtBox_user.Text.ToString().Trim();
            String password = txtBox_password.Text.ToString().Trim();
            if (!username.Equals("") && !password.Equals(""))
            {
                Boolean res;
                ConexionBD con = new ConexionBD();
                res = con.Login(username, password);

                if (res)
                {
                    Window1 win1 = new Window1(username);
                    win1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrectos");
                }
            }
            else
            {
                MessageBox.Show("Porfavor rellene todos los campos");
            }
            txtBox_password.Text = "";
        }
    }
}
