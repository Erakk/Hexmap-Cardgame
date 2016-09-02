using UnityEngine;
using System.Collections;

public class Cone : MonoBehaviour {

	public Vector3 startPosition;
	public Vector3 endPosition;
	public TileMap map;
	public int startX;
	public int startY;
	private Vector3 startLoc;
	private Vector3 hexLoc;
	private Vector3 distance;
	public int skillDistance = 0;
	public string direction;
	private bool directionChecked;

	void Start()
	{
//		map = TileMap.map;
	}

	public void CalculateCone(int startPointX, int startPointY ,int endPointX, int endPointY)
	{

		startLoc = new Vector3();

		startLoc.y = startPointY;
		startLoc.z = startPointX - (startPointY - (Mathf.Abs(startPointY) % 2)) / 2;
		startLoc.x = - startLoc.y - startLoc.z;
		CalcDistance(endPointX, endPointY);

		if (startPointY < endPointY) {
			if (distance.y > distance.x && distance.y > distance.z) {
				CalculateConeUpY();	//toimii oikeeseen suuntaan
//				direction = "upY";
				//ylös
			}
			else if (distance.x > distance.z && distance.x > distance.y) {
				CalculateConeUpX(); // toimii
//				direction = "upX";
			} 
			else if(distance.z > distance.x && distance.z > distance.y) {				
				CalculateConeUpZ(); // toimii
//				direction = "upZ";
			}
		} 
		else if (startPointY > endPointY)
		{
			if (distance.y > distance.x && distance.y > distance.z) {
				CalculateConeDownY();
//				direction = "downY";
				
			}
			else if (distance.x > distance.z && distance.x > distance.y) {
				CalculateConeDownX(); // Toimii oikeeseen suuntaan, vasen puoli
//				direction = "downX";
			} 
			else if (distance.z > distance.x && distance.z > distance.y) {
				
				CalculateConeDownZ(); // Toimii oikeeseen suuntaan
//				direction = "downZ";
			}
		}
	}

	public void CalculateConeEquals(int startPointX, int startPointY ,int endPointX, int endPointY)
	{
		startLoc = new Vector3();
		startLoc.y = startPointY;
		startLoc.z = startPointX - (startPointY - (Mathf.Abs(startPointY) % 2)) / 2;
		startLoc.x = - startLoc.y - startLoc.z;
		CalcRealDistance(endPointX, endPointY);
		float maxDistance = Mathf.Max(distance.x, distance.y, distance.z);
		float upDownDistance = Mathf.Max(startPointY, endPointY);
		int rounds = 0;
		
		directionChecked = false;

		switch (direction) {

			case "upY":
				calcUpY();
				if (directionChecked) {
				return;
				}
				calcUpZ();
				if (directionChecked) {
				return;
				}
				calcUpX();
				if (directionChecked) {
				return;
				}
				calcDownX();
				if (directionChecked) {
				return;
				}
				calcDownZ();
				if (directionChecked) {
				return;
				}
				calcDownY();
				if (directionChecked) {
				return;
				}
			break;
			case "upX":
				calcUpX();
				if (directionChecked) {
				return;
				}
				calcUpY();
				if (directionChecked) {
				return;
				}
				calcDownZ();
				if (directionChecked) {
				return;
				}
				calcUpZ();
				if (directionChecked) {
				return;
				}
				calcDownY();
				if (directionChecked) {
				return;
				}	
				calcDownX();
				if (directionChecked) {
				return;
				}
				
			break;
			case "upZ":
				calcUpZ();
				if (directionChecked) {
				return;
				}
				calcDownX();
				if (directionChecked) {
				return;
				}
				calcUpY();
				if (directionChecked) {
				return;
				}
				calcDownY();
				if (directionChecked) {
				return;
				}	
				calcUpX();		
				if (directionChecked) {
				return;
				}	
				calcDownZ();
				if (directionChecked) {
				return;
				}			
			break;
			case "downY":
				calcDownY();
				if (directionChecked) {
				return;
				}
				calcDownZ();
				if (directionChecked) {
				return;
				}
				calcDownX();
				if (directionChecked) {
				return;
				}
				calcUpX();
				if (directionChecked) {
				return;
				}
				calcUpZ();
				if (directionChecked) {
				return;
				}
				calcUpY();
				if (directionChecked) {
				return;
				}
			break;
			case "downX":
				calcDownX();
				if (directionChecked) {
				return;
				}
				calcDownY();
				if (directionChecked) {
				return;
				}
				calcUpZ();
				if (directionChecked) {
				return;
				}
				calcDownZ();
				if (directionChecked) {
				return;
				}
				calcUpY();	
				if (directionChecked) {
				return;
				}
				calcUpX();
				if (directionChecked) {
				return;
				}
			break;
			case "downZ":
				calcDownZ();
				if (directionChecked) {
				return;
				}
				calcUpX();
				if (directionChecked) {
				return;
				}
				calcDownY();
				if (directionChecked) {
				return;
				}
				calcUpY();	
				if (directionChecked) {
				return;
				}
				calcDownX();			
				if (directionChecked) {
				return;
				}
				calcUpZ();	
				if (directionChecked) {
				return;
				}
			break;
			default:
//				rounds++;
//				Debug.Log("rounds " + rounds);
//				if (rounds >= 3) {
//					Debug.LogError("couldn't find direction");
//					directionChecked = true;
				
			break;
		}
		
	}

