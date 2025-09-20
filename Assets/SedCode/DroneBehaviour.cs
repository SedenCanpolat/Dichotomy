using UnityEngine;

public class EnemyInteractBehaviour : MonoBehaviour
{
    void Start()
    {
        TriggerArea.OnTriggerArea += _explosionAnimation;
    }
    private void _explosionAnimation()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        TriggerArea.OnTriggerArea -= _explosionAnimation;
    }


}
