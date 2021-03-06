﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	private Movement m;
	private Player p;
	private Room[,] roomArray2d;
	private CombatEngine ce;
	private Floor f;
	private Room r;
	private ButtonClicked bt;
	private Map map;
	public int currentX;
	public int currentY;

	public static int floorNumber;

	public Text playerName;
	public Text roomDescriptionText;
	public Text movementText;
	public Text combatText;
	public Text lootText;
	public Text health;
	public Text mana;
	public Text strength;
	public Text defense;
	public Text floorNumberText;

	void Start () {
		f = ScriptableObject.CreateInstance<Floor> ();
		p = ScriptableObject.CreateInstance<Player> ();
		p.InitTestPlayer();

		m = ScriptableObject.CreateInstance<Movement>();

		ce = ScriptableObject.CreateInstance<CombatEngine> ();

		floorNumber = 1;

		roomArray2d = f.Floor1 (m);
		r = m.getCurrentRoom (roomArray2d);
		setMoveText (r);

		playerName.text = p.actorName;

		map = ScriptableObject.CreateInstance<Map>();
		map.CreateMap (roomArray2d);
	}

	void Update ()
	{
		health.text = "Health:\t" + p.currentHealth + "/"+ p.maxHealth;
		mana.text = "Mana:\t" + p.currentMana + "/" + p.maxMana;
		defense.text = "Defense:\t" + p.defense;
		strength.text = "Strength:\t" + p.strength;
		floorNumberText.text = "F" + floorNumber;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (r.checkForMonster(r) == null) {
				currentX = m.x;
				currentY = m.y;
				r = m.MoveSouth (roomArray2d);
				setMoveText (r);
				map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
			} else if (r.checkForMonster(r) != null) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 9) {
					currentX = m.x;
					currentY = m.y;
					r = m.MoveSouth (roomArray2d);
					setMoveText (r);
					map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
				} else {
					EscapeMonster (r);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (r.checkForMonster(r) == null) {
				currentX = m.x;
				currentY = m.y;
				r = m.MoveNorth (roomArray2d);
				setMoveText (r);
				map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
			} else if (r.checkForMonster(r) != null) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 9) {
					currentX = m.x;
					currentY = m.y;
					r = m.MoveNorth (roomArray2d);
					setMoveText (r);
					map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
				} else {
					EscapeMonster (r);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (r.checkForMonster(r) == null) {
				currentX = m.x;
				currentY = m.y;
				r = m.MoveEast (roomArray2d);
				setMoveText (r);
				map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
			} else if (r.checkForMonster(r) != null) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 9) {
					currentX = m.x;
					currentY = m.y;
					r = m.MoveEast (roomArray2d);
					setMoveText (r);
					map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
				} else {
					EscapeMonster (r);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {if (r.checkForMonster(r) == null) {
				currentX = m.x;
				currentY = m.y;
				r = m.MoveWest (roomArray2d);
				setMoveText (r);
				map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
		} else if (r.checkForMonster(r) != null) {
			int number = UnityEngine.Random.Range (1, 10);
			if (number >= 9) {
				currentX = m.x;
				currentY = m.y;
				r = m.MoveWest (roomArray2d);
				setMoveText (r);
				map.SetPlayerMapPos (currentX,currentY,m.x,m.y);
			} else {
				EscapeMonster (r);
			}
		};
		} else if (Input.GetKeyDown (KeyCode.I)) {
			setLootText (m, roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.Space) && m.getCurrentRoom (roomArray2d).EntranceToNextFloor == true) {
			MoveNextFloor (r,map,m);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			setAttackCombatText (ce, roomArray2d, p, m);
		} else if (Input.GetKeyDown (KeyCode.P)) {
			setPickUpLootText (m, p, r);
		} else if (Input.GetKeyDown (KeyCode.M)) {
			setInventoryText (p, r);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			setDodgeCombatText (ce, roomArray2d, p, m);
		} else if (Input.GetKeyDown (KeyCode.Q)) {
			setUseHealingPotionText (p);
		} else if (Input.GetKeyDown (KeyCode.V)) {
			SaveGame ();
		} else if (Input.GetKeyDown (KeyCode.B)) {
			LoadGame ();
		}
	}

