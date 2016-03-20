using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : ScriptableObject{

	private string description;
	private bool bossRoom;
	private bool loot;
	private bool entranceToPreviousFloor;
	private bool exitToNextFloor;
	private List<Item> items = new List<Item>();

	public Room ()
	{
	}

	public Room (string description,bool bossRoom, bool loot, bool entranceToPreviousFloor, bool exitToNextFloor)
	{
		this.description = description;
		this.bossRoom = bossRoom;
		this.loot = loot;
		this.entranceToPreviousFloor = entranceToPreviousFloor;
		this.exitToNextFloor = exitToNextFloor;
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

	public bool ExitToNextFloor
	{
		get { return this.exitToNextFloor; }
		set { this.exitToNextFloor = value; }
	}

	public List<Item> Items {

		get { return this.items; }

	}
}
