using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Actor {

	public ICollection<Item> lootTable = new List<Item>();
	public ICollection<Item> heldLoot = new List<Item>();
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


			if (rarityNumber <= 25) {
				e.Gloves();
				return e;
			}
			if (rarityNumber <= 50) {
				e.Boots ();
				return e;
			}
			if (rarityNumber <= 60) {
				e.Helmet();
				return e;

			}
			if (rarityNumber <= 70) {
				e.Pants ();
				return e;
			}
			if (rarityNumber <= 80) {
				e.Chest ();
				return e;
			}
			if (rarityNumber <= 90) {
				int dropNumber = Random.Range (1, 4);
				switch (dropNumber) {
				case 1:
					e.SwordAndShield ();
					return e;
				case 2:
					e.Axe ();
					return e;
				case 3:
					e.TwoHandedSword ();
					return e;
				case 4:
					e.Dagger ();
					return e;
				}
			}
		}
		return null;
	}
}
