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
		maxHealth = 50;
		currentHealth = 50;
		maxMana = 0;
		currentMana = 0;
		chanceToHit = 8;
		strength = 5;
		defense = 6;
	}

	public void ScaryGhost(){
		actorName = "TestBoss";
		maxHealth = 25;
		currentHealth = 25;
		maxMana = 0;
		currentMana = 0;
		chanceToHit = 10;
		strength = 4;
		defense = 8;
	}

}