	void CalculateConeDownZ() // oikea alas
	{
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");

		foreach (GameObject tile in Tiles) {
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			if (clickableTile.hexVisible) 
			{
				CalcDistance(clickableTile.tileX, clickableTile.tileY);
				if (distance.z >= distance.y && distance.z >= distance.x && distance.z <= skillDistance && distance.z != 0) {
					if (hexLoc.z - startLoc.z >= 0) {
						HighlightTiles(clickableTile.tileX, clickableTile.tileY);
						direction = "downZ";
					}
				}		
			}
		}
	}

	void CalculateConeUpZ() // oikea alas
	{
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");

		foreach (GameObject tile in Tiles) {
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			if (clickableTile.hexVisible) 
			{

				CalcDistance(clickableTile.tileX, clickableTile.tileY);
				if (distance.z >= distance.y && distance.z >= distance.x && distance.z <= skillDistance && distance.z != 0) {
					if (hexLoc.z - startLoc.z <= 0) {
						HighlightTiles(clickableTile.tileX, clickableTile.tileY);
						direction = "upZ";
					}
				}	
			}	
		}
	}
	void CalculateConeDownY()
	{
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");

		foreach (GameObject tile in Tiles) {
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			if (clickableTile.hexVisible) 
			{
				CalcDistance(clickableTile.tileX, clickableTile.tileY);
				if (distance.y >= distance.x && distance.y >= distance.z && distance.y <= skillDistance && distance.y != 0) {
					if (hexLoc.y - startLoc.y <= 0) {
						HighlightTiles(clickableTile.tileX, clickableTile.tileY);
						direction = "downY";
					}
				}
			}		
		}
	}
	void CalculateConeUpY()
	{
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");

		foreach (GameObject tile in Tiles) {
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			if (clickableTile.hexVisible) 
			{
				CalcDistance(clickableTile.tileX, clickableTile.tileY);
				if (distance.y >= distance.x && distance.y >= distance.z && distance.y <= skillDistance && distance.y != 0) {
					if (hexLoc.y - startLoc.y >= 0) {
						HighlightTiles(clickableTile.tileX, clickableTile.tileY);
						direction = "upY";
					}
				}		
			}
		}
	}

