using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Villageois : MonoBehaviour
{
    [SerializeField]
    private TMP_Text texteOr;

    [SerializeField]
    private TMP_Text textePlantes;

    [SerializeField]
    private TMP_Text texteRoches;

    public int or = 0;
    public int plantes = 0;
    public int roches = 0;
    private int numeroRessourceChoisie = -1;
    private NavMeshAgent navMeshAgent;
    
    private StrategieChoixRessource strategieChoix;

    void Start()
    {
        ChargerStrategie();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (numeroRessourceChoisie == -1)
        {
            AllerVersProchaineRessource();
        }
        // Assez proche pour prendre la ressource
        else if (Vector3.Distance(transform.position, navMeshAgent.destination) < 1.4f)
        {
            TypeRessource typeRessource = GameManager.Instance.ressources[numeroRessourceChoisie].type;

            if (typeRessource == TypeRessource.Or) or++;
            else if (typeRessource == TypeRessource.Plante) plantes++;
            else if (typeRessource == TypeRessource.Roche) roches++;
            
            MiseAJourTextes();

            GameManager.Instance.DetruireRessource(numeroRessourceChoisie);
            AllerVersProchaineRessource();
        }
    }

    public void MiseAJourTextes()
    {
        texteOr.text = "Or: " + or;
        textePlantes.text = "Plantes: " + plantes;
        texteRoches.text = "Roches: " + roches;
    }

    public void ChangerStrategieChoix(StrategieChoixRessource strategie)
    {
        strategieChoix = strategie;
        AllerVersProchaineRessource();
    }

    private void AllerVersProchaineRessource()
    {
        List<Ressource> ressources = GameManager.Instance.ressources;

        if (ressources.Count == 0)
        {
            numeroRessourceChoisie = -1;
        }
        else
        {
            numeroRessourceChoisie = strategieChoix.ChoisirRessource(this, ressources);

            Ressource ressource = ressources[numeroRessourceChoisie];
            navMeshAgent.SetDestination(ressource.transform.position);
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Strategie",(int)strategieChoix.Type);
    }
    void ChargerStrategie()
    {
       var strategieOriginale = PlayerPrefs.GetInt("Strategie");
        switch ((TypeStrat)strategieOriginale) {
            case TypeStrat.Equilibre:
                strategieChoix = new StrategieChoixEquilibre();
                break;
            case TypeStrat.Hasard:
                strategieChoix = new StrategieChoixHasard();
                break;
                case TypeStrat.Proche:
                strategieChoix = new StrategieChoixPlusProche(); 
                break;
        
        
        }
    }
}