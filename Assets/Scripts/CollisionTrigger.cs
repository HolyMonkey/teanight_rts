using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CollisionTrigger : MonoBehaviour {

    public UnityEvent OnCollised = new UnityEvent();
    public UnityEvent OnFree = new UnityEvent();

    private bool _isCollised;
    public bool IsCollised
    {
        get
        {
            return _isCollised;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (!_isCollised)
        {
            OnCollised.Invoke();
        }

        _isCollised = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        OnFree.Invoke();

        _isCollised = false;
    }
}
