using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class InfF_Generador : Component
    {
        public static string Inserta_ReposicionSucursal(int EmpId,string CodigoArticulo,string DescripArt,int CodigoBodega,decimal StockBod1,decimal StockCD,decimal CantEnviar,decimal Maximo,decimal PorcStock,int Embalaje,decimal PorcStockReal,decimal Calculo,string Sector,DateTime Fecha,string Rotacion,decimal SolTrasOpen,string Marca,string Lista,decimal RecepPendiente,decimal RecepPendiente50CD,int Borrar)
        {
            //OleDbConnection myConnection = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            OleDbConnection myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1436;Initial Catalog=Getpoint_GH_Test;Persist Security Info=True");
            OleDbCommand myCommand = new OleDbCommand("sp_in_ReposicionSucursal", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@EmpId", OleDbType.Integer).Value = EmpId;
            myCommand.Parameters.Add("@CodigoArticulo", OleDbType.VarChar).Value = CodigoArticulo;
            myCommand.Parameters.Add("@DescripArt", OleDbType.VarChar).Value = DescripArt;
            myCommand.Parameters.Add("@CodigoBodega ", OleDbType.Integer ).Value = CodigoBodega;
            myCommand.Parameters.Add("@StockBod1", OleDbType.Decimal).Value = StockBod1;
            myCommand.Parameters.Add("@StockCD", OleDbType.Decimal).Value = StockCD;
            myCommand.Parameters.Add("@CantEnviar", OleDbType.Decimal).Value = CantEnviar;
            myCommand.Parameters.Add("@Maximo", OleDbType.Decimal).Value = Maximo;
            myCommand.Parameters.Add("@PorcStock", OleDbType.Decimal).Value = PorcStock;
            myCommand.Parameters.Add("@Embalaje ", OleDbType.Integer).Value = Embalaje;
            myCommand.Parameters.Add("@PorcStockReal", OleDbType.Decimal).Value = PorcStockReal;
            myCommand.Parameters.Add("@CALCULO", OleDbType.Decimal).Value = Calculo;
            myCommand.Parameters.Add("@Sector ", OleDbType.VarChar).Value = Sector;
            myCommand.Parameters.Add("@Fecha ", OleDbType.Date).Value = Fecha;
            myCommand.Parameters.Add("@Rotacion ", OleDbType.VarChar).Value = Rotacion;
            myCommand.Parameters.Add("@SolTrasOpen ", OleDbType.Decimal).Value = SolTrasOpen;
            myCommand.Parameters.Add("@Marca ", OleDbType.VarChar).Value = Marca;
            myCommand.Parameters.Add("@Lista ", OleDbType.VarChar).Value = Lista;
            myCommand.Parameters.Add("@RecepPendiente ", OleDbType.Decimal).Value = RecepPendiente;
            myCommand.Parameters.Add("@RecepPendiente50CD", OleDbType.Decimal).Value = RecepPendiente50CD;
            myCommand.Parameters.Add("@Borrar", OleDbType.Integer).Value = Borrar;

            string result;
            try
            {
                myCommand.CommandTimeout = 99999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = "Error";
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }
    }
    internal class Class1
    {
    }
       
}
