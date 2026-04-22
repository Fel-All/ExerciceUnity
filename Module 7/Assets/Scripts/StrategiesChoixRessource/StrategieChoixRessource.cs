using System.Collections.Generic;

public abstract class StrategieChoixRessource
{
    public abstract TypeStrat Type {  get; }
    public abstract int ChoisirRessource(Villageois villageois, List<Ressource> ressources);
}