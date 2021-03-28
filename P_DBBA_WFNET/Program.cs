using P_DBBA_WFNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_DBBA_WFNET
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            //FileCSV filecsv = new FileCSV();

            //filecsv.readFileCSV();

            //List<Book> books = filecsv.getBooks();

            //for (ushort counter = 0; counter < books.Count; counter++)
            //    Console.WriteLine("\n" + (counter + 1) + " " + books[counter].Isbn + " " + books[counter].Title + " " + books[counter].Author + " " + books[counter].Year);



        }
    }
}
