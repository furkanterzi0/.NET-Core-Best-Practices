using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.Api.Data.Models
{
    public class Contact //veri tabanında ne varsa burada da o var dışarıya donen model DVO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    } 
}
