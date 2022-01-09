//
// MapViewForm_Layer_ReadXML_MineField.cs
// 地雷原レイヤ
//
// ●XML描画データから地雷原を読み込む。
//
//---------------------------------------------------------------------------
using DSF_NET_TacticalDrawing;

using static DSF_NET_Geography.Convert_LgLt_UTM;
using static DSF_NET_TacticalDrawing.XMLReader;

using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

using static System.Convert;
//---------------------------------------------------------------------------
namespace MapView_test
{
//---------------------------------------------------------------------------
public partial class CMapViewForm : Form
{
	// 地雷原レイヤ
	void SetLayers_ReadXML_MineField(in XmlNode drawing_xml_node, in int layer_hash)
	{
		var minefield_xml_nodes = drawing_xml_node.SelectNodes("MapDrawings/MineField");

		foreach(XmlNode minefield_xml_node in minefield_xml_nodes)
		{
			var type_str = minefield_xml_node.Attributes["Type"].InnerText;

			var type =
				(type_str == "AT"  )? DMineFieldType.AT		:
				(type_str == "AP"  )? DMineFieldType.AP		:
				(type_str == "ATAP")? DMineFieldType.ATAP	:
									  DMineFieldType.Unknown;
									  
			if(type == DMineFieldType.Unknown) return; // ◆取り敢えず。
	
			var depth = ToInt32(minefield_xml_node.Attributes["Depth"].InnerText);

			var dir_str = minefield_xml_node.Attributes["FrontEdgeDirection"].InnerText;
			
			var dir =
				(dir_str == "LeftToRight")? DMineFieldFrontEdgeDirection.LeftToRight: 
				(dir_str == "RightToLeft")? DMineFieldFrontEdgeDirection.RightToLeft:
											DMineFieldFrontEdgeDirection.Unknown	;		
			
			if(dir == DMineFieldFrontEdgeDirection.Unknown) return; // ◆取り敢えず。

			if(dir == DMineFieldFrontEdgeDirection.RightToLeft)
			{
				var front_edge_node = minefield_xml_node.SelectNodes("FrontEdgeNode");

				// ◆DSF_NET_TacticalDrawing.CMineFieldとDSF_NET_Map.CMineFieldで曖昧になっている。
				var minefield = new DSF_NET_Map.CMineField(type, depth, dir, Color.Red, 2);

				foreach(XmlNode front_edge_node_i in front_edge_node)
				{
					var lglt = ReadLgLt(front_edge_node_i);

					if(lglt == null)
					{
						var utm = ReadUTM(front_edge_node_i);

						if(utm != null)
							lglt = ToLgLt(utm);
						else
							throw new Exception("illegal mine field front edge node expression");
					}

					minefield.AddFrontEdgeNode(lglt);
				}

				TileMap.DrawingLayers[layer_hash].Add(minefield);
			}
			else
			{
				// ◆まだ
			}

		}
	}
}
//---------------------------------------------------------------------------
}
