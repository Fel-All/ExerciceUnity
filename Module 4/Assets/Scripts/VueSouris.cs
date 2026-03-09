using UnityEngine;
using UnityEngine.InputSystem;

public class VueSouris : MonoBehaviour
{
    private GameObject joueur;
    private InputAction mouvementSouris;
    private float vitesseRotation = 8f;
    private float angle = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joueur = transform.parent.gameObject;

        mouvementSouris = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        var mouv = mouvementSouris.ReadValue<Vector2>();

        joueur.transform.Rotate(Vector3.up, vitesseRotation *  mouv.x * Time.deltaTime);

        angle += -mouv.y * vitesseRotation * Time.deltaTime;
        if (angle >= 30)
        {
            angle = 30;
        }
        if (angle <= -30)
        {
            angle = -30;
        }
        transform.localEulerAngles = new Vector3(angle,0,0);
    }
}
