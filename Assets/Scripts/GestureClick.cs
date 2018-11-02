using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GestureClick : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<Vector3> OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClick != null)
        {
            OnClick.Invoke(eventData.pointerPressRaycast.worldPosition);
        }
    }

}
