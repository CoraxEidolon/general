using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {////////////////////

        /* Данная функция производит запросы  Select к БД *******************************************************************/
        private string[] InquirySelect(string inquiry, string field, int amount)
        {
            if (File.Exists(databaseWay) == true)
            {
                OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
                OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
                myOleDbCommand.CommandText = inquiry;// "SELECT TOP 1 Lines, Сolumns FROM Map1;";
                myOleDbConnection.Open();
                OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();
                string[] arResult = new string[amount];
                int i = 0;
                while (myOleDbDataReader.Read())
                {
                    arResult[i] = Convert.ToString(myOleDbDataReader[field]);
                    i++;
                }
                myOleDbDataReader.Close();
                myOleDbConnection.Close();
                return (arResult);
            }
            else
            {
                MessageBox.Show("Невозможно продолжить работу, база данных отсутствует");
                string[] arResult = new string[1];
                arResult[0] = "Невозможно продолжить работу, база данных отсутствует";
                return (arResult);
            }
        }


        /*Функция выполняет запросы, которые не возвращают значения *******************************************************************/
        private void InquiryUpdateInsertDeleteCreate(string inquiry)
        {
            if (File.Exists(databaseWay) == true)
            {
                OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
                OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
                myOleDbCommand.CommandText = inquiry;
                myOleDbConnection.Open();
                myOleDbCommand.ExecuteNonQuery();
                myOleDbConnection.Close();
            }
            else
            {
                MessageBox.Show("Невозможно продолжить работу, база данных отсутствует");
            }
        }

        /* Загрузка списка всех имеющихся таблиц *******************************************************************/
        private void tableLoad()
        {
            if (File.Exists(databaseWay) == true)
            {
                OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
                myOleDbConnection.Open();
                selectTable.Items.Clear();
                DataTable tbls = myOleDbConnection.GetSchema("Tables", new string[] { null, null, null, "TABLE" });

                foreach (DataRow row in tbls.Rows)
                {
                    string TableName = row["TABLE_NAME"].ToString();
                    selectTable.Items.Add(TableName);
                };
                myOleDbConnection.Close();
                //if (tbls.Rows.Count > 0){ selectTable.SelectedIndex = 0; }
                //else MessageBox.Show("Карты отсутствуют! Необходимо создать новые карты.");
            }
            else
            {
                MessageBox.Show("Невозможно продолжить работу, база данных отсутствует");
            }
        }
    }//////////////////

}