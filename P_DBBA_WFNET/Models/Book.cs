using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DBBA_WFNET.Models
{
    public class Book
    {
        public Book() { }

        public int Year { get; set; }

        public long Isbn { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}