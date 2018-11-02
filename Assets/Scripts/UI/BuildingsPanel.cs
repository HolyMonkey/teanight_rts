using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingsPanel : MonoBehaviour {

    public GameObject BuildingButtonTemplate;
    [SerializeField] private Transform _buttonParent;
    private List<BuidingProfile> _buildings;
    
	void Start ()
    {
        _buildings = Resources.LoadAll<BuidingProfile>("Buildings/").ToList();

        foreach (var building in _buildings)
        {
            var buttonGo = Instantiate(BuildingButtonTemplate, _buttonParent);
            buttonGo.SetActive(true);
            buttonGo.GetComponent<BuildingPresanterOnButton>().Present(building);
        }
	}
}
