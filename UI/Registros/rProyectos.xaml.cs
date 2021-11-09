using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using p2_ap1_wilkins_20170289.BLL;
using p2_ap1_wilkins_20170289.Entidades;

namespace p2_ap1_wilkins_20170289.UI.Registros
{
    public partial class rProyectos : Window
    {
        private Proyectos proyectos = new Proyectos();
        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = proyectos;

            TipoTareaComboBox.ItemsSource = TareasBLL.GetList(c => true);
            TipoTareaComboBox.SelectedValuePath = "TareaId";
            TipoTareaComboBox.DisplayMemberPath = "TipoTarea";
        }
        //CARGAR
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyectos;
        }
        //LIMPIAR
        private void Limpiar()
        {
            this.proyectos = new Proyectos();
            this.DataContext = proyectos;
        }
        //VALIDAR
        private bool Validar()
        {
            bool Validado = true;
            if (ProyectoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        //BUSCAR
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = ProyectosBLL.Buscar(proyectos.ProyectoId);

            if (encontrado != null)
            {
                proyectos = encontrado;
                Cargar();
            }
            else
            {
                MessageBox.Show($"Este Proyecto no fue encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
                ProyectoIdTextBox.Clear();
                ProyectoIdTextBox.Focus();
            }
        }
        //AGREGAR FILA
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            //TIPO TAREA VACIO
            if (TipoTareaComboBox.Text == "0" || TipoTareaComboBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Tipo Tarea Id) está vacío.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                TipoTareaComboBox.IsDropDownOpen = true;
                return;
            }
            //REQUERIMIENTO VACIO
            if (RequerimientoTextBox.Text.Trim() == String.Empty)
            {
                MessageBox.Show("El Campo (Requerimiento de la Tarea) esta vacio.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ProyectoIdTextBox.Focus();
                return;
            }
            //TIEMPO VACIO
            if (TiempoTextBox.Text.Trim() == String.Empty)
            {
                MessageBox.Show("El Campo (Tiempo) esta vacio.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                TiempoTextBox.Text = "0";
                TiempoTextBox.Focus();
                return;
            }

            var filaDetalle = new ProyectosDetalle
            {
                ProyectoId = this.proyectos.ProyectoId,
                TareaId = Convert.ToInt32(TipoTareaComboBox.SelectedValue.ToString()),
                tareas = ((Tareas)TipoTareaComboBox.SelectedItem),
                Requerimiento = (RequerimientoTextBox.Text),
                Tiempo = Convert.ToSingle(TiempoTextBox.Text)
            };

            //TIEMPO TOTAL
            proyectos.TiempoTotal += Convert.ToDouble(TiempoTextBox.Text.ToString());

            this.proyectos.Detalle.Add(filaDetalle);
            Cargar();

            TipoTareaComboBox.SelectedIndex = -1;
            RequerimientoTextBox.Clear();
            TiempoTextBox.Text = "0";
        }
        //REMOVER FILA
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var detalle = (ProyectosDetalle)DetalleDataGrid.SelectedItem;
                if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
                {
                    proyectos.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                    proyectos.TiempoTotal = proyectos.TiempoTotal - detalle.Tiempo;
                    Cargar();
                }
            }
            catch
            {
                MessageBox.Show("No has seleccionado ninguna Fila.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //NUEVO
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //GUARDAR
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                //PROYECTO ID VACIO
                if (ProyectoIdTextBox.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("El Campo (ProyectoId) esta vacio.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ProyectoIdTextBox.Focus();
                    ProyectoIdTextBox.Text = "0";
                    return;
                }
                //DESCRIPCION VACIO
                if (DescripcionTextBox.Text == String.Empty)
                {
                    MessageBox.Show("El Campo (Descripcion) esta vacio.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DescripcionTextBox.Focus();
                    return;
                }
                //DETALLE VACIO
                if (DetalleDataGrid.Items.Count == 0)
                {
                    MessageBox.Show("No has agregado ninguna Tarea para guardar este detalle.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var paso = ProyectosBLL.Guardar(this.proyectos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //ELIMINAR
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ProyectosBLL.Eliminar(int.Parse(ProyectoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TiempoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TiempoTextBox.Text.Trim() != string.Empty)
                {
                    Convert.ToDouble(TiempoTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Tiempo) debe ser un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                TiempoTextBox.Text = "0";
                TiempoTextBox.Focus();
                TiempoTextBox.SelectAll();
            }
        }

        private void ProyectoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                try
                {
                    if (ProyectoIdTextBox.Text.Trim() != string.Empty)
                    {
                        Convert.ToInt32(ProyectoIdTextBox.Text);
                    }
                }
                catch
                {
                    MessageBox.Show($"El valor digitado en el campo (Proyecto Id) debe ser un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ProyectoIdTextBox.Text = "0";
                    ProyectoIdTextBox.Focus();
                    ProyectoIdTextBox.SelectAll();
                }
            }
        }
    }
}