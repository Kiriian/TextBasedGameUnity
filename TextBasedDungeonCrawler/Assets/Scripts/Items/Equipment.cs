using UnityEngine;
using System.Collections;

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

}
