using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadedDataUpdater {

	public Player LoadPlayer(PlayerDat p){
		Player pl = new Player {
			actorName = p.actorName,
			maxHealth = p.maxHealth,
			currentHealth = p.currentHealth,
			maxMana = p.maxMana,
			currentMana = p.currentMana,
			strength = p.strength,
			defense = p.defense,
			chanceToDodge = p.chanceToDodge,
			chanceToHit = p.chanceToHit,
			items = GenerateItemDatColl (p),
			equipment = GeneratePlayerEquipDat (p)
		};
		return pl;
	}

	public Movement LoadMovement(MovementDat m){
		Movement md = new Movement {
			x = m.x,
			y = m.y,
			xAxis = m.xAxis,
			yAxis = m.yAxis,
			xCoordinate = m.xCoordinate,
			yCoordinate = m.YCoordinate
		};
			return md;
	}

	public Room[,] LoadFloor(FloorDat fd){
		Room[,] roomArray2d = GenerateFloorDatArray (fd.roomArray2d);

		return roomArray2d;
	}


	public Room[,] GenerateFloorDatArray (RoomDat[,] r){
		Room[,] roomDatArray = new Room[5, 5];
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				if (r[i,j]==null){
					roomDatArray [i, j] = null;
				} else {
					Monster roomMon = new Monster ();
					Boss roomBoss = new Boss ();
					if (r[i,j].roomMonster!=null){
						roomMon = new Monster {
							actorName = r [i, j].roomMonster.actorName,
							maxHealth = r [i, j].roomMonster.maxHealth,
							currentHealth = r [i, j].roomMonster.currentHealth,
							maxMana = r [i, j].roomMonster.maxMana,
							currentMana = r [i, j].roomMonster.currentMana,
							strength = r [i, j].roomMonster.strength,
							defense = r [i, j].roomMonster.defense,
							chanceToDodge = r [i, j].roomMonster.chanceToDodge,
							chanceToHit = r [i, j].roomMonster.chanceToHit,
							lootTable = GenerateMonsterItemLootTab (r [i, j].roomMonster),
							heldLoot = GenerateMonsterItemHeldLoot (r [i, j].roomMonster),
							droprate = r [i, j].roomMonster.droprate,
							itemRarity = r [i, j].roomMonster.itemRarity

						};
					} else {
						roomMon = null;
					}
					if (r[i,j].roomBoss!=null){
						roomBoss = new Boss {
							actorName = r [i, j].roomMonster.actorName,
							maxHealth = r [i, j].roomMonster.maxHealth,
							currentHealth = r [i, j].roomMonster.currentHealth,
							maxMana = r [i, j].roomMonster.maxMana,
							currentMana = r [i, j].roomMonster.currentMana,
							strength = r [i, j].roomMonster.strength,
							defense = r [i, j].roomMonster.defense,
							chanceToDodge = r [i, j].roomMonster.chanceToDodge,
							chanceToHit = r [i, j].roomMonster.chanceToHit,
							lootTable = GenerateMonsterItemLootTab (r [i, j].roomMonster),
							heldLoot = GenerateMonsterItemHeldLoot (r [i, j].roomMonster),
							droprate = r [i, j].roomMonster.droprate,
							itemRarity = r [i, j].roomMonster.itemRarity

						};
					} else {
						roomBoss = null;
					}
					roomDatArray [i, j] = new Room {
						Description = r[i,j].description,
						Loot = r[i,j].loot,
						EntranceToPreviousFloor = r[i,j].entranceToPreviousFloor,
						EntranceToNextFloor = r[i,j].entranceToNextFloor,
						Items = GenerateRoomItemDatColl (r[i,j]),
						Directions = GenerateDirectionDatColl (r[i,j]),
						RoomMonster = roomMon,
						RoomBoss = roomBoss
					};
				}
			}
		}
		return roomDatArray;
	}

	public PlayerEquipment GeneratePlayerEquipDat (PlayerDat p)
	{
		PlayerEquipment ped = new PlayerEquipment ();
		if (p.equipment.equippedHead != null) {
			Equipment eq = new Equipment ();
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
			Equipment eq = new Equipment ();
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
			Equipment eq = new Equipment ();
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
			Equipment eq = new Equipment ();
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
			Equipment eq = new Equipment ();
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
			Equipment eq = new Equipment ();
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

	public List<Item> GenerateItemDatColl (PlayerDat p)
	{
		List<ItemDat> items = (List<ItemDat>)p.items;
		List<Item> itemDats = new List<Item> ();
		foreach (var item in items) {
			Item dat = new Item ();
			dat.itemName = item.itemName;
			dat.carryLimit = item.carryLimit;
			dat.heldQuantity = item.heldQuantity;
			itemDats.Add (dat);
		}

		return itemDats;
	}

	public List<Item> GenerateMonsterItemHeldLoot (MonsterDat m){
		List<ItemDat> items = (List<ItemDat>)m.heldLoot;
		List<Item> itemDats = new List<Item> ();
		foreach (var item in items) {
			Item dat = new Item ();
			dat.itemName = item.itemName;
			dat.carryLimit = item.carryLimit;
			dat.heldQuantity = item.heldQuantity;
			itemDats.Add (dat);
		}

		return itemDats;
	}

	public List<Item> GenerateMonsterItemLootTab (MonsterDat m){
		List<ItemDat> items = (List<ItemDat>)m.lootTable;
		List<Item> itemDats = new List<Item> ();
		foreach (var item in items) {
			Item dat = new Item ();
			dat.itemName = item.itemName;
			dat.carryLimit = item.carryLimit;
			dat.heldQuantity = item.heldQuantity;
			itemDats.Add (dat);
		}

		return itemDats;
	}

	public List<Item> GenerateRoomItemDatColl (RoomDat r){
		List<ItemDat> items = (List<ItemDat>)r.items;
		List<Item> itemDats = new List<Item> ();
		foreach (var item in items) {
			Item dat = new Item ();
			dat.itemName = item.itemName;
			dat.carryLimit = item.carryLimit;
			dat.heldQuantity = item.heldQuantity;
			itemDats.Add (dat);
		}
		return itemDats;
	}

	public List<Direction> GenerateDirectionDatColl (RoomDat r){
		List<DirectionDat> dir = r.directions;
		List<Direction> dirDats = new List<Direction> ();
		foreach (var item in dir) {
			Direction dat = new Direction ();
			dat.DirectionName = item.directionName;
			dirDats.Add (dat);
		}
		return dirDats;
	}
}
