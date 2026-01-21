using UnityEngine;

public class Exercice2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool grandissementActif = true;

    Vector3 vecteurCroissance = new Vector3(0.1f, 0.1f, 0.1f);

    [SerializeField] private float vitesseTransformation;
    void Start()
    {
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log("Magnitude initiale" + transform.localScale.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 croissance = vitesseTransformation * Time.deltaTime * vecteurCroissance;
        if (grandissementActif)
        {
            transform.localScale += croissance;
        }
        else
        {
            transform.localScale -= croissance;
        }

        if (transform.localScale.magnitude >= 8.0f)
        {
            grandissementActif = false;
        }
        else if (transform.localScale.magnitude <= 2.0f)
        {
            grandissementActif = true;
        }
    }
}
