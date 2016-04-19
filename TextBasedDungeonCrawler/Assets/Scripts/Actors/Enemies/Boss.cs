using UnityEngine;
using System.Collections;

public class Boss : Enemy {

	public Boss ()
	{
	}

	public Boss (string enemyName, int maxHealth, int maxMana) : base (enemyName, maxHealth, maxMana)
	{
	}

	public void InitTestBoss(){
		actorName = "TestBoss";
		maxHealth = 50;
		currentHealth = 50;
		maxMana = 50;
		currentMana = 50;
		chanceToHit = 8;
		strength = 7;
		defense = 5;
	}

}
