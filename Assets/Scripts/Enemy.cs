﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	
	public float speed = 10;
	public float hp = 150;
	private float totalHp;
	public GameObject explosionEffect;
	private Slider hpSlider;
	private Transform[] positions;
	private int index = 0;
	
	
	// Use this for initialization
	void Start () {
		positions = Waypoints.positions;
		totalHp = hp;
		hpSlider = GetComponentInChildren<Slider>();
	}

	// Update is called once per frame
	void Update () {
		Move();
	}
	
	
	void Move()
	{
		if (index > positions.Length - 1) return;
		transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
		if (Vector3.Distance(positions[index].position, transform.position) < 0.5f)
		{
			index++;
		}
		if (index > positions.Length - 1)
		{
			ReachDestination();
		}
	}

	void ReachDestination()
	{
		GameManager.Instance.Failed();
		GameObject.Destroy(this.gameObject);
	}
	
	
	void OnDestroy()
	{
		EnemySpawner.CountEnemyAlive--;
	}
	
	public void TakeDamage(float damage)
	{
		if (hp <= 0) return;
		hp -= damage;
		hpSlider.value = (float)hp / totalHp;
		if (hp <= 0)
		{
			Die();
			BuildManager.Instance.ChangeMoney(10);
		}
	}
	void Die()
	{
		GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;
		Destroy(effect, 1.5f);
		Destroy(this.gameObject);
	}
	
}
