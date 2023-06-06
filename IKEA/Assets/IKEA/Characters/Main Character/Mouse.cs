using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _character;
    
    [SerializeField] private float _sensitivity;
    float _mouseX;
    float _mouseY;

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
        _mouseX += Input.GetAxis("Mouse X") * _sensitivity;
        _mouseY += Input.GetAxis("Mouse Y") * _sensitivity;
        // ограничение движения головы
        _mouseY = Mathf.Clamp(_mouseY, -30, 40);
        
        var _mouseHeadNext = Quaternion.Euler(-_mouseY, _mouseX, 0f);
        var _mousePlayerNext = Quaternion.Euler(0f, _mouseX, 0f);

        _head.transform.rotation = Quaternion.Lerp(_head.transform.rotation, _mouseHeadNext, Time.fixedDeltaTime * _sensitivity);
        _character.transform.rotation = Quaternion.Lerp(_character.transform.rotation, _mousePlayerNext, Time.fixedDeltaTime * _sensitivity);
    }
}
