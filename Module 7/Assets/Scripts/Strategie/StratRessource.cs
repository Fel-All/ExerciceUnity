using System.Collections.Generic;
using UnityEngine;

public abstract class StratRessource
{
    public abstract TypeStrat Type {  get; }
    public abstract int ChoisirRessource(Villageois villageois, List<Ressource> ressources);
}
