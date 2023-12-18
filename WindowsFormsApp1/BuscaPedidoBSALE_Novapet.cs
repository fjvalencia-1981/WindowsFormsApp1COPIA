using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Web;
using System.Net.Http;
using WS_itec2.clases.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using WindowsFormsApp1.WsHoffensV2;
using RestSharp;
using System.Net.Http.Headers;

using System.Net;
using System.Diagnostics;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

using System.Data.Sql;
using System.Configuration;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class BuscaPedidoBSALE_Novapet : Form
    {

        private Form2 Form2 = new Form2();

        public BuscaPedidoBSALE_Novapet()
        {
            InitializeComponent();
        }

        public class Variants
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public int id { get; set; }

            [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
            public string description { get; set; }

            [JsonProperty("unlimitedStock", NullValueHandling = NullValueHandling.Ignore)]
            public int unlimitedStock { get; set; }

            [JsonProperty("allowNegativeStock", NullValueHandling = NullValueHandling.Ignore)]
            public int allowNegativeStock { get; set; }

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public int state { get; set; }

            [JsonProperty("barCode", NullValueHandling = NullValueHandling.Ignore)]
            public string barCode { get; set; }

            [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
            public string code { get; set; }

            [JsonProperty("imagestionCenterCost", NullValueHandling = NullValueHandling.Ignore)]
            public int imagestionCenterCost { get; set; }

            [JsonProperty("imagestionAccount", NullValueHandling = NullValueHandling.Ignore)]
            public int imagestionAccount { get; set; }

            [JsonProperty("imagestionConceptCod", NullValueHandling = NullValueHandling.Ignore)]
            public int imagestionConceptCod { get; set; }

            [JsonProperty("imagestionProyectCod", NullValueHandling = NullValueHandling.Ignore)]
            public int imagestionProyectCod { get; set; }

            [JsonProperty("imagestionCategoryCod", NullValueHandling = NullValueHandling.Ignore)]
            public int imagestionCategoryCod { get; set; }

            [JsonProperty("imagestionProductId", NullValueHandling = NullValueHandling.Ignore)]
            public int imagestionProductId { get; set; }

            [JsonProperty("serialNumber", NullValueHandling = NullValueHandling.Ignore)]
            public int serialNumber { get; set; }

            [JsonProperty("prestashopCombinationId", NullValueHandling = NullValueHandling.Ignore)]
            public int prestashopCombinationId { get; set; }

            [JsonProperty("prestashopValueId", NullValueHandling = NullValueHandling.Ignore)]
            public int prestashopValueId { get; set; }

            [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
            public Product product { get; set; }

            [JsonProperty("attribute_values", NullValueHandling = NullValueHandling.Ignore)]
            public AttributeValues attribute_values { get; set; }

            [JsonProperty("costs", NullValueHandling = NullValueHandling.Ignore)]
            public Costs costs { get; set; }
        }

        public class Product
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }
        }

        public class AttributeValues
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        }

        public class Costs
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        }


        private async void button25_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            txtWebhook.Text = "";
            textBox5.Text = "";

            txtAPI1.Text = "";
            txtRES1.Text = "";
            txtRES2.Text = "";

            txtWebhook.Text = "";
            txtAnterior.Text = "";
            txtSiguiente.Text = "";
            txtWebhookID.Text = "";
            label13.Text = "";
            txtInsertaWebhook.Text = "";
            pictureBox1.Visible = false;

            if (txtPedidoNovapet.Text.Trim() == "")
            {
                return;
            }

            pictureBox1.Visible = true;

            //formulario procesando ---------
            MuestraProcesando();

            //busca pedido en Getpoint -----------------------------------------------

            //cabecera ---------------------------------------------------------------------------------------------------------------------------------------------
            OleDbConnection myConnectionPed = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=NOVAPET;Persist Security Info=True");
            OleDbDataAdapter myAdapterPed = new OleDbDataAdapter();
            OleDbCommand myCommandCab = new OleDbCommand("CabeceraPedido", myConnectionPed);
            DataSet myDataSetCab = new DataSet();

            try
            {
                myCommandCab.CommandType = CommandType.StoredProcedure;
                myCommandCab.Parameters.Add("@NumeroReferencia", OleDbType.VarChar).Value = txtPedidoNovapet.Text.Trim();
                myCommandCab.CommandTimeout = 9999;
                myConnectionPed.Open();
                myAdapterPed.SelectCommand = myCommandCab;
                myAdapterPed.Fill(myDataSetCab, "CabeceraPedido");
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                myConnectionPed.Close();
                myConnectionPed.Dispose();
            }

            label13.Text = "";
            if (myDataSetCab.Tables[0].Rows.Count == 0)
            {
                label13.Text = "PEDIDO NO EXISTE EN GETPOINT";
            }

            gridCabecera.DataSource = myDataSetCab.Tables[0];
            //gridCabecera.DataMember = "CabeceraPedido";

            //detalle ---------------------------------------------------------------------------------------------------------------------------------------------

            myConnectionPed = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=NOVAPET;Persist Security Info=True");
            myAdapterPed = new OleDbDataAdapter();
            OleDbCommand myCommandDet = new OleDbCommand("DetallePedido", myConnectionPed);
            DataSet myDataSetDet = new DataSet();

            try
            {
                myCommandDet.CommandType = CommandType.StoredProcedure;
                myCommandDet.Parameters.Add("@NumeroReferencia", OleDbType.VarChar).Value = txtPedidoNovapet.Text.Trim();
                myCommandDet.CommandTimeout = 9999;
                myConnectionPed.Open();
                myAdapterPed.SelectCommand = myCommandDet;
                myAdapterPed.Fill(myDataSetDet, "DetallePedido");
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                myConnectionPed.Close();
                myConnectionPed.Dispose();
            }

            gridDetalle.DataSource = myDataSetDet.Tables[0];
            //gridDetalle.DataMember = "DetallePedido";


            // llamado version 1, restclient ---------------------------------------------------------------------------------------------
            var client = new RestClient("https://api.bsale.cl/v1/documents.json?number=" + txtPedidoNovapet.Text.Trim());
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("access_token", "c79c0a87ce6966a0e0e87954552aa993d4129373");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //Ejecuta llamado de la API --------------
            IRestResponse response = client.Execute(request);
            HttpStatusCode CodigoRetorno = response.StatusCode;

            long maximafecha = 0;
            long idpedido = 0;
            long idDocto = 0;
            string tipoDocto = "";
            string rutaPDF = "";

            //Si finalizó OK --------------------------
            if (CodigoRetorno.Equals(HttpStatusCode.OK))
            {
                JObject rss = JObject.Parse(response.Content);

                for (Int32 w = 0; w < rss["items"].Count(); w++)
                {
                    if (maximafecha < long.Parse(rss["items"][w]["generationDate"].ToString()))
                    {
                        maximafecha = long.Parse(rss["items"][w]["generationDate"].ToString());
                        idpedido = long.Parse(rss["items"][w]["id"].ToString());
                        idDocto = long.Parse(rss["items"][w]["document_type"]["id"].ToString());
                        rutaPDF = rss["items"][w]["urlPdfOriginal"].ToString();
                    }
                }

                if (idpedido != 0)
                {
                    //------------------------------------------------------------------------------------------------------------
                    var client2 = new RestClient("https://api.bsale.cl/v1/document_types/" + idDocto.ToString().Trim() + ".json");
                    client2.Timeout = -1;
                    var request2 = new RestRequest(Method.GET);
                    request2.AddHeader("Content-Type", "application/json");
                    request2.AddHeader("access_token", "c79c0a87ce6966a0e0e87954552aa993d4129373");
                    var body2 = @"";
                    request.AddParameter("application/json", body2, ParameterType.RequestBody);

                    //Ejecuta llamado de la API --------------
                    IRestResponse response2 = client2.Execute(request2);
                    HttpStatusCode CodigoRetorno2 = response2.StatusCode;

                    //Si finalizó OK --------------------------
                    if (CodigoRetorno2.Equals(HttpStatusCode.OK))
                    {
                        JObject rss2 = JObject.Parse(response2.Content);

                        tipoDocto = ", Tipo Docto: " + rss2["name"].ToString();
                    }

                    //-------------------------------------------------------------------------------------------------
                    var client3 = new RestClient("https://api.bsale.cl/v1/documents/" + idpedido.ToString().Trim() + ".json?expand=[document_types,details,variant,client]");

                    //ruta llamado api principal
                    txtAPI1.Text = "https://api.bsale.cl/v1/documents/" + idpedido.ToString().Trim() + ".json?expand=[document_types,details,variant,client]";

                    client3.Timeout = -1;
                    var request3 = new RestRequest(Method.GET);
                    request3.AddHeader("Content-Type", "application/json");
                    request3.AddHeader("access_token", "c79c0a87ce6966a0e0e87954552aa993d4129373");
                    var body3 = @"";
                    request.AddParameter("application/json", body3, ParameterType.RequestBody);

                    //Ejecuta llamado de la API --------------
                    IRestResponse response3 = client3.Execute(request3);
                    HttpStatusCode CodigoRetorno3 = response3.StatusCode;

                    string items = "";
                    string salto = "\r\n";

                    string detalleItems = "";

                    //Si finalizó OK --------------------------
                    if (CodigoRetorno3.Equals(HttpStatusCode.OK))
                    {
                        JObject rss3 = JObject.Parse(response3.Content);

                        //guarda respuesta API principal
                        txtRES1.Text = response3.Content.ToString();

                        for (Int32 z = 0; z < rss3["details"]["items"].Count(); z++)
                        {
                            if (items.Trim() == "")
                            {
                                items = rss3["details"]["items"][z]["variant"]["code"].ToString();
                            }
                            else
                            {
                                items = items + salto + rss3["details"]["items"][z]["variant"]["code"].ToString();
                            }

                            //============================
                            //CONSULTA VARIANTE Y VALIDA ESTADO DISTINTO  A 55 PARA BAJAR A WMS
                            string sssUrlRequest = rss3["details"]["items"][z]["variant"]["href"].ToString(); ;

                            var client_rest = new RestClient(sssUrlRequest);
                            client_rest.Timeout = -1;
                            request = new RestRequest(Method.GET);
                            request.AddHeader("Content-Type", "application/json");
                            request.AddHeader("access_token", "c79c0a87ce6966a0e0e87954552aa993d4129373");
                            var response_rest = client_rest.Execute(request);
                            var vvvalor = response_rest.Content;
                            //FIN nuevo llamado ---------

                            var VariantsDetalle = JsonConvert.DeserializeObject<Variants>(vvvalor);

                            detalleItems = detalleItems + sssUrlRequest.Trim() + salto;
                            detalleItems = detalleItems + response_rest.Content.ToString() + salto;
                            detalleItems = detalleItems + "=========================================================================" + salto + salto;

                            //state <> 55 debe insertar
                            //if (VariantsDetalle.state.ToString().Trim() != "55")
                            //{
                            //    InsertaIntegracion = true;
                            //}
                            //else
                            //{
                            //    InsertaIntegracion = false;
                            //}
                            //============================

                        }

                        txtRES2.Text = detalleItems;
                        textBox2.Text = items;
                    }

                    //-------------------------------------------------------------------------------------------------
                    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    dtDateTime = dtDateTime.AddSeconds(maximafecha).ToLocalTime();

                    textBox4.Text = "Id interno: " + idpedido.ToString().Trim() + ", fecha: " + maximafecha.ToString().Trim() + " (" + dtDateTime.ToString("dd/MM/yyyy") + ") " + tipoDocto.Trim();
                    textBox1.Text = rutaPDF.Trim();

                    //Crea script de insert para insertar en tabla de webhook --
                    txtInsertaWebhook.Text = @"insert into L_WebHookBsale" + salto +
                                             @"		(FechaProceso,NombreProceso,Estado,Json,Texto1,Texto2,Texto3,Texto4,Texto5,Texto6,Texto7,Texto8,Texto9,Texto10,EstadoRevision,NroIntentos)" + salto +
                                             @"select	Getdate()" + salto +
                                             @"		,'' --NombreProceso" + salto +
                                             @"		,1 --Estado" + salto +
                                             @"		,'{    ""cpnId"": 11787,    ""resource"": ""/documents/" + idpedido.ToString().Trim() + @".json"",    ""resourceId"": """ + idpedido.ToString().Trim() + @""",    ""topic"": ""document"",    ""action"": ""post"",    ""officeId"": ""1"",    ""send"": " + maximafecha.ToString().Trim() + @"  }' --Json" + salto +
                                             @"		,'    ""cpnId"": 11787' --Texto1" + salto +
                                             @"		,'    ""resource"": ""/documents/" + idpedido.ToString().Trim() + @".json""' --Texto2" + salto +
                                             @"		,'    ""resourceId"": """ + idpedido.ToString().Trim() + @"""' --Texto3" + salto +
                                             @"		,'    ""topic"": ""document""' --Texto4" + salto +
                                             @"		,'    ""action"": ""post""' --Texto5" + salto +
                                             @"		,'    ""officeId"": ""1""' --Texto6" + salto +
                                             @"		,'    ""send"": " + maximafecha.ToString().Trim() + @"  ' --Texto7" + salto +
                                             @"		,'' --Texto8" + salto +
                                             @"		,'' -- Texto9" + salto +
                                             @"		,'' --Texto10" + salto +
                                             @"		,'' --EstadoRevision" + salto +
                                             @"		,0 --NroIntentos";

                    //--------------------------------------------------------------------------------

                    //REVISA SI EL PEDIDO ESTA EN LA TABLA DE WEBHOOK

                    DataSet myDataSet = new DataSet();
                    OleDbConnection myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=NOVAPET;Persist Security Info=True");
                    OleDbCommand myCommand = new OleDbCommand("BuscaWebhook", myConnection);

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Add("@documento", OleDbType.Integer).Value = idpedido.ToString().Trim();

                    try
                    {
                        myCommand.CommandTimeout = 9999;
                        myConnection.Open();

                        OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                        myAdapter.SelectCommand = myCommand;
                        myAdapter.Fill(myDataSet, "BuscaWebhook");
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

                    if (myDataSet.Tables[0].Rows[0]["salida"].ToString().Trim() != "No existe en Webhook")
                    {
                        txtWebhook.Text = "PEDIDO:" + salto +
                                        "id     : " + myDataSet.Tables[0].Rows[0]["id"].ToString().Trim() + salto +
                                        "Fecha  : " + myDataSet.Tables[0].Rows[0]["fechaproceso"].ToString().Trim() + salto +
                                        "Estado : " + myDataSet.Tables[0].Rows[0]["estado"].ToString().Trim() + salto +
                                        "JSON   : " + myDataSet.Tables[0].Rows[0]["salida"].ToString().Trim();
                        txtWebhookID.Text = myDataSet.Tables[0].Rows[0]["id"].ToString().Trim();
                    }
                    else
                    {
                        txtWebhook.Text = "PEDIDO:" + salto +
                                        "No existe en Webhook";
                        txtWebhookID.Text = "";
                    }

                    //BUSCA PEDIDO ANTERIOR -----------------------------------------------------------------------------
                    DataSet myDataSet2 = new DataSet();
                    OleDbConnection myConnection2 = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=NOVAPET;Persist Security Info=True");
                    OleDbCommand myCommand2 = new OleDbCommand("BuscaWebhook", myConnection2);

                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.Parameters.Add("@documento", OleDbType.Integer).Value = (idpedido - 1).ToString().Trim();

                    try
                    {
                        myCommand2.CommandTimeout = 9999;
                        myConnection2.Open();

                        OleDbDataAdapter myAdapter2 = new OleDbDataAdapter();
                        myAdapter2.SelectCommand = myCommand2;
                        myAdapter2.Fill(myDataSet2, "BuscaWebhook");
                    }
                    catch (Exception ee)
                    {
                        throw new Exception(ee.Message);
                    }
                    finally
                    {
                        myConnection2.Close();
                        myConnection2.Dispose();
                    }

                    if (myDataSet2.Tables[0].Rows[0]["salida"].ToString().Trim() != "No existe en Webhook")
                    {
                        txtAnterior.Text = "PEDIDO ANTERIOR:" + salto +
                                        "id interno : " + myDataSet2.Tables[0].Rows[0]["id"].ToString().Trim() + salto +
                                        "Fecha      : " + myDataSet2.Tables[0].Rows[0]["fechaproceso"].ToString().Trim() + salto +
                                        "Estado     : " + myDataSet2.Tables[0].Rows[0]["estado"].ToString().Trim() + salto +
                                        "JSON       : " + myDataSet2.Tables[0].Rows[0]["salida"].ToString().Trim();

                    }
                    else
                    {
                        txtAnterior.Text = "No existe en Webhook el pedido anterior";
                    }
                    //BUSCA PEDIDO SIGUIENTE -----------------------------------------------------------------------------
                    DataSet myDataSet3 = new DataSet();
                    OleDbConnection myConnection3 = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=NOVAPET;Persist Security Info=True");
                    OleDbCommand myCommand3 = new OleDbCommand("BuscaWebhook", myConnection3);

                    myCommand3.CommandType = CommandType.StoredProcedure;
                    myCommand3.Parameters.Add("@documento", OleDbType.Integer).Value = (idpedido + 1).ToString().Trim();

                    try
                    {
                        myCommand3.CommandTimeout = 9999;
                        myConnection3.Open();

                        OleDbDataAdapter myAdapter3 = new OleDbDataAdapter();
                        myAdapter3.SelectCommand = myCommand3;
                        myAdapter3.Fill(myDataSet3, "BuscaWebhook");
                    }
                    catch (Exception ee)
                    {
                        throw new Exception(ee.Message);
                    }
                    finally
                    {
                        myConnection3.Close();
                        myConnection3.Dispose();
                    }

                    if (myDataSet3.Tables[0].Rows[0]["salida"].ToString().Trim() != "No existe en Webhook")
                    {
                        txtSiguiente.Text = "PEDIDO SIGUIENTE:" + salto +
                                        "id interno : " + myDataSet3.Tables[0].Rows[0]["id"].ToString().Trim() + salto +
                                        "Fecha      : " + myDataSet3.Tables[0].Rows[0]["fechaproceso"].ToString().Trim() + salto +
                                        "Estado     : " + myDataSet3.Tables[0].Rows[0]["estado"].ToString().Trim() + salto +
                                        "JSON       : " + myDataSet3.Tables[0].Rows[0]["salida"].ToString().Trim();
                    }
                    else
                    {
                        txtSiguiente.Text = "No existe en Webhook el pedido siguiente";
                    }
                    //--------------------------------------------------------------------------------

                    textBox5.Text = @"--primero copiar un registro existente" + salto +
                                    @"select * into #a from L_WebHookBsale (nolock) where texto2 like '%document%' and texto2 like'%" + (idpedido - 1).ToString().Trim() + "%'" + salto + salto +
                                    @"declare @id varchar(30) = '" + idpedido.ToString() + "'-- id que insertaremos" + salto +
                                    @"       ,@fecha varchar(15) = '" + maximafecha.ToString().Trim() + "'-- fecha de ese id" + salto + salto +
                                    @"update #a " + salto +
                                    @"set json = '{    ""cpnId"": 11787,    ""resource"": ""/documents/' + ltrim(rtrim(@id)) + '.json"",    ""resourceId"": ""' + ltrim(rtrim(@id)) + '"",    ""topic"": ""document"",    ""action"": ""post"",    ""officeId"": ""1"",    ""send"": ' + ltrim(rtrim(@fecha)) + '  }'" + salto +
                                    @",texto2 = '    ""resource"": ""/documents/' + ltrim(rtrim(@id)) + '.json""'" + salto +
                                    @",texto3 = '    ""resourceId"": ""' + ltrim(rtrim(@id)) + '""'" + salto +
                                    @",texto7 = '    ""send"": ' + ltrim(rtrim(@fecha)) + '  '" + salto +
                                    @",estado = 1" + salto +
                                    @",EstadoRevision = ''" + salto +
                                    @",NroIntentos = 0 " + salto + salto +
                                    @"insert into L_WebHookBsale" + salto +
                                    @"(FechaProceso,NombreProceso,Estado,Json,Texto1,Texto2,Texto3,Texto4,Texto5,Texto6,Texto7,Texto8,Texto9,Texto10,EstadoRevision,NroIntentos)" + salto +
                                    @"select getdate(),NombreProceso,Estado,Json,Texto1,Texto2,Texto3,Texto4,Texto5,Texto6,Texto7,Texto8,Texto9,Texto10" + salto +
                                    @"from #a" + salto + salto +
                                    @"drop table #a";

                    //Thread.Sleep(2000); //pausa de 2 segundos

                    CierraForm();

                    this.Show();
                    MessageBox.Show("Id interno: " + idpedido.ToString().Trim() + ", fecha: " + maximafecha.ToString().Trim() + " (" + dtDateTime.ToString("dd/MM/yyyy") + ") " + tipoDocto.Trim());
                    this.Show();
                }
            }
            else
            {
                CierraForm();
            }

            //cierra formulario procesando -----------

            //pictureBox1.Visible = false;
            

            //formulario procesando ---------
            //Task oTask = new Task(MuestraProcesando);
            //oTask.Start();
            //await oTask;
        }

        public void MuestraProcesando()
        {
            //Form2 = new Form2();
            //Form2.Show();

            Task.Factory.StartNew(() => { Form2.ShowDialog(); });

            Thread.Sleep(1000);
        }

        public void CierraForm()
        {
            //if (Form2 != null)
            //{
            //    Form2.Close();
            //}

            Invoke(new MethodInvoker(() => { Form2.Close(); }));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BuscaPedidoBSALE_Novapet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtWebhookID.Text.Trim().Length > 0) 
            {
                if (MessageBox.Show("Quieres reprocesar el registro existente?", "Seguro???", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string resultado;

                    resultado = EjecutaSQL("update L_WebHookBsale set Estado = 1 where Id = " + txtWebhookID.Text.Trim());

                    if (resultado.Trim() == "OK")
                    {
                        MessageBox.Show("Reprocesado OK");
                    }
                    else
                    {
                        MessageBox.Show("No lo pudo reprocesar");
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay nada que reprocesar, debes insertar un registro");
            }
        }

        public static string EjecutaSQL(string SentenciaSQL)
        {
            string Resultado = "";

            OleDbConnection myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=NOVAPET;Persist Security Info=True");
            //myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1435;Initial Catalog=Alertas;Persist Security Info=True");
            OleDbCommand myCommand = new OleDbCommand(SentenciaSQL, myConnection);

            myCommand.CommandType = CommandType.Text;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();
                myCommand.ExecuteNonQuery();

                Resultado = "OK";
            }
            catch (Exception ee)
            {
                Resultado = ee.Message.ToString();
                throw new Exception(ee.Message.ToString());
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }

            return Resultado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtInsertaWebhook.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("Quieres insertar un registro en el Webhook? ", "Seguro???", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string resultado;

                    resultado = EjecutaSQL(txtInsertaWebhook.Text.Trim());

                    if (resultado.Trim() == "OK")
                    {
                        MessageBox.Show("Insertado en el Webhook OK");
                    }
                    else
                    {
                        MessageBox.Show("No pude insertar");
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay codigo para insertar");
            }
        }
    }



}