	void CalculateConeDownX()
	{
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");

		foreach (GameObject tile in Tiles) {
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			
			if (clickableTile.hexVisible) 
			{

				CalcDistance(clickableTile.tileX, clickableTile.tileY);
				if (distance.x >= distance.y && distance.x >= distance.z && distance.x <= skillDistance && distance.x != 0) {
					if (hexLoc.x - startLoc.x >= 0) {
						HighlightTiles(clickableTile.tileX, clickableTile.tileY);
						direction = "downX";
					}
				}	
			}	
		}
	}

	void CalculateConeUpX()
	{
		GameObject[] Tiles = GameObject.FindGameObjectsWithTag("Hex");

		foreach (GameObject tile in Tiles) {
			ClickableTile clickableTile = tile.GetComponent<ClickableTile> ();
			if (clickableTile.hexVisible) 
			{
				CalcDistance(clickableTile.tileX, clickableTile.tileY);
				if (distance.x >= distance.y && distance.x >= distance.z && distance.x <= skillDistance && distance.x != 0) {
					if (hexLoc.x - startLoc.x <= 0) {
						HighlightTiles(clickableTile.tileX, clickableTile.tileY);
						direction = "upX";
					}
				}	
			}	
		}
	}

	void CalcDistance(int tileXthis, int tileYthis )
	{
		hexLoc.y = tileYthis;
		hexLoc.z = tileXthis - (tileYthis - (Mathf.Abs(tileYthis) % 2)) / 2;
		hexLoc.x = - hexLoc.y - hexLoc.z;

		distance.y = (int)Mathf.Abs(hexLoc.y - startLoc.y);	
		distance.z = (int)Mathf.Abs(hexLoc.z - startLoc.z);	
		distance.x = (int)Mathf.Abs(hexLoc.x - startLoc.x);	
	}

	void HighlightTiles(int tileXthis, int tileYthis)
	{
		GameObject HighlightTiles = GameObject.Find ("_Scripts");
		HighlightTiles highlightTiles = HighlightTiles.GetComponent<HighlightTiles> ();
		highlightTiles.tileX = tileXthis;
		highlightTiles.tileY = tileYthis;
		highlightTiles.ShowTilesThatWillBeHitSkill();
	}
	void CalcRealDistance(int tileXthis, int tileYthis )
	{
		hexLoc.y = tileYthis;
		hexLoc.z = tileXthis - (tileYthis - (Mathf.Abs(tileYthis) % 2)) / 2;
		hexLoc.x = - hexLoc.y - hexLoc.z;

		distance.y = (int)(hexLoc.y - startLoc.y);	
		distance.z = (int)(hexLoc.z - startLoc.z);	
		distance.x = (int)(hexLoc.x - startLoc.x);	
	}
	void calcUpZ()
	{
		if (distance.z <= distance.y && distance.z <= distance.x && distance.z != 0 ) {
			CalculateConeUpZ();
//			Debug.Log("upZ");
			directionChecked = true;
			return;
		} 
	}
	void calcUpY()
	{
		if (distance.y >= distance.x && distance.y >= distance.z && distance.y != 0 ) {
			CalculateConeUpY();
//			Debug.Log("upY");
			directionChecked = true;
			return;
		}
	}
	void calcUpX()
	{
		if (distance.x <= distance.y && distance.x <= distance.z && distance.x != 0 ) {
			CalculateConeUpX();
//			Debug.Log("upX");
			directionChecked = true;
			return;
		}
	}
	void calcDownZ()
	{
		if (distance.z >= distance.y && distance.z >= distance.x && distance.z != 0 ) {
			CalculateConeDownZ();
//			Debug.Log("downZ");
			directionChecked = true;
			return;
		
		} 
	}
	void calcDownY()
	{
		if (distance.y <= distance.x && distance.y <= distance.z && distance.y != 0 ) {
			CalculateConeDownY();
//			Debug.Log("downY");
			directionChecked = true;
			return;
				
		} 
	}
	void calcDownX()
	{
		if (distance.x >= distance.y && distance.x >= distance.z && distance.x != 0 ) {
			CalculateConeDownX();
//			Debug.Log("downX");
			directionChecked = true;
			return;
				
		} 
	}
}
