//
// MapViewForm_Layer.cs
// レイヤ
//
//---------------------------------------------------------------------------
using DSF_NET_Map;

using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
//---------------------------------------------------------------------------
namespace MapView_test
{
//---------------------------------------------------------------------------
using TDrawings = HashSet<CDrawing>;
//---------------------------------------------------------------------------
public partial class CMapViewForm : Form
{
	readonly int DrawingLayer1_Hash  = "DrawingLayer1" .GetHashCode();
	readonly int ObserverLayer1_Hash = "ObserverLayer1".GetHashCode();

	void SetLayers(in XmlNode DrawingXML)
	{
		//--------------------------------------------------
		// 図形描画レイヤ

		// 図形描画レイヤを追加する。
		TileMap.DrawingLayers.Add(DrawingLayer1_Hash, new TDrawings());

		// 地雷原をXMLから読み込み、図形描画レイヤに追加する。
		SetLayers_ReadXML_MineField(DrawingXML, DrawingLayer1_Hash);

		// 防御陣地をXMLから読み込み、図形描画レイヤに追加する。
		SetLayers_ReadXML_DefensivePosition(DrawingXML, DrawingLayer1_Hash);

		//--------------------------------------------------
		// 通視判定レイヤ

		// 通視判定レイヤを追加する。
		TileMap.ObserverLayers.Add(ObserverLayer1_Hash, new TDrawings());

		SetLayers_Observer(ObserverLayer1_Hash);
	}

	void DrawLayers()
	{
		DrawMapImage();
	}
}
//---------------------------------------------------------------------------
}
