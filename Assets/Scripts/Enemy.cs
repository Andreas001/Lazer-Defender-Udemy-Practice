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
    float durationOfExplosion = 1f;
    [SerializeField]
    [Range(0, 1)] float deathSfxVolume = 0.7f;
    [SerializeField]
    int scoreValue = 100;

    [SerializeField]
    GameObject lazerPrefab;
    [SerializeField]
    GameObject deathVfxPrefab;
    [SerializeField]
    AudioClip deathSfx;
    [SerializeField]
    AudioClip shootSfx;
    [SerializeField]
    [Range(0, 1)] float shootSfxVolume = 0.25f;
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
        AudioSource.PlayClipAtPoint(shootSfx, Camera.main.transform.position, shootSfxVolume);
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
            Die();
        }
    }

    private void Die() {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVfxPrefab, transform.position, transform.rotation)  ;
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, deathSfxVolume);
    }
    #endregion
}
