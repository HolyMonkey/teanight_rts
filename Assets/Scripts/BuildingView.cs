using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BuildingView : MonoBehaviour {

    public Transform CurrentTransform;
    private State _currentState = State.InPlacing;

    public List<GameObject> PlaceHelpers;

    public void Awake()
    {
        CurrentTransform = GetComponent<Transform>();
    }

    public void Place()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        PlaceHelpers.ForEach((x) => x.SetActive(false));
        _currentState = State.Idle;
    }

    public void StartPlace()
    {
        gameObject.layer = LayerMask.NameToLayer("BuildingGhost");
        PlaceHelpers.ForEach((x) => x.SetActive(true));
        _currentState = State.InPlacing;
    }

    public enum State
    {
        Idle,
        InPlacing
    }
}
