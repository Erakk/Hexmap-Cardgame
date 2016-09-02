using UnityEngine;
using System.Collections;

[System.Serializable]
public class MapSettingAreas {

	// Tekee muokatttavan interfacen unityyn. Pystyy suoraan Unitystä muokaamaan karttaan halutut vuoret/swapmpit yms

	public string name;
	public int startX;
	public int endX;
	public int startY;
	public int endY;
	public int tileType;
}
