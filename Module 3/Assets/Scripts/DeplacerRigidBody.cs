using System;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacerRigidBody : MonoBehaviour
{
    Vector2 positionSouris;
    [SerializeField]
    private GameObject terrain;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float vitesse;
    private bool coroutine;
    [SerializeField]
    private GameObject obstacle;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Mouse.current.leftButton.isPressed)
        {
           
            positionSouris = Mouse.current.position.ReadValue();
            Ray ray = cam.ScreenPointToRay(positionSouris);
            RaycastHit[] hits = Physics.RaycastAll(ray);


            foreach (var rayHits in hits)
            {
                if (rayHits.collider.gameObject == terrain)
                {
                    StopAllCoroutines();
                    StartCoroutine(Rotation(rayHits.point));
                    StartCoroutine(Deplacer(rayHits.point));
               
                }
            }

        }
    }
    IEnumerator Deplacer(Vector3 objectif)
    {
        var direction = (objectif - rb.position).normalized;
 
        while(Vector3.Distance(rb.position, objectif) > 0.5f)
        {
            rb.position += vitesse * Time.deltaTime * direction;
            yield return null;
        }
    }
    IEnumerator Rotation(Vector3 objectif)
    {
        var vitesseRotation = 5.4f;
        var direction = (objectif - rb.position).normalized;
        var rotationFinale = Quaternion.LookRotation(direction);
        while (rb.rotation != rotationFinale)
        {
            rb.rotation = Quaternion.RotateTowards(rb.rotation, rotationFinale, vitesseRotation * Time.deltaTime);
        }
        yield return null;
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == obstacle)
        {
            StopAllCoroutines();
        }
    }
}
