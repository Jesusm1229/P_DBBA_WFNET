using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_DBBA_WFNET.Models;
using System.IO;

namespace P_DBBA_WFNET
{
    public class FileCSV
    {
        private List<Book> books = new List<Book>();
        private string line;

        public void readFileCSV() {

            
            StreamReader file = new StreamReader(@"..\..\CSV\books.csv");

            while ((line = file.ReadLine()) != null) {
                 Book book = extractElements(line);
                 books.Add(book);
            }

            file.Close();
        }

        public Book extractElements(string line) {

            Book book = new Book();
            byte element = 0;
            string cad = "";
            bool flag = false;

            for (ushort counter = 0; counter < line.Length; counter++) {

                switch (element) {

                    case 0: 
                            if ((line[counter] >= 48 && line[counter] <= 57))
                                cad = cad + line[counter];
                            else if(line[counter] == ','){
                                book.Isbn = Int64.Parse(cad);
                                cad = "";
                                element++;
                            }

                            break;
                    case 1:
                            if (line[counter] == '"')
                                flag = true;

                            if ((line[counter] == ',' && line[counter - 1] == '"' && flag) || (!flag && line[counter] == ',')) {
                                book.Title = cad;
                                cad = "";
                                element++;
                                flag = false;
                            }
                            else if ((line[counter] >= 65 && line[counter] <= 90) || (line[counter] >= 97 && line[counter] <= 122) || (line[counter] >= 48 && line[counter] <= 58) || (line[counter] >= 32 && line[counter] <= 33) || (line[counter] >= 35 && line[counter] <= 46))
                                cad = cad + line[counter];

                            break;
                    case 2:

                            if (line[counter] == '"')
                                flag = true;
                       
                           if ((line[counter] == ',' && line[counter - 1] == '"' && flag) || (!flag && line[counter] == ',')) {
                                book.Author = cad;
                                cad = "";
                                element++;
                                flag = false;
                            }
                           else if((line[counter] >= 65 && line[counter] <= 90) || (line[counter] >= 97 && line[counter] <= 122) || line[counter] == 32 || line[counter] == 46 || line[counter] == 44)
                                cad = cad + line[counter];

                           break;
                    case 3:
                            if (line[counter] >= 48 && line[counter] <= 57)
                                cad = cad + line[counter];
                            
                            if((counter + 1) == line.Length) 
                                book.Year = Int32.Parse(cad);

                            break;
                }
            }
            return book;
        }

        public List<Book> getBooks() {
            return books;
        }
    }
}