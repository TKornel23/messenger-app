using System.Collections.Generic;

namespace Models
{
    public static class DataContext
    {
        public static List<messenger> Messages { get; set; } = new List<messenger>();
    }
}
