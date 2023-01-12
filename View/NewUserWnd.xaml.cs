using Microsoft.EntityFrameworkCore;
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
using WpfApp1.Models;

namespace WpfApp1.View
{
    /// <summary>
    /// Logika interakcji dla klasy NewUserWnd.xaml
    /// </summary>
    public partial class NewUserWnd : Window
    {
        public NewUserWnd()
        {
            InitializeComponent();
        }

        private void btnCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                ImieiNazwisko = txtName.Text,
                Adres = txtAdress.Text,

                //UserId = Int32.Parse(txtId.Text),

                CreatedAt = DateTime.Now,
            };
            using (var context = new DbUserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            this.Close();
        }
    }
}
