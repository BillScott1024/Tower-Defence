using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	public int damage = 50;
	public float speed = 20;
	public GameObject explosionEffectPrefab;


	private Transform target;
	public void SetTarget(Transform _target)
	{
		this.target = _target;
	}

	void Update()
	{
		if (target == null) {
		
			Die();
			return;
		}

		transform.LookAt (target.position);
		transform.Translate (Vector3.forward * speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Enemy") {
			col.GetComponent<Enemy>().TakeDamage(damage);
			Die();

		}
	}

	void Die()
	{
		GameObject effect = GameObject.Instantiate (explosionEffectPrefab, transform.position, transform.rotation) as GameObject;
		Destroy (effect, 1);
		Destroy (this.gameObject);
	}
}
