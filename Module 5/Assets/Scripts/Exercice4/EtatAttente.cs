using UnityEngine;

public class EtatAttente : Etat
{
    public EtatAttente(Comportement compEnnemi) : base(compEnnemi) { }
    private float tempsAttente;
    public override void Commencer()
    {
        squelette.animateur.SetBool("Walk", false);

        squelette.agent.isStopped = true;

        tempsAttente = Random.Range(3f, 5f);

    }
    public override void FaireAction(float temps)
    {
        tempsAttente -= temps;
        if (tempsAttente < 0)
        {
            squelette.ChangerEtat(squelette.etatPatrouille);
        }

    }
}
