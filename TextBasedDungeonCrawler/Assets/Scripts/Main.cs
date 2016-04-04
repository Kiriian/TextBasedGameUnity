using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	private Movement m;
	public Text textfield;
	public Text playerInfo;
	private Player p;
	private Room[,] roomArray2d;
	private CombatEngine ce;
	private Floor f;

	void Start () {
		f = ScriptableObject.CreateInstance<Floor> ();
		p = ScriptableObject.CreateInstance<Player> ();
		p.InitTestPlayer();

		m = ScriptableObject.CreateInstance<Movement>();

		ce = ScriptableObject.CreateInstance<CombatEngine> ();

		roomArray2d = f.Floor1 ();

		textfield.text += m.getCurrentRoom (roomArray2d).Description + "\r\n" + m.Options(m.getCurrentRoom(roomArray2d));
	}

	void Update()
	{
		playerInfo.text = "Health:\t" + p.currentHealth;

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			textfield.text += "\r\n" + m.MoveSouth(roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			textfield.text += "\r\n" + m.MoveNorth(roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			textfield.text += "\r\n" + m.MoveEast(roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			textfield.text = "\r\n" + m.MoveWest(roomArray2d);
		} else if (Input.GetKeyDown (KeyCode.I)) {
			textfield.text += "\r\n" + "The rooms contains: " + (m.getCurrentRoom(roomArray2d).Items[0].Name);
		} else if (Input.GetKeyDown (KeyCode.Space) && m.getCurrentRoom(roomArray2d).EntranceToNextFloor == true) {
			roomArray2d = f.Floor2();
			textfield.text = "";
			textfield.text += "\r\n" + m.MoveSouth (roomArray2d);
		} else if (Input.GetKeyDown(KeyCode.A)){
			textfield.text += "\r\n" + ce.Attack (roomArray2d,m.xCoordinate,m.yCoordinate);	
		}
	}
}
	
