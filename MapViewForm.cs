//
// MapViewForm.cs
//
//---------------------------------------------------------------------------
using DSF_NET_Geography;
using DSF_NET_Map;

using static DSF_NET_TacticalDrawing.ReadXML;

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

	bool isMouseDown = false;

	Point prevMousePoint;

	// 地図の操作による描画とその他の理由による描画の排他制御
	// ◆(フェデレートでない)MapViewでは不要では？図形のロード等があるか？
	public bool isDrawingMap = false;

	public CMapViewForm(string[] args)
	{
		//-------------------------------------------------------

		InitializeComponent();

		mapPictureBox.MouseWheel += new MouseEventHandler(mapPictureBox_MouseWheel);
            
		//-------------------------------------------------------
		// ◆ここではXMLで設定しているが、設定方法は任意なのでライブラリにはしない。

		var map_cfg_xml = new XmlDocument();

		map_cfg_xml.Load(args[0]);

		var ct = ReadTude(map_cfg_xml.SelectSingleNode("MapViewerConfig/Center"));
		
		if(ct == null) throw new Exception("map center is not defined.");

		var map_data_fld = map_cfg_xml.SelectSingleNode("MapViewerConfig/MapData").Attributes["Folder"].InnerText;
	
		TileMap = new GSIImageTileMap
			(ct,
			 15,
			 map_data_fld,
			 infoLabel)
			{
				ToDrawTudeGrid = toDrawTudeGridToolStripMenuItem.Checked,
				ToDrawUTMGrid  = toDrawUTMGridToolStripMenuItem .Checked,

				mapType = (mapImageToolStripMenuItem.Checked)? DMapType.IMAGE_MAP: DMapType.PHOTO_MAP
			};

		SetGridSetting();

		var drawing_xml = new XmlDocument();

		drawing_xml.Load(map_cfg_xml.SelectSingleNode("MapViewerConfig/DrawingData").Attributes["File"].InnerText);

		SetLayers(drawing_xml);

		// Graphicsオブジェクトを作成するためリサイズイベントを強制的に実行する。
		// 併せて最初の描画を実施する。
		CMapForm_Resize(null, null);

		// Graphicsオブジェクト作成後に実行可能となる。
		DrawLayers();
	}

	void CMapForm_Resize(object sender, EventArgs e)
	{
		// mapPictureBoxがリサイズされたらGraphicsオブジェクトを新たなサイズで再作成する必要がある。
		// 再作成しないとリサイズ前の領域にしか描画されない。
		// Graphicsオブジェクトをリサイズすることはできない。

		if(mapPictureBox.Image != null) mapPictureBox.Image.Dispose();

		// 新たなサイズのBitmapインスタンスを作成してmapPictureBoxのImageに指定する。
		mapPictureBox.Image = new Bitmap(mapPictureBox.Width, mapPictureBox.Height);

		TileMap.Resize(Graphics.FromImage(mapPictureBox.Image), mapPictureBox.Size);

		DrawMapImage();
	}

	void mapPictureBox_MouseDown(Object sender, MouseEventArgs e)
	{
		prevMousePoint = e.Location;

		isMouseDown = true;
	}

	void mapPictureBox_MouseMove(Object sender, MouseEventArgs e)
	{
		TileMap.UpdateInfo(e);

		if(!isMouseDown) return;

		TileMap.Move(e.X - prevMousePoint.X, e.Y - prevMousePoint.Y);

		DrawMapImage();
		
		prevMousePoint = e.Location;
	}

	void mapPictureBox_MouseUp(Object sender, MouseEventArgs e)
	{
		isMouseDown = false;
	}

	void mapPictureBox_MouseWheel(object sender, MouseEventArgs e)
	{
		if(e.Delta > 0)
			TileMap.ZoomIn();
		else
			TileMap.ZoomOut();

		TileMap.UpdateInfo(e);

		DrawMapImage();
	}

	void toDrawTudeGridToolStripMenuItem_Click(Object sender, EventArgs e)
	{
		TileMap.ToDrawTudeGrid = toDrawTudeGridToolStripMenuItem.Checked;

		DrawMapImage();
	}

	void toDrawUTMGridToolStripMenuItem_Click(Object sender, EventArgs e)
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
		if(isDrawingMap) return false;

		isDrawingMap = true;

		TileMap.Draw();

		mapPictureBox.Refresh();

		isDrawingMap = false;

		return true;
	}
}
//---------------------------------------------------------------------------
}
