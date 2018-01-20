using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class MapCube : MonoBehaviour {
	[HideInInspector]
	public GameObject turretGO; //保存Cube上的炮台
	public GameObject buildEffect;
	[HideInInspector]
	public bool isUpgraded = false;
	private Renderer renderer;
	[HideInInspector]
	public TurretData turretData;
	void Start()
	{
		renderer = GetComponent<Renderer> ();
	}
	public void BuildTurret(TurretData turretData)
	{
		isUpgraded = false;
		this.turretData = turretData;
		turretGO = GameObject.Instantiate(turretData.turretPrefab,transform.position,Quaternion.identity) as GameObject;
		GameObject effect = GameObject.Instantiate(buildEffect,transform.position,Quaternion.identity) as GameObject;

		Destroy (effect, 1);
	}

	public void UpgradeTurret( )
	{
		if (isUpgraded)
			return;
		Destroy (turretGO);
		isUpgraded = false;
		turretGO = GameObject.Instantiate(turretData.turretUpgradedPrefab,transform.position,Quaternion.identity) as GameObject;

		GameObject effect = GameObject.Instantiate(buildEffect,transform.position,Quaternion.identity) as GameObject;
		
		Destroy (effect, 1.5f);

	}

	public void DestroyTurret()
	{
		Destroy (turretGO);
		isUpgraded = false;
		turretGO = null;
		turretData = null;

		GameObject effect = GameObject.Instantiate(buildEffect,transform.position,Quaternion.identity) as GameObject;
		
		Destroy (effect, 1.5f);
	}
	void OnMouseEnter()
	{
		if (turretGO == null && EventSystem.current.IsPointerOverGameObject () == false) {
			renderer.material.color = Color.green;
		} else if(EventSystem.current.IsPointerOverGameObject () == false){
			renderer.material.color = Color.red;
		}


	}
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
}
