using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionPanel : MonoBehaviour
{
    public static ProductionPanel Instance {get; private set;} 

    public GameObject ProductionElementTemplate;
    public Transform PossibleProductionElementsContainer;
    public Transform InProgressElementsContainer;

    public Text Title;
    public Image Icon;

   private IBuildingProduction _current;

    public void Awake()
    {
        Instance = this;
    }

    public void DisplayProduction(IBuildingProduction building)
    {
        if(_current != null)
        {
            _current.OnTimeProductionChange -= OnNormalizedTimeProductionChangeHandler;
            _current.OnProductionChange -= OnProductionChangeHandler;
        }

        Title.text = building.Profile.name;
        Icon.sprite = building.Profile.Icon;
        _current = building;

        _current.OnTimeProductionChange += OnNormalizedTimeProductionChangeHandler;
        _current.OnProductionChange += OnProductionChangeHandler;

        DrawPossibleProduction();
        DrawProgressQueue();
    }

    private void OnNormalizedTimeProductionChangeHandler(BuildingProduction.InProduction e)
    {
        DrawProgressQueue();
    }

    private void OnProductionChangeHandler()
    {
        DrawProgressQueue();
    }

    private void DrawPossibleProduction()
    {
        ClearChild(PossibleProductionElementsContainer);

        foreach (var possible in _current.PossibleProduction)
        {
            var go = Instantiate(ProductionElementTemplate, PossibleProductionElementsContainer);
            go.GetComponent<ProductionElementPresenter>().Present(possible, () =>
            {
                _current.AddInProduction(possible);
            });
        }
    }

    private void DrawProgressQueue()
    {
        ClearChild(InProgressElementsContainer);

        foreach (var inProgress in _current.ElementsInProgress)
        {
            var go = Instantiate(ProductionElementTemplate, InProgressElementsContainer);
            var presenter = go.GetComponent<ProductionElementPresenter>();
            presenter.Present(inProgress.Element, () =>
            {
                _current.RemoveFromProduction(inProgress);
            });
            presenter.SetProgress(inProgress.NormalizedProductionTime);
        }
    }

    private void ClearChild(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

}
