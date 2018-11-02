using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GestureClick Ground;


    public void Start()
    {
        Ground.OnClick += (pos) =>
        {
            transform.position = pos;
        };
    }
}
