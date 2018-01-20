using UnityEngine;
using System.Collections;

public class Gamemenu : MonoBehaviour {

	// Use this for initialization
	 public void OnStartGame()
	{
		Application.LoadLevel ("MainScene");
	}
	public void OnExitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
#endif
		Application.Quit ();
	}
}
