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
		maxHealth = 130;
		currentHealth = 130;
		maxMana = 50;
		currentMana = 50;
	}

}
