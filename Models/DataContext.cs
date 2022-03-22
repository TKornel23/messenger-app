using System.Collections.Generic;

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
