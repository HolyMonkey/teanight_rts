using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour {

    public Transform TargetPoint;
    public Animator Animator;

    [Range(0, 10)]
    public float Speed;
    public GestureClick Gesture;
    private Transform _selfTransform;

	private void Start ()
    {
        _selfTransform = GetComponent<Transform>();
        Gesture.OnClick += (pos) =>
        {
            TargetPoint.position = pos;
        };
    }
	
	private void Update ()
    {
        Vector3 newPosition = Vector3.MoveTowards(_selfTransform.position,
                                    TargetPoint.position,
                                    Speed * Time.deltaTime);

        Vector3 between = newPosition - _selfTransform.position;
        Animator.SetFloat("Speed", between.magnitude * 10);

        _selfTransform.position = newPosition;

    }
}
