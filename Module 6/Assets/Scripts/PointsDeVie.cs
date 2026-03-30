using UnityEngine;
using UnityEngine.UI;

public class PointsDeVie : MonoBehaviour
{
    [SerializeField] private int _pointsDeVieMax;

    [SerializeField] private Slider sliderVie;
    private int _pointsDeVie;

    // Start is called before the first frame update
    void Start()
    {
        _pointsDeVie = _pointsDeVieMax;
    }

    private void Update()
    {
        sliderVie.transform.LookAt(Camera.main.transform);
    }


    public void RetirerPointsDeVie(int dommages)
    {
        _pointsDeVie -= dommages;
        sliderVie.value = (float)_pointsDeVie / _pointsDeVieMax;

        if (_pointsDeVie <= 0)
        {
            IDamageable damage = GetComponent<IDamageable>();
            damage.Damaged();

        }
    }
}
