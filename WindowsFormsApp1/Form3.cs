using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void cmbServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection myConnection = new OleDbConnection();

            if (cmbServidor.SelectedIndex == 0) //36
            {
                myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1436;Initial Catalog=Alertas;Persist Security Info=True");
            }

            if (cmbServidor.SelectedIndex == 1) //35
            {
                myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=Alertas;Persist Security Info=True");
            }

            if (cmbServidor.SelectedIndex == 2) //37
            {
                myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1437;Initial Catalog=Alertas;Persist Security Info=True");
            }

            OleDbCommand myCommand = new OleDbCommand("BasesClientes", myConnection);
            DataSet myDataSet = new DataSet();
            myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.Parameters.Add("@Servidor", OleDbType.Integer).Value = idpedido.ToString().Trim();

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();

                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "BasesClientes");
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }

            cmbCliente.DisplayMember = "Valor";
            cmbCliente.ValueMember = "Valor";
            cmbCliente.DataSource = myDataSet.Tables["BasesClientes"];

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection myConnection = new OleDbConnection();

            if (cmbServidor.SelectedIndex == 0) //36
            {
                myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1436;Initial Catalog=Alertas;Persist Security Info=True");
            }

            if (cmbServidor.SelectedIndex == 1) //35
            {
                myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=Alertas;Persist Security Info=True");
            }

            if (cmbServidor.SelectedIndex == 2) //37
            {
                myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1437;Initial Catalog=Alertas;Persist Security Info=True");
            }

            OleDbCommand myCommand = new OleDbCommand("Articulos", myConnection);
            DataSet myDataSet = new DataSet();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@Database", OleDbType.VarChar).Value = cmbCliente.SelectedValue.ToString();

            ////try
            ////{
            ////    myCommand.CommandTimeout = 9999;
            ////    myConnection.Open();

            ////    OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            ////    myAdapter.SelectCommand = myCommand;
            ////    myAdapter.Fill(myDataSet, "Articulos");
            ////}
            ////catch (Exception ee)
            ////{
            ////    throw new Exception(ee.Message);
            ////}
            ////finally
            ////{
            ////    myConnection.Close();
            ////    myConnection.Dispose();
            ////}

            ////dataGridView1.DataSource = myDataSet.Tables[0];
            //dataGridView1.DataMember = "Table1";
        }
    }
}
