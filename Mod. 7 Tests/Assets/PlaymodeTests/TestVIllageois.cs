
using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;
public class TestVillageois
{
    private Villageois villageois;
    private GameManager gameManager;
    [SetUp]
    public void CreerObjets()
     {
        // Instantiate un villageois sans NavMesh
         GameObject prefabVillageois = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Villageois.prefab");
            
         prefabVillageois.GetComponent<NavMeshAgent>().enabled = false;

         villageois = GameObject.Instantiate(prefabVillageois, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Villageois>();

         // Instantiate le game manager
         GameObject prefabGameManager = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");

         gameManager = GameObject.Instantiate(prefabGameManager, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<GameManager>();

        gameManager.nombreRessourceCree = 0;
     }
    [TearDown]
    public void DetruireObjets()
    {
        // Detruire le villageois
        GameObject.DestroyImmediate(villageois.gameObject);
        // Detruire toutes les ressources (creer dans les tests)
        foreach (Ressource ressource in gameManager.listeRessources)
        {
            GameObject.DestroyImmediate(ressource.gameObject);
        }
        // Detruire le game manager
        GameObject.DestroyImmediate(gameManager.gameObject);
    }
    [UnityTest]
    public IEnumerator RessourcePlusPrecieuse_Simple()
    {
        // Arrange
        Ressource or1 = GameObject.Instantiate(gameManager.prefabOr, new Vector3(10, 0, 10), Quaternion.identity).GetComponent<Ressource>();
        Ressource or2 = GameObject.Instantiate(gameManager.prefabOr, new Vector3(10, 0, 0), Quaternion.identity).GetComponent<Ressource>();
        Ressource or3 = GameObject.Instantiate(gameManager.prefabOr, new Vector3(0, 0, 10), Quaternion.identity).GetComponent<Ressource>();
        or1.Valeur = 10;
        or2.Valeur = 20;
        or3.Valeur = 30;
        gameManager.listeRessources = new() { or1, or2, or3 };
        // Act
        // Attendre un frame pour villageois choisisse une ressource
        yield return null;

        // Assert

        int valeurRessourceChoisi = villageois.GetComponent<Villageois>().ressourceChoisi.Valeur;
        Assert.AreEqual(30, valeurRessourceChoisi);
    }


    [UnityTest]

    public IEnumerator RessourceUneNegative()
    {
        // Arrange
        Ressource or1 = GameObject.Instantiate(gameManager.prefabOr, new Vector3(10, 0, 10), Quaternion.identity).GetComponent<Ressource>();
        Ressource or2 = GameObject.Instantiate(gameManager.prefabOr, new Vector3(10, 0, 0), Quaternion.identity).GetComponent<Ressource>();
        Ressource or3 = GameObject.Instantiate(gameManager.prefabPiege, new Vector3(0, 0, 10), Quaternion.identity).GetComponent<Ressource>();
        or1.Valeur = 10;
        or2.Valeur = 20;
        or3.Valeur = -30;
        gameManager.listeRessources = new() { or1, or2, or3 };
        // Act

        yield return null;
        // Assert
        int valeurRessourceChoisi = villageois.GetComponent<Villageois>().ressourceChoisi.Valeur;
        Assert.AreEqual(20, valeurRessourceChoisi);
    }

    [UnityTest]

    public IEnumerator CollisionPiege()
    {
        // Arrange
        Ressource piege = GameObject.Instantiate(gameManager.prefabPiege, new Vector3(0, 0, 10), Quaternion.identity).GetComponent<Ressource>();

        piege.Valeur = -15;

        villageois.nombreOr = 15;

        gameManager.listeRessources = new () { piege };

        // Act

        villageois.transform.position = piege.transform.position;

        yield return new WaitForFixedUpdate();
        // Assert
        Assert.AreEqual(0, villageois.nombreOr);
    }


    [UnityTest]
    public IEnumerator PiegeDetruitCollision()
    {
        // Arrange
        Ressource piege = GameObject.Instantiate(gameManager.prefabPiege, new Vector3(0, 0, 10), Quaternion.identity).GetComponent<Ressource>();

        piege.Valeur = -15;

        gameManager.listeRessources = new() { piege };

        // Act
        villageois.transform.position = piege.transform.position;

        yield return new WaitForFixedUpdate();

        yield return null;
        // Assert
        Assert.IsTrue(piege == null);
    }
}
