using System.Collections.Generic;

namespace Models
{
    public class DataContext
    {
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
