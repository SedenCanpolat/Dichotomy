using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _getInDistance = 5f;
    void Update()
    {
        float playerDistanceToDoor = Vector3.Distance(transform.position, _player.position);
        if (playerDistanceToDoor <= _getInDistance)
        {
            LevelManagement.instance.ChangeLevelWithTransition(1);
        }
    }
}

