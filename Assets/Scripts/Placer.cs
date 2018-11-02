using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Placer : MonoBehaviour {

    public static Placer Instance { get; private set; }
    private PlacedEntity _currentPlaced;

    public void Place(BuidingProfile building)
    {
        if (_currentPlaced != null) return;
        
        GameObject ghost = Instantiate(building.BuildingView);
        _currentPlaced = new PlacedEntity(ghost.GetComponent<BuildingView>(),
                                            ghost.GetComponent<CollisionTrigger>(),
                                            building);  
    }

    public void Update()
    {
        var inputModule = (CustomStandaloneInputModule)EventSystem.current.currentInputModule;
 
        if (_currentPlaced != null)
        {
            if (Input.GetMouseButtonDown(0) && _currentPlaced.TryPlace())
            {
                _currentPlaced = null;
            }
            else
            {
                _currentPlaced.MoveView(ProjectOnGrid(inputModule.GetMousePositionOnGameObject()));
            }
        }
    }

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public Vector3 ProjectOnGrid(Vector3 worldPos)
    {
        return new Vector3(Mathf.Round(worldPos.x), 0, Mathf.Round(worldPos.z));
    }

    public class PlacedEntity
    {
        private BuildingView _view;
        private CollisionTrigger _trigger;
        private BuidingProfile _profile;
        private bool _isPlaced = false;

        public PlacedEntity(BuildingView view, CollisionTrigger trigger, BuidingProfile profile)
        {
            _view = view;
            _trigger = trigger;
            _profile = profile;
        }

        public void MoveView(Vector3 pos)
        {
            _view.CurrentTransform.position = pos;
        }

        public bool TryPlace()
        {
            if (_isPlaced) throw new System.InvalidOperationException();

            if (_trigger.IsCollised) return false;
   
            Destroy(_trigger);
            _view.Place();

            var production = new BuildingProduction();
            production.Init(_profile);

            _view.gameObject.GetOrAddComponent<BuildingProductionBehaviour>().Init(production);

            _isPlaced = true;

            return true;
        }
    }
}
