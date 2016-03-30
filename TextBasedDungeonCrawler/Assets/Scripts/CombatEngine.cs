using UnityEngine;
using System.Collections;

public class CombatEngine : ScriptableObject {

	Monster mon;

	public string Attack(Room[,] roomArr, int x, int y){

		if (roomArr[x,y].RoomMonster!=null){
			mon = roomArr [x, y].RoomMonster;
			mon.hurt (5);
			return "You hurt the enemy for 5 damage. Its health is now " + mon.currentHealth;
		} else {
			return "You swing at the air.";
		}

	}

}
