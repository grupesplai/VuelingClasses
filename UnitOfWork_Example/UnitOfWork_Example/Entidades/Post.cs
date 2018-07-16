using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork_Example.Modelo
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public bool IsPostCommentsClosed { get; set; }
        public int Visits { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateCreated { get; set; }

        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
