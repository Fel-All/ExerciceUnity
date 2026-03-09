using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementCC : MonoBehaviour
{
    [SerializeField] float magnitudeVitesse;
    [SerializeField] float accel;
    private InputAction mouvementJoueur;
    private InputAction sprint;
    private CharacterController cc;
    private InputAction jump;
    [SerializeField] float forceSaut;
    private float velocite;
    private Vector3 posInit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouvementJoueur = InputSystem.actions.FindAction("Move");
        cc = GetComponent<CharacterController>();
        sprint = InputSystem.actions.FindAction("Sprint");
        jump = InputSystem.actions.FindAction("Jump");
        posInit = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        velocite += Physics.gravity.y * Time.deltaTime;
        var mouv = mouvementJoueur.ReadValue<Vector2>();
        Vector3 direction = new Vector3(mouv.x, 0, mouv.y);
        
        if (sprint.IsPressed())
        {
            magnitudeVitesse *= accel;
        }
        if (jump.IsPressed() && cc.isGrounded)
        {
            velocite = forceSaut;

        } else if (cc.isGrounded)
        {
            velocite = 0;
        }

            Vector3 vitesse = magnitudeVitesse * direction;
        vitesse = transform.TransformDirection(vitesse);
        var vitFinal = vitesse + new Vector3(0, velocite, 0);
       
        cc.Move(vitFinal * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<DetectionFin>())
        {
            cc.enabled = false;
            transform.position = posInit;
            cc.enabled = true;
        }
    }
}
