using UnityEngine;
using System.Collections;

public class ButtonClicked : ScriptableObject {
	private Room r;

	public void CheckButtonPressed (Room[,] roomArray, Movement m, Main main, int id, CombatEngine ce, Player p)
	{
		switch (id) {
		case 0:
			r = m.MoveNorth (roomArray);
			main.setText (r);
			break;
		case 1:
			r = m.MoveSouth (roomArray);
			main.setText (r);
			break;
		case 2:
			r = m.MoveEast (roomArray);
			main.setText (r);
			break;
		case 3:
			r = m.MoveWest (roomArray);
			main.setText (r);
			break;
		case 4:
			main.setLootText (m, roomArray);
			break;
		case 5:
			//move To next floor
			break;
		case 6:
			main.setAttackCombatText (ce, roomArray, p, m);
			break;
		case 7:
			main.setPickUpLootText (m, p);
			break;
		case 8:
			main.setInventoryText (p);
			break;
		case 9:
			main.setDodgeCombatText (ce, roomArray, p, m);
			break;
		case 10:
			main.setUseHealingPotionText (p);
			break;
		}
	}

}
