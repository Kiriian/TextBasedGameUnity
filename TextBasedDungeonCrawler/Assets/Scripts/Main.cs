using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	private Movement m;
	public Text roomDescriptionText;
	public Text movementText;
	public Text combatText;
	public Text lootText;
	public Text health;
	public Text mana;
	private Player p;
	private Room[,] roomArray2d;
	private CombatEngine ce;
	private Floor f;
	private Room r;

	void Start () {
		f = ScriptableObject.CreateInstance<Floor> ();
		p = ScriptableObject.CreateInstance<Player> ();
		p.InitTestPlayer();

		m = ScriptableObject.CreateInstance<Movement>();

		ce = ScriptableObject.CreateInstance<CombatEngine> ();

		roomArray2d = f.Floor1 ();

		roomDescriptionText.text = m.getCurrentRoom (roomArray2d).Description;
		movementText.text = m.Options (m.getCurrentRoom(roomArray2d));
	}

	void Update()
	{
		health.text = "Health:\t" + p.currentHealth;
		mana.text = "Mana:\t" + p.currentMana;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			r = m.MoveSouth (roomArray2d);
			movementText.text = m.Options (r);
			roomDescriptionText.text = r.Description;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			r = m.MoveNorth (roomArray2d);
			movementText.text = m.Options (r);
			roomDescriptionText.text = r.Description;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			r = m.MoveEast (roomArray2d);
			movementText.text = m.Options (r);
			roomDescriptionText.text = r.Description;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			r = m.MoveWest (roomArray2d);
			movementText.text = m.Options (r);
			roomDescriptionText.text = r.Description;
		} else if (Input.GetKeyDown (KeyCode.I)) {
			if (m.getCurrentRoom(roomArray2d).Items.Count == 0) {
				lootText.text = "The room is empty.";
			} else {
				lootText.text = "The rooms contains: " + (m.getCurrentRoom(roomArray2d).Items[0].Name);
			}

		} else if (Input.GetKeyDown (KeyCode.Space) && m.getCurrentRoom(roomArray2d).EntranceToNextFloor == true) {
			roomArray2d = f.Floor2();
			r = m.MoveSouth (roomArray2d);
			movementText.text = m.Options (r);
			roomDescriptionText.text = r.Description;
		} else if (Input.GetKeyDown(KeyCode.A)){
			combatText.text = ce.Attack (p,roomArray2d,m.xCoordinate,m.yCoordinate);	
		} else if (Input.GetKeyDown(KeyCode.P)) {
			p.addItem (m.getCurrentRoom (roomArray2d).Items [0]);
			lootText.text = "You pick up the " + (m.getCurrentRoom(roomArray2d).Items[0].Name);
			m.getCurrentRoom (roomArray2d).Items.RemoveAt (0);
		} else if (Input.GetKeyDown(KeyCode.M)) {
			string items = p.GiveHeldItems();
			lootText.text = items;
		}
	}
}
	
