using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {
	private int skillDamage;
	private int manaCost;
	private int spellDamage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int FireBall(int mana, Boss b)
	{
		manaCost = 15;
		skillDamage = 5;

		if (mana >= manaCost) {
			b.currentMana -= manaCost;
			spellDamage = b.intellengence + skillDamage;
			return spellDamage;
		} else {
			return 0;
		}
	}
}
