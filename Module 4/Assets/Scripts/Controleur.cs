using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controleur : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Quitter()
    {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        
    Application.Quit();
   
    #endif
    }
    public void NouvellePartie()
    {
        SceneManager.LoadScene("Labyrinthe");
    }
}
