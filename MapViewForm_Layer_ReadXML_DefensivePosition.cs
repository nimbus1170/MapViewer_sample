//
// MapViewForm_Layer_ReadXML_DifensivePosition.cs
// 防御陣地レイヤ
//
// ●XML描画データから防御陣地を読み込む。
//
//---------------------------------------------------------------------------
using DSF_NET_Geography;
using DSF_NET_Map;

using static DSF_NET_Geography.Convert_LgLt_GeoCentricCoord;
using static DSF_NET_Geography.Convert_LgLt_UTM;
using static DSF_NET_TacticalDrawing.XMLReader;

using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

using static System.Convert;
using static System.Math;
//---------------------------------------------------------------------------
namespace MapView_test
{
//---------------------------------------------------------------------------
// ◆多用するので定義しておく。
using TDoublePair = Tuple<double, double>;
//---------------------------------------------------------------------------
public partial class CMapViewForm : Form
{
	// 防御陣地レイヤ
	void SetLayers_ReadXML_DefensivePosition(in XmlNode drawing_xml_node, in int layer_hash)
	{
		//--------------------------------------------------

		var draw_attribute_xml_nodes = drawing_xml_node.SelectSingleNode("MapDrawings/DrawAttribute");

		var color = Color.FromArgb(ToInt32(draw_attribute_xml_nodes.Attributes["Color"].InnerText, 16));

		var line_width = ToInt32(draw_attribute_xml_nodes.Attributes["LineWidth"].InnerText);

		//--------------------------------------------------

		var defensive_position_xml_nodes = drawing_xml_node.SelectNodes("MapDrawings/DefensivePosition");

		foreach(XmlNode defensive_position_xml_node in defensive_position_xml_nodes)
		{
			var unit_level = defensive_position_xml_node.Attributes["UnitLevel"].InnerText;
		
			var type_str = defensive_position_xml_node.Attributes["Type"].InnerText;
			
			var type = 
				(type_str == "Spline"	)? DDefensivePositionDrawType.Spline   :
				(type_str == "Bezier"	)? DDefensivePositionDrawType.Bezier   :
				(type_str == "RoundRect")? DDefensivePositionDrawType.RoundRect:
										   DDefensivePositionDrawType.Unknown  ;

			// ◆取り敢えず何もしない。
			if(type == DDefensivePositionDrawType.Unknown) return;

			var defensive_position = new CDefensivePosition(color, line_width, type);

			switch(type)
			{ 
				//--------------------------------------------------
				// スプライン曲線・ベジェ曲線
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

							if(utm == null)
								throw new Exception("illegal defensive position border node expression");

							lglt = ToLgLt(utm);
						}

						defensive_position.AddBorderNode(lglt);
					}

					break;
				}

