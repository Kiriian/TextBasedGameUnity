using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public int[,] tileMap = new int[,] {
		{ 1, 1, 0, 0, 1 },
		{ 1, 1, 1, 1, 1 },
		{ 0, 1, 0, 1, 0 },
		{ 0, 1, 1, 0, 0 },
		{ 1, 1, 0, 0, 0 }
	};

	public float TileSize;
	public Vector2 StartPoint;

	void Start(){
		TileSize = 1;
		StartPoint = new Vector2 (24, -180);
		PopulateTileMap ();
	}

	public void PopulateTileMap(){
		for(int i = 0; i < 5; i++){
			for(int j = 0; j < 5; j++){
				GameObject prefab = Resources.Load("tile_"+tileMap[i,j].ToString()) as GameObject;
				GameObject tile = Instantiate (prefab, Vector3.zero, Quaternion.identity) as GameObject;
				tile.transform.SetParent (GameObject.Find("PlayerInfoBackground").transform);
				tile.transform.position = new Vector3 (StartPoint.x + (TileSize * i) + (TileSize / 2), StartPoint.y + (TileSize * j) + (TileSize / 2), -35);
			}
		}
	}

}
