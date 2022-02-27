using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ForImprove2._0
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            ConnectToData();
        }

        private static void ConnectToData()
        {
            
            
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();

                String query = "Select * from CheckList;";
                String query2 = "Select * from StatusStudent;";
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                MySqlCommand cmDB2 = new MySqlCommand(query2, conn);

                MySqlDataAdapter adapterCheckList = new MySqlDataAdapter();
                adapterCheckList.TableMappings.Add("Table", "CheckList");
                cmDB.CommandType = CommandType.Text;
                // Set the SqlDataAdapter's SelectCommand.
                adapterCheckList.SelectCommand = cmDB;
                // Fill the DataSet.
                DataSet dataSet = new DataSet("CheckList");
                adapterCheckList.Fill(dataSet);

                cmDB2.CommandType = CommandType.Text;
                MySqlDataAdapter adapterStatusStudent = new MySqlDataAdapter();
                adapterStatusStudent.TableMappings.Add("Table", "StatusStudent");
                adapterStatusStudent.SelectCommand = cmDB2;
                adapterStatusStudent.Fill(dataSet);

                conn.Close();

                // Create a DataRelation to link the two tables
                // based on the id_StatusStudent.
                DataColumn parentColumn =
                    dataSet.Tables["CheckList"].Columns["id_StatusStudent"];
                DataColumn childColumn =
                    dataSet.Tables["StatusStudent"].Columns["Id_StatusStudent"];
                DataRelation relation =
                    new DataRelation("CheckList_StatusStudent",
                    parentColumn, childColumn);
                dataSet.Relations.Add(relation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }
    }
}
