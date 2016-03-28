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
	private bool north;
	private bool west;
	private bool east;
	private bool south;

	public Room ()
	{
	}

	public Room (string description,bool bossRoom, bool loot, bool entranceToPreviousFloor, bool entranceToNextFloor, bool north, bool south, bool east, bool west)
	{
		this.description = description;
		this.bossRoom = bossRoom;
		this.loot = loot;
		this.entranceToPreviousFloor = entranceToPreviousFloor;
		this.entranceToNextFloor = entranceToNextFloor;
		this.north = north;
		this.south = south;
		this.east = east;
		this.west = west;
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

	public bool East
	{
		get { return this.east; }
		set { this.east = value; }
	}

	public bool West
	{
		get { return this.west; }
		set { this.west = value; }
	}

	public bool South
	{
		get { return this.south; }
		set { this.south = value; }
	}

	public bool North
	{
		get { return this.north; }
		set { this.north = value; }
	}

	public List<Item> Items {

		get { return this.items; }

	}
}
