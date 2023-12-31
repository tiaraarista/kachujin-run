﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = -5.0f;
	private float tileLength = 12.0f;
	private float safeZone = 15.0f;
	private int amnTilesOnScreen = 5;
	private int lastPrefabsIndex = 0;

	private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
		activeTiles = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < amnTilesOnScreen; i++) {
			if (i < 2)
				SpawnTile (0);
			else
				SpawnTile ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength)) {
			SpawnTile ();
			DeleteTile ();
		}
	}

	private void SpawnTile(int PrefabIndex = -1){
		GameObject go;

		if (PrefabIndex == -1)
			go = Instantiate (tilePrefabs [RandomPrefabsIndex ()]) as GameObject;
		else
			go = Instantiate (tilePrefabs [PrefabIndex]) as GameObject;

		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}

	private void DeleteTile(){
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}

	private int RandomPrefabsIndex(){
		if (tilePrefabs.Length <= 1)
			return 0;

		int randomIndex = lastPrefabsIndex;
		while (randomIndex == lastPrefabsIndex) {
			randomIndex = Random.Range (0, tilePrefabs.Length);
		}
		lastPrefabsIndex = randomIndex;
		return randomIndex;
	}
}
