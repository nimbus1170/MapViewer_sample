//
// MapViewForm_Layer_Observer.cs
// �ʎ����背�C��
//
//---------------------------------------------------------------------------
using DSF_NET_Geography;
using DSF_NET_Map;

using static DSF_NET_Geography.DAltitudeBase;

using System.Windows.Forms;
//---------------------------------------------------------------------------
namespace MapView_test
{
//---------------------------------------------------------------------------
public partial class CMapViewForm : Form
{
	// �ʎ����背�C��
	// ��GeoViewer�̂Ƌ��ʉ�����B
	void SetLayers_Observer(in int layer_hash)
	{
		// ��R��
		var obs_p  = new CLgLt(new CLg(130.1611), new CLt(33.5722), AE, 0.0);

		var area_s = new CLgLt(new CLg(130.1500), new CLt(33.5650), AE, 0.0); 
		var area_e = new CLgLt(new CLg(130.1550), new CLt(33.5700), AE, 0.0); 
		
		// ���e�X�g�p
	//	var area_s = new CLgLt(new CLg(130.1611), new CLt(33.5722)); 
	//	var area_e = new CLgLt(new CLg(130.1661), new CLt(33.5772)); 

		var obs = new CObserver(obs_p, area_s, area_e);

		TileMap.ObserverLayers[layer_hash].Add(obs);
	}
}
//---------------------------------------------------------------------------
}
