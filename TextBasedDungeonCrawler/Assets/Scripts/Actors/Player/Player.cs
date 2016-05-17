using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : Actor {


	public ICollection<Item> items = new List<Item>();
	public PlayerEquipment equipment;

	public Player (string actorName, int maxHealth, int maxMana)
	{
		this.actorName = actorName;
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
		this.maxMana = maxMana;
		this.currentMana = maxMana;
	}

	public Player ()
	{
	}

	/// <summary>
	/// Sets up a test player. Implemented mostly for initial testing of combat and player activity.
	/// </summary>
	public void InitTestPlayer(){
		actorName = "Test";
		maxHealth = 30;
		currentHealth = 30;
		maxMana = 30;
		currentMana = 30;
		strength = 5;
		defense = 3;
		chanceToDodge = 5;
		chanceToHit = 5;
		equipment = ScriptableObject.CreateInstance<PlayerEquipment> ();

		Equipment testSword = ScriptableObject.CreateInstance<Equipment>();
		testSword.setAttributes ("Test Sword", "weapon", 2, 0, 0, 0);
		equipment.equip (this,testSword);

	}

	/// <summary>
	/// Returns a string detailing all of the items that the player is carrying.
	/// </summary>
	/// <value>The give all held items.</value>
	public string GiveHeldItems() {
		string lootString = "You are currently carrying: ";
		foreach (var item in items) {
			lootString = lootString + item.Name + ", ";
		}
		lootString = lootString.Substring (0, lootString.Length - 2);
		return lootString;
	}


	/// <summary>
	/// Returns an object containing the entirety of the player's currently-equipped gear.
	/// </summary>
	/// <value>The give all held equipment.</value>
	public PlayerEquipment GiveAllHeldEquipment {
		get {
			return this.equipment;
		}
	}

	/// <summary>
	/// Adds an item to the player's inventory.
	/// </summary>
	/// <param name="i">The index.</param>
	public void addItem(Item i){
		items.Add (i);
	}

	/// <summary>	
	/// Removes an item from the player's inventory.
	/// </summary>
	/// <param name="i">The index.</param>
	public void removeItem(Item i){
		items.Remove (i);
	}

	/// <summary>	
	/// Uses Healing potion if the player has one.
	/// </summary>
	public HealingPotion getHealingPotion(){
		foreach (HealingPotion pots in items) {
			return pots;
		}
		return null;
	}

	/// <summary>
	/// Equip a new piece of gear. Will return the piece of gear that is replaced.
	/// </summary>
	/// <returns>The equipment that has been replaced.</returns>
	/// <param name="eq">Eq.</param>
	public Equipment addEquipment(Equipment eq){
		return equipment.equip (this,eq);
	}


	

}

public class PlayerEquipment : ScriptableObject {

	public Equipment equippedHelmet;
	public Equipment equippedChest;
	public Equipment equippedGloves;
	public Equipment equippedPants;
	public Equipment equippedBoots;
	public Equipment equippedWeapon;

	// Equip a new piece of gear. Will return the piece of gear that is replaced.
	public Equipment equip(Player player, Equipment equipment){
		// Used for taking the equipment that's currently worn, so that it can be returned and left on the floor after putting on the new piece of equipment.
		Equipment swappedEquip = ScriptableObject.CreateInstance<Equipment>();
		swappedEquip = null;
		Equipment nullEquip = ScriptableObject.CreateInstance<Equipment>();

		switch (equipment.equipType)
		{
		case "helmet":
			if (equippedHelmet==null){
				swappedEquip = nullEquip;
				equippedHelmet = equipment;
			} else {
				swappedEquip = equippedHelmet;
				equippedHelmet = equipment;
			}
			break;
		case "chest":
			if (equippedChest==null){
				swappedEquip = nullEquip;
				equippedChest = equipment;
			} else {
				swappedEquip = equippedChest;
				equippedChest = equipment;
			}
			break;
		case "gloves":
			if (equippedGloves==null) {
				swappedEquip = nullEquip;
				equippedGloves = equipment;
			} else {
				swappedEquip = equippedGloves;
				equippedGloves = equipment;
			}
			break;
		case "pants":
			if (equippedPants==null){
				swappedEquip = nullEquip;
				equippedPants = equipment;
			} else {
				swappedEquip = equippedPants;
				equippedPants = equipment;
			}
			break;
		case "boots":
			if (equippedBoots==null){
				swappedEquip = nullEquip;
				equippedBoots = equipment;
			} else {
				swappedEquip = equippedBoots;
				equippedBoots = equipment;
			}
			break;
		case "weapon":
			if (equippedWeapon==null){
				swappedEquip = nullEquip;
				equippedWeapon = equipment;
			} else {
				swappedEquip = equippedWeapon;
				equippedWeapon = equipment;
			}
			break;
		}
		updateStats (player, equipment, swappedEquip);
		return swappedEquip;
	} 


	public void updateStats(Player p, Equipment newEquip, Equipment oldEquip){
		p.strength -= oldEquip.strengthMod;
		p.defense -= oldEquip.defenseMod;
		p.maxHealth -= oldEquip.healthMod;
		p.maxMana -= oldEquip.manaMod;

		p.strength += newEquip.strengthMod;
		p.defense += newEquip.defenseMod;
		p.maxHealth += newEquip.healthMod;
		p.maxMana += newEquip.manaMod;
	}

}
