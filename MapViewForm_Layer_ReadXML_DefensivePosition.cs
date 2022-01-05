//
// MapViewForm_Layer_ReadXML_DifensivePosition.cs
// 防御陣地レイヤ
//
// ●XML描画データから防御陣地を読み込む。
//
//---------------------------------------------------------------------------
using DSF_NET_Map;

using static DSF_NET_Geography.Convert_LgLt_UTM;
using static DSF_NET_TacticalDrawing.XMLReader;

using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;
//---------------------------------------------------------------------------
namespace MapView_test
{
//---------------------------------------------------------------------------
public partial class CMapViewForm : Form
{
	// 防御陣地レイヤ
	void SetLayers_ReadXML_DefensivePosition(in XmlNode drawing_xml_node, in int layer_hash)
	{
		var defensive_position_xml_nodes = drawing_xml_node.SelectNodes("MapDrawings/DefensivePosition");

		foreach(XmlNode defensive_position_xml_node in defensive_position_xml_nodes)
		{
			var type_str = defensive_position_xml_node.Attributes["Type"].InnerText;
			
			var type = 
				(type_str == "Spline"	)? DDefensivePositionDrawType.Spline   :
				(type_str == "Bezier"	)? DDefensivePositionDrawType.Bezier   :
				(type_str == "RoundRect")? DDefensivePositionDrawType.RoundRect:
										   DDefensivePositionDrawType.Unknown  ;

			// ◆取り敢えず何もしない。
			if(type == DDefensivePositionDrawType.Unknown) return;

			var defensive_position = new CDefensivePosition(Color.Red, 2, type);

			switch(type)
			{ 
				case DDefensivePositionDrawType.Spline:
				case DDefensivePositionDrawType.Bezier:
				{ 
					var border_nodes = defensive_position_xml_node.SelectNodes("BorderNode");

					foreach(XmlNode border_node in border_nodes)
					{
						var lglt = ReadLgLt(border_node);

						if(lglt == null)
						{
							var utm = ReadUTM(border_node);

							if(utm != null)
								lglt = ToLgLt(utm);
							else
								throw new Exception("illegal defensive position border node expression");
						}

						defensive_position.AddBorderNode(lglt);
					}

					break;
				}

				case DDefensivePositionDrawType.RoundRect:
				{
					var front_edge_nodes = defensive_position_xml_node.SelectNodes("FrontEdgeNode");

					foreach(XmlNode front_edge_node in front_edge_nodes)
					{
						var lglt = ReadLgLt(front_edge_node);

						if(lglt == null)
						{
							var utm = ReadUTM(front_edge_node);

							if(utm != null)
								lglt = ToLgLt(utm);
							else
								throw new Exception("illegal defensive position front edge node expression");
						}

						defensive_position.AddBorderNode(lglt);
					}

					break;
				}
			}

			TileMap.DrawingLayers[layer_hash].Add(defensive_position);
		}
	}
}
//---------------------------------------------------------------------------
}
