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
		GenerateTileMap (roomArray);
		PopulateTileMap();
		SetPlayerMapPos (0, 0, 0, 0);
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

			}
		}
	}

	public void SetPlayerMapPos(int x, int y, int nextX, int nextY){

		//		GameObject tile = GameObject.Find ("tile_"+x+","+y);
		//GameObject newTile = GameObject.Find ("tile_" + nextX + "," + nextY);
		//		tile.GetComponent<Renderer> ().material = Resources.Load ("grass");

		//newTile.GetComponent<Renderer>().material = (Material)Resources.Load ("brick", typeof(Material));
	}

}
