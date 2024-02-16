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
    /// Interaction logic for AddGenreWindow.xaml
    /// </summary>
    public partial class AddGenreWindow : Window
    {

        public AddGenreWindow()
        {
            InitializeComponent();
        }

        public void AddGenre_Click(object sender, RoutedEventArgs e)
        {


            var gvm = (GenreViewModel)this.DataContext;

            if (!string.IsNullOrEmpty(txtGenreName.Text) && !string.IsNullOrEmpty(txtIconPath.Text))
            {
                Genre newGenre = new Genre
                {
                    GenreName = txtGenreName.Text,
                    GenreIconPath = txtIconPath.Text
                };

                gvm.AddGenre(newGenre);
                Close();
            }
            else
            {
                MessageBox.Show("Please enter both Genre Name and Icon Path.");
            }
        }

        private void CancelAddGenre_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}