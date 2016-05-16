using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Actor {

	private ICollection<Item> lootTable = new List<Item>();
	private ICollection<Item> heldLoot = new List<Item>();
	public int droprate;
	public int itemRarity;

	public ICollection<Item> LootTable {
		get {
			return this.lootTable;
		}
	}

	public ICollection<Item> HeldLoot {
		get {
			return this.heldLoot;
		}
	}

	/// <summary>
	/// Adds an item to the enemy's currently-held loot, which will then be dropped on death.
	/// </summary>
	/// <param name="item">Item.</param>
	public void addToHeldLoot(Item item){
		heldLoot.Add (item);
	}

	public Enemy ()
	{
	}
	

	public Enemy (string actorName, int maxHealth, int maxMana)
	{
		// Instantiates with just the name, and their max health and mana. Current health and mana is set to their max values by default.
		this.actorName = actorName;
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
		this.maxMana = maxMana;
		this.currentMana = maxMana;
	}

	public Equipment drops (int droprate, int itemRarity)
	{
		Equipment e = ScriptableObject.CreateInstance<Equipment> ();
		int randomNumber = Random.Range (0, 100);

		if (randomNumber <= droprate) {
			int rarityNumber = Random.Range (0, itemRarity);
			int dropNumber = Random.Range (1, 3);

			if (rarityNumber <= 25) {
				switch (dropNumber) {
				case 1:
					e.DefensiveGloves ();
					return e;
				case 2:
					e.OffensiveGloves ();
					return e;
				case 3:
					e.MiddlingGloves ();
					return e;
				}
			}
			if (rarityNumber <= 50) {
				switch (dropNumber) {
				case 1:
					e.DefensiveBoots ();
					return e;
				case 2:
					e.OffensiveBoots ();
					return e;
				case 3:
					e.MiddlingBoots ();
					return e;
				}
			}
			if (rarityNumber <= 60) {
				switch (dropNumber) {
				case 1:
					e.DefensiveHelmet ();
					return e;
				case 2:
					e.OffensiveHelmet ();
					return e;
				case 3:
					e.MiddlingHelmet ();
					return e;
				}
			}
			if (rarityNumber <= 70) {
				switch (dropNumber) {
				case 1:
					e.DefensivePants ();
					return e;
				case 2:
					e.OffensivePants ();
					return e;
				case 3:
					e.MiddlingPants ();
					return e;
				}
			}
			if (rarityNumber <= 80) {
				switch (dropNumber) {
				case 1:
					e.DefensiveChest ();
					return e;
				case 2:
					e.OffensiveChest ();
					return e;
				case 3:
					e.MiddlingChest ();
					return e;
				}
			}
			if (rarityNumber <= 90) {
				e.Sword ();
				return e;
			}
		}
		return null;
	}
}
