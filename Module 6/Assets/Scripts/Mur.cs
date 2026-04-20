using UnityEngine;

public class Mur : MonoBehaviour, IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void Damaged()
    {
        Destroy(gameObject);
    }
}
