using RentABook.Models;
using System.Windows;

namespace RentABook
{
    public partial class StashABook : Window
    {
        private readonly BookViewModel _viewModel;

        public StashABook()
        {
            InitializeComponent();
            _viewModel = new BookViewModel();
            DataContext = _viewModel;
        }

        private void RetrieveBookDetails_Click(object sender, RoutedEventArgs e)
        {
            int bookId;
            if (int.TryParse(txtBookID.Text, out bookId))
            {
                _viewModel.RetrieveBookDetails(bookId);
            }
            else
            {
                MessageBox.Show("Please enter a valid Book ID.");
            }
        }

        private void SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.IsReturnedConfirmed)
            {
                _viewModel.StashBook();
                Close();
            }
            else
            {
                MessageBox.Show("Please confirm receipt of the book from the customer.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
