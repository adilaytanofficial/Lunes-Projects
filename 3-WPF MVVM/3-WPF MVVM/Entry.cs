using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_WPF_MVVM
{
    public class Entry
    {
        // Entry Class that has some parameters
        public int EntryId { get; set; } // a variable to hold values that are coming from database
        public string EntryTitle { get; set; } // a variable to hold values that are coming from database

        public string EntryPrice { get; set; } // a variable to hold values that are coming from database
        public string EntryYear { get; set; } // a variable to hold values that are coming from database
        public string EntryMonth { get; set; } // a variable to hold values that are coming from database

    }
}
