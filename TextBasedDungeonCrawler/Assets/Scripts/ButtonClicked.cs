using UnityEngine;
using System.Collections;

public class ButtonClicked : ScriptableObject {
	
	private Room r;
	private int currentX;
	private int currentY;

	public void CheckButtonPressed (Room[,] roomArray, Movement m, Main main, int id, CombatEngine ce, Player p, Map map)
	{
		switch (id) {
		case 0:
			currentX = m.x;
			currentY = m.y;
			r = m.MoveNorth (roomArray);
			main.setMoveText (r);
			map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
			break;
		case 1:
			currentX = m.x;
			currentY = m.y;
			r = m.MoveSouth (roomArray);
			main.setMoveText (r);
			map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
			break;
		case 2:
			currentX = m.x;
			currentY = m.y;
			r = m.MoveEast (roomArray);
			main.setMoveText (r);
			map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
			break;
		case 3:
			currentX = m.x;
			currentY = m.y;
			r = m.MoveWest (roomArray);
			main.setMoveText (r);
			map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
			break;
		case 4:
			main.setLootText (m, roomArray);
			break;
		case 5:
			main.MoveNextFloor(m.getCurrentRoom(roomArray),map,m);
			break;
		case 6:
			main.setAttackCombatText (ce, roomArray, p, m);
			break;
		case 7:
			main.setPickUpLootText (m, p, m.getCurrentRoom(roomArray));
			break;
		case 8:
			main.setInventoryText (p, r);
			break;
		case 9:
			main.setDodgeCombatText (ce, roomArray, p, m);
			break;
		case 10:
			main.setUseHealingPotionText (p);
			break;
		case 11:
			main.SaveGame ();
			break;
		case 12:
			main.LoadGame ();
			break;
		}
	}

}
