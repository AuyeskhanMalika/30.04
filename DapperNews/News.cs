using System;
using System.Collections.Generic;

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
