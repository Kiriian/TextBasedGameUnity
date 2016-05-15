using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class SessionData
{

	public PlayerDat p {
		get;
		set;
	}

	public MovementDat m {
		get;
		set;
	}

	public FloorDat roomArray2d {
		get;
		set;
	}

	public SessionData ()
	{
		
	}


	public SessionData (Room[,] roomArray2d, Movement m, Player p)
	{
			this.p = new PlayerDat {
			actorName = p.actorName,
			maxHealth = p.maxHealth,
			currentHealth = p.currentHealth,
			maxMana = p.maxMana,
			currentMana = p.currentMana,
			strength = p.strength,
			defense = p.defense,
			chanceToDodge = p.chanceToDodge,
			chanceToHit = p.chanceToHit,
			items = GenerateItemDatColl(p),
			equipment = GeneratePlayerEquipDat (p)

		};
		this.m = new MovementDat {
			x = m.x,
			y = m.y,
			xAxis = m.xAxis,
			yAxis = m.yAxis
		};

	}

	public PlayerEquipDat GeneratePlayerEquipDat (Player p)
	{
		PlayerEquipDat ped = new PlayerEquipDat ();
		if (p.equipment.equippedHead != null) {
			EquipDat eq = new EquipDat ();
			eq.equipType = p.equipment.equippedHead.equipType;
			eq.strengthMod = p.equipment.equippedHead.strengthMod;
			eq.defenseMod = p.equipment.equippedHead.defenseMod;
			eq.healthMod = p.equipment.equippedHead.healthMod;
			eq.manaMod = p.equipment.equippedHead.manaMod;
			ped.equippedHead = eq;
		} else {
			ped.equippedHead = null;
		}
		if (p.equipment.equippedChest != null) {
			EquipDat eq = new EquipDat ();
			eq.equipType = p.equipment.equippedChest.equipType;
			eq.strengthMod = p.equipment.equippedChest.strengthMod;
			eq.defenseMod = p.equipment.equippedChest.defenseMod;
			eq.healthMod = p.equipment.equippedChest.healthMod;
			eq.manaMod = p.equipment.equippedChest.manaMod;
			ped.equippedChest = eq;
		} else {
			ped.equippedChest = null;
		}
		if (p.equipment.equippedGloves != null) {
			EquipDat eq = new EquipDat ();
			eq.equipType = p.equipment.equippedGloves.equipType;
			eq.strengthMod = p.equipment.equippedGloves.strengthMod;
			eq.defenseMod = p.equipment.equippedGloves.defenseMod;
			eq.healthMod = p.equipment.equippedGloves.healthMod;
			eq.manaMod = p.equipment.equippedGloves.manaMod;
			ped.equippedGloves = eq;
		} else {
			ped.equippedGloves = null;
		}
		if (p.equipment.equippedPants != null) {
			EquipDat eq = new EquipDat ();
			eq.equipType = p.equipment.equippedPants.equipType;
			eq.strengthMod = p.equipment.equippedPants.strengthMod;
			eq.defenseMod = p.equipment.equippedPants.defenseMod;
			eq.healthMod = p.equipment.equippedPants.healthMod;
			eq.manaMod = p.equipment.equippedPants.manaMod;
			ped.equippedPants = eq;
		} else {
			ped.equippedPants = null;
		} 
		if (p.equipment.equippedBoots != null) {
			EquipDat eq = new EquipDat ();
			eq.equipType = p.equipment.equippedBoots.equipType;
			eq.strengthMod = p.equipment.equippedBoots.strengthMod;
			eq.defenseMod = p.equipment.equippedBoots.defenseMod;
			eq.healthMod = p.equipment.equippedBoots.healthMod;
			eq.manaMod = p.equipment.equippedBoots.manaMod;
			ped.equippedBoots = eq;
		} else {
			ped.equippedBoots = null;
		}
		if (p.equipment.equippedWeapon != null) {
			EquipDat eq = new EquipDat ();
			eq.equipType = p.equipment.equippedWeapon.equipType;
			eq.strengthMod = p.equipment.equippedWeapon.strengthMod;
			eq.defenseMod = p.equipment.equippedWeapon.defenseMod;
			eq.healthMod = p.equipment.equippedWeapon.healthMod;
			eq.manaMod = p.equipment.equippedWeapon.manaMod;
			ped.equippedWeapon = eq;
		} else {
			ped.equippedWeapon = null;
		}
		return ped;
	}

	public List<ItemDat> GenerateItemDatColl (Player p)
	{
		List<Item> items = (List<Item>)p.items;
		List<ItemDat> itemDats = new List<ItemDat> ();
		foreach (var item in items) {
			ItemDat dat = new ItemDat ();
			dat.itemName = item.itemName;
			dat.carryLimit = item.carryLimit;
			dat.heldQuantity = item.heldQuantity;
			itemDats.Add (dat);
		}
	
		return itemDats;
	}
}



[Serializable]
public class PlayerDat
{

	public string actorName;
	public int maxHealth;
	public int currentHealth;
	public int maxMana;
	public int currentMana;
	public int strength;
	public int defense;
	public int chanceToDodge;
	public int chanceToHit;
	public ICollection<ItemDat> items = new List<ItemDat> ();
	public PlayerEquipDat equipment;







}

[Serializable]
public class ItemDat
{

	public string itemName;
	public int carryLimit;
	public int heldQuantity;

}

[Serializable]
public class PlayerEquipDat
{
	public EquipDat equippedHead;
	public EquipDat equippedChest;
	public EquipDat equippedGloves;
	public EquipDat equippedPants;
	public EquipDat equippedBoots;
	public EquipDat equippedWeapon;
}

[Serializable]
public class EquipDat
{

	public string equipType;
	public int strengthMod;
	public int defenseMod;
	public int healthMod;
	public int manaMod;

}

[Serializable]
public class MovementDat{

	public int x;
	public int y;
	public int xAxis;
	public int yAxis;
	
}

[Serializable]
public class FloorDat{
	
}