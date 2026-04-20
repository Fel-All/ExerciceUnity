using UnityEngine;
using UnityEngine.InputSystem;

public class VueSouris : MonoBehaviour
{
    [SerializeField]
    private float vitesseRotation = 5f;

    private float rotationMax = 30f;
    private float rotationMin = -30f;

    private InputAction actionSouris;
    private Transform parent;
    private float rotationApplique = 0f;

    void Start()
    {
        actionSouris = InputSystem.actions.FindAction("Look");
        actionSouris.Enable();
        parent = transform.parent;
    }

    void Update()
    {
        Vector2 inputSouris = actionSouris.ReadValue<Vector2>();

        // Rotation joueur (horizontal)
        float rotationJoueur = inputSouris.x * vitesseRotation;
        parent.Rotate(Vector3.up * rotationJoueur);

        // Rotation caméra (vertical)
        float rotationCamera = inputSouris.y * vitesseRotation;
        rotationApplique += rotationCamera;

        // Clamp propre
        rotationApplique = Mathf.Clamp(rotationApplique, rotationMin, rotationMax);

        transform.localEulerAngles = new Vector3(-rotationApplique, 0f, 0f);
    }
}