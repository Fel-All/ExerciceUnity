using UnityEngine;

public class EtatMort : EtatEnnemi
{
    private float tempsAvantDetruire = 2.0f;
    private float tempsEcoule = 0.0f;

    public EtatMort(ComportementEnnemi squelette) : base(squelette)
    {
    }

    public override void Entrer()
    {
        sujet.agent.enabled = false;
        GameObject.Destroy(sujet.GetComponent<Collider>());
    }

    public override void Executer(float deltaTime)
    {
        tempsEcoule += deltaTime;
        sujet.transform.Rotate(Vector3.up, 180.0f * deltaTime);
        if (tempsEcoule >= tempsAvantDetruire)
        {
            GameObject.Destroy(sujet.gameObject);
        }
    }
}