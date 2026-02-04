using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacerCoroutine : MonoBehaviour
{
    Vector2 positionSouris;
    [SerializeField]
    private GameObject terrain;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float vitesse;
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
                    Debug.Log("Coroutine Update");

                    StartCoroutine(Deplacer(rayHits.point));
                }
            }

        }
    }
    IEnumerator Deplacer(Vector3 objectif)
    {
        var vitesseRotation = 5.4f;
        var direction = objectif - transform.position;
        var rotationFinale = Quaternion.LookRotation(direction);

        while (transform.rotation != rotationFinale)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationFinale, vitesseRotation * Time.deltaTime);
        }
        yield return new WaitForSeconds(0.5f);

      while(Vector3.Distance(transform.position, objectif) > 0.5f)
        {
        
            transform.position += vitesse * Time.deltaTime * direction;
            yield return null;

        }

    }
}
