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
	// ◆フォントをnullにすればグリッド座標をグリッド交点に表示しない。
	// ▼XMLファイル等で設定しろ。
	void SetGridSetting()
	{
		for(var zoom_level = TileMap.ZoomLevel_Min; zoom_level <= TileMap.ZoomLevel_Max; ++zoom_level)
		{
			// 経緯度グリッドを設定する。

			var lglt_grid_elements = new Dictionary<Int32, CMapGridElement>();

			switch(zoom_level)
			{
				case 10:
					lglt_grid_elements.Add(20, new CMapGridElement(new Pen(Color.Black, 4.0f)					, new Font("ＭＳ ゴシック", 24.0f,				   GraphicsUnit.Pixel), Brushes.Black));
					break;

				case 11:
				case 12:
					lglt_grid_elements.Add(20, new CMapGridElement(new Pen(Color.Black, 4.0f)					, new Font("ＭＳ ゴシック", 24.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black));
					break;

				case 13:
				case 14:
					lglt_grid_elements.Add(10, new CMapGridElement(new Pen(Color.Black, 4.0f)					, new Font("ＭＳ ゴシック", 24.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black));
					lglt_grid_elements.Add( 5, new CMapGridElement(new Pen(Color.Black, 2.0f){ DashStyle = Dot }, new Font("ＭＳ ゴシック", 24.0f,				   GraphicsUnit.Pixel), Brushes.Black));
					break;

				case 15:
				case 16:
				case 17:
				case 18:
					lglt_grid_elements.Add( 5, new CMapGridElement(new Pen(Color.Black, 4.0f)					, new Font("ＭＳ ゴシック", 24.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black));
					lglt_grid_elements.Add( 1, new CMapGridElement(new Pen(Color.Black, 2.0f){ DashStyle = Dot }, new Font("ＭＳ ゴシック", 24.0f,				   GraphicsUnit.Pixel), Brushes.Black));
					break;
			};

			TileMap.LgLtGridSetting.Add(zoom_level, lglt_grid_elements);

			// UTMグリッドを設定する。

			var utm_grid_elements = new Dictionary<Int32, CMapGridElement>();

			switch(zoom_level)
			{
				case 10:
					utm_grid_elements.Add(50, new CMapGridElement(new Pen(Color.Maroon, 4.0f)					, new Font("ＭＳ ゴシック", 18.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Maroon));
					break;

				case 11:
				case 12:
					utm_grid_elements.Add(10, new CMapGridElement(new Pen(Color.Maroon, 4.0f)					, new Font("ＭＳ ゴシック", 16.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Maroon));
					break;

				case 13:
					utm_grid_elements.Add( 5, new CMapGridElement(new Pen(Color.Maroon, 2.0f)					, new Font("ＭＳ ゴシック", 16.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Maroon));
					break;

				case 14:
					utm_grid_elements.Add( 5, new CMapGridElement(new Pen(Color.Maroon, 4.0f)					, new Font("ＭＳ ゴシック", 18.0f, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Maroon));
					utm_grid_elements.Add( 1, new CMapGridElement(new Pen(Color.Maroon, 2.0f){ DashStyle = Dot }, new Font("ＭＳ ゴシック", 16.0f,				   GraphicsUnit.Pixel), Brushes.Maroon));
					break;

				case 15:
				case 16:
				case 17:
				case 18:
					utm_grid_elements.Add( 1, new CMapGridElement(new Pen(Color.Maroon, 2.0f)					, new Font("ＭＳ ゴシック", 16.0f,				   GraphicsUnit.Pixel), Brushes.Maroon));
					break;
			};

			TileMap.UTMGridSetting.Add(zoom_level, utm_grid_elements);
		}
	}
}
//---------------------------------------------------------------------------
}
