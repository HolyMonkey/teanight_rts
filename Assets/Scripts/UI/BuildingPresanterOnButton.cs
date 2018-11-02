using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPresanterOnButton : MonoBehaviour {

    public Text BuildingName;
    public Image Icon;
    public Button Button;

    public void Present(BuidingProfile profile)
    {
        Icon.sprite = profile.Icon;
        BuildingName.text = profile.Name;

        Button.onClick.AddListener(() =>
        {
            Placer.Instance.Place(profile);
        });
    }
    
}
