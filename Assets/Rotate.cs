using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Quaternion originalRotation;
    public float maxRotationAngle = 40f;
    public float rotationDuration = 2.0f;
    public float maxFluctuation = 5f;

    void Start()
    {
        // Save the original rotation of the object
        originalRotation = transform.rotation;

        // Start the rotation coroutine
        StartCoroutine(UnstableRotateObjectCoroutine());
    }

    IEnumerator UnstableRotateObjectCoroutine()
    {
        while (true)
        {
            // Rotate the object to a random angle within the specified range
            float randomAngle = Random.Range(-maxRotationAngle, maxRotationAngle);
            Quaternion targetRotation = originalRotation * Quaternion.Euler(randomAngle, 0f, 0f);

            float duration = rotationDuration + Random.Range(-maxFluctuation, maxFluctuation);

            float elapsed = 0f;

            while (elapsed < duration)
            {
                transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Wait for a moment (you can adjust the duration or remove this part)
            yield return new WaitForSeconds(1.0f);
        }
    }
}
