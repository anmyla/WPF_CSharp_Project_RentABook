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
    /// Interaction logic for UpdateBookWindow.xaml
    public partial class UpdateBookWindow : Window
    {
        private readonly BookViewModel BVModel;

        public UpdateBookWindow()
        {
            InitializeComponent();
            BVModel = new BookViewModel();
            DataContext = BVModel;
        }

        private void RetrieveBookDetails_Click(object sender, RoutedEventArgs e)
        {
            int bookId;
            if (int.TryParse(txtBookID.Text, out bookId))
            {
                BVModel.RetrieveBookDetails(bookId);
            }
            else
            {
                // Handle invalid input
            }
        }

        private void SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            BVModel.UpdateBook();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}