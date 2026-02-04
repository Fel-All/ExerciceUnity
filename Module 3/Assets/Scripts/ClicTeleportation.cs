using UnityEngine;
using UnityEngine.InputSystem;

public class ClicTeleportation : MonoBehaviour
{
    Vector2 positionSouris;
    [SerializeField]
    private GameObject terrain;
    [SerializeField]
    private Camera cam;
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
                   transform.localPosition = rayHits.point;
                }
            }

        }
    }
}
