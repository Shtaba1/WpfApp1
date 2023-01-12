using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libraryProject;

namespace WpfApp1.Models
{

    // W tym miejscu mozemy rozszerzac klase nie martwiac sie o DBset, Dbset dla DBCompany nie zostal zrobiony 
    public class Company : Ilibraryproject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Adres { get; set; }
        
        //relacje 1 firma do 1 usera

        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
    }
}
