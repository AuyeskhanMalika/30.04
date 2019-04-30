using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNews
{
    public class News : Entity
    {
        public string Uncos { get; set; }
        public string UncosAuthor { get; set; }
        public DateTime DateOfPublication { get; set; }
        public ICollection<NewsComments> newsComments { get; set; }
    }
}
