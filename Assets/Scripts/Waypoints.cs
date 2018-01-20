using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

	public static Transform[] positions;

	// Use this for initialization
	void Awake()
	{
		positions = new Transform[transform.childCount];
		for (int i = 0; i<positions.Length; i++) {
			positions[i] = transform.GetChild(i);
		}

	}
}