public void SaveGame()
{
	SaveGame sg = new SaveGame ();
	SessionData sd = new SessionData (roomArray2d, m, p);
	sg.Save (sd);
}

public void LoadGame()
{
	LoadGame lg = new LoadGame ();
	SessionData sd = lg.Load ();
	LoadGameFromSessionData (sd);
	floorNumber--;
}

public void ScreenButtonPressed (int buttonID){
	bt = ScriptableObject.CreateInstance<ButtonClicked> ();

	bt.CheckButtonPressed (roomArray2d, m, this, buttonID, ce, p, map);

}

public void setMoveText(Room r)
{
	lootText.text = "";
	movementText.text = m.Options (r);
	combatText.text = r.checkForMonster (r);
	if (r.EntranceToNextFloor == true) {
		roomDescriptionText.text = r.Description + "There are stairs leading further down";
	} else {
		roomDescriptionText.text = r.Description;
	}

}

public void setLootText(Movement m, Room[,] roomArray)
{
	string lootinroom = "";
		if (m.getCurrentRoom (roomArray).RoomBoss == null && m.getCurrentRoom (roomArray).RoomMonster == null) {
			if (m.getCurrentRoom (roomArray).Items.Count == 0) {
				lootText.text = "There is nothing of use in the room.";
			} else {
				foreach (Item i in m.getCurrentRoom(roomArray).Items) {
					if (i != null) {
						lootinroom += i.name + ", ";
					}
				}
				if (lootinroom.Equals (", ")) {
					lootText.text = "There is nothing of use in the room.";
				} else {
					lootText.text = "In the room you find " + lootinroom;
				}
			}
		} else if (m.getCurrentRoom (roomArray).RoomBoss != null) {
			Boss b = m.getCurrentRoom (roomArray).RoomBoss;
			int playerDamage = p.hurt (Mathf.Clamp(b.strength - p.defense,1,100000));
			if (p.currentHealth <= 0) {
				Application.LoadLevel (2);
			}
			combatText.text = "The monster attacks and damages you for " + playerDamage + ", while you are distracted.";
		} else if (m.getCurrentRoom (roomArray).RoomMonster != null) {
			Monster mon = m.getCurrentRoom (roomArray).RoomMonster;
			int playerDamage = p.hurt (Mathf.Clamp(mon.strength - p.defense,1,100000));
			if (p.currentHealth <= 0) {
				Application.LoadLevel (2);
			}
			combatText.text = "The monster attacks and damages you for " + playerDamage + ", while you are distracted.";
		}
}

public void setAttackCombatText (CombatEngine ce, Room[,] roomArray, Player p, Movement m)
{
	combatText.text = ce.Attack (p, roomArray, m.xCoordinate, m.yCoordinate);    
}

