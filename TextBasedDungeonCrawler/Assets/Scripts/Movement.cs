using UnityEngine;
using System.Collections;

public class Movement : ScriptableObject {

	private int x;
	private int y;
	private int xAxis;
	private int yAxis;
	private string blocked = "That Way is Blocked";
	private string moveToNextFloor = "You can Go on to the Next Floor";

	public string MoveSouth (Room[,] roomArray){
		xAxis = roomArray.GetLength (0) - 1;
		yAxis = roomArray.GetLength (1) - 1;

		x = x + 1;

		if (x <= xAxis && x >= 0 && roomArray [x, y] != null) {
			if (roomArray [x, y].EntranceToNextFloor == true) {
				return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]) + "\r\n" + moveToNextFloor;
			}

			return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]);
		} else {
			return blocked + "\r\n" + MoveNorth (roomArray);
		}
	}

	public string MoveNorth (Room[,] roomArray){
		xAxis = roomArray.GetLength (0) - 1;
		yAxis = roomArray.GetLength (1) - 1;

		x = x - 1;

		if (x <= xAxis && x >= 0 && roomArray [x, y] != null) {
			if (roomArray [x, y].EntranceToNextFloor == true) {
				return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]) + "\r\n" + moveToNextFloor;
			}
			return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]);
		} else {
			return blocked + "\r\n" + MoveSouth (roomArray);
		}
	}

	public string MoveEast (Room[,] roomArray){
		xAxis = roomArray.GetLength (0) - 1;
		yAxis = roomArray.GetLength (1) - 1;

		y = y + 1;

		if (x <= xAxis && x >= 0 && roomArray [x, y] != null) {
			if (roomArray [x, y].EntranceToNextFloor == true) {
				return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]) + "\r\n" + moveToNextFloor;
			}
			return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]);
		} else {
			return blocked + "\r\n" + MoveWest (roomArray);
		}
	}

	public string MoveWest (Room[,] roomArray){
		xAxis = roomArray.GetLength (0) - 1;
		yAxis = roomArray.GetLength (1) - 1;

		y = y - 1;
		if (y <= xAxis && y >= 0 && roomArray [x, y] != null) {
			if (roomArray [x, y].EntranceToNextFloor == true) {
				return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]) + "\r\n" + moveToNextFloor;
			}
			return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]);
		} else {
			return blocked + "\r\n" + MoveEast (roomArray);
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
