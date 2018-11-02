using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class BuildingProductionBehaviour : MonoBehaviour, IPointerClickHandler
{
    public IBuildingProduction Production { get; private set; }

    public void OnEnable()
    {
        if(Production == null)
        {
            enabled = false;
        }
    }

    public void Init(IBuildingProduction production)
    {
        Production = production;
        enabled = production != null;

        if (production != null)
        {
            Production.OnDone += (element) =>
            {
                var offset = (Random.insideUnitCircle * 5);
                var product = Instantiate(element.Prefab,
                            new Vector3(transform.position.x + offset.x, transform.position.y, transform.position.z + offset.y),
                            Quaternion.identity);

                SquadController.Instance.Add(product.GetComponent<NavMeshAgent>());
            };
        }
    }

    public void Update()
    {
        Production.ApplyTimeDelta(Time.deltaTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ProductionPanel.Instance.DisplayProduction(Production);
    }
}
