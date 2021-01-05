using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    int damage = 100;

    [SerializeField]
    AudioClip deathSfx;

    [SerializeField]
    GameObject deathVfxPrefab;

    [SerializeField]
    float durationOfExplosion = 0.1f;

    [SerializeField]
    [Range(0,1)] float deathSfxVolume = 0.7f;

    public int GetDamage() {
        return damage;
    }

    public void Hit() {
        Destroy(gameObject);
        if(deathVfxPrefab != null) {
            GameObject explosion = Instantiate(deathVfxPrefab, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, deathSfxVolume);
        }
    }
}
