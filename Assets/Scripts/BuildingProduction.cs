using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class BuildingProduction : IBuildingProduction
{
    public event UnityAction OnProductionChange;
    public event UnityAction<InProduction> OnTimeProductionChange;
    public event UnityAction<ProductionElement> OnDone;
    public event UnityAction<ProductionElement> OnClick;

    private Queue<InProduction> _elementsInProgress = new Queue<InProduction>();
    public IEnumerable<InProduction> ElementsInProgress
    {
        get
        {
            return _elementsInProgress;
        }
    }

    private List<ProductionElement> _possibleProduction;
    public IEnumerable<ProductionElement> PossibleProduction
    {
        get
        {
            return _possibleProduction;
        }
    }

    public BuidingProfile Profile { get; private set; }

    public void Init(BuidingProfile profile)
    {
        _possibleProduction = profile.PossibleProduction;
        Profile = profile;
    }

    public void AddInProduction(ProductionElement element)
    {
        if (!_possibleProduction.Contains(element)) throw new System.InvalidOperationException();

        _elementsInProgress.Enqueue(new InProduction(element, 0));

        if (OnProductionChange != null)
        {
            OnProductionChange.Invoke();
        }
    }

    public void ApplyTimeDelta(float delta)
    {
        if (_elementsInProgress.Count == 0) return;

        var inProgress = _elementsInProgress.Peek();
        inProgress.ApplyDelta(delta);

        if(OnTimeProductionChange != null)
        {
            OnTimeProductionChange.Invoke(inProgress);
        }

        if(inProgress.NormalizedProductionTime >= 1)
        {
            _elementsInProgress.Dequeue();
            if (OnProductionChange != null) {
                OnProductionChange.Invoke();
            }
            if(OnDone != null)
            {
                OnDone.Invoke(inProgress.Element);
            }
        }
    }

    public void RemoveFromProduction(InProduction inProgress)
    {
        _elementsInProgress = new Queue<InProduction>(_elementsInProgress.Where((x) => x != inProgress));
        if (OnProductionChange != null)
        {
            OnProductionChange.Invoke();
        }
    }

    public class InProduction
    {
        public ProductionElement Element { get; private set; }
        public float ProductionTime { get; private set; }

        public float NormalizedProductionTime
        {
            get
            {
                return ProductionTime / Element.TimeForConstruct;
            }
        }

        public void ApplyDelta(float delta)
        {
            ProductionTime += delta;
        }

        public InProduction(ProductionElement element, float productionTime)
        {
            Element = element;
            ProductionTime = productionTime;
        }
    }
}


