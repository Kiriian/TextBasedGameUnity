using UnityEngine;
using System.Collections;

public class Boss : Enemy {

	public Boss ()
	{
	}

	public Boss (string enemyName, int maxHealth, int maxMana) : base (enemyName, maxHealth, maxMana)
	{
	}

	public void Golem(){
		actorName = "Golem";
		maxHealth = Mathf.Clamp(50 * Main.floorNumber/5, 50, 10000);
		currentHealth = 30;
		maxMana = 0;
		currentMana = 0;
		chanceToHit = 8;
		strength = Mathf.Clamp(7 * Main.floorNumber/5, 7, 10000);
		defense = Mathf.Clamp(5 * Main.floorNumber/5, 5, 10000); 
		droprate = 100;
		itemRarity = 100;
	}

	public void ScaryGhost(){
		actorName = "Ghost";
		maxHealth = Mathf.Clamp(30 * Main.floorNumber/5, 30, 10000);
		currentHealth = 25;
		maxMana = 0;
		currentMana = 0;
		chanceToHit = 10;
		strength = Mathf.Clamp(11 * Main.floorNumber/5, 11, 10000);
		defense = Mathf.Clamp(6 * Main.floorNumber/5, 6, 10000);
		droprate = 100;
		itemRarity = 100;
	}

}
