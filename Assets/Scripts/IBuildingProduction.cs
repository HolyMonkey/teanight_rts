using System.Collections.Generic;
using UnityEngine.Events;

public interface IBuildingProduction
{
    IEnumerable<BuildingProduction.InProduction> ElementsInProgress { get; }
    IEnumerable<ProductionElement> PossibleProduction { get; }
    BuidingProfile Profile { get; }

    event UnityAction<ProductionElement> OnDone;
    event UnityAction OnProductionChange;
    event UnityAction<BuildingProduction.InProduction> OnTimeProductionChange;

    void AddInProduction(ProductionElement element);
    void Init(BuidingProfile profile);
    void RemoveFromProduction(BuildingProduction.InProduction inProgress);
    void ApplyTimeDelta(float delta);
}