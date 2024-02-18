using RentABook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class UpdateBookWindow : Window
    {
        private readonly BookViewModel BVModel;

        public UpdateBookWindow()
        {
            InitializeComponent();
            BVModel = new BookViewModel();
            DataContext = BVModel;

            BVModel.PropertyChanged += BVModel_PropertyChanged;
        }

        private void BVModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BVModel.IsUpdateConfirmed))
            {
                IsUpdateConfirmedChanged();
            }
        }

        private void RetrieveBookDetails_Click(object sender, RoutedEventArgs e)
        {
            int bookId;
            if (int.TryParse(txtBookID.Text, out bookId))
            {
                if (BVModel.RetrieveBookDetails(bookId))
                {
                    //die details vom book werden gezeigt on the gui
                }
                else
                {
                    MessageBox.Show("No Books found! Please try again!");
                }
            }
            else
            {
                MessageBox.Show("invalid inpu! Please use numbers for Book ID!");
            }

        }

        private void SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            if (BVModel.IsUpdateConfirmed)
            {
                BVModel.UpdateBook();
                Close();
            }
            else
            {
                MessageBox.Show("Please confirm before saving.");
            }
        }

        private void IsUpdateConfirmedChanged()
        {
            SaveAndCloseButton.IsEnabled = BVModel.IsUpdateConfirmed;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}