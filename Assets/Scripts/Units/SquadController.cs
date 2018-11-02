using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquadController : MonoBehaviour
{
    [SerializeField] private List<NavMeshAgent> _agents;
    private ISquadPositionGenerator _generator;
    public Transform Target;
    public static SquadController Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        if (Instance == this) Instance = null;
    }

    private void Start()
    {
        _generator = GetComponent<ISquadPositionGenerator>();
        Target.gameObject.GetOrAddComponent<ObserverableTransform>().OnChangePosition += (target) =>
        {
            SetSquadCenter(target.position);
        };
    }

    public void SetSquadCenter(Vector3 center)
    {
        var positions = _generator.GetPositions(_agents.Count);
        for(int i = 0; i < positions.Length; i++)
        {
            _agents[i].SetDestination(center + (positions[i] * 3)); 
        }
    }

    public void Add(NavMeshAgent agent)
    {
        _agents.Add(agent);
    }
}
