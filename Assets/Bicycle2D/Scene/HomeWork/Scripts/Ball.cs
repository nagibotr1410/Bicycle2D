using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent OnBallDestroy;
    public float Money = 1000f;
    public float HP = 3f;
    public void Speake()
    {
        Debug.Log(Money);
        Debug.Log("я попал в зону");
    }
    public void TakeDamage()
    {
        if (HP > 0f)
        {
            HP = HP - 1f;
            Debug.Log($"HP: {HP}");
            if (HP <= 0)
            {
                OnBallDestroy.Invoke();
                Debug.Log("вы умерли");
                Destroy(gameObject);
            }
        }
    }

}
