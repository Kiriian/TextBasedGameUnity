using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Floor : MonoBehaviour {

	private Movement m;
	public Text textfield;
	private Player p;
	// Temporary for testing.
	private Monster mon;
	private Room[,] roomArray2d;
	private CombatEngine ce;
	private int x = 0; 
	private int y = 0;


	void Start () {
		p = ScriptableObject.CreateInstance<Player> ();
		p.InitTestPlayer();

		// Temporary for testing.
		mon = ScriptableObject.CreateInstance<Monster>();
		mon.InitTestMonster ();

		m = ScriptableObject.CreateInstance<Movement>();

		ce = ScriptableObject.CreateInstance<CombatEngine> ();

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

		roomArray2d = new Room[4, 2];

		roomArray2d [0, 0] = r1;
		roomArray2d [1, 0] = r2;
		roomArray2d [1, 1] = r3;
		roomArray2d [2, 0] = r4;
		roomArray2d [3, 0] = r5;

		textfield.text += roomArray2d[0, 0].Description + "\r\n" + m.Options(roomArray2d[0,0]);

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			textfield.text += "\r\n" + m.MoveSouth(roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			textfield.text += "\r\n" + m.MoveNorth(roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			textfield.text += "\r\n" + m.MoveWest(roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			textfield.text = "\r\n" + m.MoveEast(roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.I)) {
			textfield.text += "\r\n" + "The rooms contains: " + (roomArray2d [x,y].Items [0].Name);
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			roomArray2d = m.MoveToNextFloor ();
			textfield.text += "\r\n" + m.MoveSouth (roomArray2d);
		} else if (Input.GetKeyDown(KeyCode.A)){
			textfield.text += "\r\n" + ce.Attack (roomArray2d,x,y);	
		}


	}

}
	
