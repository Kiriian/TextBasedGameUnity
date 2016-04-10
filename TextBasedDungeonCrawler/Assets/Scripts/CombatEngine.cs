using UnityEngine;
using System.Collections;

public class CombatEngine : ScriptableObject {

	Monster mon;

	public string Attack(Player p, Room[,] roomArr, int x, int y){
		if (roomArr[x,y].RoomMonster!=null){
			mon = roomArr [x, y].RoomMonster;
			int monDamage = mon.hurt (p.strength-mon.defense);
			if (mon.currentHealth<=0) {
				roomArr [x, y].RoomMonster = null;
				return "You hurt the enemy for " + monDamage + " damage. It dies.";
			}
			int playerDamage = p.hurt (mon.strength - p.defense);
			if (p.currentHealth<=0) {
				// Implement a game-over function for this.
				return "You die.";
			}
			return "You hurt the enemy for " + monDamage + " damage. Its health is now " + mon.currentHealth + ". The enemy hurts you for " + playerDamage + ".";
		} else {
			return "You swing at the air.";
		}

	}

}
 