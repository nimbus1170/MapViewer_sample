//
// MapViewForm.cs
//
//---------------------------------------------------------------------------
using DSF_NET_Geography;
using DSF_NET_Geometry;
using DSF_NET_Map;

using static DSF_NET_Geography.Convert_MGRS_UTM;
using static DSF_NET_Geography.Convert_LgLt_UTM;
using static DSF_NET_Geography.Convert_LgLt_WP;

using static DSF_NET_Geography.XMapTile;
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
	public readonly GSIImageTileMap TileMap;

	private bool IsMouseDown = false;

	private Point PrevMousePoint;

	// 地図の操作による描画とその他の理由による描画の排他制御
	// ◆(フェデレートでない)MapViewでは不要では？図形のロード等があるか？
	public bool IsDrawingMap = false;

	public CMapViewForm(in string[] args)
	{
		//-------------------------------------------------------

		InitializeComponent();

		mapPictureBox.MouseWheel += new MouseEventHandler(MapPictureBox_MouseWheel);
            
		//-------------------------------------------------------
		// ◆ここではXMLで設定しているが、設定方法は任意なのでライブラリにはしない。

		var map_cfg_xml = new XmlDocument();

		map_cfg_xml.Load(args[0]);

		var ct = ReadLgLt(map_cfg_xml.SelectSingleNode("MapViewerCfg/Center"));
		
		if(ct == null) throw new Exception("map center is not defined.");

		var map_data_fld = map_cfg_xml.SelectSingleNode("MapViewerCfg/MapData").Attributes["Folder"].InnerText;
	
		TileMap = new GSIImageTileMap
			(ct,
			 15,
			 map_data_fld)
			{
				ToDrawLgLtGrid = toDrawLgLtGridToolStripMenuItem.Checked,
				ToDrawUTMGrid  = toDrawUTMGridToolStripMenuItem .Checked,

				mapType = (mapImageToolStripMenuItem.Checked)? DMapType.IMAGE_MAP: DMapType.PHOTO_MAP
			};

		SetGridSetting();

		var drawing_xml = new XmlDocument();

		drawing_xml.Load(map_cfg_xml.SelectSingleNode("MapViewerCfg/DrawingData").Attributes["File"].InnerText);

		SetLayers(drawing_xml);

		// Graphicsオブジェクトを作成するためリサイズイベントを強制的に実行する。
		// 併せて最初の描画を実施する。
		CMapForm_Resize(null, null);

		// Graphicsオブジェクト作成後に実行可能となる。
		DrawMapImage();
	}

	void CMapForm_Resize(Object sender, EventArgs e)
	{
		// mapPictureBoxがリサイズされたらGraphicsオブジェクトを新たなサイズで再作成する必要がある。
		// 再作成しないとリサイズ前の領域にしか描画されない。
		// Graphicsオブジェクトをリサイズすることはできない。

		if(TileMap == null) return;

		if(mapPictureBox.Image != null) mapPictureBox.Image.Dispose();

		// 新たなサイズのBitmapインスタンスを作成してmapPictureBoxのImageに指定する。
		mapPictureBox.Image = new Bitmap(mapPictureBox.Width, mapPictureBox.Height);

		TileMap.Resize(Graphics.FromImage(mapPictureBox.Image), mapPictureBox.Size);

		DrawMapImage();

		UpdateInfo();
	}

	void MapPictureBox_MouseDown(Object sender, MouseEventArgs e)
	{
		PrevMousePoint = e.Location;

		IsMouseDown = true;
	}

	void MapPictureBox_MouseMove(Object sender, MouseEventArgs e)
	{
		mouseLabel.Left = e.X + 10;
		mouseLabel.Top  = e.Y + 40;

		UpdateMouseInfo(e);

		if(!IsMouseDown) return;

		TileMap.Move(e.X - PrevMousePoint.X, e.Y - PrevMousePoint.Y);

		DrawMapImage();

		PrevMousePoint = e.Location;
		
		UpdateInfo();
	}

	void MapPictureBox_MouseUp(Object sender, MouseEventArgs e)
	{
		IsMouseDown = false;
	}

	void MapPictureBox_MouseWheel(Object sender, MouseEventArgs e)
	{
		if(e.Delta > 0)
			TileMap.ZoomIn();
		else
			TileMap.ZoomOut();

		DrawMapImage();

		UpdateInfo();
	}

	void ToDrawLgLtGridToolStripMenuItem_Click(Object sender, EventArgs e)
	{
		TileMap.ToDrawLgLtGrid = toDrawLgLtGridToolStripMenuItem.Checked;

		DrawMapImage();
	}

	void ToDrawUTMGridToolStripMenuItem_Click(Object sender, EventArgs e)
	{
		TileMap.ToDrawUTMGrid = toDrawUTMGridToolStripMenuItem.Checked;

		DrawMapImage();
	}

	private void MapImageToolStripMenuItem_Click(Object sender, EventArgs e)
	{
		mapImageToolStripMenuItem.CheckState = CheckState.Indeterminate;
		photoImageToolStripMenuItem.Checked = false;

		TileMap.mapType = DMapType.IMAGE_MAP;

		DrawMapImage();
	}

	private void PhotoImageToolStripMenuItem_Click(Object sender, EventArgs e)
	{
		photoImageToolStripMenuItem.CheckState = CheckState.Indeterminate;
		mapImageToolStripMenuItem.Checked = false;

		TileMap.mapType = DMapType.PHOTO_MAP;

		DrawMapImage();
	}

	public bool DrawMapImage()
	{
		if(IsDrawingMap) return false;

		IsDrawingMap = true;

		TileMap.Draw();

		mapPictureBox.Refresh();

		IsDrawingMap = false;

		return true;
	}

	private void mapPictureBox_MouseEnter(Object sender, EventArgs e)
	{
		mouseLabel.Show();
	}

	private void mapPictureBox_MouseLeave(Object sender, EventArgs e)
	{
		mouseLabel.Hide();
	}

	public void UpdateInfo()
	{
		var ct_wp_x = TileMap.CenterWP.X;
		var ct_wp_y = TileMap.CenterWP.Y;

		var ct_lg = ToLg(ct_wp_x);
		var ct_lt = ToLt(ct_wp_y);

		var ct_lg_dms = new CDMS(ct_lg.DecimalDeg);
		var ct_lt_dms = new CDMS(ct_lt.DecimalDeg);

		var ct_utm = ToUTM(new CLgLt(ct_lg, ct_lt));

		infoLabel.Text =
			$"中心 {ct_lg.DecimalDeg:000.0000}E (東経{ct_lg_dms.Deg:000}度{ct_lg_dms.Min:00}分{ct_lg_dms.Sec:00.00}秒)\n" +
			$"　　 {ct_lt.DecimalDeg: 00.0000}N (北緯{ct_lt_dms.Deg: 00}度{ct_lt_dms.Min:00}分{ct_lt_dms.Sec:00.00}秒)\n" +
			$"　　 {ct_utm.LgBand}{GetLtBand(ToLgLt(ct_utm).Lt)} {GetMGR(ct_utm)} {GetMGRSUTM_EW(ct_utm):00000} {GetMGRSUTM_NS(ct_utm):00000}\n" +
			$"\n" +
			$"ズームレベル{ct_wp_x.ZoomLevel} {TileMap.ZoomValue:0.00}倍\n" +
			$"中心ピクセル {(int)(ct_wp_x.Value)} {(int)(ct_wp_y.Value)}\n" +
			$"中心タイル {GetTileX(ct_wp_x).Value} {GetTileY(ct_wp_y).Value}\n" +
			$"\n" +
			$"ウインドウサイズ {mapPictureBox.Width:000} x {mapPictureBox.Height:000}";
	}

	public void UpdateMouseInfo(MouseEventArgs e)
	{
		// マウス位置のピクセル座標は、中心座標にマウス位置の中心座標からの差分を加えたもの。
		var ms_lg = ToLg(TileMap.CenterWP.X + (e.X - mapPictureBox.Width  / 2) / TileMap.ZoomValue);
		var ms_lt = ToLt(TileMap.CenterWP.Y + (e.Y - mapPictureBox.Height / 2) / TileMap.ZoomValue);

		var ms_lg_dms = new CDMS(ms_lg.DecimalDeg);
		var ms_lt_dms = new CDMS(ms_lt.DecimalDeg);

		var ms_utm = ToUTM(new CLgLt(ms_lg, ms_lt));

		mouseLabel.Text =
			$"{ms_lg.DecimalDeg:000.0000}E (東経{ms_lg_dms.Deg:000}度{ms_lg_dms.Min:00}分{ms_lg_dms.Sec:00.00}秒)\n" +
			$"{ms_lt.DecimalDeg: 00.0000}N (北緯{ms_lt_dms.Deg: 00}度{ms_lt_dms.Min:00}分{ms_lt_dms.Sec:00.00}秒)\n" +
			$"{ms_utm.LgBand}{GetLtBand(ToLgLt(ms_utm).Lt)} {GetMGR(ms_utm)} {GetMGRSUTM_EW(ms_utm):00000} {GetMGRSUTM_NS(ms_utm):00000}\n" +
			$"{e.X:000} {e.Y:000}";
	}
}
//---------------------------------------------------------------------------
}
