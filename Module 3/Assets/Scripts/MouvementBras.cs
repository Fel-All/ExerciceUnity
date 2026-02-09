using UnityEngine;

public class MouvementBras : MonoBehaviour
{
    private float vitesseRotation = 150f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vitesseRotation * Time.deltaTime, 0f, 0f);
    }
}
