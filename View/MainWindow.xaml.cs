using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using WpfApp1.Models;

using WpfApp1.View;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Company> displayedCompanies { get; set; }

        public List<User> displayedUsers { get; set; }

        public MainWindow()
        {
            InitializeComponent();



            using (var context = new DbUserContext())
            {
                displayedCompanies = context.Companies.ToList();
            }
            dataGrid.ItemsSource = displayedCompanies;


        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new CreateWnd();
            wnd.ShowDialog();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = dataGrid.SelectedItem;
            if (selectedItem != null)
            {
                using (var context = new DbUserContext())
                {
                    context.Companies.Remove((Company)selectedItem);
                    context.SaveChanges();
                }
            }

            using (var context = new DbUserContext())
            {
                displayedCompanies = context.Companies.ToList();
            }
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = displayedCompanies;

            dataGrid.IsHitTestVisible = true;

        }
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            var selectedEntity = dataGrid.SelectedItem as Company;
            if (selectedEntity != null)
            {
                var infoDialog = new EntityInfoWindow();
                //infoDialog.DataContext = selectedEntity;
                infoDialog.txtCid.Text = selectedEntity.Id.ToString();
                infoDialog.txtCName.Text = selectedEntity.Name;
                infoDialog.txtCCategory.Text = selectedEntity.Category;
                infoDialog.txtCAdres.Text = selectedEntity.Adres;

                User foundUser;
                using (var context = new DbUserContext())
                {
                    foundUser = context.Users.FirstOrDefault(a=>a.UserId == selectedEntity.UserId);
                }
                infoDialog.txtUid.Text = foundUser.UserId.ToString();
                infoDialog.txtUName.Text = foundUser.ImieiNazwisko;
                infoDialog.txtUadres.Text = foundUser.Adres;

                infoDialog.ShowDialog();
            }

            
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedEntity = dataGrid.SelectedItem as Company;
            if (selectedEntity != null)
            {
                var infoDialog = new EntityUpdateWindow();
                //infoDialog.DataContext = selectedEntity;
                infoDialog.txtCid.Text = selectedEntity.Id.ToString();
                infoDialog.txtCName.Text = selectedEntity.Name;
                infoDialog.txtCCategory.Text = selectedEntity.Category;
                infoDialog.txtCAdres.Text = selectedEntity.Adres;

                User foundUser;
                using (var context = new DbUserContext())
                {
                    foundUser = context.Users.FirstOrDefault(a => a.UserId == selectedEntity.UserId);
                }
                infoDialog.txtUid.Text = foundUser.UserId.ToString();
                infoDialog.txtUName.Text = foundUser.ImieiNazwisko;
                infoDialog.txtUadres.Text = foundUser.Adres;

                infoDialog.ShowDialog();
            }


            using (var context = new DbUserContext())
            {
                displayedCompanies = context.Companies.ToList();
            }
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = displayedCompanies;

            dataGrid.IsHitTestVisible = true;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            
            using (var context = new DbUserContext())
            {
                displayedUsers = context.Users.ToList();
            }
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = displayedUsers;
            dataGrid.IsHitTestVisible = false;

        }
    }
}
