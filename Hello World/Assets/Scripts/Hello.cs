using UnityEngine;

public class Hello : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello, World");
    }

    // Update is called once per frame
    void Update()
    {
        var vitesse = new Vector3(15.0f, 1.0f, 0.0f);

        transform.position += vitesse * Time.deltaTime;
    }
}
