//
// MapViewForm_Layer_ReadXML_MineField.cs
// 地雷原レイヤ
//
// ●XML描画データから地雷原を読み込む。
//
//---------------------------------------------------------------------------
using DSF_NET_Map;
using DSF_NET_TacticalDrawing;

using static DSF_NET_Geography.Convert_LgLt_UTM;
using static DSF_NET_TacticalDrawing.XMLReader;

using System.Collections.Generic;
using System.Drawing;
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
	// 地雷原レイヤ
	void SetLayers_ReadXML_MineField(in XmlNode drawing_xml_node, in int layer_hash)
	{
		var minefields_nodes = drawing_xml_node.SelectNodes("MapDrawings/MineField");

		foreach(XmlNode minefield_node in minefields_nodes)
		{
			var type_s = minefield_node.Attributes["Type"].InnerText;
			var type = (type_s == "AT")? DMineFieldType.AT:
					   (type_s == "AP")? DMineFieldType.AP:
										 DMineFieldType.ATAP;			
	
			var dir_s = minefield_node.Attributes["FrontEdgeDirection"].InnerText ;
			var dir = (dir_s == "LeftToRight")? DMineFieldFrontEdgeDirection.LeftToRight: 
												DMineFieldFrontEdgeDirection.RightToLeft;			
			
			if(dir == DMineFieldFrontEdgeDirection.RightToLeft)
			{
				var front_edge_pos = minefield_node.SelectNodes("FrontEdgePos");

				DSF_NET_Map.CMineField minefield = new DSF_NET_Map.CMineField(type, 200, dir, Color.Red, 2);

				foreach(XmlNode i_front_edge_pos in front_edge_pos)
				{
					// ◆経緯度かUTMのいずれか。
					// →◆ReadXML側でToLgLtすると良いか？
					{
						var lglt = ReadLgLt(i_front_edge_pos);

						if(lglt != null) minefield.AddFrontEdgePos(lglt);
					}

					{
						var utm = ReadUTM(i_front_edge_pos);

						if(utm != null) minefield.AddFrontEdgePos(ToLgLt(utm));
					}
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
