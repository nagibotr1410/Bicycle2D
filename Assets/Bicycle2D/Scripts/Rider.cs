using UnityEngine;
using UnityEngine.Events;

public class Rider : MonoBehaviour
{
    private UnityEvent OnCrush;
    public bool IsCreshed
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
    private bool crashed;
    
}
