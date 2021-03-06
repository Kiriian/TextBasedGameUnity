﻿using UnityEngine;
using System.Collections;
using System;

public class CombatEngine : ScriptableObject {

	Monster mon;
	Boss boss;
	Equipment e;

	public string Attack(Player p, Room[,] roomArr, int x, int y){
		if (roomArr[x,y].RoomMonster!=null){
			mon = roomArr [x, y].RoomMonster;
			int monDamage = mon.hurt (Mathf.Clamp(p.strength-mon.defense, 1, 1000));
			int playerDamage = p.hurt (Mathf.Clamp(mon.strength - p.defense, 1, 1000));
			if (mon.currentHealth<=0) {
				roomArr [x, y].RoomMonster = null;
				e = mon.drops (mon.droprate, mon.itemRarity);
				if (e != null) {
					roomArr [x, y].Items.Add (e);
					return "You hurt the " + mon.actorName + " for " + monDamage + " damage. It dies and drops " + e.Name + ".";
				}
				return "You hurt the " + mon.actorName + " for " + monDamage + " damage. It dies.";
			}
			else if (p.currentHealth<=0) {
				Application.LoadLevel (2);
				return "";
			}
			return "You hurt the " + mon.actorName + " for " + monDamage + " damage. Its health is now " + mon.currentHealth + ". The " + mon.actorName + " hurts you for " + playerDamage + ".";
		} if (roomArr[x,y].RoomBoss!=null){
			boss = roomArr [x, y].RoomBoss;
			int bossDamage = boss.hurt (Mathf.Clamp(p.strength-boss.defense, 1, 1000));
			int playerDamage = p.hurt (Mathf.Clamp(boss.strength - p.defense, 1, 1000));
			if (boss.currentHealth<=0) {
				roomArr [x, y].RoomBoss = null;
				e = boss.drops (boss.droprate, boss.itemRarity);
				if (e != null) {
					roomArr [x, y].Items.Add (e);
					return "You hurt the " + boss.actorName + " for " + bossDamage + " damage. It dies and drops " + e.Name + ".";
				}
				return "You hurt the " + boss.actorName + " for " + bossDamage + " damage. It dies.";
			}
			if (p.currentHealth<=0) {
				Application.LoadLevel (2);
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
					Application.LoadLevel (2);
					return "";
				}
				return "You tried to dodge, the enemy hurts you for " + playerDamage;
			} else if (mon.chanceToHit == p.chanceToDodge) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 5) {
					return "You dodge the enemy";
				} else{
					int playerDamage = p.hurt (mon.strength - p.defense);
					if (p.currentHealth<=0) {
						Application.LoadLevel (2);
						return "";
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
					Application.LoadLevel (2);
					return "";
				}
				return "You tried to dodge, the enemy hurts you for " + playerDamage;
			} else if (boss.chanceToHit == p.chanceToDodge) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 5) {
					return "You dodge the enemy";
				} else{
					int playerDamage = p.hurt (boss.strength - p.defense);
					if (p.currentHealth<=0) {
						Application.LoadLevel (2);
						return "";
					}
					return "You tried to dodge, the enemy hurts you for " + playerDamage;
				}
			}
		}
		return "You roll across the floor";
	}

}
 