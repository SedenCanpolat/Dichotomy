using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private NavMeshAgent _enemy;

    void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
        _enemy.updateRotation = false;
        _enemy.updateUpAxis = false;
    }

    void Update()
    {
        _enemy.SetDestination(_player.transform.position);
    }
}
