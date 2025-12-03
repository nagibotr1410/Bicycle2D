using UnityEngine;
using UnityEngine.Events;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    public UnityEvent OnCrush;
    public bool IsCrashed
    {
        get
        {
            return crashed;
        }
        private set
        {
            crashed = false;
        }
    }

    [SerializeField]private GameObject[] gameObjects;
    private bool crashed;
        private void OnCollisionEnter2D(Collision2D other) 
        {
            Destroy(gameObject);
            OnCrush.Invoke();
        }

}
