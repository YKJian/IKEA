using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletPosition;

    private int _time = 2;

    private AudioSource _audio;

    private Vector3 _gunPos = new Vector3(0f, 0.8f, 0.65f);
    private Quaternion _gunRot = Quaternion.Euler(15f, 90f, 0f);


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Shoot());
            _audio.Play();
        }
    }

    IEnumerator Shoot()
    {
        Vector3 gunPos = new Vector3(0.5f, 0.8f, 0.65f);
        var gunRot = Quaternion.Euler(0f, 180f, 0f);
        transform.localPosition = gunPos;
        transform.localRotation = gunRot;

        Instantiate(_bulletPrefab, _bulletPosition.position, transform.rotation);

        yield return new WaitForSeconds(_time);

        transform.localPosition = _gunPos;
        transform.localRotation = _gunRot;
    }
}
