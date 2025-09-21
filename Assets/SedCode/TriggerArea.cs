using System;
using UnityEngine;
using UnityEngine.AI;

public class TriggerArea : MonoBehaviour
{
    //public static Action OnTriggerArea;
    private DroneBehaviour _drone;
    private DogBehaviour _dog;
    void OnTriggerEnter2D(Collider2D collision)
    { 
        NavMeshAgent agent = collision.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            //OnTriggerArea?.Invoke();
            _drone = agent.GetComponent<DroneBehaviour>();
            _dog = agent.GetComponent<DogBehaviour>();
            if (_drone != null)
            {
                _drone.Interacted();
            }
            if (_dog != null)
            {
                _dog.Interacted();
            }
        }
        
    }
}
