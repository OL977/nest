using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Configuration;


namespace WPFПроба
{
    class Подключение
    {
        public int errds = 0;
        //string ConnString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dataWPF;Integrated Security=SSPI";
        string ConnString = @"Data Source=45.14.50.13\723\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=dataWPF;User ID=User1;Password=";


        public void  Start()
        {
            //SqlConnectionStringBuilder connect = new SqlConnectionStringBuilder();

            using (SqlConnection cn=new SqlConnection())
            {
                cn.ConnectionString = ConnString;
                try
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    
                }
                catch
                {

                }         


            }
        }
        public static DataTable Selects(string d)            
        {
            //string ConnString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dataWPF;Integrated Security=SSPI";
            string ConnString = @"Data Source=45.14.50.13\723\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=dataWPF;User ID=User1;Password=";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                //SqlCommand cmd = new SqlCommand(d, connection);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(d,connection); //создаем адаптер для связи с данными. 
               /* adapter.SelectCommand = new SqlCommand(d, connection); */// указываем ему команду для выборки

                //SqlDataReader dr = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                
                try
                {
                    adapter.Fill(ds);//заполняем датасет с помощьб адаптера (будет исполнена команда на выборку)
                    dt = ds.Tables[0];


                    return dt;
                }
                catch (Exception ex)
                {
                    
                   Console.WriteLine(ex.ToString());
                    Console.Read();
                }
                finally
                {
                    connection.Close();
                    //adapter.Dispose();
                }             
                
            }
            
            return dt;
        }
        public void Updates(string d)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(d, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

    }
}
