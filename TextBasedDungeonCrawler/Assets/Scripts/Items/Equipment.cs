using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : Item {

	public string equipType;
	public int strengthMod;
	public int defenseMod;
	public int healthMod;
	public int manaMod;
	public StatusEffect activeEffect;

	public Equipment ()
	{
		
	}
		

	public void setAttributes(string name, string equipType, int strengthMod, int defenseMod, int healthMod, int manaMod, StatusEffect activeEffect){
		this.Name = name;
		this.equipType = equipType;
		this.strengthMod = strengthMod;
		this.defenseMod = defenseMod;
		this.healthMod = healthMod;
		this.manaMod = manaMod;
		this.activeEffect = activeEffect;
		this.carryLimit = 1;
		this.heldQuantity = 1;
	}

	public void OffensiveGloves()
	{
		equipType = "gloves";
		name = "Leather Gloves";
		strengthMod = 3;
		defenseMod = 0;
		healthMod = 0;
	}

	public void DefensiveGloves()
	{
		equipType = "gloves";
		name = "Chainmail Gloves";
		strengthMod = 0;
		defenseMod = 2;
		healthMod = 1;
	}

	public void MiddlingGloves()
	{
		equipType = "gloves";
		name = "Hard Leather Gloves";
		strengthMod = 1;
		defenseMod = 1;
		healthMod = 1;
	}

	public void OffensiveBoots()
	{
		equipType = "boots";
		name = "Leather boots";
		strengthMod = 3;
		defenseMod = 0;
		healthMod = 0;
	}

	public void DefensiveBoots()
	{
		equipType = "boots";
		name = "Chainmail Boots";
		strengthMod = 0;
		defenseMod = 2;
		healthMod = 1;
	}

	public void MiddlingBoots()
	{
		equipType = "gloves";
		name = "Hard Leather Boots";
		strengthMod = 1;
		defenseMod = 1;
		healthMod = 1;
	}

	public void OffensiveHelmet()
	{
		equipType = "helmet";
		name = "Leather Helmet";
		strengthMod = 4;
		defenseMod = 0;
		healthMod = 0;
	}

	public void DefensiveHelmet()
	{
		equipType = "helmet";
		name = "Chainmail Helmet";
		strengthMod = 0;
		defenseMod = 2;
		healthMod = 2;
	}

	public void MiddlingHelmet()
	{
		equipType = "helmet";
		name = "Hard Leather Helmet";
		strengthMod = 1;
		defenseMod = 1;
		healthMod = 2;
	}

	public void OffensivePants()
	{
		equipType = "pants";
		name = "Leather Pants";
		strengthMod = 3;
		defenseMod = 0;
		healthMod = 2;
	}

	public void DefensivePants()
	{
		equipType = "pants";
		name = "Chainmail Pants";
		strengthMod = 0;
		defenseMod = 3;
		healthMod = 2;
	}

	public void MiddlingPants()
	{
		equipType = "pants";
		name = "Hard Leather Pants";
		strengthMod = 2;
		defenseMod = 1;
		healthMod = 2;
	}

	public void OffensiveChest()
	{
		equipType = "chest";
		name = "Leather Chest";
		strengthMod = 4;
		defenseMod = 0;
		healthMod = 2;
	}

	public void DefensiveChest()
	{
		equipType = "chest";
		name = "Chainmail Chest";
		strengthMod = 0;
		defenseMod = 4;
		healthMod = 2;
	}

	public void MiddlingChest()
	{
		equipType = "chest";
		name = "Hard Leather Chest";
		strengthMod = 2;
		defenseMod = 2;
		healthMod = 2;
	}

	public void Sword()
	{
		equipType = "weapon";
		name = "Sword";
		strengthMod = 6;
		defenseMod = 0;
		healthMod = 0;
	}
}
