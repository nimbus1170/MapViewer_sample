﻿//
// MapViewForm_Layer_ReadXML_DifensivePosition.cs
// 防御陣地レイヤ
//
// ●XML描画データから防御陣地を読み込む。
//
//---------------------------------------------------------------------------
using static DSF_NET_Geography.Convert_LgLt_UTM;
using static DSF_NET_TacticalDrawing.XMLReader;

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
		var defensive_position_nodes = drawing_xml_node.SelectNodes("MapDrawings/DefensivePosition");

		foreach(XmlNode defensive_position_node in defensive_position_nodes)
		{
			var type = defensive_position_node.Attributes["Type"].InnerText;
			
			if(type == "Spline")
			{
				var curve_pos = defensive_position_node.SelectNodes("CurvePos");

				DSF_NET_Map.CDefensivePosition defensive_position = new DSF_NET_Map.CDefensivePosition(Color.Red, 2, DSF_NET_Map.DDefensivePositionDrawType.Spline);

				foreach(XmlNode i_curve_pos in curve_pos)
				{
					// ◆経緯度かUTMのいずれか。
					// →◆ReadXML側でToLgLtすると良いか？
					{ 
						var lglt = ReadLgLt(i_curve_pos);

						if(lglt != null) defensive_position.AddCurvePos(lglt);
					}

					{
						var utm = ReadUTM(i_curve_pos);

						if(utm != null)	defensive_position.AddCurvePos(ToLgLt(utm));
					}
				}

				TileMap.DrawingLayers[layer_hash].Add(defensive_position);
			}

			if(type == "Bezier")
			{
				var curve_pos = defensive_position_node.SelectNodes("CurvePos");

				DSF_NET_Map.CDefensivePosition defensive_position = new DSF_NET_Map.CDefensivePosition(Color.Red, 2, DSF_NET_Map.DDefensivePositionDrawType.Bezier);

				foreach(XmlNode i_curve_pos in curve_pos)
				{
					// ◆経緯度かUTMのいずれか。
					// →◆ReadXML側でToLgLtすると良いか？
					{ 
						var lglt = ReadLgLt(i_curve_pos);

						if(lglt != null) defensive_position.AddCurvePos(lglt);
					}

					{
						var utm = ReadUTM(i_curve_pos);

						if(utm != null)	defensive_position.AddCurvePos(ToLgLt(utm));
					}
				}

				TileMap.DrawingLayers[layer_hash].Add(defensive_position);
			}
		}
	}
}
//---------------------------------------------------------------------------
}
