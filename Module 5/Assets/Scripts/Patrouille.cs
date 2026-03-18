using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrouille : MonoBehaviour
{
    [SerializeField] private List<GameObject> pointsPatrouille;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private NavMeshAgent agent;
    private Animator animateur;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animateur = GetComponent<Animator>();

        animateur.SetBool("Walk", true);
        PointAleatoire();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            PointAleatoire();
        }
    }

    private void PointAleatoire()
    {
        int nombreAleatoire = Random.Range(0, pointsPatrouille.Count);
        Vector3 pointSelectionne = pointsPatrouille[nombreAleatoire].transform.position;
        agent.SetDestination(pointSelectionne);
    }
}
