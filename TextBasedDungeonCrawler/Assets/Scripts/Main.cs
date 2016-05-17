using UnityEngine;
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

	public Text playerName;
	public Text roomDescriptionText;
	public Text movementText;
	public Text combatText;
	public Text lootText;
	public Text health;
	public Text mana;
	public Text strength;
	public Text defense;


	void Start () {
		f = ScriptableObject.CreateInstance<Floor> ();
		p = ScriptableObject.CreateInstance<Player> ();
		p.InitTestPlayer();

		m = ScriptableObject.CreateInstance<Movement>();

		ce = ScriptableObject.CreateInstance<CombatEngine> ();

		roomArray2d = f.Floor1 ();
		r = m.getCurrentRoom (roomArray2d);
		setMoveText (r);

		playerName.text = p.actorName;

		map = ScriptableObject.CreateInstance<Map>();
		map.CreateMap (roomArray2d);
	}

	void Update ()
	{
		health.text = "Health:\t" + p.currentHealth;
		mana.text = "Mana:\t" + p.currentMana;
		defense.text = "Defense:\t" + p.defense;
		strength.text = "Strength:\t" + p.strength;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (r.checkForMonster(r) == null) {
				r = m.MoveSouth (roomArray2d);
				setMoveText (r);
			} else if (r.checkForMonster(r) != null) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 8) {
					r = m.MoveSouth (roomArray2d);
					setMoveText (r);
				} else {
					EscapeMonster (r);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (r.checkForMonster(r) == null) {
				r = m.MoveNorth (roomArray2d);
				setMoveText (r);
			} else if (r.checkForMonster(r) != null) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 8) {
					r = m.MoveNorth (roomArray2d);
					setMoveText (r);
				} else {
					EscapeMonster (r);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (r.checkForMonster(r) == null) {
				r = m.MoveEast (roomArray2d);
				setMoveText (r);
			} else if (r.checkForMonster(r) != null) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 8) {
					r = m.MoveEast (roomArray2d);
					setMoveText (r);
				} else {
					EscapeMonster (r);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			r = m.MoveWest (roomArray2d);
			setMoveText (r);
		} else if (Input.GetKeyDown (KeyCode.I)) {
			setLootText (m, roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.Space) && m.getCurrentRoom (roomArray2d).EntranceToNextFloor == true) {
			if (r.checkForMonster(r) == null) {
				roomArray2d = f.Floor1 ();
				map.CreateMap (roomArray2d);
				r = m.MoveNorth (roomArray2d);
				setMoveText (r);
			} else if (r.checkForMonster(r) != null) {
				int number = UnityEngine.Random.Range (1, 10);
				if (number >= 8) {
					r = m.MoveNorth (roomArray2d);
					setMoveText (r);
				} else {
					EscapeMonster (r);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.A)) {
			setAttackCombatText (ce, roomArray2d, p, m);
		} else if (Input.GetKeyDown (KeyCode.P)) {
			setPickUpLootText (m, p, r);
		} else if (Input.GetKeyDown (KeyCode.M)) {
			setInventoryText (p);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			setDodgeCombatText (ce, roomArray2d, p, m);
		} else if (Input.GetKeyDown (KeyCode.Q)) {
			setUseHealingPotionText (p);
		} else if (Input.GetKeyDown (KeyCode.V)) {
			SaveGame sg = new SaveGame ();
			SessionData sd = new SessionData (roomArray2d, m, p);
			sg.Save (sd);
		} else if (Input.GetKeyDown (KeyCode.B)) {
			LoadGame lg = new LoadGame ();
 		    SessionData sd = lg.Load ();
			LoadGameFromSessionData (sd);
		}

	}

	public void ScreenButtonPressed (int buttonID){
		bt = ScriptableObject.CreateInstance<ButtonClicked> ();

		bt.CheckButtonPressed (roomArray2d, m, this, buttonID, ce, p);
	
	}

	public void setMoveText(Room r)
	{
		lootText.text = "";
		movementText.text = m.Options (r);
		roomDescriptionText.text = r.Description;
		combatText.text = r.checkForMonster (r);
	}

	public void setLootText(Movement m, Room[,] roomArray)
	{
		if (m.getCurrentRoom (roomArray).Items.Count == 0) {
			lootText.text = "The room is empty.";
		} else {
			lootText.text = "The rooms contains: " + (m.getCurrentRoom (roomArray).Items [0].Name);
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

		if (r.Items.Count != 0) {
			if (r.Items [0].GetType () == typeof(Equipment)) {
				newEquipment = (Equipment)r.Items [0];
				oldEquipment = p.addEquipment (newEquipment);
				Debug.Log ("Returned equipment is: " + oldEquipment.itemName);
				r.Items.RemoveAt (0);
				r.Items.Add (oldEquipment);
				lootText.text = "You equip the " + (newEquipment.Name);
				Debug.Log ("from when you pick something up. " + r.Items [0].itemName);
			} else {
				p.addItem (r.Items [0]);
				lootText.text = "You pick up the " + (r.Items [0].itemName);
				r.Items.RemoveAt (0);
			}
		} else {
			lootText.text = "There is nothing to pick up";
		}
	}

	public void setInventoryText (Player p)
	{
		string items = p.GiveHeldItems ();
		lootText.text = items;
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
			int playerDamage = p.hurt (mon.strength - p.defense);
			if (p.currentHealth<=0) {
				Application.LoadLevel (2);
			}
			combatText.text = "You tried to escape, the Monster hurts you for " + playerDamage;
		}
		else if (r.RoomBoss != null) {
			Boss boss = r.RoomBoss;
			int playerDamage = p.hurt (boss.strength - p.defense);
			if (p.currentHealth<=0) {
				Application.LoadLevel (2);
			}
			combatText.text = "You tried to escape, the Monster hurts you for " + playerDamage;
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
}
	
