using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    #region EnemyPathing Variables
    [SerializeField]
    WaveConfig waveConfig;
    [SerializeField]
    List<Transform> waypoints;

    int waypointIndex = 0;
    #endregion

    #region Unity Callback Functions
    //Local waypoint variable is updated with WaveConfig waypoint
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }
    #endregion

    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }

    #region Functions
    //Move Function
    //While waypoint index is still lower than the waypoint count minus one it will keep running
    //Do a simple move towards target that is the next waypoint
    //Waypoint is increased by one at the end
    //If there are no more waypoints the gameobject is destroyed
    private void Move() {
        if (waypointIndex <= waypoints.Count - 1) {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition) {
                waypointIndex += 1;
            }
        }
        else {
            Destroy(gameObject);
        }
    }
    #endregion
}
