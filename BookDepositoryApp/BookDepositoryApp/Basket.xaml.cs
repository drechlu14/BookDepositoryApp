﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BookDepositoryApp
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        ObservableCollection<BookBasket> itemsFromDb;

        public Basket()
        {
            InitializeComponent();

            itemsFromDb = new ObservableCollection<BookBasket>(Database.GetBooks().Result);
            ToDoItemsListView.ItemsSource = itemsFromDb;

        }

        private static BookBasketDatabase _database;
        public static BookBasketDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new BookBasketDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow customization = new MainWindow();
            customization.Show();
            this.Close();
        }
        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            Database.DeleteBooks();

            Tracking customization = new Tracking();
            customization.Show();
            this.Close();
        }
    }
}
