using UnityEngine;

public class EtatPatrouille : Etat
{
     public EtatPatrouille(Comportement compEnnemi) : base(compEnnemi) { }

    public override void Commencer()
    {
        squelette.animateur.SetBool("Walk", true);
        squelette.agent.isStopped = false;
        PointAleatoire();
        
    }


    public override void FaireAction(float temps)
    {
        if (squelette.ChercherJoueur())
        {
            squelette.ChangerEtat(squelette.etatPoursuite);
        } else if (squelette.agent.remainingDistance < 0.5f)
        {
            PointAleatoire();
        }
    }




    private void PointAleatoire()
    {
        int nombreAleatoire = Random.Range(0, squelette.pointsPatrouille.Count);
        Vector3 pointSelectionne = squelette.pointsPatrouille[nombreAleatoire].transform.position;
        squelette.agent.SetDestination(pointSelectionne);
    }
}
