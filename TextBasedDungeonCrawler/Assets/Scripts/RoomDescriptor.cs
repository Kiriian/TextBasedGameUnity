using UnityEngine;
using System.Collections.Generic;

public class RoomDescriptor : ScriptableObject {

	public RoomDescriptor ()
	{
		
	}

    string desc = "";
	List<string> roomTypes = new List<string> {
		"long, narrow hallway. ",
		"large room, where suspended cages dangle from the ceiling. ",
		"room containing workbenches. They seem to be alchemic. ",
		"nondescript room. ",
	};
	List<string> roomConstructionTypes = new List<string> {
	    "The walls are built with cobblestones. ",
		"The walls are built with brick. ",
		"The walls are built with sandstone. "
	};
	List<string> roomFurniture = new List<string> {
		"There's a large wooden table with chairs in the middle of the room. ",
		"There's a collection of pots and barrels in one of the corners. ",
		"There are sturdy-looking suits of armor lined against the walls. ",
		"The walls are adorned with tattered banners. ",
		""
	};


	public string GenerateDescription(){

		desc = "You stand in a ";
		desc = desc + roomTypes [Random.Range (0, roomTypes.Count)];
		desc = desc + roomConstructionTypes [Random.Range (0, roomConstructionTypes.Count)];
		desc = desc + roomFurniture [Random.Range (0, roomFurniture.Count)];
		return desc;
		
	}

}
