using System;
using TMPro;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controleur : MonoBehaviour
{
    [SerializeField] private TMP_InputField vitesse;
    [SerializeField] private TMP_InputField accel;
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

    public void changerVitesse()
    {
        ValeursJeu.Instance.vitesse = Int32.Parse(vitesse.text);

        Debug.Log(vitesse.text);
    }

    public void changerAccel()
    {
        ValeursJeu.Instance.accel = float.Parse(accel.text);
    }

}
