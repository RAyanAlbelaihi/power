using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
    // Perfab
    [SerializeField] private GameObject explosionEffectPrefab;
    [SerializeField] private Vector3 explosionParticaleOffset = new Vector3(0, 1, 0);
    [SerializeField] private AudioSource audioSourcePrefab;
    //Settings
    [SerializeField] private float explosionDelay = 3f;
    [SerializeField] private float explosionForce = 700f;
    [SerializeField] private float explosionRadius = 5f;
    // Audio Effects
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private AudioClip impactSound;
     XRGrabInteractable XRGrabInteractable;


    private float countdown;
    private bool isSelected = false;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable = GetComponent<XRGrabInteractable>();
        countdown = explosionDelay;
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       if( XRGrabInteractable.isSelected)
        {
            isSelected = true;
        }
       if(isSelected)
        {
            StartCountdown();
        }
    }
    public void StartCountdown()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Explosion();
            isSelected = false;
        }
    }
        
    void Explosion()
    {
        GameObject explosionEffect = Instantiate(explosionEffectPrefab, transform.position + explosionParticaleOffset, Quaternion.identity);

        Destroy(explosionEffect, 4f);


        PlaySoundAtPosition(explosionSound);

        NearByForceApply();

        Destroy(gameObject);
    }

    void PlaySoundAtPosition(AudioClip clip)
    {
        audioSourcePrefab.clip = clip;
        audioSourcePrefab.spatialBlend = 1;
        audioSourcePrefab.PlayOneShot(impactSound,0.1f);
    }

    void NearByForceApply()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearByObject in colliders)
        {
            Rigidbody rb = nearByObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            if (nearByObject.gameObject.tag == "Player")
            {
                //helth take damge 
            }
        }
    }
}
