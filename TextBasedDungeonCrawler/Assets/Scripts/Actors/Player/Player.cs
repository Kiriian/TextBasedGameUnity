using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Actor {


	private ICollection<Item> items;
	private PlayerEquipment equipment;

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
	/// Returns all of the items the player is currently holding.
	/// </summary>
	/// <value>The give all held items.</value>
	public ICollection<Item> GiveAllHeldItems {
		get {
			return this.items;
		}
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
	/// Equip a new piece of gear. Will return the piece of gear that is replaced.
	/// </summary>
	/// <returns>The equipment that has been replaced.</returns>
	/// <param name="eq">Eq.</param>
	public Equipment addEquipment(Equipment eq){
		return equipment.equip (eq);
	}
	

}

public class PlayerEquipment {

	Equipment equippedHead;
	Equipment equippedChest;
	Equipment equippedGloves;
	Equipment equippedPants;
	Equipment equippedBoots;
	Equipment equippedWeapon;

	// Equip a new piece of gear. Will return the piece of gear that is replaced.
	public Equipment equip(Equipment equipment){

		// Used for taking the equipment that's currently worn, so that it can be returned and left on the floor after putting on the new piece of equipment.
		Equipment swappedEquip = null;

		// When player stat changes are implemented, insert a method call that updates the player's stats in accordance with the change in equipment.

		switch (equipment.equipType)
		{

		case "head":
			swappedEquip = equippedHead;
			equippedHead = equipment;
			break;
		case "chest":
			swappedEquip = equippedChest;
			equippedChest = equipment;
			break;
		case "gloves":
			swappedEquip = equippedGloves;
			equippedGloves = equipment;
			break;
		case "pants":
			swappedEquip = equippedPants;
			equippedPants = equipment;
			break;
		case "boots":
			swappedEquip = equippedBoots;
			equippedBoots = equipment;
			break;
		case "weapon":
			swappedEquip = equippedWeapon;
			equippedWeapon = equipment;
			break;
		}
		return swappedEquip;
	}
}
