using UnityEngine;
using System.Collections;

public class Potions : Consumable {


}
	
public class HealingPotion : Potions {


	public string drink(Player p){
		p.heal (15);
		return "You drink a health potion. You restore 15 health.";
	}

}

public class StrengthPotion : Potions {

	// Implement method that temporarily increases player's Strength stat.


}

public class Antidote : Potions {

	// Implement method that removes the debuff 'Poisoned' if present.

}