using UnityEngine;
using System.Collections;
[System.Serializable]
public class TurretData{
	public GameObject turretPrefab;
	public int cost;
	public GameObject turretUpgradedPrefab;
	public int costUpgraded;
	public TurretType type;
}


public enum TurretType
{
	LaserTurret,
	MissileTurret,
	StandardTurret
}