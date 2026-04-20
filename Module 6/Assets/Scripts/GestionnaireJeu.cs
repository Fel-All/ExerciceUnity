using UnityEngine;
using UnityEngine.InputSystem;

public class GestionnaireJeu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            var objet = Utilitaires.DeterminerClic();

            var objetCliquable = objet.GetComponent<ICliquable>();

            if (objetCliquable != null)
            {
                objetCliquable.Clic();
            }


        }

    }
}