using UnityEngine;

public class MouvementTete : MonoBehaviour
{
    [SerializeField]
    private float vitesse;
    private Vector3 direction = new Vector3(1, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += vitesse * direction.normalized * Time.deltaTime;
        if (transform.localPosition.x < -0.2f)
        {
            direction = new Vector3(1, 0, 0);
        } else if (transform.localPosition.x > .2f)

        {
            direction = new Vector3(-1, 0, 0);
        }
    }
}
