using UnityEngine;
using TMPro;
public class Jeu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject sphereActive;

    private int points;

    [SerializeField]
    private TMP_Text pointsText;

    private Vector3 positionInitiale;


    void Start()
    {

        points = 0;
        pointsText.text = "0";
        positionInitiale = sphereActive.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == sphereActive)
        {
            AugmenterPoints();
            GameObject nouvelleSphere = Instantiate(sphereActive);
            nouvelleSphere.transform.position = positionInitiale;
            GameObject.Destroy(sphereActive);
            sphereActive= nouvelleSphere;
        }
    }
    void AugmenterPoints()
    {
        points++;
        pointsText.text = points.ToString();
    }
}
