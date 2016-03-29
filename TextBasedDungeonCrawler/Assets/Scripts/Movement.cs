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

		if (x <= xAxis && x >= 0 && roomArray [x, y] != null) {
			if (roomArray [x, y].EntranceToNextFloor == true) {
				return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]) + "\r\n" + moveToNextFloor;
			}
			return roomArray [x, y].Description + "\r\n" + Options (roomArray [x, y]);
		} else {
			return blocked + "\r\n" + MoveEast (roomArray);
		}
	}

	public string Options (Room r)
	{
		string availableDirections = "You can move: ";

		foreach (Direction d in r.Directions) {
			availableDirections += d.DirectionName + ", ";
		}
		return availableDirections;
	}

	public Room[,] MoveToNextFloor ()
	{
		x = -1;
		y = 0;

		Room r1 = ScriptableObject.CreateInstance<Room>();
		r1.Description = "A Round Room with a Broken Chandelier in the Middle of the Room";

		Room r2 = ScriptableObject.CreateInstance<Room>();
		r2.Description = "A small Room with Broken Funiture in the Corners";

		Room r3 = ScriptableObject.CreateInstance<Room>();
		r3.Description = "A room with where most of the celling is carved in";

		Room r4 = ScriptableObject.CreateInstance<Room>();
		r4.Description = "A bigger room with armors along the South Wall, most are missing pieces";

		Room r5 = ScriptableObject.CreateInstance<Room>();
		r5.Description = "A Medium Sized Room with Empty Frames";

		Room r6 = ScriptableObject.CreateInstance<Room>();
		r6.Description = "A Hallway with stairs leading further down";
		r5.EntranceToNextFloor = true;

		Room[,] roomArray2d = new Room[3, 3];

		roomArray2d [0, 0] = r1;
		roomArray2d [0, 1] = r2;
		roomArray2d [1, 0] = r3;
		roomArray2d [1, 1] = r4;
		roomArray2d [1, 2] = r5;
		roomArray2d [2, 2] = r6;

		return roomArray2d;
	}
}
