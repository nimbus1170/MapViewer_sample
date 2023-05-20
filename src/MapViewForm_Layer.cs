//
// MapViewForm_Layer.cs
// レイヤ
//
//---------------------------------------------------------------------------
using DSF_NET_Map;

using static DSF_NET_TacticalDrawing.CDefensivePosition;
using static DSF_NET_TacticalDrawing.XMLReader;

using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
//---------------------------------------------------------------------------
namespace MapView_test
{
//---------------------------------------------------------------------------
public partial class CMapViewForm : Form
{
	private readonly int  DrawingLayer1_Hash =  "DrawingLayer1".GetHashCode();
	private readonly int ObserverLayer1_Hash = "ObserverLayer1".GetHashCode();

	void SetLayers(in XmlNode drawing_xml_node)
	{
		//--------------------------------------------------
		// 図形描画レイヤ

		var drawing_layer = new HashSet<CDrawing>();

		var drawing_groups = drawing_xml_node.SelectNodes("DrawingGroups/DrawingGroup");

		// XMLファイル内の図形描画グループのノードを逐次に渡して処理する。
		foreach(XmlNode drawing_group in drawing_groups)
		{
			//--------------------------------------------------
			// 地雷原をXMLノードから読み込み、図形描画レイヤに追加する。

			var mf_impls = ReadMineFields(drawing_group);

			foreach(var mf_impl in mf_impls)
				drawing_layer.Add(new CMineField(mf_impl));
			
			//--------------------------------------------------
			// 防御陣地をXMLノードから読み込み、図形描画レイヤに追加する。

			var dp_impls = ReadDefensivePositions(drawing_group);

			foreach(var dp_impl in dp_impls)
				drawing_layer.Add(new CDefensivePosition(dp_impl));

			//--------------------------------------------------
			// 特科陣地をXMLノードから読み込み、図形描画レイヤに追加する。

			var fp_impls = ReadFiringPositions(drawing_group);

			foreach(var fp_impl in fp_impls)
				drawing_layer.Add(new CFiringPosition(fp_impl));
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
