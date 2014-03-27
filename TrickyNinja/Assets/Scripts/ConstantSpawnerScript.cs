﻿//Constant spawner script
//By Jason Ege, last edited on March 20, 2014 @ 10:15am
//Spawns constant enemies at the spawner's location when the player gets near to the spawner.
//Spawners can have a limit on how many enemies they spawn or can have no limit.

using UnityEngine;
using System.Collections;

public class ConstantSpawnerScript : EntityScript {

	public Vector3 vOffset;
	public Vector3 vRotateOffset;
	public bool bInhibit;
	public int iMaxEnemiesToSpawn;
	public float fActivationDistance;
	public float fTimeBetweenEnemies;
	public GameObject gEnemyToSpawn;
	InputCharContScript scrptInput;
	
	GameObject gPlayer;		//The active player object.
	GameObject[] agPlayer;	//The player array used to find the player.

	int iEnemiesSpawned;
	float fTimer;

	// Use this for initialization
	void Start () {
		iEnemiesSpawned = 0;
		fTimer = 0;
		vSpawnPoint = transform.position;
		scrptInput = CameraScriptInGame.GrabMainCamera().transform.parent.GetComponent<InputCharContScript>();
		//agPlayer = GameObject.FindGameObjectsWithTag("Player"); //The player is any object tagged as the player.
	}
	
	bool PlayerIsInRange()
	{
		for(int i = 0; i < scrptInput.agPlayer.Length; i++)
		{
			PlayerScriptSteven playerScript;
			playerScript = scrptInput.agPlayer[i].GetComponent<PlayerScriptSteven>();
			if(!playerScript.bIncorporeal)
			{
				gPlayer = scrptInput.agPlayer[i];
			}
		}
		float fDistanceBetweenSpawnPointAndEnemy = Mathf.Abs (Vector3.Distance (transform.position, gPlayer.transform.position));
		if (Mathf.Abs (Vector3.Distance(transform.position, gPlayer.transform.position)) < fActivationDistance)
		{
			return true;
		}
		return false;
	}
	
	// Update is called once per frame
	void Update () {
		fTimer += Time.deltaTime;
		if (PlayerIsInRange() && fTimer > fTimeBetweenEnemies)
		{
			if (iEnemiesSpawned < iMaxEnemiesToSpawn)
			{
				Instantiate (gEnemyToSpawn, vSpawnPoint + vOffset, Quaternion.Euler (vRotateOffset));
				fTimer = 0;
				if (bInhibit == true)
				{
					iEnemiesSpawned++;
				}
			}
		}
	}
}
