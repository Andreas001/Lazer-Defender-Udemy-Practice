﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    #region Variables
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject pathPrefab;
    [SerializeField]
    float timeBetweenSpawns = 0.5f;
    [SerializeField]
    float spawnRandomfactor = 0.3f;
    [SerializeField]
    int numberOfEnemies = 5;
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    float waitTimeOnWaypoint = 0.1f;
    #endregion

    #region Getters
    public GameObject GetEnemyPrefab() {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints() {
        var waveWayPoints = new List<Transform>();

        foreach(Transform child in pathPrefab.transform) {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns() {
        return timeBetweenSpawns;
    }

    public float GetNumberOfEnemies() {
        return numberOfEnemies;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public float GetWaitTimeOnWaypoint() {
        return waitTimeOnWaypoint;
    }
    #endregion
}
