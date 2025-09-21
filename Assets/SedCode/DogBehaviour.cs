using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
   
    private void _explosionAnimation()
    {
        Destroy(gameObject);
    }

    public void Interacted()
    {
        _explosionAnimation();
        print("DOG");
    }

   


}
