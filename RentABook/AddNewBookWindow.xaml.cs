using RentABook.Models;
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

namespace RentABook
{
    /// <summary>
    /// Interaction logic for AddNewBookWindow.xaml
    /// </summary>
    public partial class AddNewBookWindow : Window
    {
        public AddNewBookWindow()
        {
            InitializeComponent();
        }

        private void AddSaveClose_Click(object sender, RoutedEventArgs e)
        {
            var vm = (BookViewModel)this.DataContext;

            vm.AddBook(vm.NewBook);

            this.Close();


        }
    }
}
