using UnityEngine;
using System.Collections;

public class CombatEngine : ScriptableObject {

	Monster mon;
	Boss boss;

	public string Attack(Player p, Room[,] roomArr, int x, int y){
		if (roomArr[x,y].RoomMonster!=null){
			mon = roomArr [x, y].RoomMonster;
<<<<<<< HEAD
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
=======
			mon.hurt (5);
			return "You hurt the enemy for 5 damage. Its health is now " + mon.currentHealth;
		} else if (roomArr [x, y].RoomBoss != null) {
			boss = roomArr [x, y].RoomBoss;
			boss.hurt (5);
			return "You hurt the enemy for 5 damage. Its health is now " + boss.currentHealth;
		}else {
>>>>>>> ....
			return "You swing at the air.";
		}
	}

	public string Dodge(Room[,] roomArr, int x, int y)
	{
		if (roomArr[x,y].RoomMonster!=null){
			mon = roomArr [x, y].RoomMonster;

			return "You dodge the enemy " + mon.currentHealth;
		} else if (roomArr [x, y].RoomBoss != null) {
			boss = roomArr [x, y].RoomBoss;
			return "You dodge the enemy " + boss.currentHealth;
		}else {
			return "You roll across the floor, nothing happend";
		}
	}

}
 