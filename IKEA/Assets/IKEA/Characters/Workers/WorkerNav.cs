using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;

public class WorkerNav : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private float _triggerDistance;

    private NavMeshAgent _agent;
    // список, содержащий цели
    [SerializeField] private List<GameObject> _targets;
    // номер цели в списке
    private int _targetNo;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // следование за целями
        float dist = Vector3.Distance(_agent.transform.position, _agent.pathEndPosition);

        if (dist < 1.5f)
        {
            TargetNumberChange();
        }
        _agent.destination = _targets[_targetNo].transform.position;

        // следование за игроком
        float distToPlayer = Vector2.Distance(_agent.transform.localPosition, _playerTarget.position);

        if (distToPlayer < _triggerDistance)
        {
            _agent.destination = _playerTarget.position;
        }

        if (_playerTarget == null)
        {
            _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void TargetNumberChange()
    {
        _targetNo = Random.Range(0, _targets.Count);
    }
}
