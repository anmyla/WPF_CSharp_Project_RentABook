using RentABook.Models;
using System.Data.Entity.Infrastructure;
using System.Windows;

namespace RentABook
{
    public partial class RentOutBookWindow : Window
    {
        private BookViewModel _viewModel;

        public RentOutBookWindow()
        {
            InitializeComponent();
            _viewModel = new BookViewModel();
            DataContext = _viewModel;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SearchBooks(txtSearch.Text);
        }

        private void RentOut_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RentOutBook();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
