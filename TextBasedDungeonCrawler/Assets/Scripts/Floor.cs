using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	private Room[,] roomArray2d;
	private int x = 0; 
	private int y = 0;
	private int xAxis;
	private int yAxis;


	void Start () {

		print ("Hey");

		Room r1 = ScriptableObject.CreateInstance<Room>();
		r1.Description = "Starting room";
		r1.EntranceToPreviousFloor = true;
		HealingPotion pot = ScriptableObject.CreateInstance<HealingPotion>();
		pot.name = "Healing Potion";
		r1.Items.Add (pot);

		Room r2 = ScriptableObject.CreateInstance<Room>();

		r2.Description = "A Narrow Hallway with some Unburned Torchs";
		r2.Loot = true;

		Room r3 =  ScriptableObject.CreateInstance<Room>();
		r3.Description = "A Long Room with Cages Dangeling from the Celling";


		Room r4 =  ScriptableObject.CreateInstance<Room>();
		r4.Description = "A Room with Alchemy Workbenches";

		Room r5 =  ScriptableObject.CreateInstance<Room>();
		r5.Description = "A Big Room with a Giant Golem in the Middle";
		r5.BossRoom = true;

		roomArray2d = new Room[4, 2];

		roomArray2d [0, 0] = r1;
		roomArray2d [1, 0] = r2;
		roomArray2d [1, 1] = r3;
		roomArray2d [2, 0] = r4;
		roomArray2d [3, 0] = r5;


//		for (int i = 0; i < roomArray2d.GetLength (0); i++) {
//			for (int j = 0; j < roomArray2d.GetLength (1); j++) {
//				if (roomArray2d [i, j] != null) {
//					print (roomArray2d [i, j].Description);
//				}
//			}
//		}

		print(roomArray2d[0,0].Description);

	}

	void Update()
	{
		xAxis = roomArray2d.GetLength (0)-1;
		yAxis = roomArray2d.GetLength (1)-1;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			x = x + 1;
			if (x <= xAxis && x >= 0 && roomArray2d[x, y] != null) {
					print (roomArray2d [x, y].Description);
			} else {
				x = x - 1;
				print ("That way is blocked");
				print (roomArray2d [x, y].Description);
			}
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			x = x - 1;
			if (x <= xAxis && x >= 0 && roomArray2d[x, y] != null) {
				print (roomArray2d [x, y].Description);
			} else {
				x = x + 1;
				print ("That way is blocked");
				print (roomArray2d [x, y].Description);
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			y = y + 1;
			if (y <= yAxis && y >= 0 && roomArray2d[x, y] != null){
				print (roomArray2d [x, y].Description);
			} else {
				y = y - 1;
				print ("That way is blocked");
				print (roomArray2d [x, y].Description);
			}
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			y = y - 1;
			if (y <= yAxis && y >= 0 && roomArray2d[x, y] != null) {
				print (roomArray2d [x, y].Description);
			} else {
				y = y + 1;
				print ("That way is blocked");
				print (roomArray2d [x, y].Description);
			}
		}
		else if (Input.GetKeyDown (KeyCode.I)) {
			print ("The rooms contains: " + (roomArray2d [x, y].Items[0].Name));
		}

	}

}
	
