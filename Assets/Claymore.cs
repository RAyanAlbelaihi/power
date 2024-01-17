using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Claymore : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffectPrefab;
    [SerializeField] private AudioSource audioSourcePrefab;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private AudioClip impactSound;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 700f;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && (other.CompareTag("Player") || other.CompareTag("Bullet")))
        {
            hasTriggered = true;
            Debug.Log("Claymore triggered by: " + other.gameObject.name);

            
            if (other.gameObject.tag == "Player")
            {
                //helth take damge 
            }
            Explosion();
        }
    }

    void Explosion()
    {
        GameObject explosionEffect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        Destroy(explosionEffect, 4f);

        PlaySoundAtPosition(explosionSound);

        NearByForceApply();

        Destroy(gameObject);
    }
    void NearByForceApply()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Adjust the explosion force application based on your preferences
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
    void PlaySoundAtPosition(AudioClip clip)
    {
        audioSourcePrefab.clip = clip;
        audioSourcePrefab.spatialBlend = 1;
        audioSourcePrefab.PlayOneShot(impactSound, 0.1f);
    }
}
