using UnityEngine;

public class ObjectifFinal : MonoBehaviour
{

    [SerializeField] private GameObject sphere;
    private MouvementSphere mouvementJoueur;
    private bool estEnAttente;
    private float temps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estEnAttente)
        {
            temps += Time.deltaTime;
        }
        if (temps >= 2)
        {
            temps = 0;
            estEnAttente = false;
            mouvementJoueur = sphere.GetComponent<MouvementSphere>();
            mouvementJoueur.TeleporterJoueur();
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == sphere)
        {
            estEnAttente = true;
        
          
        }
    }
}
