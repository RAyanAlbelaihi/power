using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_hit : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            audioSource.Play();
            gameObject.SetActive(false);
            Destroy(gameObject,2f);
        }
    }
   
}
