using System.Collections.Generic;
using UnityEngine;

public class StrategiePlusProche : StratRessource
{
    public override TypeStrat Type => TypeStrat.Proche;

    public override int ChoisirRessource(Villageois villageois, List<Ressource> ressources)
    {
        int index = 0;
        float distanceMin = Vector3.Distance(villageois.transform.position, ressources[0].transform.position);

        for (int i = 1; i < ressources.Count; i++)
        {
            float distanceAutre = Vector3.Distance(villageois.transform.position, ressources[i].transform.position);
            if (distanceAutre < distanceMin)
            {
                distanceMin = distanceAutre;
                index = i;
            }

        }

        return index;
        
    }
}
