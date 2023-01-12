using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libraryProject;

namespace WpfApp1.Models
{
    public class User : Ilibraryproject
    {
        public string ImieiNazwisko { get; set; }
        public int UserId { get; set; }
        public string Adres { get; set; }

        //relacje 1 user do wielu company
        public ICollection<Company> Company { get; set; }
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
    }
}
