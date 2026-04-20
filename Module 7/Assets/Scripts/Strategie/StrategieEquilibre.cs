using System;
using System.Collections.Generic;
using UnityEngine;

public class StrategieEquilibre : StratRessource
{
    public override TypeStrat Type => TypeStrat.Equilibre;

    public override int ChoisirRessource(Villageois villageois, List<Ressource> ressources)
    {
        int indexMax = 0;
        float distanceMax = Vector3.Distance(villageois.transform.position, ressources[0].transform.position);
        float valMax = ressources[0].Valeur / (distanceMax * distanceMax);
        for (int i = 1; i < ressources.Count; i++)
        {
            float distanceAutre = Vector3.Distance(villageois.transform.position, ressources[i].transform.position);
            float val = ressources[i].Valeur / (distanceAutre * distanceAutre);

            if (val > valMax)
            {
                valMax = val;   
                indexMax = i;
            }
        }

        return indexMax;
    }
}
