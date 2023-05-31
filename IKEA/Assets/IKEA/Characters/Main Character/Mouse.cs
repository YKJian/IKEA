using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Transform _character;
    private float _sensitivity = 1f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Track();
    }

    private void Track()
    {
       /*
        Axis inputVector = Player.();

        Axis inputVector =  GetMouse;
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * _speed * Time.deltaTime;

        var nextPosition = Vector3.Lerp(transform.position, _character.position, Time.fixedDeltaTime * _sensitivity);
        transform.position = nextPosition;
        */
    }
}
