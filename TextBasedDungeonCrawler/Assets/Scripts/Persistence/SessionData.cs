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
			yAxis = m.yAxis,
			xCoordinate = m.xCoordinate,
			YCoordinate = m.yCoordinate

		};


		this.roomArray2d = new FloorDat {
			roomArray2d = GenerateFloorDatArray (roomArray2d)
		};

	}

	public RoomDat[,] GenerateFloorDatArray (Room[,] r){
		RoomDat[,] roomDatArray = new RoomDat[5, 5];
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				if (r[i,j]==null){
					roomDatArray [i, j] = null;
				} else {
					MonsterDat roomMon = new MonsterDat ();
					if (r[i,j].RoomMonster!=null){
						roomMon = new MonsterDat {
							actorName = r [i, j].RoomMonster.actorName,
							maxHealth = r [i, j].RoomMonster.maxHealth,
							currentHealth = r [i, j].RoomMonster.currentHealth,
							maxMana = r [i, j].RoomMonster.maxMana,
							currentMana = r [i, j].RoomMonster.currentMana,
							strength = r [i, j].RoomMonster.strength,
							defense = r [i, j].RoomMonster.defense,
							chanceToDodge = r [i, j].RoomMonster.chanceToDodge,
							chanceToHit = r [i, j].RoomMonster.chanceToHit,
							lootTable = GenerateMonsterItemLootTab (r [i, j].RoomMonster),
							heldLoot = GenerateMonsterItemHeldLoot (r [i, j].RoomMonster),
							droprate = r [i, j].RoomMonster.droprate,
							itemRarity = r [i, j].RoomMonster.itemRarity

						};
					} else {
						roomMon = null;
					}
					BossDat roomBoss = new BossDat ();
					if (r[i,j].RoomBoss!=null){
						roomBoss = new BossDat {
							actorName = r [i, j].RoomBoss.actorName,
							maxHealth = r [i, j].RoomBoss.maxHealth,
							currentHealth = r [i, j].RoomBoss.currentHealth,
							maxMana = r [i, j].RoomBoss.maxMana,
							currentMana = r [i, j].RoomBoss.currentMana,
							strength = r [i, j].RoomBoss.strength,
							defense = r [i, j].RoomBoss.defense,
							chanceToDodge = r [i, j].RoomBoss.chanceToDodge,
							chanceToHit = r [i, j].RoomBoss.chanceToHit,
							lootTable = GenerateBossItemLootTab (r [i, j].RoomBoss),
							heldLoot =  GenerateBossItemHeldLoot(r [i, j].RoomBoss),
							droprate = r [i, j].RoomBoss.droprate,
							itemRarity = r [i, j].RoomBoss.itemRarity
						};
					} else {
						roomBoss = null;
					}
					roomDatArray [i, j] = new RoomDat {
						description = r[i,j].Description,
						loot = r[i,j].Loot,
						entranceToPreviousFloor = r[i,j].EntranceToPreviousFloor,
						entranceToNextFloor = r[i,j].EntranceToNextFloor,
						items = GenerateRoomItemDatColl (r[i,j]),
						directions = GenerateDirectionDatColl (r[i,j]),
						roomMonster = roomMon,
						roomBoss = roomBoss
					};
				}
			}
		}
		return roomDatArray;
	}

	public PlayerEquipDat GeneratePlayerEquipDat (Player p)
	{
		PlayerEquipDat ped = new PlayerEquipDat ();
		if (p.equipment.equippedHelmet != null) {
			EquipDat eq = new EquipDat ();
			eq.equipType = p.equipment.equippedHelmet.equipType;
			eq.strengthMod = p.equipment.equippedHelmet.strengthMod;
			eq.defenseMod = p.equipment.equippedHelmet.defenseMod;
			eq.healthMod = p.equipment.equippedHelmet.healthMod;
			eq.manaMod = p.equipment.equippedHelmet.manaMod;
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

	public List<ItemDat> GenerateMonsterItemHeldLoot (Monster m){
		List<Item> items = (List<Item>)m.HeldLoot;
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

	public List<ItemDat> GenerateMonsterItemLootTab (Monster m){
		List<Item> items = (List<Item>)m.LootTable;
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

	public List<ItemDat> GenerateRoomItemDatColl (Room r){
		List<Item> items = (List<Item>)r.Items;
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

	public List<ItemDat> GenerateBossItemHeldLoot (Boss b){
		List<Item> items = (List<Item>)b.HeldLoot;
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

	public List<ItemDat> GenerateBossItemLootTab (Boss b){
		List<Item> items = (List<Item>)b.LootTable;
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

	public List<DirectionDat> GenerateDirectionDatColl (Room r){
		List<Direction> dir = r.Directions;
		List<DirectionDat> dirDats = new List<DirectionDat> ();
		foreach (var item in dir) {
			DirectionDat dat = new DirectionDat ();
			dat.directionName = item.DirectionName;
			dirDats.Add (dat);
		}
		return dirDats;
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
	public int xCoordinate;
	public int YCoordinate;

}

[Serializable]
public class FloorDat{

	public RoomDat[,] roomArray2d;

}

[Serializable]
public class RoomDat{

	public string description;
	public bool loot;
	public bool entranceToPreviousFloor;
	public bool entranceToNextFloor;
	public List<ItemDat> items = new List<ItemDat>();
	public List<DirectionDat> directions = new List<DirectionDat>();
	public MonsterDat roomMonster;
	public BossDat roomBoss;

}

[Serializable]
public class DirectionDat{

	public string directionName;

}

[Serializable]
public class MonsterDat{

	public string actorName;
	public int maxHealth;
	public int currentHealth;
	public int maxMana;
	public int currentMana;
	public int strength;
	public int defense;
	public int chanceToDodge;
	public int chanceToHit;
	public ICollection<ItemDat> lootTable = new List<ItemDat>();
	public ICollection<ItemDat> heldLoot = new List<ItemDat>();
	public int droprate;
	public int itemRarity;

}

[Serializable]
public class BossDat{

	public string actorName;
	public int maxHealth;
	public int currentHealth;
	public int maxMana;
	public int currentMana;
	public int strength;
	public int defense;
	public int chanceToDodge;
	public int chanceToHit;
	public ICollection<ItemDat> lootTable = new List<ItemDat>();
	public ICollection<ItemDat> heldLoot = new List<ItemDat>();
	public int droprate;
	public int itemRarity;
} 
