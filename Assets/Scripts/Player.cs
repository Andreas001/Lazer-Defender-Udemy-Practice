using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player Variables
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float padding = 1f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    #endregion

    #region Unity Callback Functions
    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
    }
    #endregion

    #region Functions
    //Set player play area function
    //Player play area is determined by the game camera using VIewportToWorldPoint
    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    //Player move function
    //Still using the old input system
    //Taking the horizontal and vertical input axis times them with moveSpeed and Time.deltaTime and then adding them to the current position to make the new position.
    //Player movement is clamped using the variables that have been set in SetUpMoveBounderies Function
    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        var deltaY = Input.GetAxis("Vertical") * moveSpeed *Time.deltaTime;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    #endregion
}
