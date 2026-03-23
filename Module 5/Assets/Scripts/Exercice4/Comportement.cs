using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Comportement : MonoBehaviour
{
    [SerializeField]  public List<GameObject> pointsPatrouille;
    [SerializeField]  public GameObject Joueur;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animateur;

    public Etat currentEtat;
    public EtatAttaque etatAttaque;
    public EtatAttente etatAttente;
    public EtatPatrouille etatPatrouille;
    public EtatPoursuite etatPoursuite;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animateur = GetComponent<Animator>();

        etatPatrouille = new EtatPatrouille(this);
        etatAttaque = new EtatAttaque(this);
        etatPoursuite = new EtatPoursuite(this);    
        etatAttente = new EtatAttente(this);

        currentEtat = etatPatrouille;
        currentEtat.Commencer();
    }

    void Update()
    {
        currentEtat.FaireAction(Time.deltaTime);

    }

    public void ChangerEtat(Etat newState)
    {
        if (currentEtat == newState) return;
        currentEtat.Arrêter();
        currentEtat = newState;
        currentEtat.Commencer();
    }
    public bool ChercherJoueur()
    {
        Vector3 directionJoueur = (Joueur.transform.position - transform.position).normalized;

        float angle = Vector3.Angle(transform.forward,directionJoueur);
        if (angle <= 60f)
        {
            if (Physics.Raycast(transform.position, directionJoueur, out RaycastHit hit))
            { 

                if (hit.collider.gameObject == Joueur)
                {
                    return true;
                }
            }    
        }

        return false;

    }

}
