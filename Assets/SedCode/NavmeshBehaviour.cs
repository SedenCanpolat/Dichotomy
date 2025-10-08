using UnityEngine;
using UnityEngine.AI;

public class NavmeshBehaviour : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _followDistance = 15f;
    private NavMeshAgent _enemy;

    void Start()
    {   
        _player = GameObject.FindWithTag("Player").transform;
		_enemy = GetComponent<NavMeshAgent>();
        _enemy.updateRotation = false;
        _enemy.updateUpAxis = false;
    }

    void Update()
    {
        float enemyDistanceToPlayer = Vector3.Distance(transform.position, _player.position);
        if (enemyDistanceToPlayer <= _followDistance)
        {
            _enemy.SetDestination(_player.transform.position);
        }
        else
        {
            _enemy.ResetPath();
        }
    }
}
