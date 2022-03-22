using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DataContext
    {
        public IList<Message> Messages { get; set; }

        public DataContext()
        {
            this.Messages = new List<Message>();
        }
    }
}
