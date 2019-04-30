using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNews
{
    public class NewsComments : Entity
    {
        public string CommentAuthor { get; set; }
        public string Comment { get; set; }
        public DateTime DateOfCommentPosting { get; set; }
        public Guid NewsId { get; set; }
    }
}
