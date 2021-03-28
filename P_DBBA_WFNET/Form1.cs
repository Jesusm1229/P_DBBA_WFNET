using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data;
using P_DBBA_WFNET.Models;

namespace P_DBBA_WFNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connString = "Host=ec2-52-70-67-123.compute-1.amazonaws.com;Port=5432;Database=d1p1v068vm8sgl; User Id=wqpiymnsewyvom; Password=aa331e27c72537501ffe81dce122856c780d55abb30bd4d1c2d0543508f7a78e;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;";
        
        public NpgsqlConnection conn;  
        public NpgsqlCommand comm;

        private DataTable dtbooks, dtauthors;

        private string sql = null;

        
        private void Insert_Values()
        {
             FileCSV filecsv = new FileCSV();
             filecsv.readFileCSV();
             List<Book> books = filecsv.getBooks();
           
                 //Console.WriteLine("\n" + (counter + 1) + " " + books[counter].Isbn + " " + books[counter].Title + " " + books[counter].Author + " " + books[counter].Year);

             try
             {
                
                for (ushort counter = 0; counter < books.Count; counter++)
                {
                    conn.Open();
                    sql = @"select * from books_insert(:_isbn,:_tittle,:_author,:_year)";
                    comm = new NpgsqlCommand(sql, conn);

                    comm.Parameters.AddWithValue("_isbn", books[counter].Isbn.ToString());
                    comm.Parameters.AddWithValue("_tittle", books[counter].Title);
                    comm.Parameters.AddWithValue("_author", books[counter].Author);
                    comm.Parameters.AddWithValue("_year", books[counter].Year);

                    if ((int)comm.ExecuteScalar() == 1) //This is the comprobation of succes from the function INSERT
                    {
                        conn.Close();
                        //btnSelect.PerformClick(); //If the values insert into the table reload the table from the windows form
                    }
                }
              
            }
            catch (Exception ex)
            {
                     MessageBox.Show("Error Books: " + ex.Message, "INSERT FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     conn.Close();
             }


        }

        private void Insert_Values_Authors()
        {

            try
            {
                conn.Open();

                sql = "INSERT INTO authors(idbook, name) SELECT id, author FROM books";
                comm = new NpgsqlCommand();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                comm.CommandText = sql;

                comm.Prepare();
                comm.ExecuteNonQuery();
                comm.Dispose();
                                
                conn.Close();
            
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error AUTOR: " + ex.Message, "INSERT FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            conn = new NpgsqlConnection(connString);
            //Insert data from CSV to tables (INSERT)
            btnInsert.PerformClick();
            //Show data in tables (SELECT)
            btnSelect.PerformClick(); 

            
        }

        //Select button insert values from CSV to tables
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDataBook.DataSource = null;
                //Loading books
                conn.Open();

                sql = "select * from books_select()";

                comm = new NpgsqlCommand(sql, conn);
                dtbooks = new DataTable();
                dtbooks.Load(comm.ExecuteReader());
                dgvDataBook.DataSource = dtbooks; 

                //Loading authors
                sql = "select * from au_select()";

                comm = new NpgsqlCommand(sql, conn);
                dtauthors = new DataTable();
                dtauthors.Load(comm.ExecuteReader());
                dgvDataAuthor.DataSource = dtauthors;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Función para insertar en la tabla
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Insert_Values();
            Insert_Values_Authors();
                                          
          
        }
    }
}
