using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class FloorGenerator : ScriptableObject
{

	private Monster mon;
	private int[] coords = { 0, 0 };
	private Room[,] roomArray2d;
	private Item item;
	private List<Direction> directions = new List<Direction> ();
//	private string[] descriptions = {
//		"A narrow hallway with some unburned torches.",
//		"A long room with cages dangling from the ceiling.",
//		"A room containing alchemy workbenches.",
//		"A nondescript cobblestone room."
//	};
	private bool bossRoom;
	private int amountOfGeneratedRooms;
	private int xCoord;
	private int yCoord;


	/// <summary>
	/// Generates a new 5x5 floor. Starting point will always be 0,0.
	/// </summary>
	/// <returns>A Room[,] array, containing a fully-generated floor.</returns>
	public Room[,] GenerateFloor ()
	{

		ResetAttributes ();
		int[] coords;
		// Generates new rooms until fifteen rooms have been created. Hard limit for testing, probably will insert a randomly-generated hard cap later.
		do {
			coords = DecideNextRoom ();
			GenerateRoom (coords [0], coords [1]);
		} while (amountOfGeneratedRooms < 15);
		// Runs a method that adds Direction objects to every room, allowing the player to see which ways they can go in any given room.
		AddDirections ();
		AddEnemies ();
		AddStairs ();
		AddItems ();

		return roomArray2d;

	}

	/// <summary>
	/// Generates a new room.
	/// </summary>
	/// <returns>A Room object.</returns>
	private void GenerateRoom (int x, int y)
	{
		Room r = ScriptableObject.CreateInstance<Room> ();
		RoomDescriptor rd = ScriptableObject.CreateInstance<RoomDescriptor> ();
		r.Description = rd.GenerateDescription ();

		roomArray2d [x, y] = r;

		amountOfGeneratedRooms++;
	}

	/// <summary>
	/// Adds stairs down to the next floor.
	/// </summary>
	private void AddStairs ()
	{

		int x = 0;
		int y = 0;
		int counter = 0;
		bool searchingForCoord = true;

		while (searchingForCoord) {
			if (counter % 2 == 0) {
				x = 4;
				y = Random.Range (0, 4);
			} else {
				x = Random.Range (0, 4);
				y = 4;
			}
			counter++;

			if (roomArray2d [x, y] != null) {
				roomArray2d [x, y].EntranceToNextFloor = true;
				AddBoss (x, y);
				searchingForCoord = false;
				break;
			}

			if (counter > 10) {
				if (counter % 2 == 0) {
					x = 3;
					y = Random.Range (0, 4);
				} else {
					x = Random.Range (0, 4);
					y = 3;
				}
				if (roomArray2d [x, y] != null) {
					roomArray2d [x, y].EntranceToNextFloor = true;
					AddBoss (x, y);
					searchingForCoord = false;
				}
			}
		}
	}

	private void AddBoss (int x, int y){
		roomArray2d [x, y].RoomBoss = ScriptableObject.CreateInstance<Boss> ();
		int i = Random.Range (0, 1);
		if (i==0) {
			roomArray2d [x, y].RoomBoss.Golem ();
		} else {
			roomArray2d [x, y].RoomBoss.ScaryGhost ();
		}

	}

	/// <summary>
	/// Adds enemies to several rooms on the floor. Randomized entirely
	/// Should perhaps be set up so that it takes into account the amount of monsters that are already present, allowing us to make sure that we do not end up with an entire floor filled with monsters, or entirely empty, by pure luck.
	/// </summary>
	private void AddEnemies ()
	{

		// Could be made a little more sleek with the use of method reflection, but performance would likely suffer for insufficient gain.
		// More desirable tactic if we were to have a much larger bestiary, and were expecting to add more enemies over a longer dev cycle.

		foreach (var r in roomArray2d) {
			if (r != null) {
				int rand = Random.Range (0, 15);

				if (rand > 11 && r.RoomBoss == null) {
					mon = ScriptableObject.CreateInstance<Monster> ();
					rand = Random.Range (1, 4);
					switch (rand) {
					case 1:
						mon.InitBat ();
						break;
					case 2:
						mon.InitSkeleton ();
						break;
					case 3:
						mon.InitSpider ();
						break;
					case 4:
						mon.InitZombie ();
						break;
					}
					r.RoomMonster = mon;
				}
			}
		}
	}

	/// <summary>
	/// Takes the entire generated floor and adds directions to every room, so you know where you can go.
	/// </summary>
	private void AddDirections ()
	{

		// NOTE: Directions are inverted, due to how the 2D array is structured and read from, functionally reversing the roles of the X and Y axes. Could be fixed, but we have enough other stuff to figure out for that to be a priority.

		Direction north = ScriptableObject.CreateInstance<Direction> ();
		north.DirectionName = "North";
		Direction south = ScriptableObject.CreateInstance<Direction> ();
		south.DirectionName = "South";
		Direction west = ScriptableObject.CreateInstance<Direction> ();
		west.DirectionName = "West";
		Direction east = ScriptableObject.CreateInstance<Direction> ();
		east.DirectionName = "East";

		int x = 0;
		int y = 0;

		// Checks every position in the array for if there is a room present, and then checks the neighboring coordinates for if there's any rooms adjacent.
		// Uses Clamp to make sure we stay within the bounds of the array. The second argument parameter in every 'if' is to make sure that the argument doesn't check whether itself exists when facing a border in the array, due to clamping.
		foreach (var r in roomArray2d) {
			if (r != null) {
				if (roomArray2d [Mathf.Clamp (x + 1, 0, 4), y] != null && Mathf.Clamp (x + 1, 0, 4) != x) {
					r.Directions.Add (south);
				}
				if (roomArray2d [Mathf.Clamp (x - 1, 0, 4), y] != null && Mathf.Clamp (x - 1, 0, 4) != x) {
					r.Directions.Add (north);
				}
				if (roomArray2d [x, Mathf.Clamp (y + 1, 0, 4)] != null && Mathf.Clamp (y + 1, 0, 4) != y) {
					r.Directions.Add (east);
				}
				if (roomArray2d [x, Mathf.Clamp (y - 1, 0, 4)] != null && Mathf.Clamp (y - 1, 0, 4) != y) {
					r.Directions.Add (west);
				}

			}
			//X and Y coordinates used to check every position. Checks along an entire horizontal line, then moves down one vertical line and repeats. 
			y++;
			if (y == 5) {
				y = 0;
				x++;
			}
		}
	}

	/// <summary>
	/// Adds items to the generated floor.
	/// </summary>
	private void AddItems ()
	{

		// TODO: Make it so there's more than equipment being added to loot tables.
		// Need to make it so that it's items in general, not just equipment.

		// Instantiates a new piece of equipment.
		Equipment equip = ScriptableObject.CreateInstance<Equipment>();
		// Using Reflection to get all methods in Equipment.
		System.Type t = typeof(Equipment);
		MethodInfo[] allMethods = t.GetMethods ();
		List<MethodInfo> equipmentMethods = new List<MethodInfo> ();

		// Getting all methods with the EquipmentModifier attribute, so we're sure we only get the right methods.
		foreach (var method in allMethods) {
			// Gets all attributes for the given method in the loop.
			foreach (System.Attribute attr in PropertyAttribute.GetCustomAttributes(method)) {
				// Checks if it contains the EquipmentModifier attribute.
				if (attr.GetType()==typeof(EquipmentModifier)){
					equipmentMethods.Add (method);
				}
			}
		}

		// Runs through every room on a floor, and through RNG, determines if there should be items, and which item it puts there.
		foreach (var r in roomArray2d) {
			if (r != null) {
				int rand = Random.Range (0, 20);
				if (rand > 15) {
					int c = equipmentMethods.Count;
					equipmentMethods [Random.Range (0, c)].Invoke (equip, null);
					r.Items.Add (equip);
				}
			}
		}	
		
	}

	/// <summary>
	/// Resets the generation attributes so that a new floor can be fully generated.
	/// </summary>
	private void ResetAttributes ()
	{
		amountOfGeneratedRooms = 0;
		roomArray2d = new Room[5, 5];
		mon = null;
		item = null;
		bossRoom = false;
	}
		

	/// <summary>
	/// Determines where in the 2D array the next room will be generated by returning a pair of coordinates.
	/// </summary>
	/// <returns>An int[] array containing two integers, meant as coordinates for the next room to be generated within.</returns>
	private int[] DecideNextRoom ()
	{
		// Making extensive use of the Unity Mathf API's Clamp method to make sure we do not go out of the array's bounds.

		// Returns 0 and 0 as coordinates if no room has been generated yet, making sure we always have a room at 0,0 to start from.
		// TODO: Make it so that the starting room is randomly chosen, instead of just always put at 0,0. Would require reworking of the Movement mechanic, as it places the player at 0,0 by default.
		// Perhaps introduce a StartPoint int[] variable to denote where the player starts on a given floor?
		if (roomArray2d [0, 0] == null) {
			coords [0] = 0;
			coords [1] = 0;
			amountOfGeneratedRooms++;
			return coords;
		} else {
			bool searchingForCoord = true;
			do {
				// Hardcoded range given that we are currently only creating 5x5 floors. Would be assigned a dynamic variable, such as the arrays length, if we were to have differing sizes of floors.
				xCoord = Random.Range (0, 5);
				yCoord = Random.Range (0, 5);
				// Checks if the coord is an empty spot.
				if (roomArray2d [xCoord, yCoord] == null) {
					// Checks if there are any rooms adjacent to the chosen empty spot.
					if (roomArray2d [Mathf.Clamp (xCoord + 1, 0, 4), yCoord] == null && roomArray2d [Mathf.Clamp (xCoord - 1, 0, 4), yCoord] == null && roomArray2d [xCoord, Mathf.Clamp (yCoord + 1, 0, 4)] == null && roomArray2d [xCoord, Mathf.Clamp (yCoord - 1, 0, 4)] == null) {
						// Restarts the loop, as the Random generator has chosen a coordinate with no adjacent rooms.
						continue;
					} else {
						searchingForCoord = false;
					}
				}
			} while(searchingForCoord);
				

			coords [0] = xCoord;
			coords [1] = yCoord;

			return coords;
		}
	}

}
