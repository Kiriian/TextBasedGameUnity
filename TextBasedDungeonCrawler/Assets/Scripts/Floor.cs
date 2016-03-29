using UnityEngine;
using System.Collections;
using WindowsInput;

public class Floor : MonoBehaviour {

	private Movement m;
	private Room[,] roomArray2d;
	private int x = 0; 
	private int y = 0;
	private int xAxis;
	private int yAxis;


	void Start () {

		m = ScriptableObject.CreateInstance<Movement>();

		Direction north = ScriptableObject.CreateInstance<Direction> ();
		north.DirectionName = "North";
		Direction south = ScriptableObject.CreateInstance<Direction> ();
		south.DirectionName = "South";
		Direction west = ScriptableObject.CreateInstance<Direction> ();
		west.DirectionName = "West";
		Direction east = ScriptableObject.CreateInstance<Direction> ();
		east.DirectionName = "East";


		Room r1 = ScriptableObject.CreateInstance<Room>();
		r1.Description = "Starting room";
		HealingPotion pot = ScriptableObject.CreateInstance<HealingPotion>();
		pot.name = "Healing Potion";
		r1.Items.Add (pot);
		r1.Directions.Add (south);


		Room r2 = ScriptableObject.CreateInstance<Room>();
		r2.Description = "A Narrow Hallway with some Unburned Torchs";
		r2.Directions.Add (south);
		r2.Directions.Add (north);
		r2.Directions.Add (east);


		Room r3 =  ScriptableObject.CreateInstance<Room>();
		r3.Description = "A Long Room with Cages Dangeling from the Celling";
		r3.Directions.Add (west);

		Room r4 =  ScriptableObject.CreateInstance<Room>();
		r4.Description = "A Room with Alchemy Workbenches";
		r4.Directions.Add (north);
		r4.Directions.Add (south);


		Room r5 =  ScriptableObject.CreateInstance<Room>();
		r5.Description = "A Big Room with a Giant Golem in the Middle";
		r5.EntranceToNextFloor = true;
		r5.Directions.Add (north);

		roomArray2d = new Room[4, 2];

		roomArray2d [0, 0] = r1;
		roomArray2d [1, 0] = r2;
		roomArray2d [1, 1] = r3;
		roomArray2d [2, 0] = r4;
		roomArray2d [3, 0] = r5;

		print (roomArray2d [0, 0].Description + " " + m.Options(roomArray2d[0,0]));
	}

	void Update()
	{
		xAxis = roomArray2d.GetLength (0)-1;
		yAxis = roomArray2d.GetLength (1)-1;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			print (m.MoveSouth(roomArray2d));
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			print (m.MoveNorth(roomArray2d));
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			print (m.MoveWest(roomArray2d));
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			print (m.MoveEast(roomArray2d));
		} else if (Input.GetKeyDown (KeyCode.I)) {
			print ("The rooms contains: " + (roomArray2d [x, y].Items [0].Name));
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			roomArray2d = m.MoveToNextFloor ();
			print (m.MoveSouth (roomArray2d));
		}


	}
}
	
