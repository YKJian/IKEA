using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    private PlayerInput _inputs;
    private float _speed = 5f;

    private void Awake()
    {
        _inputs = new PlayerInput();
        _inputs.Player.Enable();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        Vector2 inputVector = _inputs.Player.Walk.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * _speed * Time.deltaTime;
    }

    /*
    public Axis GetMouseAxis()
    {
        Axis inputAxis = _inputs.Player.Track.ReadValue<Axis>();

        return inputAxis;
    }*/
}
