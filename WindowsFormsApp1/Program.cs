using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ACA SE COLOCA EL FORMULARIO DE INICIO DE LA APLICACION -----

            Application.Run(new Form1());
            //Application.Run(new BuscaPedidoBSALE_Novapet());
            //Application.Run(new Form2());
            //Application.Run(new Form3());

        }
    }
}
