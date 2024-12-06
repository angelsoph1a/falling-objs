using UnityEngine;

public class fallobjcontorller : MonoBehaviour
{
    // Delay between spawning objects
    float wait = 0.2f; // Adjusted to slow down spawning
    public GameObject fallingObject;

    // Start is called once before the first execution of Update
    void Start()
    {
        // Repeatedly call the fall method at the specified interval
        InvokeRepeating("fall", wait, wait);
    }

    void fall()
    {
        // Instantiate a falling object at a random position
        GameObject obj = Instantiate(
            fallingObject,
            new Vector3(Random.Range(-10, 10), 10, 0),
            Quaternion.identity
        );

        // Add the custom fall behavior script to the instantiated object
        obj.AddComponent<fallbehavior>().fallSpeed = 2f; // Set fall speed here
    }
}

// Script to control custom fall speed for individual objects
public class fallbehavior : MonoBehaviour
{
    public float fallSpeed = 2f;

    void Update()
    {
        // Move the object down at the specified fall speed
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Destroy the object once it goes below a certain point
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
