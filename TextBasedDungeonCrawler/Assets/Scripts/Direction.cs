using UnityEngine;
using System.Collections;

public class Direction : ScriptableObject {

	private string directionName;

	public Direction ()
	{
	}

	public string DirectionName
	{
		get { return this.directionName; }
		set { this.directionName = value; }
	}
}
