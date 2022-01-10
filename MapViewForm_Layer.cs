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
public partial class CMapViewForm : Form
{
	readonly int  DrawingLayer1_Hash =  "DrawingLayer1".GetHashCode();
	readonly int ObserverLayer1_Hash = "ObserverLayer1".GetHashCode();

	void SetLayers(in XmlNode DrawingXML)
	{
		//--------------------------------------------------
		// 図形描画レイヤ

		var drawing_layer = new HashSet<CDrawing>();

		var map_drawing_group_xml_nodes = DrawingXML.SelectNodes("MapDrawings/MapDrawingGroup");

		// XMLファイル内の図形描画グループのノードを逐次に渡して処理する。
		foreach(XmlNode map_drawing_group_xml_node in map_drawing_group_xml_nodes)
		{
			//--------------------------------------------------
			// 地雷原をXMLノードから読み込み、図形描画レイヤに追加する。

			var minefield_impls = DSF_NET_TacticalDrawing.CMineField.ReadMineFields(map_drawing_group_xml_node);

			foreach(var minefield_impl in minefield_impls)
				drawing_layer.Add(new CMineField(minefield_impl));

			//--------------------------------------------------
			// 防御陣地をXMLノードから読み込み、図形描画レイヤに追加する。

			var defensive_position_impls = DSF_NET_TacticalDrawing.CDefensivePosition.ReadDefensivePositions(map_drawing_group_xml_node);

			foreach(var defensive_position_impl in defensive_position_impls)
				drawing_layer.Add(new CDefensivePosition(defensive_position_impl));
		}

		TileMap.DrawingLayers.Add(DrawingLayer1_Hash, drawing_layer);

		//--------------------------------------------------
		// 通視判定レイヤ

		TileMap.ObserverLayers.Add(ObserverLayer1_Hash, new HashSet<CDrawing>());

		SetLayers_Observer(ObserverLayer1_Hash);
	}
}
//---------------------------------------------------------------------------
}
