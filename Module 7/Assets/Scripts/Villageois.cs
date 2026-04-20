using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Villageois : MonoBehaviour
{
    private int or;
    private int plantes;
    private int roches;
    private int numeroRessourceChoisie = -1;
    private NavMeshAgent _navMeshAgent;
    private StratRessource strat;
    [SerializeField] private TMP_Text texteOr;
    [SerializeField] private TMP_Text textePlantes;
    [SerializeField] private TMP_Text texteRoches;

    private void Start()
    {
        ChargerStrat();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (numeroRessourceChoisie == -1)
        {
            AllerVersNouvelleRessource();
        }
        else if (numeroRessourceChoisie != -1 && Vector3.Distance(_navMeshAgent.destination, transform.position) < 1.4f)
        {
            var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];

            var ressource = objet.GetComponent<Ressource>();
            if (ressource.Type == TypeRessource.Or)
                or++;
            else if (ressource.Type == TypeRessource.Plante)
                plantes++;
            else if (ressource.Type == TypeRessource.Roche)
                roches++;

            MiseAJourTextes();

            GameManager.Instance.DetruireRessource(numeroRessourceChoisie);

            AllerVersNouvelleRessource();
        }
    }

    private void MiseAJourTextes()
    {
        texteOr.text = "Or: " + or;
        textePlantes.text = "Plantes: " + plantes;
        texteRoches.text = "Roches: " + roches;
    }

    private void AllerVersNouvelleRessource()
    {
        // Choix au hasard
        List<Ressource> ressources = GameManager.Instance.Ressources;

        if (ressources.Count == 0)
        {
            numeroRessourceChoisie = -1;
        }
        else
        {
            numeroRessourceChoisie = strat.ChoisirRessource(this, ressources);

            Ressource ressource = ressources[numeroRessourceChoisie];

            _navMeshAgent.destination = ressource.transform.position;
        }
    }



    public void ChangerStrategie(StratRessource nouvStrat)
    {
        strat = nouvStrat;
        AllerVersNouvelleRessource();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("TypeStrat", (int)strat.Type);
    }

    void ChargerStrat()
    {
        var stratChoix = PlayerPrefs.GetInt("TypeStrat");
        switch ((TypeStrat)stratChoix)
        {
             case TypeStrat.Hasard:
                strat = new StrategieHasard();
                break;
             case TypeStrat.Proche:
                strat = new StrategiePlusProche();
                break;
             case TypeStrat.Equilibre:
                strat = new StrategieEquilibre();
                break;
        }
    }
}