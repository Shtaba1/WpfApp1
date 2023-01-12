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
    /// Logika interakcji dla klasy NewCompanyWnd.xaml
    /// </summary>
    public partial class NewCompanyWnd : Window
    {
        public NewCompanyWnd()
        {
            InitializeComponent();

        }

        private void btnNewComapny_Click(object sender, RoutedEventArgs e)
        {
            var company = new Company
            {
                Name = txtName.Text,
                Category = txtCategory.Text,
                Adres = txtAdres.Text,

                CreatedAt = DateTime.Now,

                UserId = Int32.Parse(txtUser.Text)


            };
            using (var context = new DbUserContext())
            {
                context.Companies.Add(company);
                context.SaveChanges();
            }

            this.Close();

        }
    }
}