public void setPickUpLootText(Movement m, Player p, Room r)
{
	Equipment newEquipment;
	Equipment oldEquipment;
	
		if (r.RoomMonster == null && r.RoomBoss == null) {
			if (r.Items.Count != 0) {
				if (r.Items [0].GetType () == typeof(Equipment)) {
					newEquipment = (Equipment)r.Items [0];
					oldEquipment = p.addEquipment (newEquipment);
					r.Items.RemoveAt (0);
					if (oldEquipment != null) {
						r.Items.Add (oldEquipment);
					}
					lootText.text = "You equip the " + (newEquipment.Name);
				} else {
					p.addItem (r.Items [0]);
					lootText.text = "You pick up the " + (r.Items [0].itemName);
					r.Items.RemoveAt (0);
				}
			} else {
				lootText.text = "There is nothing to pick up";
			}
		}  else if (r.RoomBoss != null) {
			Boss b = r.RoomBoss;
			int playerDamage = p.hurt (Mathf.Clamp(b.strength - p.defense,1,100000));
			if (p.currentHealth <= 0) {
				Application.LoadLevel (2);
			}
			combatText.text = "The monster attacks and damages you for " + playerDamage + ", while you are distracted.";
		} else if (r.RoomMonster != null) {
			Monster mon = r.RoomMonster;
			int playerDamage = p.hurt (Mathf.Clamp(mon.strength - p.defense,1,100000));
			if (p.currentHealth <= 0) {
				Application.LoadLevel (2);
			}
			combatText.text = "The monster attacks and damages you for " + playerDamage + ", while you are distracted.";
		}
}

	public void setInventoryText (Player p, Room r)
{
		if (r.RoomBoss == null && r.RoomMonster == null) {
			string items = p.GiveHeldItems ();
			lootText.text = items;
		} else if (r.RoomBoss != null) {
			Boss b = r.RoomBoss;
			int playerDamage = p.hurt (Mathf.Clamp(b.strength - p.defense,1,100000));
			if (p.currentHealth <= 0) {
				Application.LoadLevel (2);
			}
			combatText.text = "The monster attacks and damages you for " + playerDamage + ", while you are distracted.";	
		} else if (r.RoomMonster != null) {
			Monster mon = r.RoomMonster;
			int playerDamage = p.hurt (Mathf.Clamp(mon.strength - p.defense,1,100000));
			if (p.currentHealth <= 0) {
				Application.LoadLevel (2);
			}
			combatText.text = "The monster attacks and damages you for " + playerDamage + ", while you are distracted.";
		}
	
}

public void setDodgeCombatText(CombatEngine ce, Room[,] roomArray, Player p, Movement m)
{
	combatText.text = ce.Dodge (p, roomArray2d, m.xCoordinate, m.yCoordinate);
}

public void setUseHealingPotionText(Player p)
{
	HealingPotion pot = p.getHealingPotion();
	if (pot != null) {
		lootText.text = pot.drink (p);
		p.removeItem (pot);
	} else {
		lootText.text = "You have no healing potions";
	}
}

public void EscapeMonster (Room r)
{
	if (r.RoomMonster != null) {
		Monster mon = r.RoomMonster;
			int playerDamage = p.hurt (Mathf.Clamp(mon.strength - p.defense,1,100000));
		if (p.currentHealth<=0) {
			Application.LoadLevel (2);
		}
		combatText.text = "You tried to escape, the " + mon.actorName + " hurts you for " + playerDamage;
	}
	else if (r.RoomBoss != null) {
		Boss boss = r.RoomBoss;
			int playerDamage = p.hurt (Mathf.Clamp(boss.strength - p.defense,1,10000));
		if (p.currentHealth<=0) {
			Application.LoadLevel (2);
		}
		combatText.text = "You tried to escape, the " + boss.actorName + " hurts you for " + playerDamage;
	}
}

public void LoadGameFromSessionData (SessionData sd){

	LoadedDataUpdater ldu = new LoadedDataUpdater ();
	p = ldu.LoadPlayer (sd.p);
	m = ldu.LoadMovement (sd.m);
	roomArray2d = ldu.LoadFloor (sd.roomArray2d);
	map.ClearMap ();
	map.CreateMap (roomArray2d);
}


public void MoveNextFloor(Room r, Map map, Movement m)
{
	if (r.checkForMonster (r) == null) {
		roomArray2d = f.Floor1 (m);
		floorNumber++;
		map.CreateMap (roomArray2d);
		setMoveText (r);
	} else if (r.checkForMonster (r) != null) {
		int number = Random.Range (1, 10);
		if (number >= 9) {
			setMoveText (m.getCurrentRoom (roomArray2d));
		} else {
			EscapeMonster (r);
		}
	}
}
} 

	
