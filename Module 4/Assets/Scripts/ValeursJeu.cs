using UnityEngine;

public class ValeursJeu
{

    public static ValeursJeu Instance { get; } = new ValeursJeu();


    private ValeursJeu()
    {

    }

    public int vitesse { get; set; } = 15;

    public float accel { get; set; } = 1.5f;





    
}
