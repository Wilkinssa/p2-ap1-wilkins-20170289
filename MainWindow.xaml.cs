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
using p2_ap1_wilkins_20170289.UI.Registros;
using p2_ap1_wilkins_20170289.UI.Consultas;

namespace p2_ap1_wilkins_20170289
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProyectos rProyectos = new rProyectos();
            rProyectos.Show();
        }

        private void cTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cTareas cTareas = new cTareas();
            cTareas.Show();
        }

        private void cProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cProyectos cProyectos = new cProyectos();
            cProyectos.Show();
        }
    }
}