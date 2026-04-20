using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Villageois villageois;


    public void StratHasard()
    {
        villageois.ChangerStrategie(new StrategieHasard());
    }

    public void StratPlusProche()
    {
        villageois.ChangerStrategie(new StrategiePlusProche());

    }
    public void StratEquilibre()
    {
        villageois.ChangerStrategie(new StrategieEquilibre());

    }

}
