using UnityEngine;
using TMPro;


public class GestionnaireJeu : MonoBehaviour
{
   
    [SerializeField]
    private GameObject sphereActive;

    [SerializeField]
    private TMP_Text pointsTexte;

    [SerializeField]
    private ZoneAtteinteSujet zone;

    private Vector3 positionInitiale;
    private int points;
   
    void Start()
    {
        points = 0;
    
        pointsTexte.text = "0";
        
            zone.OnZoneAtteinte += AugmenterPoints;
            zone.OnZoneAtteinte += ReplacerSphere;
        
        positionInitiale = sphereActive.transform.localPosition;
        pointsTexte.text = points.ToString();
    }

    
    private void AugmenterPoints()
    {
       
        Debug.Log("Augmentation points");
       
            points++;
            pointsTexte.text = points.ToString();
        
    }

  
    private void ReplacerSphere()
    {
        Debug.Log("ReplacerSphere");

        GameObject nouvelleSphere = Instantiate(sphereActive);
        GameObject.Destroy(sphereActive);
        nouvelleSphere.transform.localPosition = positionInitiale;
        sphereActive = nouvelleSphere;
        zone.sphereActive = sphereActive;
       
    }
}