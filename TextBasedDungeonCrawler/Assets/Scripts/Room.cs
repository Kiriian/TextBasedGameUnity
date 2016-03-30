using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : ScriptableObject{

	private string description;
	private bool bossRoom;
	private bool loot;
	private bool entranceToPreviousFloor;
	private bool entranceToNextFloor;
	private List<Item> items = new List<Item>();
	private List<Direction> directions = new List<Direction>();
	private Monster roomMonster;

	public Monster RoomMonster {
		get {
			return this.roomMonster;
		}
		set {
			roomMonster = value;
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

	public bool BossRoom
	{
		get { return this.bossRoom; }
		set { this.bossRoom = value; }
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

	}

	public List<Item> Items {

		get { return this.items; }

	}
}
