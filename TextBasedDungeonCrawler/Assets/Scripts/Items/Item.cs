using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

	public string itemName;
	public int carryLimit;
	public int heldQuantity;

	public Item () {
		
	}

	public Item (string itemName, int carryLimit, int heldQuantity) {
		this.itemName = itemName;
		this.carryLimit = carryLimit;
		this.heldQuantity = heldQuantity;
	}

	public string Name {

		get {return this.name;}
		set {this.name = value;}

	}
		
}
