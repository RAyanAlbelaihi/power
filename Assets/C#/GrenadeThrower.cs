using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    // grenade Prefab
    [SerializeField] private GameObject grenadePrefab;
    // Grenade Settings
    [SerializeField] private KeyCode throwKey = KeyCode.Mouse0;
    [SerializeField] private Transform throwposition;
    [SerializeField] private Vector3 throwDirection = new Vector3(0, 1, 0);
    // Grenade Force
    [SerializeField] private float throwForce = 20f;
    [SerializeField] private float maxForce = 20f;

    private bool isCharging = false;
    private float chargeTime = 0f;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    void handel()
    {
        if (Input.GetKeyDown(throwKey))
        {
            startThrowing();
        }
        if (isCharging)
        {
            ChargeThrow();
        }
        if (Input.GetKeyDown(throwKey))
        {
            ReleaseThrow();
        }
    }

    void startThrowing()
    {
        // pull pin sound

        isCharging = true;
        chargeTime = 0f;

        // trajectory 
    }

    void ChargeThrow()
    {
        chargeTime += Time.deltaTime;

        // trajectory
    }

    void ReleaseThrow()
    {
        ThrowGreneade(Mathf.Min(chargeTime * throwForce, maxForce));
        isCharging = false;
    }

    void ThrowGreneade(float force)
    {
        Vector3 spawnPosition = throwposition.position + mainCamera.transform.forward;

        GameObject grenade = Instantiate(grenadePrefab, spawnPosition, mainCamera.transform.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        Vector3 finalThrowDirection = (mainCamera.transform.forward + throwDirection).normalized;

        rb.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);

        //
    }
    // Update is called once per frame
    void Update()
    {
        handel(); 
    }
}
