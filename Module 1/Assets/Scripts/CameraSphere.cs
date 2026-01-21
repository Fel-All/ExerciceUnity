using UnityEngine;

public class CameraSphere : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private float hauteurCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlacerCamera();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlacerCamera();
    }
    private void PlacerCamera()
    {
        float positionX = sphere.transform.position.x;
        float positionZ = sphere.transform.position.z;
        transform.position = new Vector3(positionX, hauteurCamera, positionZ);
    }
}
