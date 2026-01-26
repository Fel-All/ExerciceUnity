using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementSphere : MonoBehaviour
{
    [SerializeField] private float niveauForce;
    private InputAction _move;
    private Rigidbody sphereRigidBody;
    private Vector3 positionInitiale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sphereRigidBody = GetComponent<Rigidbody>();
        positionInitiale = transform.position;
        _move = InputSystem.actions.FindAction("Move");
    }
    void Update()
    {
        if (transform.localPosition.y < 2.0f)
        {
            TeleporterJoueur();
        }
    }
    void FixedUpdate()
    {
        Vector2 mouvement = _move.ReadValue<Vector2>();
        Vector3 force = niveauForce* new Vector3(mouvement.y, 0, mouvement.x);
        sphereRigidBody.AddForce(force);
    }

    public void TeleporterJoueur()
    {
        transform.position = positionInitiale;
        sphereRigidBody.linearVelocity = Vector3.zero;
        sphereRigidBody.angularVelocity = Vector3.zero;   
    }
}
