using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]

public class ObjectSO : ScriptableObject
{
    public Transform prefab;
    public float healing;
    public string objectName;
}
