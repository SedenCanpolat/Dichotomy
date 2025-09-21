using System;
using UnityEngine;
using UnityEngine.AI;

public class TriggerArea : MonoBehaviour
{
    //public static Action OnTriggerArea;
    private DroneBehaviour _drone;
    void OnTriggerEnter2D(Collider2D collision)
    { 
        NavMeshAgent agent = collision.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            //OnTriggerArea?.Invoke();
            _drone = agent.GetComponent<DroneBehaviour>();
            if (_drone != null)
            {
                _drone.Interacted();
            }
        }
        
    }
}
