using UnityEngine;

public class DroneBehaviour : MonoBehaviour
{
    void Start()
    {
        //TriggerArea.OnTriggerArea += _explosionAnimation;
    }
    private void _explosionAnimation()
    {
        Destroy(gameObject);
    }

    public void Interacted()
    {
        _explosionAnimation();
    }

    void OnDestroy()
    {
        //TriggerArea.OnTriggerArea -= _explosionAnimation;
    }


}
