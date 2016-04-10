using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Actor {

	private ICollection<Item> lootTable = new List<Item>();
	private ICollection<Item> heldLoot = new List<Item>();

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



}
