using System;
using UnityEngine;
using UnityEngine.AI;

public class TriggerArea : MonoBehaviour
{
    public static Action OnTriggerArea;
    void OnTriggerEnter2D(Collider2D collision)
    { 
        NavMeshAgent agent = collision.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            OnTriggerArea?.Invoke();
        }
        
    }
}
