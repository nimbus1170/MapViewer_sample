//
// MapViewForm_Layer_Observer.cs
// �ʎ����背�C��
//
//---------------------------------------------------------------------------
using DSF_NET_Geography;
using DSF_NET_Map;

using System.Windows.Forms;
//---------------------------------------------------------------------------
namespace MapView_test
{
//---------------------------------------------------------------------------
public partial class CMapViewForm : Form
{
	// �ʎ����背�C��
	void SetLayers_Observer(in int layer_hash)
	{
		// ��R��
		CTude obs_p = new CTude(new CLongitude(130.1611), new CLatitude(33.5722));

		CTude area_s = new CTude(new CLongitude(130.1500), new CLatitude(33.5650)); 
		CTude area_e = new CTude(new CLongitude(130.1550), new CLatitude(33.5700)); 
		
		// ���e�X�g�p
	//	CTude area_s = new CTude(new CLongitude(130.1611), new CLatitude(33.5722)); 
	//	CTude area_e = new CTude(new CLongitude(130.1661), new CLatitude(33.5772)); 

		CObserver obs = new CObserver(obs_p, area_s, area_e);

		TileMap.ObserverLayers[layer_hash].Add(obs);
	}
}
//---------------------------------------------------------------------------
}
