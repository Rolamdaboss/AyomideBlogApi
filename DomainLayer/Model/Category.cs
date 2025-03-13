using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Category : BaseModel
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public string Name { get; set; }
       
        public virtual ICollection<Post> Posts { get; set; }
    }
}
