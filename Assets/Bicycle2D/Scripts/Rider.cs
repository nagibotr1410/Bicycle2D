using UnityEngine;
using UnityEngine.Events;

public class Rider : MonoBehaviour
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
    [SerializeField]private FixedJoint2D[] BodyRetainers;
    private bool crashed;

    public void Crash()
    {
        if(IsCrashed == false)
        {
            for (int i = 0; i < BodyRetainers.Length; i++)
            {
                if (BodyRetainers[i] != null)
                {
                    Destroy(BodyRetainers[i]);
                }
            }
            IsCrashed = true;

            OnCrush.Invoke();
        }
    }  
}
