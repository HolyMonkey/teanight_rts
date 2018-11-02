using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/Profile")]
public class BuidingProfile : ScriptableObject
{
    public GameObject BuildingView;
    public string Name;
    public Sprite Icon;
    public float Price;

    public List<ProductionElement> PossibleProduction;
}