				//--------------------------------------------------
				// 角を丸めた矩形
				case DDefensivePositionDrawType.RoundRect:
				{
					// ◆他の種類のものと要素が異なるため、描画ノードにするまでここで計算する。

					// 正面幅、縦深、四隅の丸の半径
					var w		= ToDouble(defensive_position_xml_node.Attributes["Width"	 ].InnerText);
					var d		= ToDouble(defensive_position_xml_node.Attributes["Depth"	 ].InnerText);
					var dir_mil	= ToDouble(defensive_position_xml_node.Attributes["Direction"].InnerText);
					var r		= ToDouble(defensive_position_xml_node.Attributes["RectR"	 ].InnerText);

					var front_edge_nodes = defensive_position_xml_node.SelectNodes("FrontEdgeNode");

					CLgLt ct_lglt = null; // 取り敢えず一つだけ
					CUTM  ct_utm  = null;

					foreach(XmlNode front_edge_node in front_edge_nodes)
					{
						ct_lglt = ReadLgLt(front_edge_node);

						if(ct_lglt == null)
						{
							ct_utm = ReadUTM(front_edge_node);

							if(ct_utm == null)
								throw new Exception("illegal defensive position front edge node expression");

							ct_lglt = ToLgLt(ct_utm);
						}
					}

					if(ct_lglt == null)
						throw new Exception("no RoundRect defensive position node defined");

					//--------------------------------------------------
					// 作成した地雷原を回転・移動させるための変数

					// 方位角の方向に合わせる。
					var dir_rad = - PI * dir_mil / 3200;

					var s = Sin(dir_rad);
					var c = Cos(dir_rad);

					//--------------------------------------------------
					// 前縁中央を原点として地雷原の外縁を作成する。
					// ●前縁を上にして、後縁の開始位置から時計回りに頂点を設定する。角は30度ずつ頂点を設定する。
					// ◆形が崩れないようにUTMで計算して最後に経緯度に変換する(当初から経緯度でやると縦長になる。)が、経度帯境界では正しく計算できないのでは？

					var w_2 = w / 2;

					var r1 = r;
					var r2 = r * (1 - Sin(PI * 30 / 180));
					var r3 = r * (1 - Sin(PI * 60 / 180));

					var border_nodes = new TDoublePair[18]; 

					border_nodes[0]  = new TDoublePair(-(50		 ), -(d		));

					border_nodes[1]  = new TDoublePair(-(w_2 - r1), -(d		));
					border_nodes[2]  = new TDoublePair(-(w_2 - r2), -(d - r3));
					border_nodes[3]  = new TDoublePair(-(w_2 - r3), -(d - r2));
					border_nodes[4]  = new TDoublePair(-(w_2	 ), -(d - r1));

					border_nodes[5]  = new TDoublePair(-(w_2	 ), -( 	  r1));
					border_nodes[6]  = new TDoublePair(-(w_2 - r3), -(	  r2));
					border_nodes[7]  = new TDoublePair(-(w_2 - r2), -(	  r3));
					border_nodes[8]  = new TDoublePair(-(w_2 - r1),  (0		));

					border_nodes[9]  = new TDoublePair( (w_2 - r1),  (0		));
					border_nodes[10] = new TDoublePair( (w_2 - r2), -(	  r3));
					border_nodes[11] = new TDoublePair( (w_2 - r3), -(	  r2));
					border_nodes[12] = new TDoublePair( (w_2	 ), -(	  r1));

					border_nodes[13] = new TDoublePair( (w_2	 ), -(d - r1));
					border_nodes[14] = new TDoublePair( (w_2 - r3), -(d - r2));
					border_nodes[15] = new TDoublePair( (w_2 - r2), -(d - r3));
					border_nodes[16] = new TDoublePair( (w_2 - r1), -(d		));

					border_nodes[17] = new TDoublePair( (50		 ), -(d		));

					// 回転させて、当該位置に平行移動させる。
					// ◆行列ひとつでできないか？
					foreach(var node in border_nodes)
					{
						var x0 = node.Item1;
						var y0 = node.Item2;

						var x = x0 * c - y0 * s;
						var y = x0 * s + y0 * c;

						var node_utm = new CUTM(ct_utm);
						
						node_utm.AddEW(x);
						node_utm.AddNS(y);

						defensive_position.AddBorderNode(ToLgLt(node_utm));
					}

					//--------------------------------------------------
					// 部隊規模標示を作成する。

					switch(unit_level)
					{
						case "Co":
						{ 
							var unit_level_nodes = new TDoublePair[2];

							unit_level_nodes[0] = new TDoublePair(0, -d - 50);
							unit_level_nodes[1] = new TDoublePair(0, -d + 50);

							// 回転させて、当該位置に平行移動させる。
							// ◆行列ひとつでできないか？
							foreach(var node in unit_level_nodes)
							{
								var x0 = node.Item1;
								var y0 = node.Item2;

								var x = x0 * c - y0 * s;
								var y = x0 * s + y0 * c;

								var node_utm = new CUTM(ct_utm);
						
								node_utm.AddEW(x);
								node_utm.AddNS(y);

								defensive_position.AddUnitLevelNode(ToLgLt(node_utm));
							}

							break;
						}

						default: throw new Exception("unknown unit level");
					}

					//--------------------------------------------------

					break;
				}
			}

			TileMap.DrawingLayers[layer_hash].Add(defensive_position);
		}
	}
}
//---------------------------------------------------------------------------
}
