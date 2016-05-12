using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class LoadGame : MonoBehaviour {

	public void Load(){
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat");
			SessionData data = (SessionData)bf.Deserialize (file);
			file.Close ();
		}
	}
}
