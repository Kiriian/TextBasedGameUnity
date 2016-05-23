using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : Item {

	public string equipType;
	public int strengthMod;
	public int defenseMod;
	public int healthMod;
	public int manaMod;
	//public StatusEffect activeEffect;

	private int randomvalue;
	private string[] materialNames = {"Leather","Hard Leather", "ChainMail", "Hide", "Imperial"};

	public Equipment ()
	{
		
	}
		

	public void setAttributes(string name, string equipType, int strengthMod, int defenseMod, int healthMod, int manaMod){
		this.Name = name;
		this.equipType = equipType;
		this.strengthMod = strengthMod;
		this.defenseMod = defenseMod;
		this.healthMod = healthMod;
		this.manaMod = manaMod;
		this.carryLimit = 1;
		this.heldQuantity = 1;
	}

	[EquipmentModifier]
	public void Gloves()
	{
		equipType = "gloves";
		name = materialNames.GetValue (Random.Range (0, materialNames.Length - 1)) + " Gloves";
		int statPoints = Main.floorNumber/5+3;
		int[] statArray = distributePoints (statPoints);
		strengthMod = (int) statArray.GetValue (0);
		defenseMod = (int) statArray.GetValue (1);
		healthMod = (int) statArray.GetValue (2);
	}

	[EquipmentModifier]
	public void Boots()
	{
		equipType = "boots";
		name = materialNames.GetValue (Random.Range (0, materialNames.Length - 1)) + " Boots";
		int statPoints = Main.floorNumber/5+3;
		int[] statArray = distributePoints (statPoints);
		strengthMod = (int) statArray.GetValue (0);
		defenseMod = (int) statArray.GetValue (1);
		healthMod = (int) statArray.GetValue (2);
	}

	[EquipmentModifier]
	public void Helmet()
	{
		equipType = "helmet";
		name = materialNames.GetValue (Random.Range (0, materialNames.Length - 1)) + " Helmet";
		int statPoints = Main.floorNumber/5+3;
		int[] statArray = distributePoints (statPoints);
		strengthMod = (int) statArray.GetValue (0);
		defenseMod = (int) statArray.GetValue (1);
		healthMod = (int) statArray.GetValue (2);
	}

	[EquipmentModifier]
	public void Pants()
	{
		equipType = "pants";
		name = materialNames.GetValue (Random.Range (0, materialNames.Length - 1)) + " Pants";
		int statPoints = Main.floorNumber/5+4;
		int[] statArray = distributePoints (statPoints);
		strengthMod = (int) statArray.GetValue (0);
		defenseMod = (int) statArray.GetValue (1);
		healthMod = (int) statArray.GetValue (2);
	}

	[EquipmentModifier]
	public void Chest()
	{
		equipType = "chest";
		name = materialNames.GetValue (Random.Range (0, materialNames.Length - 1)) + " Chest";
		int statPoints = Main.floorNumber/5+5;
		int[] statArray = distributePoints (statPoints);
		strengthMod = (int) statArray.GetValue (0);
		defenseMod = (int) statArray.GetValue (1);
		healthMod = (int) statArray.GetValue (2);
	}

	private int RandomStatValue(int statpoints)
	{
		int randomValue = Random.Range (0, statpoints);
		return randomValue;
	}

	private int[] distributePoints(int statPoints)
	{
		int[] stats = new int[3];
		for (int i = 0; i < 3; i++)
		{
			randomvalue = RandomStatValue (statPoints);
			stats.SetValue(randomvalue,i);
			statPoints = statPoints - randomvalue;
		}
		return stats;
	}

	[EquipmentModifier]
	public void SwordAndShield()
	{
		equipType = "weapon";
		name = "Sword and Shield";
		strengthMod = 3;
		defenseMod = 3;
		healthMod = 0;
	}

	[EquipmentModifier]
	public void Axe()
	{
		equipType = "weapon";
		name = "Sword and Shield";
		strengthMod = 6;
		defenseMod = 0;
		healthMod = 0;
	}

	[EquipmentModifier]
	public void TwoHandedSword()
	{
		equipType = "weapon";
		name = "Two-handed Sword";
		strengthMod = 4;
		defenseMod = 2;
		healthMod = 0;
	}

	[EquipmentModifier]
	public void Dagger()
	{
		equipType = "weapon";
		name = "Dagger";
		strengthMod = 3;
		defenseMod = 0;
		healthMod = 0;
	}

	[EquipmentModifier]
	public void Shiv()
	{
		equipType = "weapon";
		name = "Shiv";
		strengthMod = 2;
		defenseMod = 0;
		healthMod = 0;
	}

}

public class EquipmentModifier : ConstructorSafeAttribute {
	
}
