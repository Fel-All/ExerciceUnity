using UnityEngine;

public class Exercice1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
       bool grandissementActif = true;

       Vector3 tauxCroissance = new Vector3 (0.1f, 0.1f, 0.1f);
    void Start()
    {
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Magnitude initiale" + transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        if (grandissementActif)
        {
            transform.localScale += tauxCroissance;
        }
        else if (!grandissementActif)
        {
            transform.localScale -= tauxCroissance;
        }
        if (transform.localScale.magnitude >= 8.0f)
        {
            grandissementActif = false;
        } else if (transform.localScale.magnitude <= 2.0f)
        {
            grandissementActif = true;
        }
    }
}
