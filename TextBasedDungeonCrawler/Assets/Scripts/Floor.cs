using UnityEngine;
using System.Collections;
using WindowsInput;

public class Floor : MonoBehaviour {

	private Room[,] roomArray2d;
	private int x = 0; 
	private int y = 0;
	private int xAxis;
	private int yAxis;


	void Start () {

		Room r1 = ScriptableObject.CreateInstance<Room>();
		r1.Description = "Starting room";
		HealingPotion pot = ScriptableObject.CreateInstance<HealingPotion>();
		pot.name = "Healing Potion";
		r1.Items.Add (pot);
		r1.South = true;

		Room r2 = ScriptableObject.CreateInstance<Room>();
		r2.Description = "A Narrow Hallway with some Unburned Torchs";
		r2.South = true;
		r2.North = true;
		r2.East = true;

		Room r3 =  ScriptableObject.CreateInstance<Room>();
		r3.Description = "A Long Room with Cages Dangeling from the Celling";
		r3.West = true;

		Room r4 =  ScriptableObject.CreateInstance<Room>();
		r4.Description = "A Room with Alchemy Workbenches";
		r4.North = true;
		r4.South = true;

		Room r5 =  ScriptableObject.CreateInstance<Room>();
		r5.Description = "A Big Room with a Giant Golem in the Middle";
		r5.EntranceToNextFloor = true;
		r5.North = true;

		roomArray2d = new Room[4, 2];

		roomArray2d [0, 0] = r1;
		roomArray2d [1, 0] = r2;
		roomArray2d [1, 1] = r3;
		roomArray2d [2, 0] = r4;
		roomArray2d [3, 0] = r5;

		print (roomArray2d [0, 0].Description);
		Options (roomArray2d [0, 0]);

	}

	void Update()
	{
		xAxis = roomArray2d.GetLength (0)-1;
		yAxis = roomArray2d.GetLength (1)-1;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			x = x + 1;
			if (x <= xAxis && x >= 0 && roomArray2d [x, y] != null) {
				print (roomArray2d [x, y].Description);
				Options (roomArray2d [x, y]);
				if (roomArray2d [x, y].EntranceToNextFloor == true) {
					print ("Move to next floor?");

				}
			} else {
				print ("That way is blocked");
				InputSimulator.SimulateKeyDown (VirtualKeyCode.UP);
			}
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			x = x - 1;
			if (x <= xAxis && x >= 0 && roomArray2d [x, y] != null) {
				print (roomArray2d [x, y].Description);
				Options (roomArray2d [x, y]);
				if (roomArray2d [x, y].EntranceToNextFloor == true) {
					print ("Move to next floor?");
				}
			} else {
				print ("That way is blocked");
				InputSimulator.SimulateKeyDown (VirtualKeyCode.DOWN);
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			y = y + 1;
			if (y <= yAxis && y >= 0 && roomArray2d [x, y] != null) {
				print (roomArray2d [x, y].Description);
				Options (roomArray2d [x, y]);
				if (roomArray2d [x, y].EntranceToNextFloor == true) {
					print ("Move to next floor?");
				}
			} else {
				print ("That way is blocked");
				InputSimulator.SimulateKeyDown (VirtualKeyCode.LEFT);
			}
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			y = y - 1;
			if (y <= yAxis && y >= 0 && roomArray2d [x, y] != null) {
				print (roomArray2d [x, y].Description);
				Options (roomArray2d [x, y]);
				if (roomArray2d [x, y].EntranceToNextFloor == true) {
					print ("Move to next floor?");
				}
			} else {
				print ("That way is blocked");
				InputSimulator.SimulateKeyDown (VirtualKeyCode.RIGHT);
			}
		} else if (Input.GetKeyDown (KeyCode.I)) {
			print ("The rooms contains: " + (roomArray2d [x, y].Items [0].Name));
		} else if (Input.GetKeyDown (KeyCode.Space) && roomArray2d[x,y].EntranceToNextFloor == true) {
			floor2();
		}


	}

	public void Options(Room r)
	{
		if (r.North == true ) {
			print ("You can move North");
		}
		if (r.South == true) {
			print ("You can move South");
		}
		if (r.East == true) {
			print ("You can move East");
		}
		if (r.West == true) {
			print ("You can move West");
		}
	}
		

	public void floor2()
	{
		Room r1 = ScriptableObject.CreateInstance<Room>();
		r1.Description = "A Round Room with a Broken Chandelier in the Middle of the Room";
		r1.South = true;
		r1.East = true;

		Room r2 = ScriptableObject.CreateInstance<Room>();
		r2.Description = "A small Room with Broken Funiture in the Corners";
		r2.South = true;
		r2.West = true;

		Room r3 = ScriptableObject.CreateInstance<Room>();
		r3.Description = "A room with where most of the celling is carved in";
		r3.North = true;
		r3.East = true;

		Room r4 = ScriptableObject.CreateInstance<Room>();
		r4.Description = "A bigger room with armors along the South Wall, most are missing pieces";
		r4.South = true;
		r4.East = true;
		r4.West = true;

		Room r5 = ScriptableObject.CreateInstance<Room>();
		r5.Description = "A Medium Sized Room with Empty Frames";
		r5.South = true;
		r5.North = true;
		r5.East = true;

		Room r6 = ScriptableObject.CreateInstance<Room>();
		r6.Description = "A Hallway with stairs leading further down";
		r6.South = true;
		r6.North = true;
		r6.East = true;
		r5.EntranceToNextFloor = true;

		roomArray2d = new Room[3, 3];

		roomArray2d [0, 0] = r1;
		roomArray2d [0, 1] = r2;
		roomArray2d [1, 0] = r3;
		roomArray2d [1, 1] = r4;
		roomArray2d [1, 2] = r5;
		roomArray2d [2, 2] = r6;

		print (roomArray2d [0, 0].Description);
		Options (roomArray2d [0, 0]);
	}
}
	
