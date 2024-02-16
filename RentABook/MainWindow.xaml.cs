using RentABook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

namespace RentABook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookViewModel bookViewModel = new BookViewModel();
        GenreViewModel genreViewModel = new GenreViewModel();


        public MainWindow()
        {
            InitializeComponent();
            Book defaultBook = new Book();
            defaultBook.BookTitle = "";
            defaultBook.BookAuthor = "";
            defaultBook.BookYear = "";
            defaultBook.BookGenre = null;
            defaultBook.BookRentPrice = 0;
            defaultBook.BookRating = 0;
            defaultBook.BookComment = null;
            defaultBook.BookCover = "";
            defaultBook.IsAvailable = false;

            this.DataContext = bookViewModel;
          
        }
        private void AddNewBook_Click(object sender, RoutedEventArgs e)
        {
            AddNewBookWindow addNewBookWindow = new AddNewBookWindow();
            Book newBook = new Book()
            {
                BookTitle = "",
                BookAuthor = "",
                BookYear = "",
                BookGenre = null,
                BookRentPrice = 0,
                BookRating = 0,
                BookComment = "",
                BookCover = "",
                IsAvailable = false,
            };
            addNewBookWindow.DataContext = bookViewModel;
            addNewBookWindow.ShowDialog();


        }

        private void AddAGenre_Click(object sender, RoutedEventArgs e)
        {
            AddGenreWindow addGenreWindow = new AddGenreWindow();
            genreViewModel.newGenre = new Genre
            {
                GenreName = "",
                GenreIconPath = ""
            };

            addGenreWindow.DataContext = genreViewModel;
            addGenreWindow.ShowDialog();


        }

        private void ExitWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            DeleteBookWindow deleteBookWindow = new DeleteBookWindow();
            deleteBookWindow.ShowDialog();

        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            UpdateBookWindow updateBookWindow = new UpdateBookWindow();
            updateBookWindow.ShowDialog();
        }

        private void CopyBook_Click(object sender, RoutedEventArgs e)
        {
            CopyBookWindow copyBookWindow = new CopyBookWindow();
            copyBookWindow.ShowDialog();
        }

        private void RentOut_Click(object sender, RoutedEventArgs e)
        {
            // You may implement code to rent out a book here
            bookViewModel.RemoveBook();
        }

        private void Stash_Click(object sender, RoutedEventArgs e)
        {
            // You may implement code to stash a book here
            bookViewModel.RemoveBook();
        }

        private void HelpWindow_Click(object sender, RoutedEventArgs e)
        {
            // You may implement code to open a help window here
            bookViewModel.RemoveBook();
        }

        private void AboutWindow_Click(object sender, RoutedEventArgs e)
        {
            // You may implement code to open an about window here
            bookViewModel.RemoveBook();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.SelectedItem != null)
            {
                // You can access the selected item here and perform any necessary logic
            }
        }

    }
}

