using UnityEngine;
using System.Collections;
using System;

public class CombatEngine : ScriptableObject {

	Monster mon;
	Boss boss;

	public string Attack(Player p, Room[,] roomArr, int x, int y){
		if (roomArr[x,y].RoomMonster!=null){
			mon = roomArr [x, y].RoomMonster;
			int monDamage = mon.hurt (p.strength-mon.defense);
			int playerDamage = p.hurt (mon.strength - p.defense);
			if (mon.currentHealth<=0) {
				roomArr [x, y].RoomMonster = null;
				return "You hurt the " + mon.actorName + " for " + monDamage + " damage. It dies.";
			}
			else if (p.currentHealth<=0) {
				Application.LoadLevel (0);
				return "";
			}
			return "You hurt the " + mon.actorName + " for " + monDamage + " damage. Its health is now " + mon.currentHealth + ". The " + mon.actorName + " hurts you for " + playerDamage + ".";
		} if (roomArr[x,y].RoomBoss!=null){
			boss = roomArr [x, y].RoomBoss;
			int bossDamage = boss.hurt (p.strength-boss.defense);
			int playerDamage = p.hurt (boss.strength - p.defense);
			if (boss.currentHealth<=0) {
				roomArr [x, y].RoomBoss = null;
				return "You hurt the " + boss.actorName + " for " + bossDamage + " damage. It dies.";
			}
			if (p.currentHealth<=0) {
				Application.LoadLevel (0);
				return "";
			}
			return "You hurt the " + boss.actorName + " for " + bossDamage + " damage. Its health is now " + boss.currentHealth + ". The " + boss.actorName + " hurts you for " + playerDamage + ".";
		} else {
			return "You swing at the air.";
		}
	}

	public string Dodge(Player p, Room[,] roomArr, int x, int y)
	{
		if (roomArr[x,y].RoomMonster!=null){
			mon = roomArr [x, y].RoomMonster;
			if (mon.chanceToHit < p.chanceToDodge) {
				return "You dodge the enemy";
			} else if (mon.chanceToHit > p.chanceToDodge) {
				int playerDamage = p.hurt (mon.strength - p.defense);
				if (p.currentHealth<=0) {
					// Implement a game-over function for this.
					return "You die.";
				}
				return "You tried to dodge, the enemy hurts you for " + playerDamage;
			} else if (mon.chanceToHit == p.chanceToDodge) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= p.chanceToDodge) {
					return "You dodge the enemy";
				} else{
					int playerDamage = p.hurt (mon.strength - p.defense);
					if (p.currentHealth<=0) {
						// Implement a game-over function for this.
						return "You die.";
					}
					return "You tried to dodge, the enemy hurts you for " + playerDamage;
				}
			}
		}
		if (roomArr[x,y].RoomBoss!=null){
			boss = roomArr [x, y].RoomBoss;
			if (boss.chanceToHit < p.chanceToDodge) {
				return "You dodge the enemy";
			} else if (boss.chanceToHit > p.chanceToDodge) {
				int playerDamage = p.hurt (boss.strength - p.defense);
				if (p.currentHealth<=0) {
					// Implement a game-over function for this.
					return "You die.";
				}
				return "You tried to dodge, the enemy hurts you for " + playerDamage;
			} else if (boss.chanceToHit == p.chanceToDodge) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= p.chanceToDodge) {
					return "You dodge the enemy";
				} else{
					int playerDamage = p.hurt (boss.strength - p.defense);
					if (p.currentHealth<=0) {
						// Implement a game-over function for this.
						return "You die.";
					}
					return "You tried to dodge, the enemy hurts you for " + playerDamage;
				}
			}
		}
		return "You roll across the floor";
	}

}
 