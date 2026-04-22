using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabsRessources;

    [SerializeField]
    private int nbRessources;
    [SerializeField] Villageois villageois;
    private string nomFichierSauvegarde;
    [HideInInspector]
    public List<Ressource> ressources;

    public static GameManager Instance;

    void Awake()
    {
        // Valide qu'il y a un seul GameManager
        Debug.Assert(Instance == null);
        Instance = this;

    }

	void Start()
	{
        nomFichierSauvegarde = Application.persistentDataPath + "/donnes-jeu.json"; 

        if (File.Exists(nomFichierSauvegarde))
        {
            ChargerPartie();
        }
        else
        {
            CreerRessources(nbRessources);

        }
    }

    private void CreerRessources(int nbRess)
    {
        for (int i = 0; i < nbRess; i++)
        {
            float positionX = Random.Range(-25, 25);
            float positionZ = Random.Range(-25, 25);
            Vector3 position = new Vector3(positionX, 0.5f, positionZ);

            int indexAleatoire = Random.Range(0, prefabsRessources.Count);
            GameObject ressourceAleatoire = Instantiate(prefabsRessources[indexAleatoire], position, Quaternion.identity);
            ressources.Add(ressourceAleatoire.GetComponent<Ressource>());
        }
    }

    void Update()
    {
        if (ressources.Count == 0)
        {
            CreerRessources(nbRessources);
        }
    }

    public void DetruireRessource(int numeroRessourceChoisie)
    {
        Ressource ressource = ressources[numeroRessourceChoisie];
        Destroy(ressource.gameObject);
        ressources.Remove(ressource);
    }

    void SauvegardeJeu()
    {
        EtatJeu etatJeu = new EtatJeu();
        etatJeu.Or = villageois.or;
        etatJeu.Roches = villageois.roches;
        etatJeu.Plantes = villageois.plantes;
        etatJeu.NbRessourcesDispo = ressources.Count;

        string json = JsonUtility.ToJson(etatJeu);
        
        File.WriteAllText(nomFichierSauvegarde,json);

    }

    private void OnApplicationQuit()
    {
        SauvegardeJeu();
    }

    private void ChargerPartie()
    {
        string json = File.ReadAllText(nomFichierSauvegarde);

        EtatJeu etat = JsonUtility.FromJson<EtatJeu>(json);

        villageois.or = etat.Or;
        villageois.plantes = etat.Plantes;
        villageois.roches = etat.Roches;
        villageois.MiseAJourTextes();
        CreerRessources(etat.NbRessourcesDispo);
    }
}
