using UnityEngine;
using System.Collections;

public class Floor : ScriptableObject {

	// Temporary for testing.
	private Monster mon;
	private Boss boss;
	private Room[,] roomArray2d;

	public Room[,] Floor1(){

		// Temporary for testing.
		mon = ScriptableObject.CreateInstance<Monster>();
		mon.InitSpider ();

		boss = ScriptableObject.CreateInstance<Boss>();
		boss.Golem ();

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
		r1.RoomMonster = mon;

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
		r5.RoomBoss = boss;

		roomArray2d = new Room[4, 2];

		roomArray2d [0, 0] = r1;
		roomArray2d [1, 0] = r2;
		roomArray2d [1, 1] = r3;
		roomArray2d [2, 0] = r4;
		roomArray2d [3, 0] = r5;

		// Comment out all code above and uncomment the two following lines to enable floor generation.


		FloorGenerator fg = ScriptableObject.CreateInstance<FloorGenerator> ();
		roomArray2d = fg.GenerateFloor ();

		return roomArray2d;
	}


	public Room[,] Floor2 (Movement m)
	{
		m.xCoordinate = 0;
		m.yCoordinate = 1;

		Direction north = ScriptableObject.CreateInstance<Direction> ();
		north.DirectionName = "North";
		Direction south = ScriptableObject.CreateInstance<Direction> ();
		south.DirectionName = "South";
		Direction west = ScriptableObject.CreateInstance<Direction> ();
		west.DirectionName = "West";
		Direction east = ScriptableObject.CreateInstance<Direction> ();
		east.DirectionName = "East";

		Room r1 = ScriptableObject.CreateInstance<Room>();
		r1.Description = "A Round Room with a Broken Chandelier in the Middle of the Room";
		r1.Directions.Add (south);
		r1.Directions.Add (east);

		Room r2 = ScriptableObject.CreateInstance<Room>();
		r2.Description = "A small Room with Broken Funiture in the Corners";
		r2.Directions.Add (west);
		r2.Directions.Add (south);

		Room r3 = ScriptableObject.CreateInstance<Room>();
		r3.Description = "A room with where most of the celling is carved in";
		r3.Directions.Add (north);
		r3.Directions.Add (east);

		Room r4 = ScriptableObject.CreateInstance<Room>();
		r4.Description = "A bigger room with armors along the South Wall, most are missing pieces";
		r4.Directions.Add (west);
		r4.Directions.Add (east);

		Room r5 = ScriptableObject.CreateInstance<Room>();
		r5.Description = "A Medium Sized Room with Empty Frames";
		r5.Directions.Add (south);
		r5.Directions.Add (west);

		Room r6 = ScriptableObject.CreateInstance<Room>();
		r6.Description = "A Hallway with stairs leading further down";
		r6.Directions.Add (north);
		r6.EntranceToNextFloor = true;

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
