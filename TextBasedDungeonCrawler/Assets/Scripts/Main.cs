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
		setText (r);

		playerName.text = p.actorName;
	}

	void Update()
	{
		health.text = "Health:\t" + p.currentHealth;
		mana.text = "Mana:\t" + p.currentMana;
		defense.text = "Defense:\t" + p.defense;
		strength.text = "Strength:\t" + p.strength;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			r = m.MoveSouth (roomArray2d);
			setText (r);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			r = m.MoveNorth (roomArray2d);
			setText (r);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			r = m.MoveEast (roomArray2d);
			setText (r);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			r = m.MoveWest (roomArray2d);
			setText (r);
		} else if (Input.GetKeyDown (KeyCode.I)) {
			setLootText (m, roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.Space) && m.getCurrentRoom (roomArray2d).EntranceToNextFloor == true) {
			roomArray2d = f.Floor2 (m);
			r = m.MoveNorth (roomArray2d);
			setText (r);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			setAttackCombatText (ce, roomArray2d, p, m);
		} else if (Input.GetKeyDown (KeyCode.P)) {
			setPickUpLootText (m, p);
		} else if (Input.GetKeyDown (KeyCode.M)) {
			setInventoryText (p);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			setDodgeCombatText (ce, roomArray2d, p, m);
		} else if (Input.GetKeyDown (KeyCode.Q)) {
			setUseHealingPotionText (p);
		}
	}

	public void ScreenButtonPressed (int buttonID){
		bt = ScriptableObject.CreateInstance<ButtonClicked> ();

		bt.CheckButtonPressed (roomArray2d, m, this, buttonID, ce, p);
	
	}

	public void setText(Room r)
	{
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

	public void setPickUpLootText(Movement m, Player p)
	{
		if (m.getCurrentRoom (roomArray2d).Items.Count != 0) {
			p.addItem (m.getCurrentRoom (roomArray2d).Items [0]);
			lootText.text = "You pick up the " + (m.getCurrentRoom (roomArray2d).Items [0].Name);
			m.getCurrentRoom (roomArray2d).Items.RemoveAt (0);
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
}
	
