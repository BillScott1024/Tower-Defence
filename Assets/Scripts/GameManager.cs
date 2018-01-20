using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public GameObject endUI;
	public Text endMessage;

	public static GameManager Instance;
	private EnemySpawner enemySpawner;
	void Awake()
	{
		Instance = this;
		enemySpawner = GetComponent<EnemySpawner> ();
	}
	// Use this for initialization

	public string SceneName;
	
	

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	 public void Win()
	{
		endUI.SetActive (true);
		endMessage.text = "胜 利";
	}
	public	void Failed()
	{
		enemySpawner.Stop();
		endUI.SetActive (true);
		endMessage.text = "失 败";
	}


	public void OnButtonRetry()
	{
		Application.LoadLevel ("MainScene");
	}
	public void OnButtonMenu()
	{

		Application.LoadLevel ("Menu");
	}

	public void OnButtonNext()
	{
		if (Application.loadedLevel == 1) {
			Application.LoadLevel ("Level_2");
		}else if (Application.loadedLevel == 2) {
			Application.LoadLevel ("Level_3");
		}

	}
}




