using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProductionElementPresenter : MonoBehaviour { 

    [SerializeField] private Image Image;
    [SerializeField] private Image ProgressImage;
    [SerializeField] private Button Button;

    public void Present(ProductionElement element, UnityAction onClick)
    {
        Image.sprite = element.Icon;
        ProgressImage.fillAmount = 0;
        Button.onClick.AddListener(onClick);
    }

    public void SetProgress(float normalizedProgress)
    {
        ProgressImage.fillAmount = normalizedProgress;
    }
}
