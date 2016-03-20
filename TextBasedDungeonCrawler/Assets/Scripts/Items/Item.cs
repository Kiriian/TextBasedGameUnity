using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

	public string name;
	public int carryLimit;
	public int heldQuantity;

	public Item () {
		
	}

	public Item (string name, int carryLimit, int heldQuantity) {
		this.name = name;
		this.carryLimit = carryLimit;
		this.heldQuantity = heldQuantity;
	}

	public string Name {

		get {return this.name;}
		set {this.name = value;}

	}
		
}
