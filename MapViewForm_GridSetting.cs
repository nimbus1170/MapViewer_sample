//
// MapViewForm_GridSetting.cs
// グリッド設定
//
//---------------------------------------------------------------------------
using DSF_NET_Map;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using static System.Drawing.Drawing2D.DashStyle;
//---------------------------------------------------------------------------
namespace MapView_test
{
//---------------------------------------------------------------------------
public partial class CMapViewForm : Form
{
	// グリッド設定を設定する。
	// ▼XMLファイル等で設定しろ。
	void SetGridSetting()
	{
		// ◆ズームレベル10～18はとりあえず固定
		for(Int32 zoom_level = 10; zoom_level <= 18; ++zoom_level)
		{
			// 経緯度グリッド設定を設定する。

			var tude_grid_elements = new Dictionary<Int32, CMapGridElement>();

			switch(zoom_level)
			{
				case 10:
					tude_grid_elements.Add(20, new CMapGridElement(new Pen(Color.Black, 4.0f)					, new Font("ＭＳ ゴシック", 24.0f,				   GraphicsUnit.Pixel), Brushes.Black));
					break;

				case 11:
				case 12:
					tude_grid_elements.Add(20, new CMapGridElement(new Pen(Color.Black, 4.0f)					, new Font("ＭＳ ゴシック", 24.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black));
					break;

				case 13:
				case 14:
					tude_grid_elements.Add(10, new CMapGridElement(new Pen(Color.Black, 4.0f)					, new Font("ＭＳ ゴシック", 24.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black));
					tude_grid_elements.Add( 5, new CMapGridElement(new Pen(Color.Black, 2.0f){ DashStyle = Dot }, new Font("ＭＳ ゴシック", 24.0f,				   GraphicsUnit.Pixel), Brushes.Black));
					break;

				case 15:
				case 16:
				case 17:
				case 18:
					tude_grid_elements.Add( 5, new CMapGridElement(new Pen(Color.Black, 4.0f)					, new Font("ＭＳ ゴシック", 24.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black));
					tude_grid_elements.Add( 1, new CMapGridElement(new Pen(Color.Black, 2.0f){ DashStyle = Dot }, new Font("ＭＳ ゴシック", 24.0f,				   GraphicsUnit.Pixel), Brushes.Black));
					break;
			};

			TileMap.TudeGridSetting.Add(zoom_level, tude_grid_elements);

			// UTMグリッド設定を設定する。

			var utm_grid_elements = new Dictionary<Int32, CMapGridElement>();

			switch(zoom_level)
			{
				case 10:
					utm_grid_elements.Add(50, new CMapGridElement(new Pen(Color.Blue, 4.0f)					  , new Font("ＭＳ ゴシック", 14.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Blue));
					break;

				case 11:
				case 12:
					utm_grid_elements.Add(10, new CMapGridElement(new Pen(Color.Blue, 4.0f)					  , new Font("ＭＳ ゴシック", 12.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Blue));
					break;

				case 13:
					utm_grid_elements.Add( 5, new CMapGridElement(new Pen(Color.Blue, 2.0f)					  , new Font("ＭＳ ゴシック", 12.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Blue));
					break;

				case 14:
					utm_grid_elements.Add( 5, new CMapGridElement(new Pen(Color.Blue, 4.0f)					  , new Font("ＭＳ ゴシック", 14.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Blue));
					utm_grid_elements.Add( 1, new CMapGridElement(new Pen(Color.Blue, 2.0f){ DashStyle = Dot }, new Font("ＭＳ ゴシック", 12.0f,				 GraphicsUnit.Pixel), Brushes.Blue));
					break;

				case 15:
				case 16:
				case 17:
				case 18:
					utm_grid_elements.Add( 1, new CMapGridElement(new Pen(Color.Blue, 2.0f)					  , new Font("ＭＳ ゴシック", 12.0f,				 GraphicsUnit.Pixel), Brushes.Blue));
					break;
			};

			TileMap.UTMGridSetting.Add(zoom_level, utm_grid_elements);
		}
	}
}
//---------------------------------------------------------------------------
}
