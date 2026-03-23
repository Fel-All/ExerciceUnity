using UnityEngine;

public class EtatAttaque : Etat
{
    public EtatAttaque(Comportement compEnnemi) : base(compEnnemi) { }

    public override void Commencer()
    {
        squelette.animateur.SetTrigger("Attack");
        squelette.agent.isStopped = true;
    }

    public override void FaireAction(float temps)
    {
        Vector3 posJoueur = squelette.Joueur.transform.position;
        Vector3 posEnnemi = squelette.transform.position;
        float distanceJoueur = (posJoueur - posEnnemi).magnitude;
        if (distanceJoueur > 2.5f)
        {
            squelette.ChangerEtat(squelette.etatPatrouille);
        }
    }

}
