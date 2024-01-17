using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public GameObject _bulletHolePefab;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            var healthComponent = other.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Bomb")
        {
            //Make it explode

            //destroy the bullet
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Instantiate(_bulletHolePefab, gameObject.transform.position, Quaternion.identity);
            text_count.score += 10;
            //destroy the bullet
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Object")
        {
            Instantiate(_bulletHolePefab, gameObject.transform.position, Quaternion.identity);

            //destroy the bullet
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
