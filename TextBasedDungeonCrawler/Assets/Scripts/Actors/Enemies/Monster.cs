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
		maxHealth = 15;
		currentHealth = maxHealth;
		maxMana = 0;
		currentMana = 0;
		strength = 2;
		defense = 1;
		chanceToHit = 7;
		droprate = 100;
		itemRarity = 10;

	}

	public void InitZombie(){
		actorName = "Zombie";
		maxHealth = 30;
		currentHealth = 30;
		maxMana = 0;
		currentMana = 0;
		strength = 4;
		defense = 4;
		chanceToHit = 3;
		droprate = 100;
		itemRarity = 20;
	}

	public void InitSkeleton(){
		actorName = "Skeleton";
		maxHealth = 15;
		currentHealth = 15;
		maxMana = 0;
		currentMana = 0;
		strength = 4;
		defense = 1;
		chanceToHit = 5;
		droprate = 100;
		itemRarity = 20;
	}

	public void InitBat()
	{
		actorName = "Bat";
		maxHealth = 5;
		currentHealth = 5;
		maxMana = 0;
		currentMana = 0;
		strength = 4;
		defense = 1;
		chanceToHit = 5;
		droprate = 100;
		itemRarity = 10;
	}
}
