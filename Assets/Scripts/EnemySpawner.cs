using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Variables
    [SerializeField]
    List<WaveConfig> waveConfigs;
    [SerializeField]
    bool looping = false;
    [SerializeField]
    int startingWave = 0;
    #endregion

    #region Unity Callback Functions
    IEnumerator Start()
    {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }
    #endregion

    #region Functions
    //Coroutine for looping start coroutine for all the waveconfig in waveconfigs list
    private IEnumerator SpawnAllWaves() {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++) {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    //Coroutine for spawning all enemies inside a wave using the wave config
    //Creates a var newEnemy and instantiate it (Could use object pooling in the future)
    //Set the wave config in the enemy pathing script to the current wave config and then wait for the time between spawns
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++) {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
    #endregion
}
