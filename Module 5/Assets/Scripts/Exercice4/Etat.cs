using UnityEngine;

public abstract class Etat
{

    public Comportement squelette;

    public Etat ( Comportement sujet)
    {
        squelette = sujet;
    }

    public virtual void Commencer() { }
    public virtual void Arrêter() { }
    public virtual void FaireAction(float temps) { }





}
