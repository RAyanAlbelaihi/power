using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public AudioSource sfx;
    public ParticleSystem efx;
    [SerializeField] GameObject _mid;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //play sfx
            sfx.Play();
            //play efx
            efx.Play();
            //heal player
            var healthComponent = other.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.Heal(60);
            }
            _mid.SetActive(false);
            Destroy(gameObject,2f);
        }
    }
}