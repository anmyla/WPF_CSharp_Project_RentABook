using RentABook.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace RentABook
{

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
            defaultBook.BookRenter = null;
            defaultBook.BookCover = "";
            defaultBook.IsAvailable = false;
            defaultBook.GenreName = "";
           

            this.DataContext = bookViewModel;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
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
                BookRenter = "",
                BookCover = "",
                IsAvailable = false,
                GenreName = "",
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

            RentOutBookWindow rentOutWindow = new RentOutBookWindow();
            rentOutWindow.ShowDialog();
        }

        private void Stash_Click(object sender, RoutedEventArgs e)
        {

            StashABook stashBookWindow = new StashABook();
            stashBookWindow.ShowDialog();
        }

        private void HelpWindow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string filePath = "C:\\Users\\MM\\source\\repos\\RentABook\\RentABook\\HELP.txt";
                string readMeContent = File.ReadAllText(filePath);
                MessageBox.Show(readMeContent, "About Rent-A-Book Shop Manager", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AboutWindow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string filePath = "C:\\Users\\MM\\source\\repos\\RentABook\\RentABook\\ABOUT.txt";
                string readMeContent = File.ReadAllText(filePath);
                MessageBox.Show(readMeContent, "About Rent-A-Book Shop Manager", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.SelectedItem != null)
            {

            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            bookViewModel.Keyword = textBox.Text;
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bookViewModel.SearchBooks(searchTextBox.Text);
            }
        }


    }
}

