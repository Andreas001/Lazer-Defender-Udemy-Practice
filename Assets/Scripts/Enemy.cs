using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    [SerializeField]
    float health = 100f;
    [SerializeField]
    float shotCounter;
    [SerializeField]
    float minTimeBetweenShots = 0.2f;
    [SerializeField]
    float maxTimeBetweenShots = 3f;
    [SerializeField]
    float projectileSpeed = 15f;

    [SerializeField]
    GameObject lazerPrefab;
    #endregion

    #region Unity Callback Functions
    void Start()
    {
        ResetShootCounter();
    }

    void Update()
    {
        CountDownAndShoot();
    }
    #endregion

    #region Functions
    private void ResetShootCounter() {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void CountDownAndShoot() {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f) {
            Fire();
            ResetShootCounter();
        }
    }

    private void Fire() {
        GameObject lazer = Instantiate(lazerPrefab, transform.position, Quaternion.identity) as GameObject;
        lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
    #endregion
}
