using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Post : BaseModel
    {

        public Post()
        {
            categories = new HashSet<Category>();
        }

        public string Title { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Content { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Category> categories { get; set; }
    }
}
