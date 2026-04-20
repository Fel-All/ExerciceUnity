using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsRessources;
    [SerializeField] private int nbRessources;

    public static GameManager Instance;
    public List<Ressource> Ressources = new List<Ressource>();
    public int NbRessourcesDisponibles { get; private set; }

    private void Awake()
    {
        // Valide qu'il y a un seul GameManager
        Debug.Assert(Instance == null);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreerRessources();
    }

    private void CreerRessources()
    {
        
        // Crée les ressources au début du jeu
        for (int i = 0; i < nbRessources; i++)
        {
            float x = Random.value * 50 - 25;
            float z = Random.value * 50 - 25;
            Vector3 pos = new Vector3(x, 0.5f, z);
            int choix = Random.Range(0, prefabsRessources.Length);
            var objet = Instantiate(prefabsRessources[choix], pos, Quaternion.identity);
            Ressources.Add(objet.GetComponent<Ressource>());
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        if (Ressources.Count() == 0)
        {
            CreerRessources();
        }
    }

    public void DetruireRessource(int numeroRessourceChoisie)
    {
        Ressource ressource = Ressources[numeroRessourceChoisie];
        Destroy(ressource.gameObject);
        Ressources.Remove(ressource);
    }
}