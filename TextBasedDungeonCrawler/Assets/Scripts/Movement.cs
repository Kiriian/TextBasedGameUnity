using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Movement : ScriptableObject {

	public int x;
	public  int y;
	public  int xAxis;
	public  int yAxis;

	public Room MoveSouth (Room[,] roomArray){
		xAxis = roomArray.GetLength (0) - 1;
		yAxis = roomArray.GetLength (1) - 1;

		x = x + 1;

		if (x <= xAxis && x >= 0 && roomArray [x, y] != null) {
			return roomArray [x, y];
		} else {
			return MoveNorth (roomArray);
		}
	}

	public Room MoveNorth (Room[,] roomArray){
		xAxis = roomArray.GetLength (0) - 1;
		yAxis = roomArray.GetLength (1) - 1;

		x = x - 1;

		if (x <= xAxis && x >= 0 && roomArray [x, y] != null) {
			return roomArray [x, y];
		} else {
			return MoveSouth (roomArray);
		}
	}

	public Room MoveEast (Room[,] roomArray){
		xAxis = roomArray.GetLength (0) - 1;
		yAxis = roomArray.GetLength (1) - 1;

		y = y + 1;

		if (y <= yAxis && y >= 0 && roomArray [x, y] != null) {
			return roomArray [x, y];
		} else {
			return MoveWest (roomArray);
		}
	}

	public Room MoveWest (Room[,] roomArray){
		xAxis = roomArray.GetLength (0) - 1;
		yAxis = roomArray.GetLength (1) - 1;

		y = y - 1;
		if (y <= yAxis && y >= 0 && roomArray [x, y] != null) {
			return roomArray [x, y];
		} else {
			return MoveEast (roomArray);
		}
	}

	public Room getCurrentRoom(Room[,] roomArray)
	{
		return roomArray [x, y];
	}

	public int xCoordinate
	{
		get {return this.x; }
		set {this.x = value; }
	}

	public int yCoordinate
	{
		get {return this.y; }
		set {this.y = value; }
	}
	public string Options (Room r)
	{
		string availableDirections = "You can move: ";

		foreach (Direction d in r.Directions) {
			availableDirections += d.DirectionName + ", ";
		}
		return availableDirections;
	}
}
