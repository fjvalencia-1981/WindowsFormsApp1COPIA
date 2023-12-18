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

using System.Xml.Serialization;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices.ComTypes;
using System.Web.UI.WebControls;

//using SAPbobsCOM;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public partial class clase_prueba
        {
            public string dato1 { get; set; }
            public string dato2 { get; set; }
        }

        public partial class Pedido_Cab
        {
            public string ORIGEN { get; set; }
            public int EMPID { get; set; }
            public string DESTINATARIO { get; set; }
            public string FOLIOGP { get; set; }
            public string FECHAGEN { get; set; }
            public string FECHAREQ { get; set; }
            public string VENDEDOR { get; set; }
            public string OBS1 { get; set; }
            public string OBS2 { get; set; }
            public string ESTADO { get; set; }
            public string NRODOCREL { get; set; }
            public string NROREFERENCIA { get; set; }
            public string DESCTOCAB { get; set; }
            public string LPRECIO { get; set; }

            public List<Pedido_Det> ITEMS = new List<Pedido_Det>();
        }

        public partial class Pedido_Det
        {
            public int LINEA { get; set; }
            public string CODIGOARTICULO { get; set; }
            public int CANTIDAD { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument _xmlDocument = new XmlDocument();
            XmlNodeList _xmlList;
            string xmlseg = "";
            string xml = "<CXP_DATA><DATOS_OT><ETIQUETA_EPL>&lt;CXP_ETIQUETA&gt;&lt;LINEA_DEF_1 /&gt;&lt;LINEA_DEF_2&gt;N&lt;/LINEA_DEF_2&gt;&lt;LINEA_DEF_3&gt;q800&lt;/LINEA_DEF_3&gt;&lt;LINEA_DEF_4&gt;Q400,24+0&lt;/LINEA_DEF_4&gt;&lt;LINEA_DEF_5&gt;S4&lt;/LINEA_DEF_5&gt;&lt;LINEA_DEF_6&gt;D12&lt;/LINEA_DEF_6&gt;&lt;LINEA_DEF_7&gt;ZB&lt;/LINEA_DEF_7&gt;&lt;LINEA_DAT_1&gt;A024,10,0,w,1,1,N,\"CHILEXPRESS\"&lt;/LINEA_DAT_1&gt;&lt;LINEA_DAT_2&gt;A234,10,0,a,1,1,N,\"6100303311\"&lt;/LINEA_DAT_2&gt;&lt;LINEA_DAT_3&gt;A420,0,0,d,1,1,N,\"712100820071\"&lt;/LINEA_DAT_3&gt;&lt;LINEA_DAT_4&gt;A730,0,0,d,1,1,N,\"E\"&lt;/LINEA_DAT_4&gt;&lt;LINEA_DAT_5&gt;A555,60,0,f,1,0,R,\"\"&lt;/LINEA_DAT_5&gt;&lt;LINEA_DAT_6&gt;A510,95,0,x,1,1,N,\"V.1.0 IMP:26-11-2020\"&lt;/LINEA_DAT_6&gt;&lt;LINEA_DAT_7&gt;A040,42,0,x,1,1,N,\"GRUPO\"&lt;/LINEA_DAT_7&gt;&lt;LINEA_DAT_8&gt;A040,60,0,x,1,1,N,\"Marcela Vera\"&lt;/LINEA_DAT_8&gt;&lt;LINEA_DAT_9&gt;A040,78,0,f,1,1,N,\"AVENIDA MANUEL MONTT 427\"&lt;/LINEA_DAT_9&gt;&lt;LINEA_DAT_10&gt;A040,97,0,f,1,1,N,\"REF:TEST-EOC-17\"&lt;/LINEA_DAT_10&gt;&lt;LINEA_DAT_11&gt;A655,038,0,d,1,1,N,\"\"&lt;/LINEA_DAT_11&gt;&lt;LINEA_DAT_12&gt;A400,37,0,x,1,1,N,\"\"&lt;/LINEA_DAT_12&gt;&lt;LINEA_DAT_13&gt;A655,086,0,a,1,1,N,\"01/01\"&lt;/LINEA_DAT_13&gt;&lt;LINEA_DAT_14&gt;LO617,84,160,2&lt;/LINEA_DAT_14&gt;&lt;LINEA_DAT_16&gt;A030,121,0,f,1,2,R,\"           (RM)PROVIDENCIA            \"&lt;/LINEA_DAT_16&gt;&lt;LINEA_DAT_17&gt;A340,121,0,f,1,2,R,\"           C MIGUEL CLARO-1                 \"&lt;/LINEA_DAT_17&gt;&lt;LINEA_DAT_18&gt;A621,121,0,f,1,2,R,\"          DHS         \"&lt;/LINEA_DAT_18&gt;&lt;LINEA_DAT_19&gt;LO026,38,752,2&lt;/LINEA_DAT_19&gt;&lt;LINEA_DAT_20&gt;LO026,38,2,126&lt;/LINEA_DAT_20&gt;&lt;LINEA_DAT_21&gt;LO777,38,2,126&lt;/LINEA_DAT_21&gt;&lt;LINEA_DAT_22&gt;LO617,38,2,126&lt;/LINEA_DAT_22&gt;&lt;LINEA_DAT_23&gt;LO026,117,752,2&lt;/LINEA_DAT_23&gt;&lt;LINEA_DAT_24&gt;LO026,164,752,2&lt;/LINEA_DAT_24&gt;&lt;LINEA_DAT_25&gt;B050,186,0,1,4,4,187,N,\"61003033117121008200710\"&lt;/LINEA_DAT_25&gt;&lt;LINEA_DAT_26&gt;A700,0,0,d,1,1,N,\"\"&lt;/LINEA_DAT_26&gt;&lt;LINEA_DAT_27&gt;FE&lt;/LINEA_DAT_27&gt;&lt;LINEA_DAT_28&gt;P1&lt;/LINEA_DAT_28&gt;&lt;LINEA_DAT_29 /&gt;&lt;/CXP_ETIQUETA&gt;</ETIQUETA_EPL></DATOS_OT></CXP_DATA>";
            string texto1, texto2, texto3, texto4, texto5, texto6, texto7, texto8, texto9, texto10, texto11, texto12, texto13, texto14, texto15, texto16, texto17, texto18, texto19, texto20, texto21, texto22, texto23, texto24, texto25, texto26, texto27, texto28, texto29, texto30, texto31, texto32, texto33, texto34, texto35, texto36, texto37;
            string epl = "";
            string json = "", URL = "";


            //inicio: hace llamada WebService que retorna xml

            //LLAMADO API
            //para llamado de ws
            URL = "https://testservices.wschilexpress.com/transport-orders/api/v1.0/transport-orders";
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Begin 2: Parametros para Header
            client.DefaultRequestHeaders.TryAddWithoutValidation("Cache-Control", "no-cache");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", "c9a0936881564c79bbb82433f341d9d3");
            //

            json = txtJsonChileExpress.Text;

            //RESPUESTA
            System.Net.Http.HttpContent content = new StringContent(json, UTF8Encoding.UTF8, "application/json"); //EJEMPLO DESDE BD
                                                                                                                  //System.Net.Http.HttpContent content = new StringContent(DATA_EJEMPLO, UTF8Encoding.UTF8, "application/json"); //EJEMPLO CON JSON EN DURO
            try
            {
                HttpResponseMessage messge = client.PostAsync(URL, content).Result;

                //string respuesta2 = messge.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(respuesta2);


                if (messge.IsSuccessStatusCode)
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //this.EscribeLog("Registro OK : " + respuesta);
                    MessageBox.Show(respuesta);
                    ChileExpress chileexpress = JsonConvert.DeserializeObject<ChileExpress>(respuesta);
                }
                else
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //this.EscribeLog("Registro Error : " + respuesta);
                    MessageBox.Show(respuesta);
                }
                content.Dispose();
                client.Dispose();
            }
            catch (Exception ex1)
            {
                //this.EscribeLog("Error Llamando ENDPOINT : " + ex1.Message + "; URL:" + URL + "; TOKEN:" + TOKEN + "; DATA:" + DATA);
                content.Dispose();
                client.Dispose();
            }
            //fin



            //reemplaza caracteres extraños de <>
            xml = xml.Replace("&lt;", "<").Replace("&gt;", ">");

            _xmlDocument.LoadXml(xml);

            //obtiene el comando EPL entero
            epl = _xmlDocument.InnerText;


            //obtiene el comando epl por partes 
            _xmlList = _xmlDocument.GetElementsByTagName("CXP_DATA");
            foreach (XmlNode _xmlNodo in _xmlList)
            {
                //foreach (XmlNode _xmlNodo2 in _xmlNodo.ChildNodes)
                {

                    xmlseg = _xmlNodo.InnerXml;
                    texto1 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DEF_1").InnerXml;
                    texto2 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DEF_2").InnerXml;
                    texto3 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DEF_3").InnerXml;
                    texto4 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DEF_4").InnerXml;
                    texto5 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DEF_5").InnerXml;
                    texto6 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DEF_6").InnerXml;
                    texto7 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DEF_7").InnerXml;
                    texto8 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_1").InnerXml;
                    texto9 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_2").InnerXml;
                    texto10 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_3").InnerXml;
                    texto11 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_4").InnerXml;
                    texto12 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_5").InnerXml;
                    texto13 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_6").InnerXml;
                    texto14 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_7").InnerXml;
                    texto15 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_8").InnerXml;
                    texto16 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_9").InnerXml;
                    texto17 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_10").InnerXml;
                    texto18 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_11").InnerXml;
                    texto19 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_12").InnerXml;
                    texto20 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_13").InnerXml;
                    texto21 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_14").InnerXml;
                    texto22 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_15").InnerXml;
                    texto23 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_16").InnerXml;
                    texto24 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_17").InnerXml;
                    texto25 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_18").InnerXml;
                    texto26 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_19").InnerXml;
                    texto27 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_20").InnerXml;
                    texto28 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_21").InnerXml;
                    texto29 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_22").InnerXml;
                    texto30 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_23").InnerXml;
                    texto31 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_24").InnerXml;
                    texto32 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_25").InnerXml;
                    texto33 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_26").InnerXml;
                    texto34 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_27").InnerXml;
                    texto35 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_28").InnerXml;
                    texto36 = _xmlNodo.SelectSingleNode("DATOS_OT/ETIQUETA_EPL/CXP_ETIQUETA/LINEA_DAT_29").InnerXml;
                }
            }


            //inserta en GP en tabla L_CabImpEtiquetas
            //con impresora Zebra_EPL
            //debe inserta en campo ZPL y TipoEtiqueta = 99

        }

        //static HttpWebRequest CreateSOAPWebRequest(string Url, string UrlDet)
        //{
        //    HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@Url);
        //    Req.Headers.Add(@UrlDet);
        //    Req.ContentType = "text/xml;charset=\"utf-8\"";
        //    Req.Accept = "text/xml";
        //    Req.Method = "POST";
        //    return Req;
        //}
        private void btnHttpWebResponse_Click(object sender, EventArgs e)
        {
            string URL = "", json = "";

            //LLAMADO API
            //para llamado de ws
            URL = "http://localhost:81";
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Begin 2: Parametros para Header
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Cache-Control", "no-cache");
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", "c9a0936881564c79bbb82433f341d9d3");
            //

            json = txtJsonROAD.Text;

            //RESPUESTA
            System.Net.Http.HttpContent content = new StringContent(json, UTF8Encoding.UTF8, "application/json"); //EJEMPLO DESDE BD
                                                                                                                  //System.Net.Http.HttpContent content = new StringContent(DATA_EJEMPLO, UTF8Encoding.UTF8, "application/json"); //EJEMPLO CON JSON EN DURO
            try
            {
                HttpResponseMessage messge = client.PostAsync(URL, content).Result;

                //string respuesta2 = messge.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(respuesta2);


                if (messge.IsSuccessStatusCode)
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //this.EscribeLog("Registro OK : " + respuesta);
                    MessageBox.Show(respuesta);
                    //ChileExpress chileexpress = JsonConvert.DeserializeObject<ChileExpress>(respuesta);
                }
                else
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //this.EscribeLog("Registro Error : " + respuesta);
                    MessageBox.Show(respuesta);
                }
                content.Dispose();
                client.Dispose();
            }
            catch (Exception ex1)
            {
                //this.EscribeLog("Error Llamando ENDPOINT : " + ex1.Message + "; URL:" + URL + "; TOKEN:" + TOKEN + "; DATA:" + DATA);
                content.Dispose();
                client.Dispose();
            }
            //fin
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result, ov;
            result = textBox2.Text;

            ov = result.Substring(result.IndexOf("<key>"), result.IndexOf("</key>"));



        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtRetorno.Text = DateTime.Parse(txtFecha.Text).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string URL = "", json = "";

            //LLAMADO API
            //para llamado de ws
            URL = URLSimpli.Text;
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Token 9fd0b1c384adc831c7a26a740a0cef395697c6db");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


            //Begin 2: Parametros para Header
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Cache-Control", "no-cache");
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", "c9a0936881564c79bbb82433f341d9d3");
            //

            //json = "?planned_date=2021-04-05";

            //RESPUESTA
            System.Net.Http.HttpContent content = new StringContent(json, UTF8Encoding.UTF8, "application/json"); //EJEMPLO DESDE BD
                                                                                                                  //System.Net.Http.HttpContent content = new StringContent(DATA_EJEMPLO, UTF8Encoding.UTF8, "application/json"); //EJEMPLO CON JSON EN DURO
            try
            {
                //HttpResponseMessage messge = client.PostAsync(URL, content).Result;

                HttpResponseMessage messge = client.GetAsync(URL).Result;
                //string respuesta2 = messge.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(respuesta2);


                if (messge.IsSuccessStatusCode)
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //this.EscribeLog("Registro OK : " + respuesta);
                    MessageBox.Show(respuesta);
                    //ChileExpress chileexpress = JsonConvert.DeserializeObject<ChileExpress>(respuesta);
                }
                else
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //this.EscribeLog("Registro Error : " + respuesta);
                    MessageBox.Show(respuesta);
                }
                content.Dispose();
                client.Dispose();
            }
            catch (Exception ex1)
            {
                //this.EscribeLog("Error Llamando ENDPOINT : " + ex1.Message + "; URL:" + URL + "; TOKEN:" + TOKEN + "; DATA:" + DATA);
                content.Dispose();
                client.Dispose();
            }
            //fin
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Token = "H0FF3N$#_4789@";
            string stFechaIni = "";
            string stFechaFin = "";
            orden[] ordenes;

            int id = 0, idOV = 0, idDet = 0;
            int countOV = 0, countItem = 0;


            string cardcode = "", email = ""; //segmento cliente
            string numero, tipopago, mediopago, comentario; //segmento general
            string regionD, direccionD, sectorD, telefonoD;  //direccionDespacho
            string regionP, direccionP, sectorP, telefonoP; //direccionPedido
            string sku, precio, cantidad;//articulo

            //LogInfo("boConsumeWebServiceOrdersV2", " generando myWeb");

            WsHoffensV2.ServicioWebIntegracionEnexum myWeb = new WsHoffensV2.ServicioWebIntegracionEnexum();

            //WSHoffens.servicesService myWeb = new WSHoffens.servicesService();

            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls; // .Tls12;
            myWeb.Proxy = System.Net.HttpWebRequest.GetSystemWebProxy();
            //myWeb.Credentials = new System.Net.NetworkCredential(Username, Password);
            string xml = myWeb.ordenes(Token, out ordenes);
            //LogInfo("xml ", xml);
            //LogInfo("ordenes ", ordenes[0].ToString());


            //recorre todas las ordenes
            countOV = ordenes.Length;
            for (int i = 0; i < ordenes.Count(); i++)
            {
                cardcode = ordenes[i].cliente.cardcode;
                email = ordenes[i].cliente.email;

                numero = ordenes[i].general.numero;
                tipopago = ordenes[i].general.tipoPago;
                mediopago = ordenes[i].general.medioPago;
                comentario = ordenes[i].general.comentarioCliente;

                regionD = ordenes[i].direccionDespacho.region;
                direccionD = ordenes[i].direccionDespacho.direccion;
                sectorD = ordenes[i].direccionDespacho.sector;
                telefonoD = ordenes[i].direccionDespacho.telefono;

                regionP = ordenes[i].direccionPedido.region;
                direccionP = ordenes[i].direccionPedido.direccion;
                sectorP = ordenes[i].direccionPedido.sector;
                telefonoP = ordenes[i].direccionPedido.telefono;

                for (int j = 0; j < ordenes[i].listado_articulos.Count(); j++)
                {
                    sku = ordenes[i].listado_articulos[j].sku;
                    precio = ordenes[i].listado_articulos[j].precio;
                    cantidad = ordenes[i].listado_articulos[j].cantidad;
                }
            }

            MessageBox.Show(cardcode);



        }

        private void button6_Click(object sender, EventArgs e)
        {
            string URL = "", json = "";

            //LLAMADO API
            //para llamado de ws
            URL = "http://api.tecnogps.cl/positions?from=2021/05/31 00:00:00&to=2021/05/31 23:59:59";
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic 5E4t6xWyvF4KcNeNyDy34twqbnnZrC5S");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


            //Begin 2: Parametros para Header
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Cache-Control", "no-cache");
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", "c9a0936881564c79bbb82433f341d9d3");
            //

            //json = "?planned_date=2021-04-05";

            //RESPUESTA
            System.Net.Http.HttpContent content = new StringContent(json, UTF8Encoding.UTF8, "application/json"); //EJEMPLO DESDE BD
                                                                                                                  //System.Net.Http.HttpContent content = new StringContent(DATA_EJEMPLO, UTF8Encoding.UTF8, "application/json"); //EJEMPLO CON JSON EN DURO
            try
            {
                //HttpResponseMessage messge = client.PostAsync(URL, content).Result;

                HttpResponseMessage messge = client.GetAsync(URL).Result;
                //string respuesta2 = messge.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(respuesta2);


                if (messge.IsSuccessStatusCode)
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //this.EscribeLog("Registro OK : " + respuesta);
                    MessageBox.Show(respuesta);
                    //ChileExpress chileexpress = JsonConvert.DeserializeObject<ChileExpress>(respuesta);
                }
                else
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //this.EscribeLog("Registro Error : " + respuesta);
                    MessageBox.Show(respuesta);
                }
                content.Dispose();
                client.Dispose();
            }
            catch (Exception ex1)
            {
                //this.EscribeLog("Error Llamando ENDPOINT : " + ex1.Message + "; URL:" + URL + "; TOKEN:" + TOKEN + "; DATA:" + DATA);
                content.Dispose();
                client.Dispose();
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            {



                //string URL = "", json1 = "", token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImNvbXBhbnlfaWQiOiI5NjUiLCJ1c2VyX2lkIjoiNzY4ODI0MzExIiwiYmRfbmFtZSI6ImJpY29tX3p1cnByb2R1Y3RvcmEifSwiaXNzIjoiVG9rZW4gRGUgU2VndXJpZGFkIn0.DExz3JlZ_j36YVhvStpgkD4DoHFGTjd_EwvCbewUQ_qR3SVb9J-iA3dlncEJxKYMVLfP1F6Z4Ygq3cTVKreFU13km_Pw8WMeXh8FqgTTBLQP2_6wybPivzZgZbH6B2iHlB94z-cmR5Fj8le-0daE8coYjAUbLfoOyyx1qVBvd6pi2IJLa5NLIK1QrWFeXGfRHdMa_kPa9vJh4p5K-_S8w_RkVPkNjBUZ5xzy1L53PGYw4uUeNDe9BvYbNwGyefKqw7ixzFAVpotyz25z5Zps6flUEB5n--Dx12oOyecxmQqHjmE_sdb01PB5PMjs6McnmbW_d8mESCSvH3nhYWNJ_A";
                //HttpResponseMessage response = new HttpResponseMessage();


                //var client = new RestClient("http://104.248.237.26:5050/v1/taxes");
                //var request = new RestRequest(Method.GET);

                //request.AddHeader("Authorization", "Bearer " + token.Trim());
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //request.AddHeader("Cache-Control", "no-cache");
                ////request.AddParameter("application/json", JsonConvert.SerializeObject(boletaHonorario), ParameterType.RequestBody);

                //IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);
                //Console.WriteLine(response.StatusCode);

                //respuesta.retCode = (int)response.StatusCode;
                //if (response.Content != null && response.Content != "")
                //{
                //    respuesta = JsonConvert.DeserializeObject<ResponseHonorTicket>(response.Content);
                //}
                //else
                //{
                //    respuesta.exception = response.ErrorMessage.ToString();
                //}
                //respuesta.retCode = (int)response.StatusCode;


                //LLAMADO API CODIGO POSTMAN
                var client = new RestClient("http://104.248.237.26:5050/v1/activities/?page=1");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET); request.AddHeader("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImNvbXBhbnlfaWQiOiI5NjUiLCJ1c2VyX2lkIjoiNzY4ODI0MzExIiwiYmRfbmFtZSI6ImJpY29tX3p1cnByb2R1Y3RvcmEifSwiaXNzIjoiVG9rZW4gRGUgU2VndXJpZGFkIn0.NBGNRShoSh-qnZyQhiJrg8bRDW7dClGxrKKM6Ptaz1Cn0Tc6IlPVW0Lo7WG8yJlcOiisVRNsXSGQ6ftUGvwI6OW_JTkV3eSucpCg0THNqyBpVlPpIax68uYJNZIuPT6a50CbjVmQ-C9oXtBP7d_bCvSQWj_ToJOST7UFS2CbD3FXlzgOaT1_rKU-3U8yt5Li9EhVcaXHcrM9x5U9t-YB-e4Mbvco1RHxrjygJUqSGTZDtKg971oCXMFltF2AVDpFax_HSYe9HaL76dMxnTCd7loagQKNt91m5gCL0ksmKNEqR6VMeTCOxJB_FdbrJrZMQ6B-3qOcmyn6qaKAsPmSIQ");

                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                MessageBox.Show(response.Content);

                //para llamado de ws
                //URL = "http://104.248.237.26:5051/v1/taxes";
                //System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                //client.BaseAddress = new System.Uri(URL);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.Trim());
                ////client.DefaultRequestHeaders.TryAddWithoutValidation("Postman-Token", "<calculated when request is sent>");
                ////client.DefaultRequestHeaders.TryAddWithoutValidation("Host", "<calculated when request is sent>");
                ////client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "PostmanRuntime/7.26.8");
                //client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                ////client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br");
                ////client.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");

                //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


                ////Begin 2: Parametros para Header
                ////client.DefaultRequestHeaders.TryAddWithoutValidation("Cache-Control", "no-cache");
                ////client.DefaultRequestHeaders.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", "c9a0936881564c79bbb82433f341d9d3");
                ////

                ////json = "?planned_date=2021-04-05";

                //////RESPUESTA


                //System.Net.Http.HttpContent content = new StringContent(json1, UTF8Encoding.UTF8, "application/json"); //EJEMPLO DESDE BD
                //System.Net.Http.HttpContent content = new StringContent(DATA_EJEMPLO, UTF8Encoding.UTF8, "application/json"); //EJEMPLO CON JSON EN DURO
                //try
                //{
                //  HttpResponseMessage messge = client.PostAsync(URL, content).Result;
                //string json = await client.GetStringAsync(URL);
                //HttpResponseMessage messge = client.GetAsync(URL).Result;

                //response = client.GetAsync(URL).Result;
                //string valor = response.Content.ReadAsStringAsync().Result;

                //string respuesta2 = messge.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(respuesta2);


                //if (messge.IsSuccessStatusCode)
                //{
                //    string respuesta = messge.Content.ReadAsStringAsync().Result;
                //this.EscribeLog("Registro OK : " + respuesta);
                //    MessageBox.Show(respuesta);
                //ChileExpress chileexpress = JsonConvert.DeserializeObject<ChileExpress>(respuesta);
                //    }
                //    else
                //    {
                //        string respuesta = messge.Content.ReadAsStringAsync().Result;
                //        //this.EscribeLog("Registro Error : " + respuesta);
                //        MessageBox.Show(respuesta);
                //    }
                //    //content.Dispose();
                //    client.Dispose();
                //}
                //catch (Exception ex1)
                //{
                //    //this.EscribeLog("Error Llamando ENDPOINT : " + ex1.Message + "; URL:" + URL + "; TOKEN:" + TOKEN + "; DATA:" + DATA);
                //    //content.Dispose();
                //    client.Dispose();
                //}
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string url = "https://api.bsale.cl/v1/products.json?&expand=[variants]";
            string token = "4ea9ab77ab57a01ecc18e4591b9efe68c4d461e5";
            string s = "", url2 = "", linea = "", linea0 = "";
            int Count = 0, limit = 0, offset = 0, variantcount = 0;


            s = GetGeneral(url, token, 0);

            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            Count = (Int32)rss["count"];
            limit = (Int32)rss["limit"];
            offset = (Int32)rss["offset"];
            var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));

            var total = 0;
            var k = 1;

            for (Int32 w = 0; w < veces; w++)
            {
                if (w > 0)
                {
                    s = GetGeneral(url, token, offset);

                    //Func.log(s);
                    json = JsonConvert.DeserializeObject(s);
                    rss = JObject.Parse(s);

                }

                for (Int32 i = 0; i < rss["items"].Count(); i++)
                {
                    linea = "INT-ARTICULOS;";

                    linea += ";" + rss["items"][i]["id"].ToString(); //productid
                    linea += ";" + rss["items"][i]["name"].ToString(); //productid
                    linea += ";" + rss["items"][i]["product_type"]["id"].ToString();
                    linea0 = linea;

                    variantcount = (Int32)rss["items"][i]["variants"]["count"];

                    for (Int32 i_var = 0; i_var < variantcount; i_var++)
                    {
                        linea = linea0;
                        linea += ";" + rss["items"][i]["variants"]["items"][i_var]["id"];  //variantid
                        linea += ";" + rss["items"][i]["variants"]["items"][i_var]["code"];  //sku
                        linea += ";" + rss["items"][i]["variants"]["items"][i_var]["barCode"];  //barcode
                        //MessageBox.Show(linea);
                    }



                    //MessageBox.Show (linea);

                }

                offset = offset + limit;
            }



        }

        private string GetGeneral(String URL, String Token, Int32 offset)
        {
            if (offset > 0)
                URL = URL + @"&offset=" + offset.ToString();

            //if (MostrarURL)
            //    Func.log("->-> " + URL);
            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("access_token", Token);
            //request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //string respuesta = @"<?xml version=""1.0"" encoding=""UTF - 8""?><SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:SOAP-ENC=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:ns1=""http://www.roadnet.com/RTS/TransportationSuite/TransportationWebService""><SOAP-ENV:Body><SOAP-ENV:Fault><faultcode>SOAP-ENV:Client</faultcode><faultstring>Data failed validation</faultstring><detail><fault xsi:type=""ns1:Fault""><ns1:code>1002</ns1:code><ns1:errorMessage>Data failed validation</ns1:errorMessage><ns1:detailMessage>TimeWindowTypeDetail values are not valid</ns1:detailMessage></fault></detail></SOAP-ENV:Fault></SOAP-ENV:Body></SOAP-ENV:Envelope>";

            string respuesta = @xml_roadnet.Text;
            XmlDocument oXml = new XmlDocument();
            XmlDocument document = new XmlDocument();


            oXml.LoadXml(respuesta);
            var nodo = oXml.GetElementsByTagName("SOAP-ENV:Fault");

            if (nodo[0] != null) //por que encontro el tag fault debe buscar 
            {
                MessageBox.Show("Inyección con problemas de data y/o formato en uno o más campos");
                //Enviado = "E";

                //Func.log("CargarUbicacionesRoadNet - Registro ERROR : Estado: " + Enviado + ", Mensaje:" + mens);
            }
            else
            {
                nodo = oXml.GetElementsByTagName("ns1:rejectedOrders");
                //marcar con N y la glosa del error (este se reenviara insistentemente hasta que logre entrar)
                if (nodo[0] != null) //por que encontro el tag y lo marca para volver a procesar
                    MessageBox.Show("Inyección rechazada, debido a que una sesión de planificación se encuentra en actividad por parte de un planner.");
                else
                    MessageBox.Show("Error Indefinido");

                //Enviado = "N";
                //Func.log("CargarUbicacionesRoadNet - Registro ERROR : Estado: " + Enviado + ", Mensaje:" + mens);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string url = "https://api.bsale.cl/v1/stocks.json?officeid=1";
            string token = "c79c0a87ce6966a0e0e87954552aa993d4129373";
            string s = "", url2 = "", linea = "", linea0 = "";
            int Count = 0, limit = 0, offset = 0, variantcount = 0;


            s = GetGeneral(url, token, 0);

            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            Count = (Int32)rss["count"];
            limit = (Int32)rss["limit"];
            offset = (Int32)rss["offset"];
            var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));

            var total = 0;
            var k = 1;

            for (Int32 w = 0; w < veces; w++)
            {
                if (w > 0)
                {
                    s = GetGeneral(url, token, offset);

                    //Func.log(s);
                    json = JsonConvert.DeserializeObject(s);
                    rss = JObject.Parse(s);

                }

                for (Int32 i = 0; i < rss["items"].Count(); i++)
                {
                    linea = "INT-SALDOS-DIARIOS;";

                    linea += ";" + rss["items"][i]["id"].ToString(); //productid
                    linea += ";" + rss["items"][i]["variant"]["id"].ToString(); //variantid
                    linea += ";" + rss["items"][i]["quantity"].ToString(); //quantity
                    linea += ";" + rss["items"][i]["quantityReserved"].ToString(); //quantity
                    linea += ";" + rss["items"][i]["quantityAvailable"].ToString(); //quantity

                    linea0 += linea + System.Environment.NewLine;

                    //variantcount = (Int32)rss["items"][i]["variants"]["count"];

                    //for (Int32 i_var = 0; i_var < variantcount; i_var++)
                    //{
                    //    linea = linea0;
                    //    linea += ";" + rss["items"][i]["variants"]["items"][i_var]["id"];  //variantid
                    //    linea += ";" + rss["items"][i]["variants"]["items"][i_var]["code"];  //sku
                    //    linea += ";" + rss["items"][i]["variants"]["items"][i_var]["barCode"];  //barcode
                    //    MessageBox.Show(linea);
                    //}



                    //MessageBox.Show (linea);

                }

                offset = offset + limit;
            }

            txtBsale.Text = linea0;

        }

        private string GetGeneralBICOM(String URL, String Token, Int32 page)
        {
            if (page > 0)
                URL = URL + @"?page=" + page.ToString();

            //if (MostrarURL)
            //    Func.log("->-> " + URL);
            //var client = new RestClient(URL);
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("access_token", Token);
            ////request.AddParameter("application/json", json, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //return response.Content;


            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + Token);
            IRestResponse response = client.Execute(request);
            return response.Content;
            //Console.WriteLine(response.Content);

            //MessageBox.Show(response.Content);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string url = @"http://104.248.237.26:5050/v1/products/";
            string token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImNvbXBhbnlfaWQiOiI5NjUiLCJ1c2VyX2lkIjoiNzY4ODI0MzExIiwiYmRfbmFtZSI6ImJpY29tX3p1cnByb2R1Y3RvcmEifSwiaXNzIjoiVG9rZW4gRGUgU2VndXJpZGFkIn0.NBGNRShoSh-qnZyQhiJrg8bRDW7dClGxrKKM6Ptaz1Cn0Tc6IlPVW0Lo7WG8yJlcOiisVRNsXSGQ6ftUGvwI6OW_JTkV3eSucpCg0THNqyBpVlPpIax68uYJNZIuPT6a50CbjVmQ-C9oXtBP7d_bCvSQWj_ToJOST7UFS2CbD3FXlzgOaT1_rKU-3U8yt5Li9EhVcaXHcrM9x5U9t-YB-e4Mbvco1RHxrjygJUqSGTZDtKg971oCXMFltF2AVDpFax_HSYe9HaL76dMxnTCd7loagQKNt91m5gCL0ksmKNEqR6VMeTCOxJB_FdbrJrZMQ6B-3qOcmyn6qaKAsPmSIQ";
            string s = "", url2 = "", linea = "", linea0 = "";
            int Count = 0, limit = 0, offset = 0, variantcount = 0;


            s = GetGeneralBICOM(url, token, 1);

            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            //Count = (Int32)rss["count"];
            //limit = (Int32)rss["limit"];
            //offset = (Int32)rss["offset"];
            //var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));
            var veces = (Int32)rss["TotalPage"];
            var total = 0;
            var k = 1;

            for (Int32 w = 0; w < veces; w++)
            {
                if (w > 0)
                {
                    s = GetGeneralBICOM(url, token, w + 1);

                    //Func.log(s);
                    json = JsonConvert.DeserializeObject(s);
                    rss = JObject.Parse(s);

                }

                for (Int32 i = 0; i < rss["Products"].Count(); i++)
                {
                    linea += "INT-ARTICULOS;";

                    linea += ";" + rss["Products"][i]["id"].ToString(); //productid
                    linea += ";" + rss["Products"][i]["group_id"].ToString(); //group_id
                    linea += ";" + rss["Products"][i]["sub_group_id"].ToString(); //sub_group_id
                    linea += ";" + rss["Products"][i]["code"].ToString(); //sku
                    linea += ";" + rss["Products"][i]["description"].ToString(); //sku
                    linea += System.Environment.NewLine;
                    //MessageBox.Show(linea);
                }

                txtBaseSKUBICOM.Text = linea;

                //MessageBox.Show (linea);

            }

            //offset = offset + limit;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string url = "https://api.bsale.cl/v1/documents.json?emissiondaterange=[1626048000,1626048000]&expand=[document_types,client,office,payments,details]&codesii=39&officeid=1&offset=0";
            string token = "96f0c4a5e6173d0836b00ec322f7e406b6c9078f";
            string s = "", url2 = "", linea = "", linea0 = "";
            int Count = 0, limit = 0, offset = 0, variantcount = 0;


            s = GetGeneral(url, token, 0);

            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            Count = (Int32)rss["count"];
            limit = (Int32)rss["limit"];
            offset = (Int32)rss["offset"];
            var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));

            var total = 0;
            var k = 1;

            for (Int32 w = 0; w < veces; w++)
            {
                if (w > 0)
                {
                    s = GetGeneral(url, token, offset);

                    //Func.log(s);
                    json = JsonConvert.DeserializeObject(s);
                    rss = JObject.Parse(s);

                }

                for (Int32 i = 0; i < rss["items"].Count(); i++)
                {
                    linea = "INT-DOCTOS;";

                    linea += ";" + rss["items"][i]["id"].ToString(); //productid
                    linea += ";" + rss["items"][i]["variant"]["id"].ToString(); //variantid
                    linea += ";" + rss["items"][i]["quantity"].ToString(); //quantity
                    linea0 = linea;

                    //variantcount = (Int32)rss["items"][i]["variants"]["count"];

                    //for (Int32 i_var = 0; i_var < variantcount; i_var++)
                    //{
                    //    linea = linea0;
                    //    linea += ";" + rss["items"][i]["variants"]["items"][i_var]["id"];  //variantid
                    //    linea += ";" + rss["items"][i]["variants"]["items"][i_var]["code"];  //sku
                    //    linea += ";" + rss["items"][i]["variants"]["items"][i_var]["barCode"];  //barcode
                    //    MessageBox.Show(linea);
                    //}



                    MessageBox.Show(linea);

                }

                offset = offset + limit;
            }
        }

        private void btnBICOM_Grupo_Click(object sender, EventArgs e)
        {
            string url = @"http://104.248.237.26:5050/v1/groups/";
            string token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImNvbXBhbnlfaWQiOiI5NjUiLCJ1c2VyX2lkIjoiNzY4ODI0MzExIiwiYmRfbmFtZSI6ImJpY29tX3p1cnByb2R1Y3RvcmEifSwiaXNzIjoiVG9rZW4gRGUgU2VndXJpZGFkIn0.NBGNRShoSh-qnZyQhiJrg8bRDW7dClGxrKKM6Ptaz1Cn0Tc6IlPVW0Lo7WG8yJlcOiisVRNsXSGQ6ftUGvwI6OW_JTkV3eSucpCg0THNqyBpVlPpIax68uYJNZIuPT6a50CbjVmQ-C9oXtBP7d_bCvSQWj_ToJOST7UFS2CbD3FXlzgOaT1_rKU-3U8yt5Li9EhVcaXHcrM9x5U9t-YB-e4Mbvco1RHxrjygJUqSGTZDtKg971oCXMFltF2AVDpFax_HSYe9HaL76dMxnTCd7loagQKNt91m5gCL0ksmKNEqR6VMeTCOxJB_FdbrJrZMQ6B-3qOcmyn6qaKAsPmSIQ";
            string s = "", url2 = "", linea = "", linea0 = "";
            int Count = 0, limit = 0, offset = 0, variantcount = 0;


            s = GetGeneralBICOM(url, token, 1);

            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            //Count = (Int32)rss["count"];
            //limit = (Int32)rss["limit"];
            //offset = (Int32)rss["offset"];
            //var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));
            var veces = (Int32)rss["TotalPage"];
            var total = 0;
            var k = 1;

            for (Int32 w = 0; w < veces; w++)
            {
                if (w > 0)
                {
                    s = GetGeneralBICOM(url, token, w + 1);

                    //Func.log(s);
                    json = JsonConvert.DeserializeObject(s);
                    rss = JObject.Parse(s);

                }

                for (Int32 i = 0; i < rss["Groups"].Count(); i++)
                {
                    linea += "INT-GRUPOS;";

                    linea += ";" + rss["Groups"][i]["id"].ToString(); //productid
                    //linea += ";" + rss["Groups"][i]["code"].ToString(); //sku
                    linea += ";" + rss["Groups"][i]["description"].ToString(); //sku
                    linea += System.Environment.NewLine;
                    //MessageBox.Show(linea);
                }

                txtBaseSKUBICOM.Text = linea;

                //MessageBox.Show (linea);

            }

            //offset = offset + limit;
        }

        private void btnBICOM_SubGrupo_Click(object sender, EventArgs e)
        {
            string url = @"104.248.237.26:5050/v1/groups/";
            string token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImNvbXBhbnlfaWQiOiI5NjUiLCJ1c2VyX2lkIjoiNzY4ODI0MzExIiwiYmRfbmFtZSI6ImJpY29tX3p1cnByb2R1Y3RvcmEifSwiaXNzIjoiVG9rZW4gRGUgU2VndXJpZGFkIn0.NBGNRShoSh-qnZyQhiJrg8bRDW7dClGxrKKM6Ptaz1Cn0Tc6IlPVW0Lo7WG8yJlcOiisVRNsXSGQ6ftUGvwI6OW_JTkV3eSucpCg0THNqyBpVlPpIax68uYJNZIuPT6a50CbjVmQ-C9oXtBP7d_bCvSQWj_ToJOST7UFS2CbD3FXlzgOaT1_rKU-3U8yt5Li9EhVcaXHcrM9x5U9t-YB-e4Mbvco1RHxrjygJUqSGTZDtKg971oCXMFltF2AVDpFax_HSYe9HaL76dMxnTCd7loagQKNt91m5gCL0ksmKNEqR6VMeTCOxJB_FdbrJrZMQ6B-3qOcmyn6qaKAsPmSIQ";
            string s = "", url2 = "", linea = "", linea0 = "";
            int Count = 0, limit = 0, offset = 0, variantcount = 0;


            s = GetGeneralBICOM(url, token, 1);

            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            //Count = (Int32)rss["count"];
            //limit = (Int32)rss["limit"];
            //offset = (Int32)rss["offset"];
            //var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));
            var veces = (Int32)rss["TotalPage"];
            var total = 0;
            var k = 1;

            for (Int32 w = 0; w < veces; w++)
            {
                if (w > 0)
                {
                    s = GetGeneralBICOM(url, token, w + 1);

                    //Func.log(s);
                    json = JsonConvert.DeserializeObject(s);
                    rss = JObject.Parse(s);

                }

                for (Int32 i = 0; i < rss["Products"].Count(); i++)
                {
                    linea += "INT-ARTICULOS;";

                    linea += ";" + rss["Products"][i]["id"].ToString(); //productid
                    linea += ";" + rss["Products"][i]["code"].ToString(); //sku
                    linea += ";" + rss["Products"][i]["description"].ToString(); //sku
                    linea += System.Environment.NewLine;
                    //MessageBox.Show(linea);
                }

                txtBaseSKUBICOM.Text = linea;

                //MessageBox.Show (linea);

            }

            //offset = offset + limit;
        }

        private void btnBSALETipoProducto_Click(object sender, EventArgs e)
        {
            string url = "https://api.bsale.cl/v1/product_types.json?";
            string token = "c79c0a87ce6966a0e0e87954552aa993d4129373";
            string s = "", url2 = "", linea = "", linea0 = "";
            int Count = 0, limit = 0, offset = 0, variantcount = 0;


            s = GetGeneral(url, token, 0);

            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            Count = (Int32)rss["count"];
            limit = (Int32)rss["limit"];
            offset = (Int32)rss["offset"];
            var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));

            var total = 0;
            var k = 1;

            for (Int32 w = 0; w < veces; w++)
            {
                if (w > 0)
                {
                    s = GetGeneral(url, token, offset);

                    //Func.log(s);
                    json = JsonConvert.DeserializeObject(s);
                    rss = JObject.Parse(s);

                }

                for (Int32 i = 0; i < rss["items"].Count(); i++)
                {
                    linea += "INT-TIPOPRODUCTO";

                    linea += ";" + rss["items"][i]["id"].ToString(); //productid
                    linea += ";" + rss["items"][i]["name"].ToString(); //productid
                    linea += System.Environment.NewLine;
                    linea0 = linea;





                    //MessageBox.Show (linea);

                }

                offset = offset + limit;
            }

            txtBaseSKUBICOM.Text = linea;

        }

        private void btnLogFire_Click(object sender, EventArgs e)
        {
            string xml = "prueba";
            //var client = new RestClient("https://te2.wms.ocs.oraclecloud.com/uyusa_test/wms/api/init_stage_interface/");
            var client = new RestClient("https://a8.wms.ocs.oraclecloud.com/tiendaamiga/wms/api/init_stage_interface/");

            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            //request.AddHeader("Authorization", "Basic aW50ZWdyYWNpb25fbHNfY2w6aW5pY2lvMDE=");
            request.AddHeader("Authorization", "Basic YXBpX3VzZXI6Ym80MzIx");

            request.AddHeader("postman-token", "34b9771b-448d-4a8d-0a17-1f63f249cf21");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Authorization", AUTH_WS);
            request.AddParameter("application/x-www-form-urlencoded", "async=false&xml_data=" + xml, ParameterType.RequestBody);


            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("async", "false");
            request.AddParameter("xml_data", xml);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            string url = "https://api.bsale.cl/v1/shippings.json?shipping_type=6&officeid=1&expand=[guide,shipping_type,details]";
            string token = "c79c0a87ce6966a0e0e87954552aa993d4129373";
            string s = "", url2 = "", linea = "", linea0 = "", archivo = "";
            int Count = 0, limit = 0, offset = 0, variantcount = 0;

            for (Int32 cont_fecha = 0; cont_fecha < 21; cont_fecha++)
            {
                fecha = DateTime.Parse("01-10-2021").AddDays(cont_fecha);

                long epochTicks = new DateTime(1970, 1, 1).Ticks;
                long unixTime = ((fecha.Ticks - epochTicks) / TimeSpan.TicksPerSecond);



                s = GetGeneral(url + "&shippingdate=" + unixTime.ToString(), token, 0);

                dynamic json = JsonConvert.DeserializeObject(s);
                JObject rss = JObject.Parse(s);

                Count = (Int32)rss["count"];
                limit = (Int32)rss["limit"];
                offset = (Int32)rss["offset"];
                var veces = Math.Ceiling(Convert.ToDouble(Count) / Convert.ToDouble(limit));

                var total = 0;
                var k = 1;

                for (Int32 w = 0; w < veces; w++)
                {
                    if (w > 0)
                    {
                        s = GetGeneral(url + "&shippingdate=" + unixTime.ToString(), token, offset);

                        //Func.log(s);
                        json = JsonConvert.DeserializeObject(s);
                        rss = JObject.Parse(s);

                    }

                    for (Int32 i = 0; i < rss["items"].Count(); i++)
                    {
                        linea0 = "INT-DOCTOS-DESPACHOS;";
                        linea0 += ";" + fecha.ToString("dd-MM-yyyy"); //
                        linea0 += ";" + rss["items"][i]["id"].ToString(); //
                        linea0 += ";" + rss["items"][i]["address"].ToString(); //
                        linea0 += ";" + rss["items"][i]["recipient"].ToString(); //

                        linea0 += ";" + rss["items"][i]["guide"]["id"].ToString(); //
                        linea0 += ";" + rss["items"][i]["guide"]["number"].ToString(); //
                        linea0 += ";" + rss["items"][i]["guide"]["details"]["count"].ToString();
                        //linea += ";" + rss["items"][i]["quantity"].ToString(); //quantity
                        //linea += ";" + rss["items"][i]["quantityReserved"].ToString(); //quantity
                        //linea += ";" + rss["items"][i]["quantityAvailable"].ToString(); //quantity



                        variantcount = (Int32)rss["items"][i]["guide"]["details"]["count"];

                        for (Int32 i_var = 0; i_var < variantcount; i_var++)
                        {
                            if (i_var <= 24)
                            {
                                linea = linea0;
                                linea += ";" + i_var.ToString();
                                linea += ";" + rss["items"][i]["guide"]["details"]["items"][i_var]["variant"]["code"];  //
                                linea += ";" + rss["items"][i]["guide"]["details"]["items"][i_var]["quantity"];  //
                                linea += ";" + rss["items"][i]["guide"]["details"]["items"][i_var]["relatedDetailId"];   //sku

                                archivo += linea + System.Environment.NewLine;

                            }


                        }



                        //MessageBox.Show (linea);

                    }

                    offset = offset + limit;
                }





            }







            txtBsale.Text = archivo;


        }

        private void button14_Click(object sender, EventArgs e)
        {

            var client = new RestClient("https://pre.ultimatefitness.cl/wp-json/wc/v3/orders/94970");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic Y2tfNzNmMjVjMmQxOGVhNjcyMDFkOTEzNDQ3YWE5YmY0ZWJlNmNiZTI5MDpjc18zYWM5ZmYyNmI4Y2U3NDJiYzBkY2UwZTAzZTE1NjNkODllMzEwZjc1");
            request.AddHeader("Cookie", "PHPSESSID=bec41acf1738740e7ee7aadcb586130c");
            var body = @"{
" + "\n" +
            @"    ""status"": ""completed""
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);


        }

        private void button15_Click(object sender, EventArgs e)
        {
            string s;
            string URL;
            //URL = "https://api.bsale.cl/v1/products.json?&expand=[variants,pack_details,attribute_values,attributes,product_type]&state=0" + @"&offset=1018";
            URL = "https://api.bsale.cl/v1/products.json?&expand=[variants,pack_details,attribute_values,attributes,product_type]&state=0" + @"&offset=676";

            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("access_token", "bc06bd65c4e4af00d78e4d6d04a345d1bc480d4f");
            //request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            s = response.Content;

            //Func.log(s);
            dynamic json = JsonConvert.DeserializeObject(s);
            JObject rss = JObject.Parse(s);

            string stTexto31;

            //stTexto31 = rss["items"][0]["pack_details"][0]["variant"]["id"].ToString(); // Id variante Pack
            //stTexto31 = DatoNulo(rss["items"][0]["pack_details"][0]["variant"]["id"]?.ToString());

            //pregunta si viene el campo variant en el detalle de pack_details -----
            if (rss["items"][0]["pack_details"].Parent.ToString().Contains("variant") == true)
            {
                stTexto31 = rss["items"][0]["pack_details"][0]["variant"]["id"]?.ToString(); // Id variante Pack
            }
            else
            {
                stTexto31 = "";
            }

            try
            {
                stTexto31 = rss["items"][0]["pack_details"][0]["variant"]["id"]?.ToString(); // Id variante Pack
            }

            catch (Exception ex)
            {
                stTexto31 = "";
            }


            if (rss["items"][0]["pack_details"][0]["variant"]["id"].ToString() == null)
            {
                Console.WriteLine("Error");
            }

        }

        private string DatoNulo(object dato)
        {
            try
            {
                dato = dato; // Id variante Pack
            }

            catch (Exception ex)
            {
                dato = "";
            }

            return dato.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string[] Palabras = "aortizg1984@gmail.com|||AV. LA MONTAÑA|".Split('|');

            string a;

            a = Palabras[3].Trim();

            var body1 = @"{" + "\n" +
                        @" ""shipping_order"": {" + "\n" +
                        @"      ""n_packages"": 1," + "\n" +
                        @"      ""content_description"": ""Orden 123""," + "\n" +
                        @"      ""imported_id"": ""123""," + "\n" +
                        @"      ""order_price"": 21990.0," + "\n" +
                        @"      ""weight"": ""1.0""," + "\n" +
                        @"      ""volume"": ""1.0""," + "\n" +
                        @"      ""type"": ""delivery"" " + "\n" +
                        @" }, " + "\n" +
                        @" ""shipping_origin"": { " + "\n" +
                        @"      ""warehouse_code"": ""bod_81"" " + "\n" +
                        @" }, " + "\n" +
                        @" ""shipping_destination"": { " + "\n" +
                        @"      ""customer"": { " + "\n" +
                        @"              ""name"": ""roberto pavez basualto"", " + "\n" +
                        @"              ""email"": """", " + "\n" +
                        @"              ""phone"": """" " + "\n" +
                        @"      }, " + "\n" +
                        @"      ""delivery_address"": { " + "\n" +
                        @"              ""home_address"": { " + "\n" +
                        @"                      ""place"": ""Providencia"", " + "\n" +
                        @"                      ""full_address"": ""Avenida Diego Portales  1197 1197 Curicó"", " + "\n" +
                        @"                      ""information"": """" " + "\n" +
                        @"              } " + "\n" +
                        @"      } " + "\n" +
                        @" }, " + "\n" +
                        @" ""carrier"": { " + "\n" +
                        @"      ""carrier_code"": ""SKN"", " + "\n" +
                        @"      ""carrier_service"": """", " + "\n" +
                        @"      ""tracking_number"": """" " + "\n" +
                        @"      } " + "\n" +
                        @" } ";

            JObject rss2 = JObject.Parse(body1);

            //var client = new RestClient("https://pre.ultimatefitness.cl/wp-json/wc/v3/products/93535");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.PUT);
            //request.AddHeader("Authorization", "Basic Y2tfNzNmMjVjMmQxOGVhNjcyMDFkOTEzNDQ3YWE5YmY0ZWJlNmNiZTI5MDpjc18zYWM5ZmYyNmI4Y2U3NDJiYzBkY2UwZTAzZTE1NjNkODllMzEwZjc1");
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Cookie", "PHPSESSID=d80f960887ce0225ca45ce1b85b9dfef");

            //string cantidad = "1200";

            //var body = @"{" + "\n" +
            //           @"    ""stock_quantity"": """ + cantidad.ToString() + @"""" + "\n" +
            //           @"}";

            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            //System.Net.ServicePointManager.SecurityProtocol = System.Net.ServicePointManager.SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            var client = new RestClient("https://pre.ultimatefitness.cl/wp-json/wc/v3/products?sku=1639597249809");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic Y2tfNzNmMjVjMmQxOGVhNjcyMDFkOTEzNDQ3YWE5YmY0ZWJlNmNiZTI5MDpjc18zYWM5ZmYyNmI4Y2U3NDJiYzBkY2UwZTAzZTE1NjNkODllMzEwZjc1");
            //request.AddHeader("Cookie", "PHPSESSID=d80f960887ce0225ca45ce1b85b9dfef");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string s;
            s = response.Content;

            s = s.Remove(0, 1);
            s = s.Remove(s.LastIndexOf("]"), 1);

            JObject rss = JObject.Parse(s);

            Console.WriteLine(response.Content);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Carga ruta de la API segun nombre proceso --------------------
            var client = new RestClient("https://stage.api.enviame.io/api/s2/v2/marketplaces/35/companies/1000/deliveries");

            client.Timeout = -1;
            var request = new RestRequest(Method.GET); //inserta

            //var request = new RestRequest(Method.GET);

            string metodo = "POST";

            switch (metodo)
            {
                case "GET":
                    request = new RestRequest(Method.GET);
                    break;
                case "POST":
                    request = new RestRequest(Method.POST);
                    break;
                case "PUT":
                    request = new RestRequest(Method.PUT);
                    break;
            }



            //agrega key y su valor -----------
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("api-key", "7JuXLvWuhXrDQfyltN9I7mWSByNnla");

            var body = @"{" + "\n" +
                       @" ""shipping_order"": {" + "\n" +
                       @"      ""n_packages"": " + "1" + @"," + "\n" +
                       @"      ""content_description"": """ + "123" + @"""," + "\n" +
                       @"      ""imported_id"": """ + "123" + @"""," + "\n" +
                       @"      ""order_price"": 1," + "\n" +
                       @"      ""weight"": ""1.0""," + "\n" +
                       @"      ""volume"": ""1.0""," + "\n" +
                       @"      ""type"": ""delivery"" " + "\n" +
                       @" }, " + "\n" +
                       @" ""shipping_origin"": { " + "\n" +
                       @"      ""warehouse_code"": ""BA088"" " + "\n" +
                       @" }, " + "\n" +
                       @" ""shipping_destination"": { " + "\n" +
                       @"      ""customer"": { " + "\n" +
                       @"              ""name"": """ + "pepito" + @""", " + "\n" +
                       @"              ""email"": """ + "prueba@getpoint.cl" + @""", " + "\n" +
                       @"              ""phone"": """ + "11223344" + @""" " + "\n" +
                       @"      }, " + "\n" +
                       @"      ""delivery_address"": { " + "\n" +
                       @"              ""home_address"": { " + "\n" +
                       @"                      ""place"": """ + "" + @""", " + "\n" +
                       @"                      ""full_address"": """ + "andres bello s/n" + @""", " + "\n" +
                       @"                      ""information"": """" " + "\n" +
                       @"              } " + "\n" +
                       @"      } " + "\n" +
                       @" }, " + "\n" +
                       @" ""carrier"": { " + "\n" +
                       @"      ""carrier_code"": ""SKN"", " + "\n" +
                       @"      ""carrier_service"": """", " + "\n" +
                       @"      ""tracking_number"": """" " + "\n" +
                       @"      } " + "\n" +
                       @" } ";

            request.AddParameter("application /json", body, ParameterType.RequestBody);
            IRestResponse responseStock = client.Execute(request);

            HttpStatusCode CodigoRetorno = responseStock.StatusCode;

            dynamic json = JsonConvert.DeserializeObject(responseStock.Content);
            JObject rss = JObject.Parse(responseStock.Content);


            //Si finalizó OK --------------------------
            if ((CodigoRetorno.Equals(HttpStatusCode.OK)) || (responseStock.StatusCode.ToString() == "Created"))
            {
                //JObject rss = JObject.Parse(responseStock.Content);

                //Actualiza estado de L_IntegraConfirmaciones, deja en estado traspasado ------
                //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()));
            }
            //else
            //{
            //    JObject rss = JObject.Parse(responseStock.Content);
            //}
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://api.bsale.cl/v1/products.json?limit=50");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("access_token", "c79c0a87ce6966a0e0e87954552aa993d4129373");
            IRestResponse response = client.Execute(request);

            JObject rss = JObject.Parse(response.Content);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            dt.Columns.Add("CodigoArticulo", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));

            dt.Rows.Add("codigo prueba", "descripcion prueba");

            int sw;
            int i;

            sw = 1;

            while (sw == 1)
            {
                for (i = 0; i < rss["items"].Count(); i++)
                {
                    dt.Rows.Add(rss["items"][i]["id"].ToString(),
                                rss["items"][i]["name"].ToString().Replace("'", ""));
                }

                //pregunta si viene el campo next en el detalle de pack_details, para controlar NullReferenceException -----
                if (rss.ToString().Contains(@"""next"":") == true)
                {
                    client = new RestClient(rss["next"].ToString());
                    client.Timeout = -1;
                    request = new RestRequest(Method.GET);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("access_token", "c79c0a87ce6966a0e0e87954552aa993d4129373");
                    response = client.Execute(request);

                    rss = JObject.Parse(response.Content);
                }
                else
                {
                    sw = 0;
                }
            }

            string archivo = @"C:\ITEC\ArticulosBSALE_" + System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + @".txt";

            ds.WriteXml(archivo);

            Process p = new Process();
            p.StartInfo.FileName = archivo;
            p.Start();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://stage.api.enviame.io/api/s2/v2/marketplaces/35/companies/1000/deliveries");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("api-key", "7JuXLvWuhXrDQfyltN9I7mWSByNnla");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @" ""shipping_order"": {
" + "\n" +
            @"      ""n_packages"": 3,
" + "\n" +
            @"      ""content_description"": ""203538"",
" + "\n" +
            @"      ""imported_id"": ""UF#203538"",
" + "\n" +
            @"      ""order_price"": 1,
" + "\n" +
            @"      ""weight"": ""1.0"",
" + "\n" +
            @"      ""volume"": ""1.0"",
" + "\n" +
            @"      ""type"": ""delivery"" 
" + "\n" +
            @" }, 
" + "\n" +
            @" ""shipping_origin"": { 
" + "\n" +
            @"      ""warehouse_code"": ""BA088"" 
" + "\n" +
            @" }, 
" + "\n" +
            @" ""shipping_destination"": { 
" + "\n" +
            @"      ""customer"": { 
" + "\n" +
            @"              ""name"": ""System gp"", 
" + "\n" +
            @"              ""email"": ""gerarld.zamorano@gmail.com"", 
" + "\n" +
            @"              ""phone"": ""+56973275594"" 
" + "\n" +
            @"      }, 
" + "\n" +
            @"      ""delivery_address"": { 
" + "\n" +
            @"              ""home_address"": { 
" + "\n" +
            @"                      ""place"": ""Lo Espejo"", 
" + "\n" +
            @"                      ""full_address"": ""seis poniente 6695 casa esquina frente a la comisaria"", 
" + "\n" +
            @"                      ""information"": """" 
" + "\n" +
            @"              } 
" + "\n" +
            @"      } 
" + "\n" +
            @" }, 
" + "\n" +
            @" ""carrier"": { 
" + "\n" +
            @"      ""carrier_code"": ""SKN"", 
" + "\n" +
            @"      ""carrier_service"": """", 
" + "\n" +
            @"      ""tracking_number"": """" 
" + "\n" +
            @"      } 
" + "\n" +
            @" } ";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            JObject rss = JObject.Parse(response.Content);

            string dato;
            dato = rss["data"]["label"]["ZPL"]["raw"].ToString();
            dato = rss["data"]["label"]["PDF"].ToString();

        }

        //como llamar a una webservice, ejemplo para MINUTO VERDE -------------------
        private void button20_Click(object sender, EventArgs e)
        {

            ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientes zmmfObtenerClientes = new ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientes();
            ZWSMM_OBTENER_CLIENTES.service servicio = new ZWSMM_OBTENER_CLIENTES.service();
            ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientesResponse zmmfObtenerClientesResponse = new ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientesResponse();


            zmmfObtenerClientes.PFechaultimadescarga = "20220831";
            zmmfObtenerClientes.PLimit = 10;
            zmmfObtenerClientes.PRowset = 0;
            zmmfObtenerClientes.PTipodescarga = 0;

            System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential();
            credenciales.UserName = "C-ABAPEXT1";
            credenciales.Password = "Goplicity@01.2023*";

            servicio.Credentials = credenciales; 

            zmmfObtenerClientesResponse = servicio.ZmmfObtenerClientes(zmmfObtenerClientes);

            var todo = zmmfObtenerClientesResponse.WeCustomers.Items;



            string URLRoadNet;
            string s;

            //URLRoadNet = "http://sapqasp9.ayf.local:8000/sap/bc/srt/rfc/sap/zws_get_products/310/zws_get_products/zb_get_products";
            URLRoadNet = "http://sapqasp9.ayf.local:8000/sap/bc/srt/wsdl/srvc_62EF45EDC98DEF62E10080F1C0A84651/wsdl11/allinone/ws_policy/document?sap-client=310";

            s = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:urn=""urn:sap-com:document:sap:soap:functions:mc-style"">
   <soap:Header/>
    <soap:Body>
        <urn:ZmmfObtenerClientes>
             <PFechaultimadescarga>20220831</PFechaultimadescarga>
             <PLimit>10</PLimit>
             <PRowset>0</PRowset>
             <PTipodescarga>0</PTipodescarga>
        </urn:ZmmfObtenerClientes>
       </soap:Body>
   </soap:Envelope> ";

            //s = String.Format(s, Fecha1, Fecha2);

            System.Uri ruta;
            ruta = new System.Uri("http://sapqasp9.ayf.local:8000/sap/bc/srt/scs/sap/zwsmm_obtener_clientes?sap-client=");


            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URLRoadNet);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));

            //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic Qy1BQkFQRVhUMTpHb3BsaWNpdHlAMjAyMi4=");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic Qy1BQkFQRVhUMTpHb3BsaWNpdHlAMDEuMjAyMyo=");
            client.BaseAddress = ruta;

            //RESPUESTA
            //System.Net.Http.HttpContent content = new StringContent(s, UTF8Encoding.UTF8, "application/json"); //EJEMPLO DESDE BD
            System.Net.Http.HttpContent content = new StringContent(s, UTF8Encoding.UTF8, "text/xml"); //EJEMPLO DESDE BD

            try
            {
                HttpResponseMessage messge = client.PostAsync(URLRoadNet, content).Result;

                if (messge.IsSuccessStatusCode)
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;

                    //Func.log("Registro OK");
                    //if (respuesta != "")
                    //ActualizarDoc_RoadNet(respuesta);

                    //convierte xml recibido en dataset
                    //trae 5 tablas, la ultima es la tabla con los items

                    DataSet ds = new DataSet();
                    ds.ReadXml(new XmlTextReader(new StringReader(respuesta)));



                }
                else
                {
                    //string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //Func.log("Registro ERROR : " + respuesta);
                }
                content.Dispose();
                client.Dispose();
            }
            catch (Exception ex1)
            {
                content.Dispose();
                client.Dispose();
            }
        }

        //private void button21_Click(object sender, EventArgs e)
        //{
        //    SAPbobsCOM.Recordset oRs
        //    Dim oRsAux As SAPbobsCOM.Recordset
        //    Dim s As String
        //    Dim _nf As New System.Globalization.CultureInfo("en-US")
        //Dim oXml As XmlDocument
        //Dim Linea As String
        //Dim sArchivo As String
        //Dim sConnection As String
        //Dim comando1 As SqlCommand = New SqlCommand
        //Dim sqlCnn As SqlConnection = New SqlConnection
        //Dim rTable As DataTable
        //Dim adapter As SqlDataAdapter
        //Dim i As Integer

        //Try
        //    oRs = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        //    oRsAux = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)


        //    s = "SELECT Code, U_IndicaTraspaso FROM OITT" + vbNewLine
        //    s += " WHERE ISNULL(U_IndicaTraspaso,'0') IN ('1','3')"
        //    oRs.DoQuery(s)

        //    While oRs.EoF = False
        //        s = "SELECT 'BOM_TRAN'	AS 'CTRL_SEG/TRNNAM'," + vbNewLine
        //        s += "       '2010.2'     AS 'CTRL_SEG/TRNVER'," + vbNewLine
        //        s += "       'CDHF'       AS 'CTRL_SEG/WHSE_ID'," + vbNewLine
        //        s += "       'HEADER_SEG' AS 'CTRL_SEG/HEADER_SEG/SEGNAM'," + vbNewLine
        //        If oRs.Fields.Item("U_IndicaTraspaso").Value = "1" Then
        //            s += "       'A'          AS 'CTRL_SEG/HEADER_SEG/TRNTYP'," + vbNewLine
        //        Else
        //            s += "       'U'          AS 'CTRL_SEG/HEADER_SEG/TRNTYP'," + vbNewLine
        //        End If
        //        s += "       T0.Code      AS 'CTRL_SEG/HEADER_SEG/BOMNUM'," + vbNewLine
        //        s += "       '----'       AS 'CTRL_SEG/HEADER_SEG/CLIENT_ID'," + vbNewLine
        //        s += "       T0.Code      AS 'CTRL_SEG/HEADER_SEG/PRTNUM'," + vbNewLine
        //        s += "       'A'          AS 'CTRL_SEG/HEADER_SEG/INVSTS'," + vbNewLine
        //        s += "       'A'          AS 'CTRL_SEG/HEADER_SEG/INVSTS_PRG'," + vbNewLine
        //        s += "       '0'          AS 'CTRL_SEG/HEADER_SEG/CMP_TRK_FLG'," + vbNewLine
        //        s += "       (SELECT 'LINE_SEG'     AS 'SEGNAM'," + vbNewLine
        //        s += "               RIGHT(REPLICATE('0',4) + CAST(T1.ChildNum + 1 AS VARCHAR(4)),4) AS 'BOMLIN'," + vbNewLine
        //        s += "               T1.Code        AS 'PRTNUM'," + vbNewLine
        //        s += "               T1.Quantity	AS 'CNSQTY'," + vbNewLine
        //        s += "               '0'			AS 'UNTCAS'," + vbNewLine
        //        s += "               '0'      	    AS 'UNTPAK'," + vbNewLine
        //        s += "               '0'			AS 'SKP_ALC_FLG'," + vbNewLine
        //        s += "               'A'			AS 'INVSTS_PRG'" + vbNewLine
        //        s += "          FROM ITT1 T1" + vbNewLine
        //        s += "         WHERE T1.Father = T0.Code" + vbNewLine
        //        s += "       FOR XML PATH('LINE_SEG'),TYPE) AS 'CTRL_SEG/HEADER_SEG'," + vbNewLine
        //        s += "       'PRCS_SEG'     AS 'CTRL_SEG/HEADER_SEG/PRCS_SEG/SEGNAM'," + vbNewLine
        //        s += "       'MA'           AS 'CTRL_SEG/HEADER_SEG/PRCS_SEG/WKO_TYP'," + vbNewLine
        //        s += "       'LINEAPROD'    AS 'CTRL_SEG/HEADER_SEG/PRCS_SEG/PRCARE'," + vbNewLine
        //        s += "       ' '            AS 'CTRL_SEG/HEADER_SEG/PRCS_SEG/DISASS_PRCLOC'," + vbNewLine
        //        s += "       ' '            AS 'CTRL_SEG/HEADER_SEG/PRCS_SEG/PRDLIN'," + vbNewLine
        //        s += "       '0'            AS 'CTRL_SEG/HEADER_SEG/PRCS_SEG/DEF_GEN_FLG'" + vbNewLine
        //        s += "  FROM OITT T0" + vbNewLine
        //        s += " WHERE T0.Code = '" + oRs.Fields.Item("Code").Value.ToString.Trim + "'" + vbNewLine
        //        s += " FOR XML path ('VC_BOM_INB_IFD') " + vbNewLine

        //        Try
        //            'oRsAux.DoQuery(s)
        //            sConnection = Lb.ConectarSQL()
        //            If(sqlCnn.State = ConnectionState.Open) Then
        //                sqlCnn.Close()
        //            End If
        //            sqlCnn.ConnectionString = sConnection

        //            sqlCnn.Open()
        //            If(sqlCnn.State = ConnectionState.Open) Then
        //                comando1.Connection = sqlCnn
        //                comando1.CommandText = s
        //                rTable = New DataTable
        //                adapter = New SqlDataAdapter(comando1)
        //                adapter.Fill(rTable)
        //                If(rTable.Rows.Count > 0) Then
        //                   i = 0
        //                    For Each row As DataRow In rTable.Rows
        //                        If i = 0 Then
        //                            s = row(0).ToString().Trim()
        //                        Else
        //                            s += row(0).ToString().Trim()
        //                        End If
        //                        i = i + 1
        //                    Next


        //                    sArchivo = sPath + "LM_" + oRs.Fields.Item("Code").Value.ToString.Trim + "_" + Date.Now.ToString("yyyyMMddHHmmss") + ".xml"

        //                    If File.Exists(sArchivo) Then
        //                        IO.File.Delete(sArchivo)
        //                    End If

        //                    'oSW = New StreamWriter(sArchivo)
        //                    'Linea = s 'oRsAux.Fields.Item(0).Value
        //                    'oSW.WriteLine(Linea)
        //                    'oSW.Flush()
        //                    'oSW.Close()
        //                    oXml = New XmlDocument
        //                    oXml.LoadXml(s)
        //                    oXml.Save(sArchivo)
        //                    oXml = Nothing

        //                    If oRs.Fields.Item("U_IndicaTraspaso").Value.ToString.Trim = "1" Then
        //                        Update_Status(oCompany, oRs.Fields.Item("Code").Value.ToString.Trim, False)
        //                    Else
        //                        Update_Status(oCompany, oRs.Fields.Item("Code").Value.ToString.Trim, True)
        //                    End If
        //                End If
        //            End If
        //        Catch ex As Exception
        //            Lb.AddLog("Error ExtraerListaMateriales(1), Articulo " & oRs.Fields.Item("Code").Value.ToString.Trim & ", " & ex.Message)
        //        Finally

        //        End Try
        //        oRs.MoveNext()
        //    End While
        //Catch ex As Exception
        //    Lb.AddLog("Error ExtraerListaMateriales(2), " & ex.Message)
        //Finally
        //    oRs = Nothing
        //    oRsAux = Nothing
        //End Try
        //}

        private void button22_Click(object sender, EventArgs e)
        {
            







            //base64 a PDF en ruta de red
            string base64BinaryStr_ = "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MCAyNzcgMCAwIDI3NyA4ODkgNjEwIDYxMCAwIDAgMzg5IDU1NiAzMzMgNjEwIDU1NiAwIDAgMCA1MDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCA2MTBdPj4KZW5kb2JqCjggMCBvYmoKPDwvQmFzZUZvbnQgL1RPR0hKTStMaWJlcmF0aW9uU2FucyAvRW5jb2RpbmcgL1dpbkFuc2lFbmNvZGluZyAvRmlyc3RDaGFyCiAgMzIgL0ZvbnREZXNjcmlwdG9yIDI4IDAgUiAvTGFzdENoYXIgMjQzIC9TdWJ0eXBlIC9UcnVlVHlwZSAvVG9Vbmljb2RlCiAgMjkgMCBSIC9UeXBlIC9Gb250IC9XaWR0aHMKICBbMjc3IDAgMCAwIDAgMCAwIDAgMzMzIDMzMyAwIDAgMjc3IDMzMyAwIDI3NyA1NTYgNTU2IDU1NiA1NTYgNTU2IDU1NgogIDU1NiA1NTYgNTU2IDU1NiAyNzcgMCAwIDAgMCAwIDAgNjY2IDAgNzIyIDcyMiA2NjYgNjEwIDAgMCAyNzcgMCA2NjYKICA1NTYgODMzIDcyMiA3NzcgNjY2IDAgMCA2NjYgNjEwIDcyMiA2NjYgMCAwIDAgNjEwIDAgMCAwIDAgMCAwIDU1NiAwCiAgNTAwIDU1NiA1NTYgMjc3IDU1NiAwIDIyMiAwIDAgMjIyIDgzMyA1NTYgNTU2IDU1NiA1NTYgMzMzIDUwMCAyNzcgNTU2CiAgNTAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAw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MDAwMDAwMDAgNjU1MzUgZg0KMDAwMDAwMDAxNSAwMDAwMCBuDQowMDAwMDAwMTk2IDAwMDAwIG4NCjAwMDAwMDAyNDMgMDAwMDAgbg0KMDAwMDAwMDI5OCAwMDAwMCBuDQowMDAwMDAwNTE3IDAwMDAwIG4NCjAwMDAwMDQ4MTQgMDAwMDAgbg0KMDAwMDAwNDk5MCAwMDAwMCBuDQowMDAwMDA1NzIyIDAwMDAwIG4NCjAwMDAwMDY0NjMgMDAwMDAgbg0KMDAwMDAwNjY5MCAwMDAwMCBuDQowMDAwMDA2OTkyIDAwMDAwIG4NCjAwMDAwMDc2NjIgMDAwMDAgbg0KMDAwMDAwODY3MSAwMDAwMCBuDQowMDAwMDA4OTQ4IDAwMDAwIG4NCjAwMDAwMDg5NjcgMDAwMDAgbg0KMDAwMDAwODk4NyAwMDAwMCBuDQowMDAwMDExNTgwIDAwMDAwIG4NCjAwMDAwMTE2MDEgMDAwMDAgbg0KMDAwMDAxMTYyMSAwMDAwMCBuDQowMDAwMDExNjc2IDAwMDAwIG4NCjAwMDAwMTE2OTYgMDAwMDAgbg0KMDAwMDAxMTcxNSAwMDAwMCBuDQowMDAwMDExOTA0IDAwMDAwIG4NCjAwMDAwMTE5MjMgMDAwMDAgbg0KMDAwMDAxMjAwMyAwMDAwMCBuDQowMDAwMDEyMTU5IDAwMDAwIG4NCjAwMDAwMTIxNzggMDAwMDAgbg0KMDAwMDAxMjE5OSAwMDAwMCBuDQowMDAwMDEyNDQ1IDAwMDAwIG4NCjAwMDAwMTI5OTAgMDAwMDAgbg0KMDAwMDAxMzAxMCAwMDAwMCBuDQowMDAwMDIyMzk2IDAwMDAwIG4NCjAwMDAwMjI0MTcgMDAwMDAgbg0KMDAwMDAyMjY3MCAwMDAwMCBuDQowMDAwMDIzMTg1IDAwMDAwIG4NCjAwMDAwMjMyMDUgMDAwMDAgbg0KMDAwMDAzMjM0NiAwMDAwMCBuDQowMDAwMDMyMzY3IDAwMDAwIG4NCnRyYWlsZXIKCjw8L0luZm8gMSAwIFIgL1Jvb3QgMiAwIFIgL1NpemUgMzk+PgpzdGFydHhyZWYKMzIzODgKJSVFT0YK";
            byte[] bytes_ = Convert.FromBase64String(base64BinaryStr_);

            //File.WriteAllBytes(@"FolderPath\pdfFileName.pdf", bytes);
            //File.WriteAllBytes(@"\\192.168.1.76\c$\Sitios\MUNDOSALUD\uploads\SDR\pruebaBase64aPDF.pdf", bytes_);
            File.WriteAllBytes(@"C:\_imagen\pruebaBase64aPDF.pdf", bytes_);

            //-------------------------------------------------------------------------------------------
            //imagen a base64
            byte[] imageArray = System.IO.File.ReadAllBytes("C:/_imagen/Screenshot_3.jpg");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            //-------------------------------------------------------------------------------------------
            //base64 a PDF
            string base64BinaryStr = "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MCAyNzcgMCAwIDI3NyA4ODkgNjEwIDYxMCAwIDAgMzg5IDU1NiAzMzMgNjEwIDU1NiAwIDAgMCA1MDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCA2MTBdPj4KZW5kb2JqCjggMCBvYmoKPDwvQmFzZUZvbnQgL1RPR0hKTStMaWJlcmF0aW9uU2FucyAvRW5jb2RpbmcgL1dpbkFuc2lFbmNvZGluZyAvRmlyc3RDaGFyCiAgMzIgL0ZvbnREZXNjcmlwdG9yIDI4IDAgUiAvTGFzdENoYXIgMjQzIC9TdWJ0eXBlIC9UcnVlVHlwZSAvVG9Vbmljb2RlCiAgMjkgMCBSIC9UeXBlIC9Gb250IC9XaWR0aHMKICBbMjc3IDAgMCAwIDAgMCAwIDAgMzMzIDMzMyAwIDAgMjc3IDMzMyAwIDI3NyA1NTYgNTU2IDU1NiA1NTYgNTU2IDU1NgogIDU1NiA1NTYgNTU2IDU1NiAyNzcgMCAwIDAgMCAwIDAgNjY2IDAgNzIyIDcyMiA2NjYgNjEwIDAgMCAyNzcgMCA2NjYKICA1NTYgODMzIDcyMiA3NzcgNjY2IDAgMCA2NjYgNjEwIDcyMiA2NjYgMCAwIDAgNjEwIDAgMCAwIDAgMCAwIDU1NiAwCiAgNTAwIDU1NiA1NTYgMjc3IDU1NiAwIDIyMiAwIDAgMjIyIDgzMyA1NTYgNTU2IDU1NiA1NTYgMzMzIDUwMCAyNzcgNTU2CiAgNTAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAw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MDAwMDAwMDAgNjU1MzUgZg0KMDAwMDAwMDAxNSAwMDAwMCBuDQowMDAwMDAwMTk2IDAwMDAwIG4NCjAwMDAwMDAyNDMgMDAwMDAgbg0KMDAwMDAwMDI5OCAwMDAwMCBuDQowMDAwMDAwNTE3IDAwMDAwIG4NCjAwMDAwMDQ4MTQgMDAwMDAgbg0KMDAwMDAwNDk5MCAwMDAwMCBuDQowMDAwMDA1NzIyIDAwMDAwIG4NCjAwMDAwMDY0NjMgMDAwMDAgbg0KMDAwMDAwNjY5MCAwMDAwMCBuDQowMDAwMDA2OTkyIDAwMDAwIG4NCjAwMDAwMDc2NjIgMDAwMDAgbg0KMDAwMDAwODY3MSAwMDAwMCBuDQowMDAwMDA4OTQ4IDAwMDAwIG4NCjAwMDAwMDg5NjcgMDAwMDAgbg0KMDAwMDAwODk4NyAwMDAwMCBuDQowMDAwMDExNTgwIDAwMDAwIG4NCjAwMDAwMTE2MDEgMDAwMDAgbg0KMDAwMDAxMTYyMSAwMDAwMCBuDQowMDAwMDExNjc2IDAwMDAwIG4NCjAwMDAwMTE2OTYgMDAwMDAgbg0KMDAwMDAxMTcxNSAwMDAwMCBuDQowMDAwMDExOTA0IDAwMDAwIG4NCjAwMDAwMTE5MjMgMDAwMDAgbg0KMDAwMDAxMjAwMyAwMDAwMCBuDQowMDAwMDEyMTU5IDAwMDAwIG4NCjAwMDAwMTIxNzggMDAwMDAgbg0KMDAwMDAxMjE5OSAwMDAwMCBuDQowMDAwMDEyNDQ1IDAwMDAwIG4NCjAwMDAwMTI5OTAgMDAwMDAgbg0KMDAwMDAxMzAxMCAwMDAwMCBuDQowMDAwMDIyMzk2IDAwMDAwIG4NCjAwMDAwMjI0MTcgMDAwMDAgbg0KMDAwMDAyMjY3MCAwMDAwMCBuDQowMDAwMDIzMTg1IDAwMDAwIG4NCjAwMDAwMjMyMDUgMDAwMDAgbg0KMDAwMDAzMjM0NiAwMDAwMCBuDQowMDAwMDMyMzY3IDAwMDAwIG4NCnRyYWlsZXIKCjw8L0luZm8gMSAwIFIgL1Jvb3QgMiAwIFIgL1NpemUgMzk+PgpzdGFydHhyZWYKMzIzODgKJSVFT0YK";
            byte[] bytes = Convert.FromBase64String(base64BinaryStr);
            
            //File.WriteAllBytes(@"FolderPath\pdfFileName.pdf", bytes);
            File.WriteAllBytes(@"C:\_imagen\pdfFileName.pdf", bytes);

            //-------------------------------------------------------------------------------------------
            //pdf a base64
            string filePath = @"C:\_imagen\ejemplo.pdf";
            Byte[] bytes2 = File.ReadAllBytes(filePath);
            String base64String = Convert.ToBase64String(bytes);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // llamado version 2, framework 4.5 en adelante -------------------------------------------------------------------------------------------
            var DATA = "";
            string URL = "https://app.getpoint.cl/API_GP_VIGAFLOW/api/CONSTOCK/LISTAR";

            System.Net.Http.HttpClient client2 = new System.Net.Http.HttpClient();
            client2.Timeout = TimeSpan.FromMinutes(5);
            client2.BaseAddress = new System.Uri(URL);
            client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client2.DefaultRequestHeaders.Add("GP_TOKEN", "3ECCB296-72EF-4C63-8AF1-F3A909C2E2C3");
            client2.DefaultRequestHeaders.Add("GP_SECRET", "447A6BD8-F3DB-4544-BFFF-086B1C01C701");

            //string strBody;

            DATA = @"{
                        ""EmpId"": ""1"",
                        ""LineaProducto"": ""0"",
                        ""TipoProducto"": """",
                        ""CodigoArticulo"": """"
                     }";

            System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
            //System.Net.Http.HttpContent Content = new StringContent(JsonConvert.SerializeObject(strBody), Encoding.UTF8, "application/json");

           //HttpResponseMessage messge = client2.GetAsync()

            //messge.Content = Content;

            string resp;
            //resp = messge.Content.ReadAsStringAsync().Result; //aqui queda el contenido


            //==================================================================================

            // llamado version 3, desde framework 1.1 en adelante  ---------------------------------------
            var url = $"http://10.10.60.7/webapi_dartel/api/dartel/StockReposicion";
            var request3 = (HttpWebRequest)WebRequest.Create(url);
            request3.Method = "GET";
            request3.ContentType = "application/json";
            request3.Accept = "application/json";

            try
            {
                using (WebResponse response3 = request3.GetResponse())
                {
                    using (Stream strReader = response3.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            string respuesta = @"{""Items"" : " + responseBody + " }";

                            //Crea dataset con el JSON ---
                            DataSet myDataSet = JsonConvert.DeserializeObject<DataSet>(respuesta);

                            MessageBox.Show("La api retornó " + myDataSet.Tables[0].Rows.Count.ToString() + " registros");

                            MessageBox.Show("Primer Producto: " + myDataSet.Tables[0].Rows[0]["ItemCode"].ToString() + " - " + 
                                                                  myDataSet.Tables[0].Rows[0]["ItemName"].ToString());
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Error");
            }

            //----------------------------------------------------------------------

            //string strEmpÌd = ConfigurationSettings.AppSettings["EmpId"].ToString();
            string strEmpÌd = "10";
            int Empid;

            Empid = int.Parse(strEmpÌd.Trim());

            // llamado version 2, framework 4.5 en adelante -------------------------------------------------------------------------------------------
            //var DATA = "";
            ////string URL = "http://10.10.60.7/webapi_dartel/api/dartel/StockReposicion";
            //string URL = "https://app.getpoint.cl/API_GP_VIGAFLOW/api/CONSTOCK/LISTAR";

            //System.Net.Http.HttpClient client2 = new System.Net.Http.HttpClient();
            //client2.Timeout = TimeSpan.FromMinutes(5);
            //client2.BaseAddress = new System.Uri(URL);
            //client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            //client2.DefaultRequestHeaders.Add("GP_TOKEN", "3ECCB296-72EF-4C63-8AF1-F3A909C2E2C3");
            //client2.DefaultRequestHeaders.Add("GP_SECRET", "447A6BD8-F3DB-4544-BFFF-086B1C01C701");

            //System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
            //HttpResponseMessage messge = client2.GetAsync(URL).Result;

            //string resp;
            //resp = messge.Content.ReadAsStringAsync().Result; //aqui queda el contenido

            // llamado version 1, restclient ---------------------------------------------------------------------------------------------
            var client = new RestClient("http://10.10.60.7/webapi_dartel/api/dartel/StockReposicion");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //Ejecuta llamado de la API --------------
            IRestResponse response = client.Execute(request);
            HttpStatusCode CodigoRetorno = response.StatusCode;
            //----------------------------------------------------------------------------------------------

            //Si finalizó OK --------------------------
            if (CodigoRetorno.Equals(HttpStatusCode.OK))
            {
                string s;
                s = @"{""Items"" : " + response.Content + " }";
                JObject rss = JObject.Parse(s);
                string result;
                int borrar = 1;

                for (Int32 i = 0; i < rss["Items"].Count(); i++)
                {
                    //Guarda datos en tabla de integracion ---------------
                    //result = WS_Integrador.Classes.model.InfF_Generador.Inserta_ReposicionSucursal();
                    result = WindowsFormsApp1.InfF_Generador.Inserta_ReposicionSucursal(Empid,
                                                                                        rss["Items"][i]["ItemCode"].ToString().Trim(),
                                                                                        rss["Items"][i]["ItemName"].ToString().Trim(),
                                                                                        0,
                                                                                        decimal.Parse(rss["Items"][i]["StockMatta"].ToString()),
                                                                                        decimal.Parse(rss["Items"][i]["StockCD"].ToString()),
                                                                                        decimal.Parse(rss["Items"][i]["Enviar"].ToString()),
                                                                                        decimal.Parse(rss["Items"][i]["U_NXMax"].ToString()),
                                                                                        decimal.Parse(rss["Items"][i]["PorcStock"].ToString()),
                                                                                        int.Parse(rss["Items"][i]["Embalaje"].ToString()),
                                                                                        decimal.Parse(rss["Items"][i]["PorcStockReal"].ToString()),
                                                                                        decimal.Parse(rss["Items"][i]["Calculo"].ToString()),
                                                                                        rss["Items"][i]["Sector"].ToString().Trim(),
                                                                                        DateTime.Parse(rss["Items"][i]["Fecha"].ToString().Trim()),
                                                                                        rss["Items"][i]["Rotacion"].ToString().Trim(),
                                                                                        decimal.Parse(rss["Items"][i]["SolicTrasAbierta"].ToString()),
                                                                                        rss["Items"][i]["Marca"].ToString().Trim(),
                                                                                        rss["Items"][i]["Lista"].ToString().Trim(),
                                                                                        decimal.Parse(rss["Items"][i]["RecepPend50Matta"].ToString()),
                                                                                        decimal.Parse(rss["Items"][i]["RecepPend50CD"].ToString()),
                                                                                        borrar);
                    //Para quer solo la primera vez limpie
                    borrar = 0;

                    //Si integra correctamente actualiza estado a 2, en tabla de integracion
                    if (result == "OK")
                    {
                        MessageBox.Show("Proceso OK");
                    }
                    else
                    {
                        MessageBox.Show("Proceso con Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Proceso con Error");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("A");
            ds.Tables[0].Columns.Add("B");

            ds.Tables[0].Rows.Add(new object[] { 1, "prueba" });
            ds.Tables[0].Rows.Add(new object[] { 2, "dato" });

            DataRow[] rslt = ds.Tables[0].Select("A <> 'mouse' AND B = '5'");

            foreach (DataRow row in rslt)
            {
                MessageBox.Show("ciclo");
                MessageBox.Show(row["B"].ToString());
            }

            //string a = "24.7";
            //decimal prueba = decimal.Parse(a);


            //Ejemplo de buscar --------------------------
            List<clase_prueba> lista = new List<clase_prueba>();
            clase_prueba item = new clase_prueba();
            string mensaje;

            item.dato1 = "AAAAAA";
            item.dato2 = "111111";
            lista.Add(item);

            item = new clase_prueba();
            item.dato1 = "BBBBBB";
            item.dato2 = "222222";
            lista.Add(item);

            item = new clase_prueba();
            item.dato1 = "CCCCCC";
            item.dato2 = "333333";
            lista.Add(item);

            //clase_prueba res = lista.ToList().Find(x => x.dato1.Trim() == textBox3.Text.Trim());
            //clase_prueba res = lista.ToList().Find(x => x.dato1.Trim() != "D");
            List<clase_prueba> res = lista.ToList().FindAll(x => x.dato1.Trim() == textBox3.Text.Trim() || textBox3.Text.Trim() == "");

            if (res.Count > 0)
            {
                mensaje = "EXISTE - " + res.Count.ToString();
                MessageBox.Show(mensaje);
            }
            else
            {
                mensaje = "No Existe - " + res.Count.ToString();
                MessageBox.Show(mensaje);
            }









        }

        private void button24_Click(object sender, EventArgs e)
        {
            var _b = @"{ ""error"":{ ""code"":""500"",""message"":""Internal Server Error""}}{""SDTRespuestas"":{""Tipo"":0}}";
            JObject rss1 = JObject.Parse(_b);

            if (_b.Contains(@"{""SDTRespuestas"":{""Tipo"":0}}") == true)
            {
                _b = _b.Replace(@"{""SDTRespuestas"":{""Tipo"":0}}", "");
                MessageBox.Show("existe");
            }
            else
            {
                MessageBox.Show("NO EXISTE");
            }


            var _body = @"{" +
	                    @"""error"": {" +
                        @"""code"": ""400""," + 
		                @"""message"": ""Bad Request""" + 
                        @"   }" +
                        @"}";

            JObject rss = JObject.Parse(_body);

            if (rss.ToString().Contains("message") == true)
            {
                MessageBox.Show("existe");
            }
            else
            {
                MessageBox.Show("NO EXISTE");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";

            if (txtPedidoNovapet.Text.Trim() == "")
            {
                return;
            }

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
                    }

                }
            
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

                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(maximafecha).ToLocalTime();

                textBox4.Text = "Id interno: " + idpedido.ToString().Trim() + ", fecha: " + maximafecha.ToString().Trim() + " (" + dtDateTime.ToString("dd/MM/yyyy") + ") " + tipoDocto.Trim();
                MessageBox.Show("Id interno: " + idpedido.ToString().Trim() + ", fecha: " + maximafecha.ToString().Trim() + " (" + dtDateTime.ToString("dd/MM/yyyy") + ") " + tipoDocto.Trim());

                //Actualiza estado de L_IntegraConfirmaciones, deja en estado traspasado ------
                //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaIntegraConfirmaciones(int.Parse(myData.Tables[0].Rows[i]["IntId"].ToString()));
            }

        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                //para evitar error de seguridad en el llamado a la API -----------------------------------------------------------------------------------------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS
                //-----------------------------------------------------------------------------------------------------------------------------------------------

                //PRUEBA DE UN CAMBIO EN GITHUB -----------------------------------
                //string resultado = "";
                //string SqlInsert = "";
                string NombreArchivo = "";
                string SqlInsert2 = "";
                string usuario = "INTEGRADOR_API";

                //Ejecuta la API para SDD confirmadas no procesadas --------
                var client = new RestClient("https://app.getpoint.cl/API_GP_PERSA/API/INTEGRACION_CONFIRMACIONES_JSON/LISTAR");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-GPOINT-API-TOKEN", "985E2B08-AD1A-4D64-B292-240F82668C0E");
                request.AddHeader("X-GPOINT-API-SECRET", "80B808C3-98A0-4F09-A2E1-46E4F7761649");

                //Carga variable body a enviar
                var body = @"{" + "\n" +
                           @"   ""EmpId"": 1," + "\n" +
                           @"   ""NombreProceso"": ""SDD_CONFIRMADAS""," + "\n" +
                           @"   ""Limit"": 100," + "\n" +
                           @"   ""RowSet"": 0" + "\n" +
                           @"   }";

                request.AddParameter("application/json", body, ParameterType.RequestBody);

                //Ejecuta llamado de la API --------------
                IRestResponse response = client.Execute(request);
                HttpStatusCode CodigoRetorno = response.StatusCode;

                //Si finalizó OK --------------------------
                if (CodigoRetorno.Equals(HttpStatusCode.OK))
                {
                    JObject rss = JObject.Parse(response.Content);
                    MessageBox.Show("voLeeConfirmacionSDD_JSON." + "Confirmaciones SDD. JSON: " + response.Content);

                    //La API se ejecuto correctamente
                    if (rss["Resultado"].ToString().Trim() == "OK")
                    {
                        //Recorre las confirmaciones que devolvio la API -------
                        for (Int32 i = 0; i < rss["Confirmacion"].Count(); i++)
                        {
                            int correlativo = 1;
                            string[] Texto1Cab = rss["Confirmacion"][i]["Texto1"].ToString().Trim().Split('|'); //separa campos concatenados dentro del texto1

                            //Recorre los items de la confirmacion
                            for (Int32 item = 0; item < rss["Confirmacion"][i]["Items"].Count(); item++)
                            {
                                //crea lista de campos
                                SqlInsert = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, Texto1, Texto2, Texto3, Texto4, Texto5, Texto6, Texto7, Texto8, Texto9, Texto10, Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20, Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29)";

                                NombreArchivo = "API_WMS_CONF_" + rss["Confirmacion"][i]["NumeroReferencia"].ToString() + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv"; //"Archivo, ";

                                //crea lista de valores
                                SqlInsert2 = "('" + NombreArchivo.Trim() + "','" + //"Archivo, " +
                                             usuario.Trim() + "','" + //"UserName, " +
                                             DateTime.Now.ToString("yyyyMMdd") + "','" + //"FechaProceso, " +
                                             correlativo.ToString() + "',"; // "Linea, ";

                                string[] Texto1Det = rss["Confirmacion"][i]["Items"][item]["Texto1"].ToString().Trim().Split('|'); //separa campos concatenados dentro del texto1

                                SqlInsert2 = SqlInsert2 +
                                             "'" + rss["Confirmacion"][i]["NombreProceso"].ToString() + "'," +
                                             //"'" + Texto1Cab[2].Trim() + "'," + //rss["Confirmacion"][i]["FECHAHORA"].ToString() + "'," +
                                             "'" + DateTime.Parse(Texto1Cab[2].Trim().Substring(0, 10)).ToString("yyyyMMdd") + " " +
                                                   Texto1Cab[2].Trim().Substring(11, 8).Replace(":", "") + "'," + // se guarda en el formato "AAAAMMDD HHMMSS" //rss["Confirmacion"][i]["FECHAHORA"].ToString() + "'," +
                                             "'" + Texto1Cab[3].Trim() + "'," + //rss["Confirmacion"][i]["TIPO_TRK"].ToString() + "'," +
                                             "'" + Texto1Cab[0].Trim() + "'," + //rss["Confirmacion"][i]["ID_WMS"].ToString() + "'," +
                                             "'" + Texto1Cab[4].Trim() + "'," + //rss["Confirmacion"][i]["ID_QAD"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["EmpId"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Folio"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["FolioRel"].ToString() + "'," +
                                             "'" + DateTime.Parse(rss["Confirmacion"][i]["FechaProceso"].ToString()).ToString("yyyyMMdd") + "'," +
                                             "'" + rss["Confirmacion"][i]["TipoDocumento"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["NumeroDocto"].ToString() + "'," +
                                             "'" + DateTime.Parse(rss["Confirmacion"][i]["FechaDocto"].ToString()).ToString("yyyyMMdd") + "'," +
                                             "'" + rss["Confirmacion"][i]["TipoReferencia"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["NumeroReferencia"].ToString() + "'," +
                                             "'" + DateTime.Parse(rss["Confirmacion"][i]["FechaReferencia"].ToString()).ToString("yyyyMMdd") + "'," +
                                             "'" + Texto1Cab[17].Trim() + "'," + //rss["Confirmacion"][i]["Items"][item]["PorcTolerancia"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["Linea"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["CodigoArticulo"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["CodigoArticulo"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["UnidadMedida"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["Cantidad"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["ItemReferencia"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["NroSerieDesp"].ToString() + "'," +
                                             "'" + Texto1Det[2].Trim() + "'," + //rss["Confirmacion"][i]["Items"][item]["Referencia"].ToString() + "'," +
                                             "'" + DateTime.Parse(rss["Confirmacion"][i]["Items"][item]["FechaVectoDesp"].ToString()).ToString("yyyyMMdd") + "'," +
                                             "'" + Texto1Det[7].Trim() + "'," + //rss["Confirmacion"][i]["Items"][item]["CantAlmacenWMS"].ToString() + "'," +
                                             "'" + Texto1Det[9].Trim() + "'," + //rss["Confirmacion"][i]["Items"][item]["NroSerieAlmacenWMS"].ToString() + "'," +
                                             "'" + DateTime.Parse(Texto1Det[10].Trim()).ToString("yyyyMMdd") + "'," + //rss["Confirmacion"][i]["Items"][item]["FechaVectoAlmacenWMS"].ToString() + "'," +
                                             "'" + Texto1Det[11].Trim() + "')"; //rss["Confirmacion"][i]["Items"][item]["UbicacionAndenWMS"].ToString() + "')";

                                ////Inserta en tabla de integracion ----------------------------------------------
                                //resultado = WS_Integrador.Classes.model.InfF_Generador.InsertarRegistro_OleDb(BD_GETPOINT,
                                //                                                                              SqlInsert,
                                //                                                                              SqlInsert2);
                                //if (resultado != "")
                                //{
                                //    LogInfo("voLeeConfirmacionSDD_JSON", "Error InsertarRegistro_OLEDb: " + resultado.Trim(), true);
                                //}

                                correlativo = correlativo + 1;

                            } // FIN ciclo Recorre los items de la confirmacion

                            //----------------------------------------------------------------------
                            //Marcar cabecera registro de integracion despues de insertarlo -----------
                            //----------------------------------------------------------------------------
                            //var client2 = new RestClient(ConfigurationManager.AppSettings["URL_API"].ToString() + "/API/INTEGRACION_CONFIRMACIONES_UPD");
                            //client2.Timeout = -1;
                            //var request2 = new RestRequest(Method.POST);
                            //request2.AddHeader("Content-Type", "application/json");
                            //request2.AddHeader("X-GPOINT-API-TOKEN", ConfigurationManager.AppSettings["TOKEN_API"].ToString());
                            //request2.AddHeader("X-GPOINT-API-SECRET", ConfigurationManager.AppSettings["SECRET_API"].ToString());

                            ////Carga variable body a enviar
                            //var body2 = @"{" + "\n" +
                            //            @"   ""IntId"": " + rss["Confirmacion"][i]["IntId"].ToString() + "\n" +
                            //            @"}";

                            //request2.AddParameter("application/json", body2, ParameterType.RequestBody);

                            ////Ejecuta llamado de la API --------------
                            //IRestResponse response2 = client2.Execute(request2);
                            //HttpStatusCode CodigoRetorno2 = response2.StatusCode;

                            ////Si finalizó OK --------------------------
                            //if (CodigoRetorno.Equals(HttpStatusCode.OK))
                            //{
                            //    JObject rss2 = JObject.Parse(response.Content);

                            //    //actualizado ok

                            //    if (rss2["Resultado"].ToString() == "OK")
                            //    {
                            //        //Procesa la confirmacion recibida ----------------------------------------------------------------------
                            //        resultado = WS_Integrador.Classes.model.InfF_Generador.ProcesaArchivo(BD_GETPOINT,
                            //                                                                              NombreArchivo,
                            //                                                                              usuario,
                            //                                                                              DateTime.Now.ToString("yyyyMMdd"));
                            //        //0: Error; 1:OK
                            //        if (resultado == "0;OK")
                            //        {
                            //            MessageBox.Show("voLeeConfirmacionSDD_JSON." + "Confirmacion SDD procesada OK. " +
                            //                    "NumeroReferencia: " + rss["Confirmacion"][i]["NumeroReferencia"].ToString() +
                            //                    "IntId: " + rss["Confirmacion"][i]["IntId"].ToString());
                            //        }
                            //        else
                            //        {
                            //            MessageBox.Show("voLeeConfirmacionSDD_JSON." + "Error: Confirmacion SDD no procesada.");
                            //        }


                            //        MessageBox.Show("voLeeConfirmacionSDD_JSON" + "Integracion OK. IntId: " + rss["Confirmacion"][i]["IntId"].ToString());
                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("voLeeConfirmacionSDD_JSON" + "ERROR: Problema actualizar estado. IntId: " + rss["Confirmacion"][i]["IntId"].ToString() +
                            //                                             ". Mensaje: " + rss2["Resultado_Descripcion"].ToString());
                            //    }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("voLeeConfirmacionSDD_JSON" + "ERROR: Problema llamar API cambio estado. IntId: " + rss["Confirmacion"][i]["IntId"].ToString());
                            //}

                        }// FIN Recorre las confirmaciones que devolvio la API -------
                    }
                    else
                    {
                        MessageBox.Show ("voGenArchivoSDD_JSON" + ", ERROR: Problema al ejecutar api trae confirmaciones. " +
                                                        rss["Resultado_Descripcion"].ToString().Trim() + ". " +
                                                        rss["Descripcion"].ToString().Trim());
                    }
                }
                else
                {
                    MessageBox.Show("voLeeConfirmacionSDD_JSON" + "ERROR: Problema ejecutar API extrae confirmaciones. Codigo respuesta: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                //para evitar error de seguridad en el llamado a la API -----------------------------------------------------------------------------------------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS
                //-----------------------------------------------------------------------------------------------------------------------------------------------

                //LogInfo("voLeeConfirmacionSDR_JSON", "Inicio proceso");

                string NombreArchivo = "";
                string usuario = "INTEGRADOR_API";
                string resultado = "";
                string SqlInsert = "";
                string SqlInsert2 = "";

                //crea lista de campos para insertar
                SqlInsert = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, Texto1, Texto2, Texto3, Texto4, Texto5, Texto6, Texto7, Texto8, Texto9, Texto10, Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20, Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29)";

                //Ejecuta la API para SDR confirmadas no procesadas --------
                var client = new RestClient("https://app.getpoint.cl/API_GP_PERSA/API/INTEGRACION_CONFIRMACIONES_JSON/LISTAR");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-GPOINT-API-TOKEN", "985E2B08-AD1A-4D64-B292-240F82668C0E");
                request.AddHeader("X-GPOINT-API-SECRET", "80B808C3-98A0-4F09-A2E1-46E4F7761649");

                //Carga variable body a enviar
                var body = @"{" + "\n" +
                           @"   ""EmpId"": 1," + "\n" +
                           @"   ""NombreProceso"": ""SDR_CONFIRMADAS""," + "\n" +
                           @"   ""Limit"": 100," + "\n" +
                           @"   ""RowSet"": 0" + "\n" +
                           @"   }";

                request.AddParameter("application/json", body, ParameterType.RequestBody);

                //Ejecuta llamado de la API --------------
                IRestResponse response = client.Execute(request);
                HttpStatusCode CodigoRetorno = response.StatusCode;

                //Si finalizó OK --------------------------
                if (CodigoRetorno.Equals(HttpStatusCode.OK))
                {
                    JObject rss = JObject.Parse(response.Content);
                    //LogInfo("voLeeConfirmacionSDR_JSON", "Ejecuta API SDR confirmadas");

                    //La API se ejecuto correctamente
                    if (rss["Resultado"].ToString().Trim() == "OK")
                    {
                        //Recorre las confirmaciones que devolvio la API -------
                        for (Int32 i = 0; i < rss["Confirmacion"].Count(); i++)
                        {
                            //separa campos concatenados dentro del texto1 de la cabecera en un array --------
                            string[] Texto1Cab = rss["Confirmacion"][i]["Texto1"].ToString().Trim().Split('|');

                            NombreArchivo = "API_WMS_CONF_SDR_" + rss["Confirmacion"][i]["NumeroReferencia"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".csv"; //"Archivo, ";

                            int correlativo = 1;

                            //Recorre los items de la confirmacion
                            for (Int32 item = 0; item < rss["Confirmacion"][i]["Items"].Count(); item++)
                            {
                                //separa campos concatenados dentro del texto1 y crea un arreglo -----------
                                string[] Texto1Det = rss["Confirmacion"][i]["Items"][item]["Texto1"].ToString().Trim().Split('|');

                                //crea lista de valores
                                SqlInsert2 = "('" + NombreArchivo.Trim() + "'," + //"Archivo, " +
                                             "'" + usuario.Trim() + "'," + //"UserName, " +
                                             "'" + DateTime.Now.ToString("yyyyMMdd") + "'," + //"FechaProceso, " +
                                             "'" + correlativo.ToString() + "'," + // "Linea, ";

                                             //textos -----------
                                             "'" + rss["Confirmacion"][i]["NombreProceso"].ToString() + "'," +
                                             "'" + DateTime.Parse(Texto1Cab[2].Trim().Substring(0, 10)).ToString("yyyyMMdd") + " " + Texto1Cab[2].Trim().Substring(11, 8).Replace(":", "") + "'," + // se guarda en el formato "AAAAMMDD HHMMSS" //rss["Confirmacion"][i]["FECHAHORA"].ToString() + "'," +
                                             "'" + Texto1Cab[3].Trim() + "'," + //rss["Confirmacion"][i]["TIPO_TRK"].ToString() + "'," +
                                             "'" + Texto1Cab[0].Trim() + "'," + //rss["Confirmacion"][i]["ID_WMS"].ToString() + "'," +
                                             "'" + Texto1Cab[1].Trim() + "'," + //rss["Confirmacion"][i]["ID_QAD"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["EmpId"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Folio"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["FolioRel"].ToString() + "'," +
                                             "'" + DateTime.Parse(rss["Confirmacion"][i]["FechaProceso"].ToString()).ToString("yyyyMMdd") + "'," +
                                             "'" + rss["Confirmacion"][i]["TipoDocumento"].ToString() + "'," +

                                             "'" + rss["Confirmacion"][i]["NumeroDocto"].ToString() + "'," +
                                             "'" + DateTime.Parse(rss["Confirmacion"][i]["FechaDocto"].ToString()).ToString("yyyyMMdd") + "'," +
                                             "'" + rss["Confirmacion"][i]["TipoReferencia"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["NumeroReferencia"].ToString() + "'," +
                                             "'" + DateTime.Parse(rss["Confirmacion"][i]["FechaReferencia"].ToString()).ToString("yyyyMMdd") + "'," +
                                             "'" + Texto1Cab[5].Trim() + "'," + //rss["Confirmacion"][i]["Items"][item]["PorcTolerancia"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["Linea"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["CodigoArticulo"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["CodigoArticulo"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["UnidadMedida"].ToString() + "'," +

                                             "'" + rss["Confirmacion"][i]["Items"][item]["Cantidad"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["ItemReferencia"].ToString() + "'," +
                                             "'" + rss["Confirmacion"][i]["Items"][item]["NroSerieDesp"].ToString() + "'," +
                                             "'" + DateTime.Parse(rss["Confirmacion"][i]["Items"][item]["FechaVectoDesp"].ToString()).ToString("yyyyMMdd") + "'," +
                                             "'" + Texto1Det[0].Trim() + "'," + //rss["Confirmacion"][i]["Items"][item]["CantAlmacenWMS"].ToString() + "'," +
                                             "'" + Texto1Det[1].Trim() + "'," + //rss["Confirmacion"][i]["Items"][item]["NroSerieAlmacenWMS"].ToString() + "'," +
                                             "'" + DateTime.Parse(Texto1Det[2].Trim()).ToString("yyyyMMdd") + "'," + //rss["Confirmacion"][i]["Items"][item]["FechaVectoAlmacenWMS"].ToString() + "'," +
                                             "'" + Texto1Det[3].Trim() + "'," +
                                             "'" + "1" + "')";

                                //Inserta en tabla de integracion ----------------------------------------------
                                //resultado = WS_Integrador.Classes.model.InfF_Generador.InsertarRegistro_OleDb(BD_GETPOINT,
                                //                                                                              SqlInsert,
                                //                                                                              SqlInsert2);
                                //if (resultado != "")
                                //{
                                //    LogInfo("voLeeConfirmacionSDR_JSON", "Error InsertarRegistro_OLEDb: " + resultado.Trim(), true);
                                //}
                                //else
                                //{
                                //    LogInfo("voLeeConfirmacionSDR_JSON", "Inserta Registro Integracion. Linea: " + correlativo.ToString() +
                                //                                         ", NumeroReferencia: " + rss["Confirmacion"][i]["NumeroReferencia"].ToString());
                                //}

                                correlativo = correlativo + 1;

                            } // FIN ciclo Recorre los items de la confirmacion

                            //----------------------------------------------------------------------
                            //Marcar cabecera registro de integracion despues de insertarlo -----------
                            //----------------------------------------------------------------------------
                            //var client2 = new RestClient(ConfigurationManager.AppSettings["URL_API"].ToString() + "/API/INTEGRACION_CONFIRMACIONES_UPD");
                            //client2.Timeout = -1;
                            //var request2 = new RestRequest(Method.POST);
                            //request2.AddHeader("Content-Type", "application/json");
                            //request2.AddHeader("X-GPOINT-API-TOKEN", ConfigurationManager.AppSettings["TOKEN_API"].ToString());
                            //request2.AddHeader("X-GPOINT-API-SECRET", ConfigurationManager.AppSettings["SECRET_API"].ToString());

                            ////Carga variable body a enviar
                            //var body2 = @"{" + "\n" +
                            //            @"   ""IntId"": " + rss["Confirmacion"][i]["Id"].ToString() + "\n" +
                            //            @"}";

                            //request2.AddParameter("application/json", body2, ParameterType.RequestBody);

                            //Ejecuta llamado de la API --------------
                            //IRestResponse response2 = client2.Execute(request2);
                            //HttpStatusCode CodigoRetorno2 = response2.StatusCode;

                            //Si finalizó OK --------------------------
                            //if (CodigoRetorno.Equals(HttpStatusCode.OK))
                            //{
                            //    JObject rss2 = JObject.Parse(response2.Content);

                            //    //actualizado ok
                            //    if (rss2["Resultado"].ToString() == "OK")
                            //    {
                            //        //Procesa la confirmacion recibida ----------------------------------------------------------------------
                            //        resultado = WS_Integrador.Classes.model.InfF_Generador.ProcesaArchivo(BD_GETPOINT,
                            //                                                                              NombreArchivo,
                            //                                                                              usuario,
                            //                                                                              DateTime.Now.ToString("yyyyMMdd"));
                            //        //0: Error; 1:OK
                            //        if (resultado == "1;OK")
                            //        {
                            //            LogInfo("voLeeConfirmacionSDR_JSON", "Confirmacion SDR procesada OK. " +
                            //                                                 "NumeroReferencia: " + rss["Confirmacion"][i]["NumeroReferencia"].ToString() +
                            //                                                 ", SDR: " + rss["Confirmacion"][i]["Folio"].ToString() +
                            //                                                 ", Picking: " + rss["Confirmacion"][i]["FolioRel"].ToString() +
                            //                                                 ". Id integracion: " + rss["Confirmacion"][i]["Id"].ToString());
                            //        }
                            //        else
                            //        {
                            //            LogInfo("voLeeConfirmacionSDR_JSON", "ERROR: Confirmacion SDR no procesada." +
                            //                                                 "NumeroReferencia: " + rss["Confirmacion"][i]["NumeroReferencia"].ToString() +
                            //                                                 ", SDR: " + rss["Confirmacion"][i]["Folio"].ToString() +
                            //                                                 ", Picking: " + rss["Confirmacion"][i]["FolioRel"].ToString() +
                            //                                                 ". Id integracion: " + rss["Confirmacion"][i]["Id"].ToString());
                            //        }
                            //    }
                            //    else
                            //    {
                            //        LogInfo("voLeeConfirmacionSDR_JSON", "ERROR: Problema actualizar estado. " +
                            //                                             "NumeroReferencia: " + rss["Confirmacion"][i]["NumeroReferencia"].ToString() +
                            //                                             ", SDR: " + rss["Confirmacion"][i]["Folio"].ToString() +
                            //                                             ", Picking: " + rss["Confirmacion"][i]["FolioRel"].ToString() +
                            //                                             ", Id integracion: " + rss["Confirmacion"][i]["Id"].ToString() +
                            //                                             ". Mensaje: " + rss2["Resultado_Descripcion"].ToString());
                            //    }
                            //}
                            //else
                            //{
                            //    LogInfo("voLeeConfirmacionSDR_JSON", "ERROR: Problema llamar API cambio estado. " +
                            //                                         "NumeroReferencia: " + rss["Confirmacion"][i]["NumeroReferencia"].ToString() +
                            //                                         ", SDR: " + rss["Confirmacion"][i]["Folio"].ToString() +
                            //                                         ", Picking: " + rss["Confirmacion"][i]["FolioRel"].ToString() +
                            //                                         ", Id integracion: " + rss["Confirmacion"][i]["Id"].ToString());
                            //}

                        }// FIN Recorre las confirmaciones que devolvio la API -------
                    }
                    else
                    {
                        MessageBox.Show("voLeeConfirmacionSDR_JSON." + "ERROR: Problema al ejecutar api trae confirmaciones. " + 
                                        rss["Resultado_Descripcion"].ToString().Trim() + ". " +
                                                             rss["Descripcion"].ToString().Trim());
                    }
                }
                else
                {
                    MessageBox.Show("voLeeConfirmacionSDR_JSON." + "ERROR: Problema ejecutar API extrae confirmaciones. Codigo respuesta: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("voLeeConfirmacionSDR_JSON." + "ERROR: " + ex.Message.Trim());
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1436;Initial Catalog=Getpoint_GH_Test;Persist Security Info=True");
            OleDbCommand myCommand = new OleDbCommand("Prueba", myConnection);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@empid", OleDbType.Integer).Value = 2;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();

                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "Prueba");
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


            //myDataSet.Tables[0].Columns.Add(new DataColumn("Detalle",GetType(DataTable));


            StringWriter obj = new StringWriter();
            string xmlstring;
            //DataSet ds = new DataSet();

            //myDataSet.WriteXml(obj,);
            xmlstring = obj.ToString();

            MessageBox.Show(xmlstring.Trim());
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //string respuesta = @"{""Items"" : " + responseBody + " }";

            string respuesta = @"{ " +
                               @"     ""Items"": [ " +
                               @"         { " +
                               @"             ""result_count"": 6, " +
                               @"                 ""results"": [ " +
                               @"                     { " +
                               @"                         ""seq_nbr"": 1, " +
                               @"                         ""LPN"": ""IB0000000000008641"", " +
                               @"                     }, " +
                               @"                     { " +
                               @"                         ""seq_nbr"": 2, " +
                               @"                         ""LPN"": ""IB0000000000008641"", " +
                               @"                     } " +
                               @"                 ] " +
                               @"         } " +
                               @"     ] " +
                               @" } ";



            //Crea dataset con el JSON ---
            DataSet myDataSet = JsonConvert.DeserializeObject<DataSet>(respuesta);

            MessageBox.Show("La api retornó " + myDataSet.Tables[0].Rows.Count.ToString() + " registros");

            MessageBox.Show("Primer Producto: " + myDataSet.Tables[0].Rows[0]["ItemCode"].ToString() + " - " +
                                                  myDataSet.Tables[0].Rows[0]["ItemName"].ToString());


        }

        private void button30_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            string URLRoadNet;
            string s;

            URLRoadNet = "http://sapqasp9.ayf.local:8000/sap/bc/srt/wsdl/srvc_62EF45FCC98DEF62E10080F1C0A84651/wsdl11/allinone/ws_policy/document?sap-client=310";

            s = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:urn=""urn:sap-com:document:sap:soap:functions:mc-style"">
                  <soap:Header/>
                    <soap:Body>
                        <urn:ZmmfObtenerProductos>
                        <PFechaultimadescarga>20220831</PFechaultimadescarga>
                        <PLimit>10</PLimit>
                        <PRowset>0</PRowset>
                        <PTipodescarga>0</PTipodescarga>
                        </urn:ZmmfObtenerProductos>
                    </soap:Body>
                  </soap:Envelope>";

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URLRoadNet);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic Qy1BQkFQRVhUMTpHb3BsaWNpdHlAMDEuMjAyMyo=");

            //RESPUESTA
            System.Net.Http.HttpContent content = new StringContent(s, UTF8Encoding.UTF8, "text/xml"); //EJEMPLO DESDE BD

            try
            {
                HttpResponseMessage messge = client.PostAsync(URLRoadNet, content).Result;

                if (messge.IsSuccessStatusCode)
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;

                    //Func.log("Registro OK");
                    //if (respuesta != "")
                    //ActualizarDoc_RoadNet(respuesta);

                    //convierte xml recibido en dataset
                    //trae 5 tablas, la ultima es la tabla con los items

                    DataSet ds = new DataSet();
                    ds.ReadXml(new XmlTextReader(new StringReader(respuesta)));



                }
                else
                {
                    //string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //Func.log("Registro ERROR : " + respuesta);
                }
                content.Dispose();
                client.Dispose();
            }
            catch (Exception ex1)
            {
                content.Dispose();
                client.Dispose();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientes cli = new ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientes();
            ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientesResponse clientesResponse = new ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientesResponse();
            ZWSMM_OBTENER_CLIENTES.service cliservicio = new ZWSMM_OBTENER_CLIENTES.service();

            cli.PFechaultimadescarga = "20221001";
            cli.PLimit = 300;
            cli.PLimitSpecified = true;
            cli.PRowset = 0;
            cli.PTipodescarga = 0;

            System.Net.NetworkCredential clicredenciales = new System.Net.NetworkCredential();
            clicredenciales.UserName = "C-ABAPEXT1";
            clicredenciales.Password = "Goplicity@01.2023*";

            cliservicio.Credentials = clicredenciales;
            clientesResponse = cliservicio.ZmmfObtenerClientes(cli);

            MessageBox.Show(clientesResponse.WeCustomers.Items.Count().ToString());
            //MessageBox.Show(clientesResponse.WeCustomers.Items[0].Rutcliente);


            //an instance of the XmlSerializer class is created
            XmlSerializer inst = new XmlSerializer(typeof(ZWSMM_OBTENER_CLIENTES.ZmmsGetCustomers));

            using (StringWriter textWriter = new StringWriter())
            {
                inst.Serialize(textWriter, clientesResponse.WeCustomers);

                //return textWriter.ToString(); ese comando saca el xml completo
            }

            //=============================================================================================

            string DatoLeido = "";

            ZWSSD_GENERAR_PEDIDO.ZMMF_DO_VA01 DO_VA01 = new ZWSSD_GENERAR_PEDIDO.ZMMF_DO_VA01(); //agrega parametros
            ZWSSD_GENERAR_PEDIDO.ZMMF_DO_VA01Response DO_VA01Response = new ZWSSD_GENERAR_PEDIDO.ZMMF_DO_VA01Response(); //recibe respuesta
            ZWSSD_GENERAR_PEDIDO.service DO_VA01Servicio = new ZWSSD_GENERAR_PEDIDO.service(); //ejecuta llamado

            //Carga credenciales conexion ----------
            NetworkCredential DO_VA01Credenciales = new NetworkCredential();
            DO_VA01Credenciales.UserName = "";
            DO_VA01Credenciales.Password = "";
            DO_VA01Servicio.Credentials = DO_VA01Credenciales;

            //Variable nuevo pedido -------
            ZWSSD_GENERAR_PEDIDO.ZMMS_ORDERS NuevoPedido = new ZWSSD_GENERAR_PEDIDO.ZMMS_ORDERS(); //para la cabecera
            ZWSSD_GENERAR_PEDIDO.ZMMS_ITEMS_ORDERS ITEMS_ORDERS = new ZWSSD_GENERAR_PEDIDO.ZMMS_ITEMS_ORDERS(); //para los items
            List<ZWSSD_GENERAR_PEDIDO.ZMMS_ITEMS_ORDERS> Lista_ITEMS_ORDERS = new List<ZWSSD_GENERAR_PEDIDO.ZMMS_ITEMS_ORDERS>(); //para los items

                        //Carga parametros webservice ----------
            NuevoPedido.DESCTOCAB = "";
            NuevoPedido.DESTINATARIO = "";
            NuevoPedido.EMPID = 1;
            NuevoPedido.ESTADO = "";
            NuevoPedido.FECHADIG = "";
            NuevoPedido.FECHAGEN = "";
            NuevoPedido.FECHAREQ = "";
            NuevoPedido.FOLIOGP = "";
            //NuevoPedido.ITEMS = "";
            NuevoPedido.LPRECIO = "";
            NuevoPedido.NRODOCREL = "";
            NuevoPedido.NROREFERENCIA = "";
            NuevoPedido.OBS1 = "";
            NuevoPedido.OBS2 = "";
            NuevoPedido.ORIGEN = "";
            NuevoPedido.VENDEDOR = "";

            //Agrega linea de detalle ----
            Lista_ITEMS_ORDERS = new List<ZWSSD_GENERAR_PEDIDO.ZMMS_ITEMS_ORDERS>(); //limpia la lista

            ITEMS_ORDERS = new ZWSSD_GENERAR_PEDIDO.ZMMS_ITEMS_ORDERS(); //limpia variable de items
            ITEMS_ORDERS.CANTIDAD = 1;
            ITEMS_ORDERS.CODIGOARTICULO = "ABCDE";
            ITEMS_ORDERS.LINEA = "1";
            Lista_ITEMS_ORDERS.Add(ITEMS_ORDERS); //Agrega ITEM a la Lista

            ITEMS_ORDERS = new ZWSSD_GENERAR_PEDIDO.ZMMS_ITEMS_ORDERS(); //limpia variable de items
            ITEMS_ORDERS.CANTIDAD = 20;
            ITEMS_ORDERS.CODIGOARTICULO = "XYZ";
            ITEMS_ORDERS.LINEA = "2";
            Lista_ITEMS_ORDERS.Add(ITEMS_ORDERS); //Agrega ITEM a la Lista

            NuevoPedido.ITEMS = Lista_ITEMS_ORDERS.ToArray();

            DO_VA01.WA_DATOS = NuevoPedido;

            //Realiza llamado -----
            DO_VA01Response = DO_VA01Servicio.ZMMF_DO_VA01(DO_VA01);

            //Si respuesta es OK -------
            if (DO_VA01Response.WE_RESULT.RESULTADO == "OK")
            {
                //Si trae datos
                if (DO_VA01Response.WE_RESULT.COUNT > 0)
                {
                    DatoLeido = DO_VA01Response.WE_RESULT.ESTADOPEDIDOERP;
                    DatoLeido = DO_VA01Response.WE_RESULT.NROPEDIDOERP;
                    DatoLeido = DO_VA01Response.WE_RESULT.OBSERVACIONES;
                }
            }

            //------------------------------------------------------------------

            string usuario = "C-ABAPEXT1";
            string clave = "Goplicity@01.2023*";

            ZWSMM_OBTENER_DESC_DEST.ZmmfObtenerDescDestinatario obtenerDescDestinatario = new ZWSMM_OBTENER_DESC_DEST.ZmmfObtenerDescDestinatario();
            ZWSMM_OBTENER_DESC_DEST.ZmmfObtenerDescDestinatarioResponse obtenerDescDestinatarioResponse = new ZWSMM_OBTENER_DESC_DEST.ZmmfObtenerDescDestinatarioResponse();
            ZWSMM_OBTENER_DESC_DEST.service obtenerDescDestinatarioServicio = new ZWSMM_OBTENER_DESC_DEST.service();

            //Carga credenciales conexion ----------
            NetworkCredential obtenerDescDestinatarioCredenciales = new NetworkCredential();
            obtenerDescDestinatarioCredenciales.UserName = usuario.Trim();
            obtenerDescDestinatarioCredenciales.Password = clave.Trim();
            obtenerDescDestinatarioServicio.Credentials = obtenerDescDestinatarioCredenciales;

            //Carga parametros webservice ----------
            obtenerDescDestinatario.PDestinatario = "0035370595;0010893697";
            obtenerDescDestinatario.PFechaultimadescarga = "?";
            obtenerDescDestinatario.PLimit = 100;
            obtenerDescDestinatario.PRowset = 0;
            obtenerDescDestinatario.PTipodescarga = 0;

            //Realiza llamado -----
            obtenerDescDestinatarioResponse = obtenerDescDestinatarioServicio.ZmmfObtenerDescDestinatario(obtenerDescDestinatario);

            MessageBox.Show(obtenerDescDestinatarioResponse.WeDescdest.Items.Count().ToString());

            //Si respuesta es OK -------
            //if (obtenerDescDestinatarioResponse.WeDescdest.Resultado == "OK")
            //{
            //    //Si trae datos
            //    if (obtenerDescDestinatarioResponse.WeDescdest.Count > 0)
            //    {

            //    }
            //}

            //----------------------------------------------------


            //local.ayf.sapqasp91.ZmmfObtenerClientes cli = new local.ayf.sapqasp91.ZmmfObtenerClientes();
            //local.ayf.sapqasp91.ZmmfObtenerClientesResponse clientesResponse = new local.ayf.sapqasp91.ZmmfObtenerClientesResponse();
            //local.ayf.sapqasp91.service cliservicio = new local.ayf.sapqasp91.service();

            //cli.PFechaultimadescarga = "20221001";
            //cli.PLimit = 1000;
            //cli.PRowset = 0;
            //cli.PTipodescarga = 0;

            //System.Net.NetworkCredential clicredenciales = new System.Net.NetworkCredential();
            //clicredenciales.UserName = "C-ABAPEXT1";
            //clicredenciales.Password = "Goplicity@01.2023*";

            //cliservicio.Credentials = clicredenciales;

            //clientesResponse = cliservicio.ZmmfObtenerClientes(cli);

            //MessageBox.Show(clientesResponse.WeCustomers.Items.Count().ToString());
            //MessageBox.Show(clientesResponse.WeCustomers.Items[0].Rutcliente);




            //----------------------------------------------------------------------------------------------------
            //local.ayf.sapqasp9.ZmmfObtenerProductos prod = new local.ayf.sapqasp9.ZmmfObtenerProductos();
            //local.ayf.sapqasp9.ZmmfObtenerProductosResponse productoResponse = new local.ayf.sapqasp9.ZmmfObtenerProductosResponse();

            //local.ayf.sapqasp9.service servicio = new local.ayf.sapqasp9.service();

            //prod.PFechaultimadescarga = "20220831";
            //prod.PLimit = 10;
            //prod.PRowset = 0;
            //prod.PTipodescarga = 0;

            //System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential();
            //credenciales.UserName = "C-ABAPEXT1";
            //credenciales.Password = "Goplicity@01.2023*";

            //servicio.Credentials = credenciales;

            //productoResponse = servicio.ZmmfObtenerProductos(prod);


            //MessageBox.Show(productoResponse.WeProducts.Items.Count().ToString());
            ////MessageBox.Show(p.WeProducts.Items[0].Descripart);

            //if (productoResponse.WeProducts.Items.Count() > 0)
            //{
            //    //an instance of the XmlSerializer class is created
            //    XmlSerializer inst2 = new XmlSerializer(typeof(local.ayf.sapqasp9.ZmmsGetProducts));

            //    using (StringWriter textWriter = new StringWriter())
            //    {
            //        inst2.Serialize(textWriter, productoResponse.WeProducts);

            //        //return textWriter.ToString(); ese comando saca el xml completo
            //    }

            //}




















            //=========================================================================================================

            //ServiceReference1.ZmmfObtenerClientes c = new ServiceReference1.ZmmfObtenerClientes();
            //ServiceReference1.ZmmfObtenerClientesResponse cr = new ServiceReference1.ZmmfObtenerClientesResponse();
            //ServiceReference1.ZmmfObtenerClientesResponse1 cr1 = new ServiceReference1.ZmmfObtenerClientesResponse1();
            //ServiceReference1.ZmmfObtenerClientesRequest crq = new ServiceReference1.ZmmfObtenerClientesRequest();


            //c.PFechaultimadescarga = "20220831";
            //c.PTipodescarga = 0;
            //c.PRowset = 0;
            //c.PLimit = 10;

            //crq.ZmmfObtenerClientes.PFechaultimadescarga = "20220831";
            //crq.ZmmfObtenerClientes.PTipodescarga = 0;
            //crq.ZmmfObtenerClientes.PRowset = 0;
            //crq.ZmmfObtenerClientes.PLimit= 10;
            //c = crq.ZmmfObtenerClientes;



            //var resultado = cr1.ZmmfObtenerClientesResponse;






            ////DataSet myDataSet;
            //string DatoLeido = "";

            ////if (myDataSet.Tables[0].Rows[i]["NombreProceso"].ToString().Trim() == "ZWSMM_OBTENER_CLIENTES")
            //{
            //    ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientes obtenerClientes = new ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientes();
            //    ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientesResponse obtenerClientesResponse = new ZWSMM_OBTENER_CLIENTES.ZmmfObtenerClientesResponse();
            //    ZWSMM_OBTENER_CLIENTES.service obtenerClientesServicio = new ZWSMM_OBTENER_CLIENTES.service();



            //    //Carga credenciales conexion ----------
            //    NetworkCredential obtenerClientesCredenciales = new NetworkCredential();
            //    obtenerClientesCredenciales.UserName = "C-ABAPEXT1";
            //    obtenerClientesCredenciales.Password = "Goplicity@01.2023*";
            //    obtenerClientesServicio.Credentials = obtenerClientesCredenciales;

            //    //Carga parametros webservice ----------
            //    obtenerClientes.PFechaultimadescarga = "20220701";
            //    obtenerClientes.PLimit = 10;
            //    obtenerClientes.PRowset = 0;
            //    obtenerClientes.PTipodescarga = 0;

            //    //Realiza llamado -----
            //    obtenerClientesResponse = obtenerClientesServicio.ZmmfObtenerClientes(obtenerClientes);

            //                obtenerClientesServicio.ZmmfObtenerClientesCompleted





            //    //Valida respuesta -------
            //    if (obtenerClientesResponse.WeCustomers.Resultado == "OK")
            //    {
            //        ZWSMM_OBTENER_CLIENTES.ZmmsGetItemsCustomers[] Filas = obtenerClientesResponse.WeCustomers.Items;


            //        for (int a = 0; a < obtenerClientesResponse.WeCustomers.Count - 1; a++)
            //        {
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Apellidos;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Banco.ToString();
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Ciuid;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Codigoext;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Codigolista;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Comuna;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Contacto;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Direccion;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Email;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Empid.ToString();
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Formapago;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Georeferencia;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Giro.ToString();
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Id.ToString();
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Indbloqueo;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Lineacredito;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Nombrefantasia;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Nombres;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Nombresucursal;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Nrocuenta;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Numeroreferencia;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Origen;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Razonsocial;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Region.ToString();
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Rutcliente;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Sucursal.ToString();
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Telefono;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Telefonocontacto;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Tipocliente;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Tiporeferencia;
            //            DatoLeido = obtenerClientesResponse.WeCustomers.Items[a].Vendedor;
            //        }
            //    }
            //}

            ////========================================================================
            ////========================================================================

            //pruebaSAP.ZmmfObtenerProductos prod = new pruebaSAP.ZmmfObtenerProductos();
            //pruebaSAP.ZmmfObtenerProductosResponse p = new pruebaSAP.ZmmfObtenerProductosResponse();

            //pruebaSAP.service servicio = new pruebaSAP.service();

            //prod.PFechaultimadescarga = "20230101";
            //prod.PLimit = 10;
            //prod.PRowset = 0;
            //prod.PTipodescarga = 0;

            //System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential();
            //credenciales.UserName = "C-ABAPEXT1";
            //credenciales.Password = "Goplicity@01.2023*";

            //servicio.Credentials = credenciales;

            //p = servicio.ZmmfObtenerProductos(prod);

            //string texto;

            //texto = "";


            //Console.WriteLine("{0}", proxy.GetData("this is my service"));
            //proxy.GetDataUsingDataContract(asg);
            //Console.WriteLine("{0}", proxy.GetDataUsingDataContract(asg).StringValue);
            //Console.Read();

        }

        private void button33_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------------
            CLIENTES.ZSDF_OBTCLI cli = new CLIENTES.ZSDF_OBTCLI();
            CLIENTES.ZSDF_OBTCLIResponse clientesResponse = new CLIENTES.ZSDF_OBTCLIResponse();
            CLIENTES.service cliservicio = new CLIENTES.service();

            cli.P_FECHAULTIMADESCARGA = "20220101";
            cli.P_LIMIT = 100;
            cli.P_ROWSET = 0;
            cli.P_TIPODESCARGA = 0;
            cli.P_LIMITSpecified = true;
            

            System.Net.NetworkCredential clicredenciales = new System.Net.NetworkCredential();
            clicredenciales.UserName = "C-ABAPEXT1";
            clicredenciales.Password = "Goplicity@01.2023*";

            cliservicio.Credentials = clicredenciales;

            clientesResponse = cliservicio.ZSDF_OBTCLI(cli);

            MessageBox.Show(clientesResponse.WE_CUSTOMERS.ITEMS.Count().ToString());
            //MessageBox.Show(clientesResponse.WeCustomers.Items[0].Rutcliente);


            //an instance of the XmlSerializer class is created
            XmlSerializer inst = new XmlSerializer(typeof(ZWSMM_OBTENER_CLIENTES.ZmmsGetCustomers));

            using (StringWriter textWriter = new StringWriter())
            {
                inst.Serialize(textWriter, clientesResponse.WE_CUSTOMERS);

                //return textWriter.ToString(); ese comando saca el xml completo
            }

        }

        private void button34_Click(object sender, EventArgs e)
        { 
            string prueba = "";

            prueba = prueba.PadLeft(2147000000);


            MessageBox.Show(prueba.Length.ToString());

        }

        private void button35_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime Fecha;

                Fecha = FechaValida(textBox5.Text.Trim(), "FechaPrueba");
                

                MessageBox.Show("Fecha OK: " + Fecha.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de fecha: " + ex.Message.Trim());
            }

        }

        private DateTime FechaValida(string Fecha,string NombreCampo)
        {
            try
            {
                if (Fecha.Equals(""))
                {
                    return DateTime.ParseExact("01-01-1900", "dd-MM-yyyy", null);
                }
                else
                {
                    return DateTime.ParseExact(Fecha, "dd-MM-yyyy", null);
                }
            }
            catch { throw new Exception("ERROR - " + NombreCampo.Trim() + " DEBE SER FORMATO FECHA dd-MM-yyyy, por ejemplo 06-11-2020"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {
            //Carga URL de la API del cliente para enviar la confirmacion de la SDD --------------------
            #region Carga URL de la API del cliente para enviar la confirmacion de la SDD 
            var client = new RestClient("http://200.54.198.4:8015/sap/zconfirma_recep/WEBHOOK_MOVTO_AJUSTE?sap-client=320");

            client.Timeout = -1;

            //Indica el metodo de llamado de la API ----
            var request = new RestRequest(Method.GET);
            switch ("GET")
            {
                case "GET":
                    request = new RestRequest(Method.GET); //consulta
                    break;
                case "POST":
                    request = new RestRequest(Method.POST); //crea
                    break;
                case "PUT":
                    request = new RestRequest(Method.PUT); //modifica
                    break;
            }

            //Trae informacion para headers segun el nombre proceso -------
            //DataSet dsHeaders = WS_Integrador.Classes.model.InfF_Generador.ShowList_EndPointHeadersJson(EmpIdGlobal,
            //                                                                                            EmpId,
            //                                                                                            myData.Tables[0].Rows[i]["NombreProceso"].ToString(),
            //                                                                                            2);

            //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
            //if (dsHeaders.Tables.Count > 0)
            //{
            //    for (int k = 0; k <= dsHeaders.Tables[0].Rows.Count - 1; k++)
            //    {
            //        //agrega key y su valor -----------
            //        request.AddHeader(dsHeaders.Tables[0].Rows[k]["myKey"].ToString().Trim(), dsHeaders.Tables[0].Rows[k]["myValue"].ToString().Trim());
            //    }
            //}

            request.AddHeader("x-csrf-token", "fetch");
            request.AddHeader("Authorization", "Basic aGVkZXM6aW5pY2lvMDM=");

            #endregion

            //Carga Variable para generar JSON ----------------------------------------------

            DateTime fecha;
            fecha = DateTime.Now;

            //-------------------------------------------------------------
            //Crea body para llamado con estructura de variable cargada ---
            //var body = JsonConvert.SerializeObject(CabJson);

            //Guarda JSON que se envia ------------------
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            //EJECUTA LLAMADO API ---------------------------
            IRestResponse response = client.Execute(request);
            HttpStatusCode CodigoRetorno = response.StatusCode;
            //JObject rss = JObject.Parse(response.Content); //recupera json de retorno

            string Respuesta = "";
            string cookie_llamado = "";

            //Si finalizó OK --------------------------
            if (CodigoRetorno.Equals(HttpStatusCode.OK)) //Si la API destino retorna un status 200 marca como integrado OK ---
            {
                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado Procesado 

                cookie_llamado = response.Cookies[0].Name.Trim() + "=" + response.Cookies[0].Value.Trim();
                cookie_llamado = cookie_llamado.Trim() + ";" + response.Cookies[1].Name.Trim() + "=" + response.Cookies[1].Value.Trim();

                string token_ = "";

                for (int i = 0; i < response.Headers.Count; i++)
                {
                
                    if (response.Headers[i].Name.Trim() == "x-csrf-token")
                    {
                        token_ = response.Headers[i].Value.ToString().Trim();
                    }
                }



                    Respuesta = "Integracion OK. IntId: ";

            }
            else //status Error <> 200
            {
                //Actualiza estado de L_IntegraConfirmacionesDet, deja en estado error 

                Respuesta = "Error. IntId: ";
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            ConsultaPedidosDoctoLegal("");
        }

        public static bool ConsultaPedidosDoctoLegal(string FechaDescarga)
        {
            //LogInfo("ConsultaPedidosDoctoLegal", "Inicio proceso", true);
            bool resultCons = false;

        //    try
        //    {
        //        int hora = DateTime.Now.Hour;
        //        string hora_ejecucion;

        //        hora_ejecucion = ConfigurationManager.AppSettings["BSALE_Hora_ConsultaPedidosDoctoLegal"].ToString();

        //        //if (hora == 7) //Para que se ejecute solo de 7:00 a 7:59 
        //        //Busca la hora como '7'
        //        if (hora_ejecucion.IndexOf("'" + hora.ToString() + "'") >= 0) //si la hora esta dentro de la key ejecuta el proceso
        //        {
        //            string sqlQuery = "";
        //            string stArchivo = "";
        //            string stUserName = "";
        //            string dtFechaProcesoInt = "1900-01-01";
        //            int stLinea = 0;
        //            string stTexto1 = "", stTexto2 = "", stTexto3 = "", stTexto4 = "", stTexto5 = "", stTexto6 = "", stTexto7 = "", stTexto8 = "", stTexto9 = "";
        //            string stTexto10 = "", stTexto11 = "", stTexto12 = "", stTexto13 = "", stTexto14 = "", stTexto15 = "", stTexto16 = "", stTexto17 = "", stTexto18 = "", stTexto19 = "";
        //            string stTexto20 = "", stTexto21 = "", stTexto22 = "", stTexto23 = "", stTexto24 = "", stTexto25 = "", stTexto26 = "", stTexto27 = "", stTexto28 = "", stTexto29 = "";
        //            string stTexto30 = "", stTexto31 = "", stTexto32 = "", stTexto33 = "", stTexto34 = "", stTexto35 = "", stTexto36 = "", stTexto37 = "", stTexto38 = "", stTexto39 = "";
        //            string stTexto40 = "", stTexto41 = "", stTexto42 = "", stTexto43 = "", stTexto44 = "", stTexto45 = "", stTexto46 = "", stTexto47 = "", stTexto48 = "", stTexto49 = "";
        //            string stTexto50 = "", stTexto51 = "", stTexto52 = "", stTexto53 = "", stTexto54 = "", stTexto55 = "", stTexto56 = "", stTexto57 = "", stTexto58 = ""; //stTexto59 = "";

        //            string stDoc_Type = ConfigurationManager.AppSettings["BSALE_DocType"].ToString();
        //            string stEmpId = ConfigurationManager.AppSettings["EmpId"].ToString();

        //            string result = "";
        //            int _CantDocto = 0;
        //            int _limit = 0;
        //            int _CantLineas = 0;
        //            int offset = 0;
        //            int ContadorOffset = 0;

        //            string sUrlRequest = "";
        //            string DATA = "";
        //            string shipping_type_id = "";
        //            string destinationOffice_id = "";

        //            DataSet myDataSet = new DataSet();

        //            string BSALE_FechaEpoch = ConfigurationManager.AppSettings["BSALE_FechaEpoch"].ToString();
        //            string BSALE_Number = ConfigurationManager.AppSettings["BSALE_Number"].ToString();
        //            DateTime _date1, _date;
        //            Int32 unixTimestamp1, unixTimestamp2;

        //            if (FechaDescarga.Trim() != "")
        //            {
        //                BSALE_FechaEpoch = FechaDescarga;
        //            }

        //            if (BSALE_FechaEpoch == "")
        //            {
        //                //para que se ejecute con los documentos del dia
        //                _date1 = DateTime.Parse(DateTime.Now.ToShortDateString());

        //                //if (hora == 7)
        //                //{
        //                //    _date1 = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
        //                //}
        //                //else
        //                //{
        //                //    _date1 = DateTime.Parse(DateTime.Now.ToShortDateString());
        //                //}

        //                //_date1 = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
        //                //SE DEJA SOLO LA FECHA DEL DIA ACTUAL

        //                _date = DateTime.Parse(DateTime.Now.ToShortDateString());
        //                unixTimestamp1 = (Int32)(_date1.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        //                unixTimestamp2 = (Int32)(_date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        //            }
        //            else
        //            {
        //                unixTimestamp1 = Int32.Parse(BSALE_FechaEpoch);
        //                unixTimestamp2 = Int32.Parse(BSALE_FechaEpoch);
        //            }

        //            /*RECUPERA OFFSET DESDE BD*/
        //            //result = WS_Integrador.Classes.model.InfF_Generador.ValEjecutaProcesoOffSet();
        //            //offset = int.Parse(result);

        //            offset = 0;

        //        Reprocesar:

        //            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
        //            ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1
        //                                                                              //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //                                                                              //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
        //            HttpResponseMessage response = new HttpResponseMessage();

        //            PedidoDocumentosBSale PedidoDocumentosBSale;
        //            ShippingBSale ShippingBSale1;
        //            TaxDocument TaxDocument;
        //            DocumentAttributte DocumentAttributte;
        //            Variants VariantsDetalle;

        //            string datoCourier = string.Empty;
        //            string Glosa = string.Empty;
        //            string Glosacheckout = string.Empty;
        //            string shipping_id = string.Empty;
        //            string clientStreetcheckout = string.Empty;
        //            string clientCityZonecheckout = string.Empty;
        //            string clientState = string.Empty;
        //            string clientEmail = string.Empty;
        //            string clientPhone = string.Empty;
        //            string payProcesscheckout = string.Empty;
        //            string idVentaMercadoLibre = string.Empty;
        //            string documentEmail = string.Empty;
        //            string documentPhone = string.Empty;
        //            string documentCity = string.Empty;
        //            string documentMunicipality = string.Empty;
        //            string documentAddress = string.Empty;
        //            string clientAddress = string.Empty;
        //            string retiroTienda = "0";
        //            string clientNumber = "";
        //            bool InsertaIntegracion = false;

        //            HttpContent content = new StringContent(DATA);

        //            //LogInfo("antes llamado api extrae", "ConsultaPedidosDoctoLegal");
        //            stUserName = "Integrado_BSALE";
        //            if (BSALE_Number == "")
        //            {
        //                //TODOS LOS DOCUMENTOS DE VENTAS
        //                sUrlRequest = "https://api.bsale.cl/v1/documents.json?emissiondaterange=[" + unixTimestamp1 + "," + unixTimestamp2 + "]&expand=[document_types,details,variant,client]&offset=" + offset + "&limit=50";
        //                stUserName = "Integrado_BSALE";

        //                //SOLO BOLETAS 
        //                //sUrlRequest = "https://api.bsale.cl/v1/documents.json?emissiondaterange=[" + unixTimestamp1 + "," + unixTimestamp2 + "]&expand=[document_types,details,variant,client]&offset=" + offset + "&limit=50&documenttypeid=1";
        //                //stUserName = "Integrado_BSALE_BOL";
        //            }
        //            else
        //            {
        //                sUrlRequest = "https://api.bsale.cl/v1/documents.json?emissiondaterange=[" + unixTimestamp1 + "," + unixTimestamp2 + "]&expand=[document_types,details,variant,client]&offset=" + offset + "&limit=50&number=" + BSALE_Number;
        //            }

        //            HttpClient client = new HttpClient();
        //            client.BaseAddress = new Uri(sUrlRequest);

        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));

        //            //TOKEN DE PRODUCCION
        //            client.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

        //            // List data response.
        //            //LogInfo("ConsultaPedidosDoctoLegal_Get", sUrlRequest);
        //            //LogInfo("ConsultaPedidosDoctoLegal_GetToken", ConfigurationManager.AppSettings["TokenBsale"].ToString());

        //            try
        //            {
        //                //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
        //                //response = client.GetAsync(sUrlRequest).Result; //Ejecuta consulta de documentos 

        //                //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
        //                for (Int32 intentos_8 = 1; intentos_8 <= 3; intentos_8++)
        //                {
        //                    response = client.GetAsync(sUrlRequest).Result; //Ejecuta consulta de documentos 

        //                    //Si la respuesta es un json válido y no un texto html
        //                    //if (response.Content.ToString().Contains("{") == true &&
        //                    //    response.Content.ToString().Contains("<html>") == false &&
        //                    //    response.Content.ToString().Contains("502 Bad Gateway") == false)

        //                    if (response.IsSuccessStatusCode) // finalizo ok
        //                    {
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_8.ToString().Trim() +
        //                                                             ", URL: " + sUrlRequest.Trim() +
        //                                                             ", Respuesta BSALE: " + response.ToString().Trim());

        //                    }
        //                } // ---------------------------------------------------------------------------------------------
        //            }
        //            catch (Exception e_)
        //            {
        //                LogInfo("ConsultaPedidosDoctoLegal_PostGet", "Error: " + e_.ToString(), true);
        //            }

        //            //Si finalizó correctamente -----
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string valor = response.Content.ReadAsStringAsync().Result;

        //                PedidoDocumentosBSale = JsonConvert.DeserializeObject<PedidoDocumentosBSale>(valor);

        //                _CantDocto = PedidoDocumentosBSale.count;
        //                _limit = PedidoDocumentosBSale.limit;

        //                foreach (var Document in PedidoDocumentosBSale.items)
        //                {
        //                    /*CONTADOR DE REGISTROS EXTRAIDOS*/
        //                    ContadorOffset = ContadorOffset + 1;

        //                    //Si el tipo de documento esta dentro de los permitidos ==> Integra
        //                    if (stDoc_Type.IndexOf("'" + Document.document_type.id.ToString() + "'") >= 0)
        //                    {
        //                        //LogInfo("va por el documento:", Document.id.ToString()+ " - Tipo Docto: " + Document.document_type.id.ToString());

        //                        stTexto58 = Document.id.ToString();
        //                        //LogInfo("Dentro del For document_type:" + Document.document_type.id.ToString() + ", Number:" + Document.number.ToString(), "");

        //                        //Valida si el docto ya fue integrado, solo procesa documentos no integrados --------
        //                        if (WS_Integrador.Classes.model.InfF_Generador.ValDoctoIntegrado(Document.urlPublicView.Trim(),
        //                                                                                         Document.document_type.id.ToString(),
        //                                                                                         Document.number.ToString(),
        //                                                                                         Document.emissionDate.ToString()) == "0")
        //                        {
        //                            LogInfo("ConsultaPedidosDoctoLegal", "Documento Por integrar:" + Document.document_type.id.ToString() + ", Number:" + Document.number.ToString());

        //                            //Indica si debe concatenar el Tipo Docto Guia + '-' + Tipo de Guia ----- 
        //                            if (ConfigurationManager.AppSettings["BSALE_Guia_TipoDespacho"].ToString() == "True")
        //                            {
        //                                //21.01.2021
        //                                //Si el documento es de tipo guia de despacho
        //                                //ejecuta api de shipping para obtener tipo de guia y sucursal de destino
        //                                if (Document.document_type.id.ToString() == "7")
        //                                {
        //                                    shipping_type_id = ""; destinationOffice_id = "";

        //                                    //LogInfo("Antes de BaseAddress", "");
        //                                    sUrlRequest = "https://api.bsale.cl/v1/shippings.json?documentid=" + Document.id.ToString() + "&expand=[guide,document_types,client,office,payments,details]";

        //                                    HttpClient client2 = new HttpClient();
        //                                    client2.BaseAddress = new Uri(sUrlRequest);

        //                                    client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                                    client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
        //                                    //TOKEN DE PRODUCCION
        //                                    client2.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

        //                                    try
        //                                    {
        //                                        //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
        //                                        //response = client2.GetAsync(sUrlRequest).Result;

        //                                        //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
        //                                        for (Int32 intentos_1 = 1; intentos_1 <= 3; intentos_1++)
        //                                        {
        //                                            response = client2.GetAsync(sUrlRequest).Result;

        //                                            //Si la respuesta es un json válido y no un texto html
        //                                            //if (response.Content.ToString().Contains("{") == true &&
        //                                            //    response.Content.ToString().Contains("<html>") == false &&
        //                                            //    response.Content.ToString().Contains("502 Bad Gateway") == false)

        //                                            if (response.IsSuccessStatusCode) // finalizo ok
        //                                            {
        //                                                break;
        //                                            }
        //                                            else
        //                                            {
        //                                                LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_1.ToString().Trim() +
        //                                                                                     ", URL: " + sUrlRequest.Trim() +
        //                                                                                     ", Respuesta BSALE: " + response.ToString().Trim());

        //                                            }
        //                                        } // ---------------------------------------------------------------------------------------------

        //                                        valor = response.Content.ReadAsStringAsync().Result;

        //                                        ShippingBSale1 = JsonConvert.DeserializeObject<ShippingBSale>(valor);

        //                                        foreach (var ShippingDocument in ShippingBSale1.items)
        //                                        {
        //                                            if (ShippingDocument.shipping_type.id.ToString() != null)
        //                                            { shipping_type_id = ShippingDocument.shipping_type.id.ToString(); }
        //                                            else
        //                                            { shipping_type_id = "0"; }

        //                                            //solo cuando es shipping_type_id=5; Traslados internos (no constituye venta)
        //                                            destinationOffice_id = "0";
        //                                            if (shipping_type_id == "5")
        //                                            {
        //                                                if (ShippingDocument.destinationOffice.id.ToString() != null)
        //                                                { destinationOffice_id = ShippingDocument.destinationOffice.id.ToString(); }
        //                                            }
        //                                        }
        //                                    }
        //                                    catch (AggregateException e)
        //                                    {
        //                                        LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Shipping. Error:" + e.ToString(), true);
        //                                        LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Shipping. URL:" + sUrlRequest.ToString(), true);
        //                                    }

        //                                    client2.Dispose();
        //                                }
        //                            }

        //                            //OBTENER DATO TIPO COURIER
        //                            sUrlRequest = "https://api.bsale.io/v1/markets/checkout/list.json?id_venta_documento_tributario=" + Document.id;

        //                            HttpClient client3 = new HttpClient();
        //                            client3.BaseAddress = new Uri(sUrlRequest);

        //                            client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                            client3.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
        //                            //TOKEN DE PRODUCCION
        //                            client3.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

        //                            try
        //                            {
        //                                //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
        //                                //response = client3.GetAsync(sUrlRequest).Result;

        //                                //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
        //                                for (Int32 intentos_2 = 1; intentos_2 <= 3; intentos_2++)
        //                                {
        //                                    response = client3.GetAsync(sUrlRequest).Result;

        //                                    //Si la respuesta es un json válido y no un texto html
        //                                    //if (response.Content.ToString().Contains("{") == true &&
        //                                    //    response.Content.ToString().Contains("<html>") == false &&
        //                                    //    response.Content.ToString().Contains("502 Bad Gateway") == false)

        //                                    if (response.IsSuccessStatusCode) // finalizo ok
        //                                    {
        //                                        break;
        //                                    }
        //                                    else
        //                                    {
        //                                        LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_2.ToString().Trim() +
        //                                                                             ", URL: " + sUrlRequest.Trim() +
        //                                                                             ", Respuesta BSALE: " + response.ToString().Trim());

        //                                    }
        //                                } // ---------------------------------------------------------------------------------------------

        //                                valor = response.Content.ReadAsStringAsync().Result;

        //                                TaxDocument = JsonConvert.DeserializeObject<TaxDocument>(valor);

        //                                //Limpia variables -----
        //                                clientNumber = "";
        //                                clientStreetcheckout = "";
        //                                clientCityZonecheckout = "";
        //                                clientState = "";
        //                                clientEmail = "";
        //                                clientPhone = "";
        //                                clientAddress = "";
        //                                datoCourier = "";
        //                                Glosacheckout = "";
        //                                payProcesscheckout = "";
        //                                retiroTienda = "0";
        //                                shipping_id = "";
        //                                idVentaMercadoLibre = "0";

        //                                if (TaxDocument.data != null)
        //                                {
        //                                    foreach (var item in TaxDocument.data)
        //                                    {
        //                                        clientNumber = item.clientBuildingNumber == null ? "" : item.clientBuildingNumber.ToString();
        //                                        clientStreetcheckout = item.clientStreet == null ? "" : item.clientStreet.ToString();
        //                                        clientCityZonecheckout = item.clientCityZone == null ? "" : item.clientCityZone.ToString();
        //                                        clientState = item.clientState == null ? "" : item.clientState.ToString();
        //                                        clientEmail = item.clientEmail == null ? "" : item.clientEmail.ToString();
        //                                        clientPhone = item.clientPhone == null ? "" : item.clientPhone.ToString();
        //                                        clientAddress = clientStreetcheckout + "," + clientNumber + ", " + clientCityZonecheckout;
        //                                        datoCourier = item.stName == null ? "" : item.stName.ToString();
        //                                        Glosacheckout = item.shippingComment == null ? "" : item.shippingComment.ToString();
        //                                        payProcesscheckout = item.payProcess == null ? "" : item.payProcess.ToString();
        //                                        retiroTienda = item.pickStoreId.ToString() == null ? "0" : item.pickStoreId.ToString();

        //                                        if (item.integrationDetail != null)
        //                                        {
        //                                            shipping_id = item.integrationDetail.shipping_id == null ? "" : item.integrationDetail.shipping_id.ToString();
        //                                            idVentaMercadoLibre = item.integrationDetail.id == null ? "0" : item.integrationDetail.id.ToString();
        //                                        }
        //                                        else
        //                                        {
        //                                            shipping_id = "";
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                            catch (AggregateException e)
        //                            {
        //                                LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de TaxDocument. Error:" + e.ToString(), true);
        //                                LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de TaxDocument. URL:" + sUrlRequest.ToString(), true);
        //                            }
        //                            //FIN OBTENER DATO TIPO COURIER

        //                            //OBTENER GLOSA
        //                            if (!string.IsNullOrEmpty(Document.attributes.href.ToString()))
        //                            {
        //                                sUrlRequest = Document.attributes.href.ToString();

        //                                HttpClient client4 = new HttpClient();
        //                                client4.BaseAddress = new Uri(sUrlRequest);

        //                                client4.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                                client4.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
        //                                //TOKEN DE PRODUCCION
        //                                client4.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

        //                                try
        //                                {
        //                                    //response = client.GetAsync(sUrlRequest).GetAwaiter().GetResult();
        //                                    //response = client4.GetAsync(sUrlRequest).Result;

        //                                    //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
        //                                    for (Int32 intentos_3 = 1; intentos_3 <= 3; intentos_3++)
        //                                    {
        //                                        response = client4.GetAsync(sUrlRequest).Result;

        //                                        //Si la respuesta es un json válido y no un texto html
        //                                        //if (response.Content.ToString().Contains("{") == true &&
        //                                        //    response.Content.ToString().Contains("<html>") == false &&
        //                                        //    response.Content.ToString().Contains("502 Bad Gateway") == false)

        //                                        if (response.IsSuccessStatusCode) // finalizo ok
        //                                        {
        //                                            break;
        //                                        }
        //                                        else
        //                                        {
        //                                            LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_3.ToString().Trim() +
        //                                                                                 ", URL: " + sUrlRequest.Trim() +
        //                                                                                 ", Respuesta BSALE: " + response.ToString().Trim());

        //                                        }
        //                                    } // ---------------------------------------------------------------------------------------------

        //                                    valor = response.Content.ReadAsStringAsync().Result;

        //                                    DocumentAttributte = JsonConvert.DeserializeObject<DocumentAttributte>(valor);

        //                                    if (DocumentAttributte.items != null)
        //                                    {
        //                                        foreach (var item in DocumentAttributte.items)
        //                                        {
        //                                            if (item.name != null)
        //                                            {
        //                                                if (item.name.Trim().ToUpper() == "NOTA".Trim().ToUpper())
        //                                                {
        //                                                    Glosa = item.value == null ? "" : item.value.ToString();
        //                                                }
        //                                            }
        //                                        }
        //                                    }

        //                                }
        //                                catch (AggregateException e)
        //                                {
        //                                    LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de TaxDocument. Error:" + e.ToString(), true);
        //                                    LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de TaxDocument. URL:" + sUrlRequest.ToString(), true);
        //                                }
        //                            }

        //                            //FIN OBTENER GLOSA

        //                            //ASIGNA DATOS PARA INTEGRACION EN WMS
        //                            stLinea = 0;

        //                            //LogInfo("Debug1", "");
        //                            stArchivo = DateTime.Now.ToString(("dd/MM/yyyy HH:mm:ss:fff")) + "_" + Document.emissionDate;

        //                            dtFechaProcesoInt = DateTime.Now.ToString("yyyyMMdd");
        //                            stTexto1 = "INT-DTE-BSALE";
        //                            stTexto2 = DateTime.Now.ToString("yyyyMMdd HHmmss");
        //                            stTexto3 = "A";
        //                            stTexto4 = Document.urlPublicView == null ? "" : Document.urlPublicView.Trim(); //Dato1
        //                            stTexto6 = stEmpId; // "1";
        //                            stTexto7 = DateTime.Now.ToString("yyyyMMdd");  //PedidoDetalle.creationDate.ToString();
        //                            stTexto8 = "Integrado_BSALE";
        //                            stTexto9 = Document.emissionDate.ToString();
        //                            stTexto10 = Document.document_type.id.ToString(); // TipoSolicitud

        //                            //Indica si debe concatenar el Tipo Docto Guia + '-' + Tipo de Guia ----- 
        //                            if (ConfigurationManager.AppSettings["BSALE_Guia_TipoDespacho"].ToString() == "True")
        //                            {
        //                                if (shipping_type_id.ToString() != "")
        //                                {
        //                                    stTexto10 = Document.document_type.id.ToString() + "-" + shipping_type_id.ToString();
        //                                } // TipoSolicitud 
        //                            }

        //                            stTexto11 = Document.number.ToString();

        //                            //LogInfo("Debug2", "");

        //                            if (Document.document_type.useClient.ToString() == "0")
        //                            {
        //                                stTexto12 = "";
        //                                stTexto13 = "";
        //                                stTexto20 = "";
        //                            }
        //                            else if (Document.client == null)
        //                            {
        //                                stTexto12 = "";
        //                                stTexto13 = "";
        //                                stTexto20 = "";
        //                            }
        //                            else
        //                            {
        //                                if (Document.client.code != null)
        //                                {
        //                                    stTexto12 = Document.client.code.ToString();
        //                                }
        //                                else
        //                                {
        //                                    stTexto12 = "";
        //                                }

        //                                stTexto13 = Document.client.firstName == null ? "" : Document.client.firstName + " " + Document.client.lastName;
        //                                documentEmail = Document.client.email == null ? "" : Document.client.email.ToString();
        //                                // stTexto20 = Document.client.email == null ? "" : Document.client.email.ToString();
        //                            }

        //                            //LogInfo("Debug3", "");
        //                            stTexto16 = "0";

        //                            if (Document.client != null)
        //                            {
        //                                documentCity = Document.client.city == null ? "0" : Document.client.city.ToString();
        //                                documentMunicipality = Document.client.municipality == null ? "0" : Document.client.municipality.ToString();
        //                                documentPhone = Document.client.phone == null ? "" : Document.client.phone.ToString();

        //                                // stTexto17 = Document.client.city == null ? "0" : Document.client.city.ToString();
        //                                // stTexto18 = Document.client.municipality == null ? "0" : Document.client.municipality.ToString();
        //                                // stTexto49 = Document.client.phone == null ? "" : Document.client.phone.ToString();
        //                            }
        //                            else
        //                            {
        //                                stTexto17 = "0";
        //                                stTexto18 = "0";
        //                                stTexto49 = "";
        //                            }

        //                            documentAddress = Document.address == null ? "" : Document.address.ToString() + "," + Document.municipality.ToString();

        //                            //IIF
        //                            stTexto20 = clientEmail == string.Empty ? documentEmail : clientEmail;
        //                            stTexto17 = documentCity;
        //                            stTexto18 = clientCityZonecheckout == string.Empty ? documentMunicipality : clientCityZonecheckout;
        //                            stTexto49 = clientPhone == string.Empty ? documentPhone : clientPhone;
        //                            stTexto19 = clientAddress == string.Empty ? documentAddress : clientAddress;
        //                            stTexto19 = stTexto19.Replace("'", ""); // REEMPLAZAR LA COMILLA EN LA DIRECCION
        //                            stTexto21 = datoCourier == null ? "" : datoCourier.ToString(); // datocourier
        //                            stTexto22 = "1"; //MONEDA;
        //                            stTexto23 = Document.document_type.id.ToString(); //TIPO DOCUMENTO;
        //                            stTexto24 = Document.number.ToString(); //NUMERO DOCUMENTO
        //                            stTexto25 = Document.emissionDate.ToString(); //FECHA DOCUMENTO
        //                            stTexto26 = "BSALE";
        //                            stTexto27 = Document.number.ToString();
        //                            stTexto28 = Document.emissionDate.ToString();
        //                            stTexto29 = "";
        //                            stTexto30 = Glosa;//""; //Glosa
        //                            stTexto45 = Document.totalAmount.ToString();
        //                            stTexto47 = Document.office.id.ToString(); //oficina o bodega
        //                            stTexto48 = destinationOffice_id.ToString();
        //                            stTexto51 = clientStreetcheckout;
        //                            stTexto52 = clientCityZonecheckout;
        //                            stTexto53 = Glosacheckout;
        //                            stTexto54 = shipping_id;
        //                            stTexto55 = payProcesscheckout;
        //                            stTexto56 = idVentaMercadoLibre;
        //                            stTexto57 = retiroTienda;

        //                            _CantLineas = Document.details.count;

        //                            if (_CantLineas < 26)
        //                            {
        //                                foreach (var item in Document.details.items)
        //                                {
        //                                    InsertaIntegracion = true; //Por defecto puede insertar

        //                                    //Si debe validar state de variante glosa -----
        //                                    if (ConfigurationManager.AppSettings["BSALE_Valida_Variante_Glosa"].ToString() == "True")
        //                                    {
        //                                        try
        //                                        {
        //                                            //CONSULTA VARIANTE Y VALIDA ESTADO DISTINTO  A 55 PARA BAJAR A WMS
        //                                            sUrlRequest = item.variant.href.ToString(); ;

        //                                            HttpClient client5 = new HttpClient();
        //                                            client5.BaseAddress = new Uri(sUrlRequest);

        //                                            client5.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                                            client5.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
        //                                            client5.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

        //                                            //response = client5.GetAsync(sUrlRequest).Result;

        //                                            //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
        //                                            for (Int32 intentos_4 = 1; intentos_4 <= 3; intentos_4++)
        //                                            {
        //                                                response = client5.GetAsync(sUrlRequest).Result;

        //                                                if (response.IsSuccessStatusCode) // finalizo ok
        //                                                {
        //                                                    break;
        //                                                }
        //                                                else
        //                                                {
        //                                                    LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_4.ToString().Trim() +
        //                                                                                         ", URL: " + sUrlRequest.Trim() +
        //                                                                                         ", Respuesta BSALE: " + response.ToString().Trim());

        //                                                }
        //                                            } // ---------------------------------------------------------------------------------------------

        //                                            valor = response.Content.ReadAsStringAsync().Result;

        //                                            VariantsDetalle = JsonConvert.DeserializeObject<Variants>(valor);

        //                                            //state <> 55 debe insertar
        //                                            if (VariantsDetalle.state.ToString().Trim() != "55")
        //                                            {
        //                                                InsertaIntegracion = true;
        //                                            }
        //                                            else
        //                                            {
        //                                                InsertaIntegracion = false;
        //                                            }
        //                                        }
        //                                        catch (AggregateException e)
        //                                        {
        //                                            LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Variante. Error:" + e.ToString(), true);
        //                                            LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Shipping. URL:" + sUrlRequest.ToString(), true);
        //                                        }

        //                                    } //FIN Si debe validar state de variante glosa -----

        //                                    if (item.variant.description.Trim() != "Costo de Envio" && InsertaIntegracion == true)
        //                                    {
        //                                        sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
        //                                        sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10 ,";
        //                                        sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
        //                                        sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29,";
        //                                        sqlQuery += "Texto30, Texto31, Texto32, Texto33, Texto34, Texto35, Texto36, Texto37, Texto38, Texto39,";
        //                                        sqlQuery += "Texto40, Texto41, Texto42, Texto43, Texto44, Texto45, Texto46, Texto47, Texto48, Texto49,";
        //                                        sqlQuery += "Texto50, Texto51, Texto52, Texto53, Texto54, Texto55, Texto56, Texto57) values (";

        //                                        stLinea = stLinea + 1;
        //                                        stTexto31 = stLinea.ToString();
        //                                        stTexto32 = item.variant.code.ToString();
        //                                        stTexto34 = "UN";
        //                                        stTexto35 = item.quantity.ToString();
        //                                        stTexto36 = item.id.ToString();
        //                                        stTexto38 = item.variant.code.Trim();
        //                                        stTexto41 = item.netUnitValue.ToString();
        //                                        stTexto42 = item.totalUnitValue.ToString();
        //                                        stTexto43 = "";
        //                                        stTexto44 = item.quantity.ToString();
        //                                        stTexto46 = item.id.ToString();
        //                                        stTexto50 = item.relatedDetailId.ToString();

        //                                        #region Carga Variables Insert

        //                                        sqlQuery += "'" + stArchivo.Trim() + "'";
        //                                        sqlQuery += ",'" + stUserName.Trim() + "'";
        //                                        sqlQuery += ",'" + dtFechaProcesoInt + "'";
        //                                        sqlQuery += ",'" + stLinea + "'";
        //                                        sqlQuery += ",'" + stTexto1.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto2.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto3.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto4.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto5.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto6.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto7.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto8.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto9.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto10.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto11.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto12.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto13.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto14.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto15.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto16.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto17.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto18.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto19.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto20.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto21.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto22.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto23.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto24.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto25.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto26.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto27.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto28.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto29.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto30.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto31.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto32.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto33.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto34.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto35.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto36.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto37.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto38.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto39.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto40.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto41.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto42.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto43.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto44.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto45.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto46.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto47.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto48.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto49.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto50.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto51.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto52.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto53.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto54.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto55.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto56.Trim().Replace("'", "") + "'";
        //                                        sqlQuery += ",'" + stTexto57.Trim().Replace("'", "") + "')";
        //                                        #endregion

        //                                        result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
        //                                    }

        //                                } //FIN ciclo recorre Items
        //                            }
        //                            else
        //                            {
        //                                string s2 = "";
        //                                //string s3 = "";
        //                                //int variantcount = 0; 
        //                                int Countvariant = 0, offsetvariant = 0, limitvariant = 0;
        //                                string token = ConfigurationManager.AppSettings["TokenBsale"].ToString();
        //                                string urlvariant = "https://api.bsale.cl/v1/documents/" + Document.id.ToString() + "/details.json?B";

        //                                s2 = GetGeneral(urlvariant, token, 0, "ConsultaPedidosDoctoLegal");

        //                                dynamic jsonvariant = JsonConvert.DeserializeObject(s2);
        //                                JObject rssvariant = JObject.Parse(s2);

        //                                Countvariant = (Int32)rssvariant["count"];
        //                                limitvariant = (Int32)rssvariant["limit"];
        //                                offsetvariant = (Int32)rssvariant["offset"];

        //                                var vecesvariant = Math.Ceiling(Convert.ToDouble(Countvariant) / limitvariant);

        //                                for (Int32 q = 0; q < vecesvariant; q++)
        //                                {
        //                                    if (q > 0)
        //                                    {
        //                                        s2 = GetGeneral(urlvariant, token, offsetvariant, "ConsultaPedidosDoctoLegal");

        //                                        jsonvariant = JsonConvert.DeserializeObject(s2);
        //                                        rssvariant = JObject.Parse(s2);
        //                                    }

        //                                    for (Int32 i_var = 0; i_var < rssvariant["items"].Count(); i_var++)
        //                                    {
        //                                        InsertaIntegracion = true; //Por defecto puede insertar

        //                                        if (ConfigurationManager.AppSettings["BSALE_Valida_Variante_Glosa"].ToString() == "True")
        //                                        {
        //                                            //CONSULTA VARIANTE Y VALIDA ESTADO DISTINTO  A 55 PARA BAJAR A WMS
        //                                            try
        //                                            {
        //                                                sUrlRequest = rssvariant["items"][i_var]["variant"]["href"].ToString().Trim();

        //                                                HttpClient client5 = new HttpClient();
        //                                                client5.BaseAddress = new Uri(sUrlRequest);

        //                                                client5.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                                                client5.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ("application/json"));
        //                                                client5.DefaultRequestHeaders.TryAddWithoutValidation("access_token", ConfigurationManager.AppSettings["TokenBsale"].ToString());

        //                                                //response = client5.GetAsync(sUrlRequest).Result;

        //                                                //llamado api variante BSale, se hace Control de error bad gateway desde BSale, se hacen 3 intentos de llamada ----
        //                                                for (Int32 intentos_7 = 1; intentos_7 <= 3; intentos_7++)
        //                                                {
        //                                                    response = client5.GetAsync(sUrlRequest).Result;

        //                                                    if (response.IsSuccessStatusCode) // finalizo ok
        //                                                    {
        //                                                        break;
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        LogInfo("ConsultaPedidosDoctoLegal", "Error respuesta BSALE. N° intento: " + intentos_7.ToString().Trim() +
        //                                                                                             ", URL: " + sUrlRequest.Trim() +
        //                                                                                             ", Respuesta BSALE: " + response.ToString().Trim());

        //                                                    }
        //                                                } // ---------------------------------------------------------------------------------------------

        //                                                valor = response.Content.ReadAsStringAsync().Result;

        //                                                VariantsDetalle = JsonConvert.DeserializeObject<Variants>(valor);

        //                                                //state <> 55 debe insertar
        //                                                if (VariantsDetalle.state.ToString().Trim() != "55")
        //                                                {
        //                                                    InsertaIntegracion = true;
        //                                                }
        //                                                else
        //                                                {
        //                                                    InsertaIntegracion = false;
        //                                                }
        //                                            }
        //                                            catch (AggregateException e)
        //                                            {
        //                                                LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Variante. Error:" + e.ToString(), true);
        //                                                LogInfo("ConsultaPedidosDoctoLegal", "Obteniendo informacion de Shipping. URL:" + sUrlRequest.ToString(), true);
        //                                            }
        //                                        }

        //                                        if (rssvariant["items"][i_var]["variant"]["description"].ToString().Trim() != "Costo de Envio" && InsertaIntegracion == true)
        //                                        {
        //                                            sqlQuery = "Insert Into L_Integraciones (Archivo, UserName, FechaProceso, Linea, ";
        //                                            sqlQuery += "Texto1 , Texto2 , Texto3 , Texto4 , Texto5 , Texto6 , Texto7 , Texto8 , Texto9 , Texto10 ,";
        //                                            sqlQuery += "Texto11, Texto12, Texto13, Texto14, Texto15, Texto16, Texto17, Texto18, Texto19, Texto20,";
        //                                            sqlQuery += "Texto21, Texto22, Texto23, Texto24, Texto25, Texto26, Texto27, Texto28, Texto29,";
        //                                            sqlQuery += "Texto30, Texto31, Texto32, Texto33, Texto34, Texto35, Texto36, Texto37, Texto38, Texto39,";
        //                                            sqlQuery += "Texto40, Texto41, Texto42, Texto43, Texto44, Texto45, Texto46, Texto47, Texto48, Texto49,";
        //                                            sqlQuery += "Texto50, Texto51, Texto52, Texto53, Texto54, Texto55, Texto56, Texto57) values (";

        //                                            stLinea = stLinea + 1;
        //                                            stTexto31 = stLinea.ToString();
        //                                            stTexto32 = rssvariant["items"][i_var]["variant"]["code"].ToString();
        //                                            stTexto34 = "UN";
        //                                            stTexto35 = rssvariant["items"][i_var]["quantity"].ToString();
        //                                            stTexto36 = rssvariant["items"][i_var]["id"].ToString();
        //                                            stTexto38 = rssvariant["items"][i_var]["variant"]["code"].ToString();
        //                                            stTexto41 = stTexto36 = rssvariant["items"][i_var]["netUnitValue"].ToString();
        //                                            stTexto42 = stTexto36 = rssvariant["items"][i_var]["totalUnitValue"].ToString();
        //                                            stTexto43 = "";
        //                                            stTexto44 = rssvariant["items"][i_var]["quantity"].ToString();
        //                                            stTexto46 = rssvariant["items"][i_var]["id"].ToString();
        //                                            stTexto50 = rssvariant["items"][i_var]["relatedDetailId"].ToString();

        //                                            #region CargaVariables
        //                                            sqlQuery += "'" + stArchivo.Trim() + "'";
        //                                            sqlQuery += ",'" + stUserName.Trim() + "'";
        //                                            sqlQuery += ",'" + dtFechaProcesoInt + "'";
        //                                            sqlQuery += ",'" + stLinea + "'";
        //                                            sqlQuery += ",'" + stTexto1.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto2.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto3.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto4.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto5.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto6.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto7.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto8.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto9.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto10.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto11.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto12.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto13.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto14.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto15.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto16.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto17.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto18.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto19.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto20.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto21.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto22.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto23.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto24.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto25.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto26.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto27.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto28.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto29.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto30.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto31.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto32.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto33.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto34.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto35.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto36.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto37.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto38.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto39.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto40.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto41.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto42.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto43.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto44.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto45.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto46.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto47.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto48.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto49.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto50.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto51.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto52.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto53.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto54.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto55.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto56.Trim().Replace("'", "") + "'";
        //                                            sqlQuery += ",'" + stTexto57.Trim().Replace("'", "") + "')";
        //                                            #endregion

        //                                            result = Tmpt_SolImportDespacho.InsertarRegistro_OleDb("", sqlQuery);
        //                                        }
        //                                    }
        //                                    offsetvariant = offsetvariant + limitvariant;
        //                                }
        //                            }

        //                            DataSet myDataSet1 = new DataSet();
        //                            string resultIntegracion = "0";
        //                            myDataSet1 = Tmpt_SolImportDespacho.GeneraProceso(stArchivo,
        //                                                                              stUserName,
        //                                                                              DateTime.Parse(DateTime.Now.ToShortDateString()));

        //                            if (myDataSet1.Tables.Count > 0)
        //                            {
        //                                int tabla1 = myDataSet1.Tables.Count;
        //                                resultIntegracion = myDataSet1.Tables[tabla1 - 1].Rows[0]["Generacion"].ToString().Trim();
        //                                if (resultIntegracion != "0")
        //                                {
        //                                    //Console.WriteLine("PROCESA PEDIDO DE INTEGRACION");
        //                                    LogInfo("ConsultaPedidosDoctoLegal", "PROCESA PEDIDO DE INTEGRACION OK");
        //                                }
        //                                //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoWebhook("0", "5", decimal.Parse(stTexto58));
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                string valor = response.Content.ReadAsStringAsync().Result;
        //                LogInfo("ConsultaPedidosDoctoLegal", "Error de Facturacion Api REST BSALE: " + response.Content.ReadAsStringAsync().Result, true);
        //            }
        //            offset = offset + 50;
        //            if (offset < _CantDocto)
        //            {
        //                response.Dispose();
        //                goto Reprocesar;
        //            }

        //            LogInfo("ConsultaPedidosDoctoLegal", "final proceso");

        //            /*ACTUALIZA OFF EN BD*/
        //            //result = WS_Integrador.Classes.model.InfF_Generador.ActualizaOffSet(1, "Integrado_BSALE", ContadorOffset.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogInfo("ConsultaPedidosDoctoLegal", "Error: " + ex.Message, true);
        //    }
            return resultCons;

        }

        private void button38_Click(object sender, EventArgs e)
        {
            //create a memory stream
            MemoryStream outStream = new MemoryStream();
            var writer = new StreamWriter(outStream);

            //get your PDF into the memory stream
            writer.Write("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MCAyNzcgMCAwIDI3NyA4ODkgNjEwIDYxMCAwIDAgMzg5IDU1NiAzMzMgNjEwIDU1NiAwIDAgMCA1MDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCA2MTBdPj4KZW5kb2JqCjggMCBvYmoKPDwvQmFzZUZvbnQgL1RPR0hKTStMaWJlcmF0aW9uU2FucyAvRW5jb2RpbmcgL1dpbkFuc2lFbmNvZGluZyAvRmlyc3RDaGFyCiAgMzIgL0ZvbnREZXNjcmlwdG9yIDI4IDAgUiAvTGFzdENoYXIgMjQzIC9TdWJ0eXBlIC9UcnVlVHlwZSAvVG9Vbmljb2RlCiAgMjkgMCBSIC9UeXBlIC9Gb250IC9XaWR0aHMKICBbMjc3IDAgMCAwIDAgMCAwIDAgMzMzIDMzMyAwIDAgMjc3IDMzMyAwIDI3NyA1NTYgNTU2IDU1NiA1NTYgNTU2IDU1NgogIDU1NiA1NTYgNTU2IDU1NiAyNzcgMCAwIDAgMCAwIDAgNjY2IDAgNzIyIDcyMiA2NjYgNjEwIDAgMCAyNzcgMCA2NjYKICA1NTYgODMzIDcyMiA3NzcgNjY2IDAgMCA2NjYgNjEwIDcyMiA2NjYgMCAwIDAgNjEwIDAgMCAwIDAgMCAwIDU1NiAwCiAgNTAwIDU1NiA1NTYgMjc3IDU1NiAwIDIyMiAwIDAgMjIyIDgzMyA1NTYgNTU2IDU1NiA1NTYgMzMzIDUwMCAyNzcgNTU2CiAgNTAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwCiAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAwIDAgMCAw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MDAwMDAwMDAgNjU1MzUgZg0KMDAwMDAwMDAxNSAwMDAwMCBuDQowMDAwMDAwMTk2IDAwMDAwIG4NCjAwMDAwMDAyNDMgMDAwMDAgbg0KMDAwMDAwMDI5OCAwMDAwMCBuDQowMDAwMDAwNTE3IDAwMDAwIG4NCjAwMDAwMDQ4MTQgMDAwMDAgbg0KMDAwMDAwNDk5MCAwMDAwMCBuDQowMDAwMDA1NzIyIDAwMDAwIG4NCjAwMDAwMDY0NjMgMDAwMDAgbg0KMDAwMDAwNjY5MCAwMDAwMCBuDQowMDAwMDA2OTkyIDAwMDAwIG4NCjAwMDAwMDc2NjIgMDAwMDAgbg0KMDAwMDAwODY3MSAwMDAwMCBuDQowMDAwMDA4OTQ4IDAwMDAwIG4NCjAwMDAwMDg5NjcgMDAwMDAgbg0KMDAwMDAwODk4NyAwMDAwMCBuDQowMDAwMDExNTgwIDAwMDAwIG4NCjAwMDAwMTE2MDEgMDAwMDAgbg0KMDAwMDAxMTYyMSAwMDAwMCBuDQowMDAwMDExNjc2IDAwMDAwIG4NCjAwMDAwMTE2OTYgMDAwMDAgbg0KMDAwMDAxMTcxNSAwMDAwMCBuDQowMDAwMDExOTA0IDAwMDAwIG4NCjAwMDAwMTE5MjMgMDAwMDAgbg0KMDAwMDAxMjAwMyAwMDAwMCBuDQowMDAwMDEyMTU5IDAwMDAwIG4NCjAwMDAwMTIxNzggMDAwMDAgbg0KMDAwMDAxMjE5OSAwMDAwMCBuDQowMDAwMDEyNDQ1IDAwMDAwIG4NCjAwMDAwMTI5OTAgMDAwMDAgbg0KMDAwMDAxMzAxMCAwMDAwMCBuDQowMDAwMDIyMzk2IDAwMDAwIG4NCjAwMDAwMjI0MTcgMDAwMDAgbg0KMDAwMDAyMjY3MCAwMDAwMCBuDQowMDAwMDIzMTg1IDAwMDAwIG4NCjAwMDAwMjMyMDUgMDAwMDAgbg0KMDAwMDAzMjM0NiAwMDAwMCBuDQowMDAwMDMyMzY3IDAwMDAwIG4NCnRyYWlsZXIKCjw8L0luZm8gMSAwIFIgL1Jvb3QgMiAwIFIgL1NpemUgMzk+PgpzdGFydHhyZWYKMzIzODgKJSVFT0YK");
            writer.Flush();
            outStream.Position = 0;

            // create a byte array that will hold the output pdf
            byte[] outBuf = outStream.GetBuffer();

            var response = HttpContext.Current.Response;

            // specify the duration of time before a page,cached on a browser expires
            response.Expires = 0;
            // Specify the property to buffer the output page
            response.Buffer = true;
            // Erase any buffered HTML output
            response.ClearContent();
            //Add a new HTML header and value to the response sent to the client
            response.AddHeader("content-disposition", "inline; filename=" + "output.pdf");
            // Specify the HTTP content type for response as Pdf
            response.ContentType = "application/pdf";
            // Write specified information of current HTTP output to Byte array
            response.BinaryWrite(outBuf);
            // close the output stream
            outStream.Close();
            //end the processing of the current page to ensure that no other HTML content is sent
            response.End();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            string[] Palabras = "1,2,3".Split(',');
            string OfficeId_Bodega = "";

            for (int i = 0; i < Palabras.Length; i++)
            {
                OfficeId_Bodega = Palabras[i].Trim();

                // 1 EXTRAE SALDO DE BSALE
                MessageBox.Show("BODEGA: " + OfficeId_Bodega.Trim());
            }

            return; 

            //PRUEBA llamdo procedimiento almacenado con campos de respuesta variables sin que se caiga

            DataSet myDataSet = new DataSet();
            OleDbConnection myConnection = new OleDbConnection("Provider=SQLOLEDB.1;Password=@Qaz151618;User ID=sa;Data Source=127.0.0.2,1436;Initial Catalog=Getpoint_GH_Test;Persist Security Info=True");
            OleDbCommand myCommand = new OleDbCommand("PruebaDATASET", myConnection);

            myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.Parameters.Add("@empid", OleDbType.Integer).Value = 2;

            try
            {
                myCommand.CommandTimeout = 9999;
                myConnection.Open();

                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(myDataSet, "PruebaDATASET");
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



            DataColumnCollection columns = myDataSet.Tables[0].Columns;
            //string columnName = "Campo3";

            if (columns.Contains("Campo1"))
            {
                MessageBox.Show(myDataSet.Tables[0].Rows[0]["Campo1"].ToString());
            }

            if (columns.Contains("Campo2"))
            {
                MessageBox.Show(myDataSet.Tables[0].Rows[0]["Campo2"].ToString());
            }

            if (columns.Contains("Campo3"))
            {
                MessageBox.Show(myDataSet.Tables[0].Rows[0]["Campo3"].ToString());
            }

            if (columns.Contains("Campo4"))
            {
                MessageBox.Show(myDataSet.Tables[0].Rows[0]["Campo4"].ToString());
            }

            //if (columns.Contains(columnName))
            //{
            //    MessageBox.Show("Campo Existe");
            //}
            //else
            //{
            //    MessageBox.Show("Campo NO Existe");
            //}



        }

        private void button40_Click(object sender, EventArgs e)
        {
            try
            {
                //>//LogInfo("ConfirmacionIngreso", NombreProceso.Trim() + " - Inicio ejecucion", true, false);

                //para evitar error de seguridad en el llamado a la API ----------
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768; //TLS 1.1 
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; // para error No se puede crear un canal seguro SSL/TLS

                //>//string stEmpId = ConfigurationManager.AppSettings["EmpId"].ToString();
                string result = "";
                int EmpId;
                int EmpIdGlobal;

                //>//Int32.TryParse(stEmpId, out EmpId);

                //Extrae Pedidos
                DataSet dsPedidos = WS_Integrador.Classes.model.InfF_Generador.ShowList_IntegraConfirmacionesJson(EmpId,NombreProceso);
                if (dsPedidos.Tables.Count > 0)
                {
                    if (dsPedidos.Tables[0].Rows.Count > 0)
                    {
                        Pedido_Cab Cabecera = new Pedido_Cab();
                        Pedido_Det Detalle = new Pedido_Det();

                        string var_IntId = "";
                        string FolioGP = "";

                        //Recorre la confirmaciones de recepcion --------------
                        for (int i = 0; i <= dsPedidos.Tables[0].Rows.Count - 1; i++)
                        {
                            //Cada vez que cambie de Pedido o la primera vez del ciclo -----
                            if (dsPedidos.Tables[0].Rows[i]["FOLIOGP"].ToString().Trim() != FolioGP.Trim())
                            {
                                //Si ya venía procesando un pedido significa que hubo un cambio de pedido, debe generar el Pedido anterior ----
                                if (FolioGP.Trim() != "")
                                {
                                    //Carga URL de la API Webhook del cliente correspondiente al proceso segun la empresa ----------
                                    #region Carga URL de la API Webhook del cliente correspondiente al proceso segun la empresa ----------
                                    var client = new RestClient(dsPedidos.Tables[0].Rows[i]["URL_EndPoint"].ToString().Trim());

                                    EmpIdGlobal = int.Parse(dsPedidos.Tables[0].Rows[i]["EmpIdGlobal"].ToString());

                                    client.Timeout = -1;

                                    //Indica el metodo de llamado de la API ----
                                    var request = new RestRequest(Method.GET);
                                    switch (dsPedidos.Tables[0].Rows[i]["Metodo"].ToString().Trim())
                                    {
                                        case "GET":
                                            request = new RestRequest(Method.GET); //consulta
                                            break;
                                        case "POST":
                                            request = new RestRequest(Method.POST); //crea
                                            break;
                                        case "PUT":
                                            request = new RestRequest(Method.PUT); //modifica
                                            break;
                                    }

                                    DataSet dsHeaders = new DataSet(); //quitar
                                                                       //>//DataSet dsHeaders = WS_Integrador.Classes.model.InfF_Generador.ShowList_EndPointHeadersJson(EmpIdGlobal,
                                                                       //>//                                                                                            EmpId,
                                                                       //>//                                                                                            dsPedidos.Tables[0].Rows[i]["NombreProceso"].ToString(),
                                                                       //>//                                                                                            2);

                                    //Trae los headers (atributo y valor) necesarios para realizar el llamado a la api segun nombre de proceso que esta integrando ----------------
                                    if (dsHeaders.Tables.Count > 0)
                                    {
                                        for (int k = 0; k <= dsHeaders.Tables[0].Rows.Count - 1; k++)
                                        {
                                            //agrega key y su valor -----------
                                            request.AddHeader(dsHeaders.Tables[0].Rows[k]["myKey"].ToString().Trim(), dsHeaders.Tables[0].Rows[k]["myValue"].ToString().Trim());
                                        }
                                    }

                                    #endregion
                                }

                                //Carga Variable para generar JSON ----------------------------------------------

                                //Inicializa variable principal
                                Cabecera = new Pedido_Cab();

                                DateTime fecha;
                                fecha = DateTime.Now;

                                //Guarda IntId que esta procesando ---------
                                var_IntId = dsPedidos.Tables[0].Rows[i]["IntId"].ToString().Trim();

                                //--------------------------------------------
                                //Carga parametros cabecera del Pedido ----------
                                Cabecera.ORIGEN = dsPedidos.Tables[0].Rows[i]["ORIGEN"].ToString().Trim();
                                Cabecera.EMPID = int.Parse(dsPedidos.Tables[0].Rows[i]["EMPID"].ToString().Trim());
                                Cabecera.DESTINATARIO = dsPedidos.Tables[0].Rows[i]["DESTINATARIO"].ToString().Trim();
                                Cabecera.FOLIOGP = dsPedidos.Tables[0].Rows[i]["FOLIOGP"].ToString().Trim();
                                Cabecera.FECHAGEN = dsPedidos.Tables[0].Rows[i]["FECHAGEN"].ToString().Trim();
                                Cabecera.FECHAREQ = dsPedidos.Tables[0].Rows[i]["FECHAREQ"].ToString().Trim();
                                Cabecera.VENDEDOR = dsPedidos.Tables[0].Rows[i]["VENDEDOR"].ToString().Trim();
                                Cabecera.NRODOCREL = dsPedidos.Tables[0].Rows[i]["NRODOCREL"].ToString().Trim();
                                Cabecera.NROREFERENCIA = dsPedidos.Tables[0].Rows[i]["NROREFERENCIA"].ToString().Trim();
                                Cabecera.OBS1 = dsPedidos.Tables[0].Rows[i]["OBS1"].ToString().Trim();
                                Cabecera.OBS2 = dsPedidos.Tables[0].Rows[i]["OBS2"].ToString().Trim();
                                Cabecera.ESTADO = dsPedidos.Tables[0].Rows[i]["ESTADO"].ToString().Trim();
                                Cabecera.DESCTOCAB = dsPedidos.Tables[0].Rows[i]["DESCTOCAB"].ToString().Trim();
                                Cabecera.LPRECIO = dsPedidos.Tables[0].Rows[i]["LPRECIO"].ToString().Trim();

                            } //FIN Cada vez que cambie de Pedido o la primera vez del ciclo -----

                            Detalle = new Pedido_Det();

                            Detalle.LINEA = int.Parse(dsPedidos.Tables[0].Rows[i]["LINEA"].ToString().Trim());
                            Detalle.CODIGOARTICULO = dsPedidos.Tables[0].Rows[i]["CODIGOARTICULO"].ToString().Trim();
                            Detalle.CANTIDAD = int.Parse(dsPedidos.Tables[0].Rows[i]["CANTIDAD"].ToString().Trim());

                            //Detalle.Linea = int.Parse(fila["Linea"].ToString()); // 1;
                            //Detalle.CodigoArticulo = fila["CodigoArticulo"].ToString(); // "5";
                            //Detalle.Fecha1Det = DateTime.Parse(fila["Fecha1Det"].ToString()).ToString("dd-MM-yyyy");

                            Cabecera.ITEMS.Add(Detalle);


                            //Cuando cambie de IntId debe cargar la estructura para enviar al Webhook -----
                            if (dsPedidos.Tables[0].Rows[i]["IntId"].ToString().Trim() != var_IntId || var_IntId == "")
                            {

                                //-------------------------------------------------------------
                                //Crea body para llamado con estructura de variable cargada ---
                                var body = JsonConvert.SerializeObject(Cabecera);

                                //Guarda JSON que se envia ------------------
                                //>//LogInfo("ConfirmacionIngreso", " JSON Enviado", true, true, dsPedidos.Tables[0].Rows[i]["NombreProceso"].ToString(), Cabecera.NumeroReferencia, body.Trim());

                                request.AddParameter("application/json", body, ParameterType.RequestBody);

                                //EJECUTA LLAMADO API ---------------------------
                                IRestResponse response = client.Execute(request);

                                //>//LogInfo("ConfirmacionIngreso", NombreProceso.Trim() + " - Ejecuta api NumeroReferencia " + dsPedidos.Tables[0].Rows[i]["Folio"].ToString().Trim());

                                HttpStatusCode CodigoRetorno = response.StatusCode;
                                //JObject rss = JObject.Parse(response.Content); //recupera json de retorno

                                string Respuesta = "";

                                //Si finalizó OK, retorna status 200 --------------------------
                                if (CodigoRetorno.Equals(HttpStatusCode.OK))
                                {
                                    //Debe venir la siguiente respuesta:
                                    //{
                                    //    "Resultado": "OK",
                                    //    "Descripcion": "Integracion OK"
                                    //}

                                    //>//LogInfo("ConfirmacionIngreso", "JSON respuesta recibido.", true, true, dsPedidos.Tables[0].Rows[i]["NombreProceso"].ToString(), Cabecera.NumeroReferencia, response.Content.ToString());

                                    JObject rss = JObject.Parse(response.Content); //recupera json de retorno
                                    string Resultado;
                                    string Descripcion;

                                    try
                                    {
                                        Resultado = rss["Resultado"].ToString(); //OK - ERROR
                                        Descripcion = rss["Descripcion"].ToString(); //descripcion 
                                    }
                                    catch (Exception ex)
                                    {
                                        Resultado = "ERROR";
                                        Descripcion = "Respuesta no retorna estructura definida (Resultado y Descripcion)";
                                    }

                                    if (Resultado.Trim() == "OK")
                                    {
                                        //Actualiza estado de L_IntegraConfirmaciones, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(dsPedidos.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                    2); //Procesado

                                        Respuesta = "Integracion OK. IntId: " + dsPedidos.Tables[0].Rows[i]["IntId"].ToString().Trim() +
                                                    " .Resultado: " + Resultado.Trim() +
                                                    " .Descripcion: " + Descripcion.Trim();

                                        //>//LogInfo("ConfirmacionIngreso", Respuesta, true, true, dsPedidos.Tables[0].Rows[i]["NombreProceso"].ToString(), Cabecera.NumeroReferencia);
                                    }
                                    else
                                    {
                                        //Actualiza estado de L_IntegraConfirmaciones, deja en estado Procesado 
                                        result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(dsPedidos.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                                    3); //Procesado con error

                                        Respuesta = "Error. IntId: " + dsPedidos.Tables[0].Rows[i]["IntId"].ToString().Trim() +
                                                    " .Resultado: " + Resultado.Trim() +
                                                    " .Descripcion: " + Descripcion.Trim();

                                        //>//LogInfo("ConfirmacionIngreso", Respuesta, true, true, dsPedidos.Tables[0].Rows[i]["NombreProceso"].ToString(), Cabecera.NumeroReferencia);
                                    }

                                    //Guarda respuesta en Dato2 RDM procesada -------------
                                    result = WS_Integrador.Classes.model.InfF_Generador.InformaRespuestaWebhook(dsPedidos.Tables[0].Rows[i]["NombreProceso"].ToString(),
                                                                                                                    EmpIdGlobal,
                                                                                                                    int.Parse(dsPedidos.Tables[0].Rows[i]["Folio"].ToString()),
                                                                                                                    int.Parse(dsPedidos.Tables[0].Rows[i]["FolioRel"].ToString()),
                                                                                                                    "Resultado: " + Resultado.Trim() + " .Descripcion: " + Descripcion.Trim());
                                    
                                }
                                else
                                {
                                    //Actualiza estado de L_IntegraConfirmaciones, deja en estado Procesado 
                                    result = WS_Integrador.Classes.model.InfF_Generador.ActualizaEstadoIntegraConfirmaciones(int.Parse(dsPedidos.Tables[0].Rows[i]["IntId"].ToString()),
                                                                                                                             3); //Procesado con error

                                    Respuesta = "Error. IntId: " + dsPedidos.Tables[0].Rows[i]["IntId"].ToString().Trim();
                                    //>//LogInfo("ConfirmacionIngreso", Respuesta, true, true, dsPedidos.Tables[0].Rows[i]["NombreProceso"].ToString(), Cabecera.NumeroReferencia);
                                }
                            } //FIN si cambia de IntId

                        } //FIN ciclo recorre Confirmaciones
                    }
                }
            }
            catch (Exception ex)
            {
                //>//LogInfo("ConfirmacionIngreso", "Error: " + ex.Message.Trim(), true, true, NombreProceso.Trim());
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            string URLRoadNet;
            string s;

            URLRoadNet = "https://alifrutcpiprd.it-cpi019-rt.cfapps.us10-002.hana.ondemand.com/cxf/QAS/GetPoint/CreacionPedidoVentas?wsdl";

            s = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:urn=""urn:sap-com:document:sap:rfc:functions"">
                   <soap:Header/>
                   <soap:Body>
                      <urn:ZMMF_DO_VA01>
                         <WA_DATOS>
	                <ORIGEN>INT-PEDIDO</ORIGEN>
	                <EMPID>1</EMPID>
	                <DESTINATARIO>7763066101</DESTINATARIO>
	                <FOLIOGP>GP300000</FOLIOGP>
	                <FECHAGEN>20231110</FECHAGEN>
	                <FECHAREQ>20231114</FECHAREQ>
	                <VENDEDOR>90007009</VENDEDOR>
	                <OBS1>10:00 - 18:00</OBS1>
	                <OBS2>ACONCAGUA 2281, COLINA, COLINA, METROPOLITANA</OBS2>
	                <ESTADO>A</ESTADO>
	                <NRODOCREL></NRODOCREL>
	                <NROREFERENCIA></NROREFERENCIA>
	                <DESCTOCAB>0</DESCTOCAB>
	                <LPRECIO>J7</LPRECIO>
	                <ITEMS>
	                <item>
	                <LINEA>1</LINEA>
	                <CODIGOARTICULO>10000103</CODIGOARTICULO>
	                <CANTIDAD>1</CANTIDAD>
	                </item>
	                </ITEMS>
                         </WA_DATOS>
                      </urn:ZMMF_DO_VA01>
                   </soap:Body>
                </soap:Envelope>";

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new System.Uri(URLRoadNet);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));

            //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic aW50ZWdyYWNpb25lcy5jcGlAbWludXRvdmVyZGUuY2w6VjNyZDMuMjAyZQ==");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "aW50ZWdyYWNpb25lcy5jcGlAbWludXRvdmVyZGUuY2w6VjNyZDMuMjAyZQ==");

            //RESPUESTA
            System.Net.Http.HttpContent content = new StringContent(s, UTF8Encoding.UTF8, "text/xml"); //EJEMPLO DESDE BD

            try
            {
                HttpResponseMessage messge = client.PostAsync(URLRoadNet, content).Result;

                if (messge.IsSuccessStatusCode)
                {
                    string respuesta = messge.Content.ReadAsStringAsync().Result;

                    //Func.log("Registro OK");
                    //if (respuesta != "")
                    //ActualizarDoc_RoadNet(respuesta);

                    //convierte xml recibido en dataset
                    //trae 5 tablas, la ultima es la tabla con los items

                    DataSet ds = new DataSet();
                    ds.ReadXml(new XmlTextReader(new StringReader(respuesta)));



                }
                else
                {
                    //string respuesta = messge.Content.ReadAsStringAsync().Result;
                    //Func.log("Registro ERROR : " + respuesta);
                }
                content.Dispose();
                client.Dispose();
            }
            catch (Exception ex1)
            {
                content.Dispose();
                client.Dispose();
            }
        }
    }



}


