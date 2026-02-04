using System;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Deplacer2Coroutine : MonoBehaviour
{
    Vector2 positionSouris;
    [SerializeField]
    private GameObject terrain;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float vitesse;
    private bool coroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
                    if (coroutine)
                    {
                        StopAllCoroutines();
                         coroutine = false;
                        Debug.Log("test");
                    }
                    Debug.Log("Coroutine Update");
                    StartCoroutine(Rotation(rayHits.point));
                    StartCoroutine(Deplacer(rayHits.point));
                    coroutine = true;
                }
            }

        }
    }
    IEnumerator Deplacer(Vector3 objectif)
    {
        var direction = objectif - transform.position;
 
        while(Vector3.Distance(transform.position, objectif) > 0.5f)
        {
            transform.position += vitesse * Time.deltaTime * direction;
            yield return null;
        }
    }
    IEnumerator Rotation(Vector3 objectif)
    {
        var vitesseRotation = 5.4f;
        var direction = objectif - transform.position;
        var rotationFinale = Quaternion.LookRotation(direction);
        while (transform.rotation != rotationFinale)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationFinale, vitesseRotation * Time.deltaTime);
        }
        yield return null;
    }
}
