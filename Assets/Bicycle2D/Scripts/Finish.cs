using UnityEngine;
using UnityEngine.Events;


public class Finish : MonoBehaviour
{
    public UnityEvent OnFinished;
    public bool riderCheck = false;
    public bool bikeCheck = false;
    [SerializeField]private int riderLayer;

    [SerializeField]private int bikeLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"попал в тригер: {other.name}");
        Debug.Log($"проверка 1 : {other.gameObject.layer}=={riderLayer}");
        Debug.Log($"");
        Debug.Log($"");
        if (other.gameObject.layer == riderLayer && riderCheck == false )
        {
            Debug.Log("");
            riderCheck = true;
            OnFinished.Invoke();
        }


        if (other.gameObject.layer == bikeLayer && bikeCheck == false)
        {
            bikeCheck = true;
            OnFinished.Invoke();
        }
        

    }

}
