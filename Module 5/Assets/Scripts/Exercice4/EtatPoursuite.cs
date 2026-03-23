using UnityEngine;

public class EtatPoursuite : Etat
{
    public EtatPoursuite(Comportement compEnnemi) : base(compEnnemi) { }

    public override void Commencer()
    {
        squelette.animateur.SetBool("Walk", true);
        squelette.agent.isStopped = false;
        squelette.agent.SetDestination(squelette.Joueur.transform.position);
    }

    public override void FaireAction(float temps)
    {
        Vector3 posJoueur = squelette.Joueur.transform.position;
        Vector3 posEnnemi = squelette.transform.position;
        float distanceJoueur = (posJoueur - posEnnemi).magnitude;
        if (distanceJoueur < 2.5f)
        {
            Debug.Log("attack");
            squelette.ChangerEtat(squelette.etatAttaque);

        } else if (!squelette.ChercherJoueur())
        {
            squelette.ChangerEtat(squelette.etatAttente);

        } else
        {

         squelette.agent.SetDestination(posJoueur);

        }

    }

}
