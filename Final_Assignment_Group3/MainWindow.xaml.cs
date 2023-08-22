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

namespace Final_Assignment_Group3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
             
            
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
           
           viewModel = new ViewModel(this.txtText.Text);         
           this.DataContext = viewModel;
          
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtText.Text = string.Empty;
            txtLength.Text = string.Empty;
            txtWidth.Text = string.Empty;
            txtText.Focus();
        }
    }
}
