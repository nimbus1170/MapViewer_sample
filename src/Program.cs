using MapView_test;
using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace MapViewer_sample.src
{
	[SupportedOSPlatform("windows")]
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new CMapViewForm(args));
		}
	}
}
