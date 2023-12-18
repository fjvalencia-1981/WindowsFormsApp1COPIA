﻿using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace WS_Integrador_MeLoLLevo.Classes.global
{
	/// <summary>
	/// Descripción breve de DB.
	/// </summary>
	public class DB : System.ComponentModel.Component
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DB(System.ComponentModel.IContainer container)
		{
			///
			/// Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
		}

		public DB()
		{
			///
			/// Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
			///
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
		}

		/// <summary> 
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		public static OleDbConnection getConnection()
		{
			try
			{
				OleDbConnection mySqlConnection = new OleDbConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
				return mySqlConnection;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message.ToString());
			}
		}

		public static OleDbConnection getOleDbConnection()
		{
			try
			{
				OleDbConnection mySqlConnection = new OleDbConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
				return mySqlConnection;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message.ToString());
			}
		}

		/*	Public Shared Function getOledbConnection() As OleDbConnection
		Return New OleDbConnection(ConfigurationSettings.AppSettings("ConnectionOLEDBString"))
		End Function
			Public Shared Function getOdbcConnection() As OdbcConnection
														   Try
															   Return New OdbcConnection(ConfigurationSettings.AppSettings("ConnectionODBCString"))
		Catch objException As OdbcException
							   Throw New Exception()
											 Finally
												 End Try
														 End Function

		*/
		#region Código generado por el Diseñador de componentes
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
