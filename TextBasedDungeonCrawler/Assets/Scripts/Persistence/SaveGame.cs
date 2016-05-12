using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class SaveGame : MonoBehaviour {

	// https://www.youtube.com/watch?v=J6FfcJpbPXE
	// Skip to 33:00. Bad video, wastes a huge amount of time before getting to the actual topic.
	// No clue how this is allowed in an official in-house tutorial. Terrible.

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

		SessionData sd = new SessionData();

		bf.Serialize (bf, sd);
		file.Close ();
	}
}
