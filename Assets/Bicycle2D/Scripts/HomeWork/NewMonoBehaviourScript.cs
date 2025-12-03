using UnityEngine;
using UnityEngine.Events;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public UnityEvent CrateEvent;
    [SerializeField]private float highImpactPower = 5f;
     private void OnCollisionEnter2D(Collision2D collision)
    {
     if (collision.relativeVelocity.magnitude >= highImpactPower)
        {
            Debug.Log("что-то выводить в консоль");
        }
        else
        {
            CrateEvent.Invoke();
        }
           
    }
}
