using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : Enemy {

	public Monster ()
	{
	}

	public Monster (string enemyName, int maxHealth, int maxMana) : base (enemyName, maxHealth, maxMana)
	{
	}

	public void InitTestMonster(){
		actorName = "TestMonster";
		maxHealth = 30;
		currentHealth = 30;
		maxMana = 30;
		currentMana = 30;
		strength = 4;
		defense = 2;
		chanceToHit = 5;

	}

	public void InitSpider(){
		actorName = "Spider";
		maxHealth = Mathf.Clamp(15 * Main.floorNumber/5, 15, 10000);
		currentHealth = maxHealth;
		maxMana = 0;
		currentMana = 0;
		strength = Mathf.Clamp(3 * Main.floorNumber/5, 3, 10000);
		defense = Mathf.Clamp(2 * Main.floorNumber/5, 2, 10000);
		chanceToHit = 7;
		droprate = 10;
		itemRarity = 10;

	}

	public void InitZombie(){
		actorName = "Zombie";
		maxHealth = Mathf.Clamp(30 * Main.floorNumber/5, 30, 10000);
		currentHealth = 30;
		maxMana = 0;
		currentMana = 0;
		strength = Mathf.Clamp(4 * Main.floorNumber/5, 4, 10000);
		defense = Mathf.Clamp(4 * Main.floorNumber/5, 4, 10000);
		chanceToHit = 3;
		droprate = 40;
		itemRarity = 40;
	}

	public void InitSkeleton(){
		actorName = "Skeleton";
		maxHealth = Mathf.Clamp(15 * Main.floorNumber/5, 15, 10000);
		currentHealth = 15;
		maxMana = 0;
		currentMana = 0;
		Mathf.Clamp(5 * Main.floorNumber/5, 5, 10000);
		Mathf.Clamp(3 * Main.floorNumber/5, 3, 10000);
		chanceToHit = 5;
		droprate = 20;
		itemRarity = 30;
	}

	public void InitBat()
	{
		actorName = "Bat";
		maxHealth = Mathf.Clamp(5 * Main.floorNumber/5, 5, 10000);
		currentHealth = 5;
		maxMana = 0;
		currentMana = 0;
		Mathf.Clamp(2 * Main.floorNumber/5, 2, 10000);
		Mathf.Clamp(2 * Main.floorNumber/5, 2, 10000);
		chanceToHit = 5;
		droprate = 10;
		itemRarity = 10;
	}
}
