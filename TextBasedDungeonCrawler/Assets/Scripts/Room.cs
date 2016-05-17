using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Room : ScriptableObject{

	private string description;
	private bool loot;
	private bool entranceToPreviousFloor;
	private bool entranceToNextFloor;
	private List<Item> items = new List<Item>();
	private List<Direction> directions = new List<Direction>();
	private Monster roomMonster;
	private Boss roomBoss;

	public Monster RoomMonster {
		get {
			return this.roomMonster;
		}
		set {
			roomMonster = value;
		}
	}

	public Boss RoomBoss {
		get {
			return this.roomBoss;
		}
		set {
			roomBoss = value;
		}
	}

	public Room ()
	{
	}

	public string Description
	{
		get { return this.description; }
		set { this.description = value; }
	}

	public bool Loot
	{
		get { return this.loot; }
		set { this.loot = value; }
	}

	public bool EntranceToPreviousFloor
	{
		get { return this.entranceToPreviousFloor; }
		set { this.entranceToPreviousFloor = value; }
	}

	public bool EntranceToNextFloor
	{
		get { return this.entranceToNextFloor; }
		set { this.entranceToNextFloor = value; }
	}

	public List<Direction> Directions {

		get { return this.directions; }
		set { this.directions = value; }
	}

	public List<Item> Items {

		get { return this.items; }
		set { this.items = value; }

	}

	public string checkForMonster(Room r)
	{
		if (r.RoomBoss != null ) {
			return "Room contains a " + r.roomBoss.actorName;
		}
		else if (r.roomMonster != null ) {
			return "Room contains a " + r.roomMonster.actorName;
		}
		return null;
	}
}
