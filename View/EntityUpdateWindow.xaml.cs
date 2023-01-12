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
    /// Interaction logic for EntityUpdateWindow.xaml
    /// </summary>
    public partial class EntityUpdateWindow : Window
    {
        public EntityUpdateWindow()
        {
            InitializeComponent();
        }

        private void updateCompany_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new DbUserContext())
            {
                var foundcompany = context.Companies.FirstOrDefault(a => a.Id == Int32.Parse(txtCid.Text));
                if (foundcompany != null)
                {
                    foundcompany.Name = utxtCName.Text;
                    foundcompany.Category = utxtCCategory.Text;
                    foundcompany.Adres = utxtCAdres.Text;
                    foundcompany.UpdatedAt = DateTime.Now;
                    context.SaveChanges();
                }
                
            }
        }
        private void updateUser_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new DbUserContext())
            {
                var founduser = context.Users.FirstOrDefault(a => a.UserId == Int32.Parse(txtUid.Text));
                if (founduser != null)
                {
                    founduser.ImieiNazwisko = utxtUName.Text;
                    founduser.Adres = utxtUadres.Text;
                    founduser.UpdatedAt = DateTime.Now;
                    context.SaveChanges();
                }

            }
        }
    }
}
