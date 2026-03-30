using UnityEngine;
using UnityEngine.InputSystem;

public class LancerProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _modeleProjectile;
    [SerializeField] private float force;
    [SerializeField] private AudioClip sonProjectile; // Glisser le son ici dans l'Inspector

    private CharacterController characterController;
    private Collider joueurCollider;
    private InputAction click;
    private AudioSource audioSource; // Ajout

    private void Start()
    {
        click = InputSystem.actions.FindAction("Click");
        characterController = GetComponent<CharacterController>();
        joueurCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>(); // Ajout
    }

    void Update()
    {
        if (click.WasPressedThisFrame())
        {
            audioSource.PlayOneShot(sonProjectile); // Ajout

            GameObject projectile = Instantiate(_modeleProjectile);
            projectile.transform.position = transform.position + transform.forward;

            var rigidbody = projectile.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.Lerp(transform.forward, Vector3.up, 0.5f) * force, ForceMode.Impulse);
            var projectileCollider = projectile.GetComponent<Collider>();

            Physics.IgnoreCollision(characterController, projectileCollider);
            Physics.IgnoreCollision(joueurCollider, projectileCollider);
        }
    }
}

