using UnityEngine;
using System.Collections;
using System;

public class Map : ScriptableObject {

	// Map generation is based on X and Y, but in this structure, visually in this table, what is the Y axis is actually the X axis.

	public int[,] tileMap = new int[,] {
		{ 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0 }
	};

	public float TileSize;
	public Vector2 StartPoint;

	public void CreateMap(Room[,] roomArray){
		TileSize = 25;
		StartPoint = new Vector2 (-65, -120);
		ResetTileMap ();
		GenerateTileMap (roomArray);
		PopulateTileMap();
		SetPlayerMapPos (0, 0, 0, 0);
	}

	public void ResetTileMap(){
		tileMap = new int[,] {
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 }
		};
	}

	public void GenerateTileMap(Room[,] roomArray){
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				if (roomArray[i,j] != null){
					tileMap [i, j] = 1;
				}
			}
		}
	}

	public void PopulateTileMap(){
		for(int i = 0; i < 5; i++){
			for(int j = 0; j < 5; j++){

				GameObject prefab = Resources.Load("tile_"+tileMap[i,j].ToString()) as GameObject;
				GameObject tile = Instantiate (prefab, Vector3.zero, Quaternion.identity) as GameObject;
				tile.name = "tile_" + i + "," + j;
				tile.transform.SetParent (GameObject.Find("PlayerInfoBackground").transform);
				tile.transform.localPosition = new Vector3 (StartPoint.x + (TileSize * j) + (TileSize / 2), StartPoint.y - (TileSize * i) - (TileSize / 2), -35);
				tile.tag = "maptile";

			}
		}
	}

	public void ClearMap(){
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("maptile");
		foreach (var item in tiles) {
			Destroy (item);
		}
	}

	public void SetPlayerMapPos(int x, int y, int nextX, int nextY){

		GameObject smilePrefab = Resources.Load("tile_2") as GameObject;
		GameObject greenPrefab = Resources.Load ("tile_1") as GameObject;

		GameObject tile = GameObject.Find ("tile_"+x+","+y);
		GameObject newTile = GameObject.Find ("tile_" + nextX + "," + nextY);

		Vector3 tileVec = tile.transform.localPosition;
		Vector3 nextTileVec = newTile.transform.localPosition;

		Destroy (tile);
		GameObject tile2 = Instantiate (greenPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		tile2.name = "tile_" + x + "," + y;
		tile2.transform.SetParent (GameObject.Find("PlayerInfoBackground").transform);
		tile2.transform.localPosition = tileVec;
		tile2.tag = "maptile";

		Destroy (newTile);
		GameObject tile1 = Instantiate (smilePrefab, Vector3.zero, Quaternion.identity) as GameObject;
		tile1.name = "tile_" + nextX + "," + nextY;
		tile1.transform.SetParent (GameObject.Find("PlayerInfoBackground").transform);
		tile1.transform.localPosition = nextTileVec;
		tile1.tag = "maptile";


	}

}
