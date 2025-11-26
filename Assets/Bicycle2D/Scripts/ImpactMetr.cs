using UnityEngine;
using UnityEngine.Events;

public class ImpactMetr : MonoBehaviour
{
   public UnityEvent OnEmptyBlow;
   public UnityEvent OnStrongBlow;
  [SerializeField]private float highImpactPower = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
     if (collision.relativeVelocity.magnitude >= highImpactPower)
        {
            Debug.Log("вы сильно ударились");
            OnStrongBlow.Invoke();
        }
      else
        {
            Debug.Log("вы слабо ударились");
            OnStrongBlow.Invoke();
        }     
    }
}
