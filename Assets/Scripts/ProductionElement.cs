using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/Product")]
public class ProductionElement : ScriptableObject
{
    /// <summary>
    /// In Seconds
    /// </summary>
    public float TimeForConstruct;
    public Sprite Icon;
    public GameObject Prefab;
}
