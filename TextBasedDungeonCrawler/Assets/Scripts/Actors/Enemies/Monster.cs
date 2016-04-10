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
	}
	
}
