using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    public class UserViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public DbUserContext Context { get; set; }
        public User SelectedUser { get; set; }

    }
}
