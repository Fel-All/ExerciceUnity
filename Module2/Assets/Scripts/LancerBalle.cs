using UnityEngine;

public class LancerBalle : MonoBehaviour
{
    [SerializeField]
    private float force;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        rb.AddForce(Vector3.up * force,ForceMode.Impulse);
    }
}
