using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Generic;
using p2_ap1_wilkins_20170289.BLL;
using p2_ap1_wilkins_20170289.Entidades;

namespace p2_ap1_wilkins_20170289.UI.Consultas
{
    public partial class cTareas : Window
    {
        private Tareas tareas = new Tareas();//--
        public cTareas()
        {
            InitializeComponent();
            DatosDataGrid.ItemsSource = TareasBLL.GetList(c => true);
            ConteoTextBox.Text = Convert.ToInt32(DatosDataGrid.Items.Count).ToString();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Tareas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    //Filtro por id
                    case 0:
                        try
                        {
                            listado = TareasBLL.GetList(c => c.TareaId == int.Parse(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido para aplicar este filtro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    //Filtro por Tipo de tarea
                    case 1:
                        try
                        {
                            listado = TareasBLL.GetList(c => c.TipoTarea.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido para aplicar este filtro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                }
            }
            else
            {
                listado = TareasBLL.GetList(c => true);
                ConteoTextBox.Text = Convert.ToInt32(DatosDataGrid.Items.Count).ToString();
            }

            if (DesdeDatePicker.SelectedDate != null)
                listado = TareasBLL.GetList(c => c.FechaCreacion.Date >= DesdeDatePicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = TareasBLL.GetList(c => c.FechaCreacion.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
            ConteoTextBox.Text = Convert.ToInt32(DatosDataGrid.Items.Count).ToString();
        }
    }
}