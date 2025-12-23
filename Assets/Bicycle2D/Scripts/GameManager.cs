using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public UnityEvent OcCrashed;
    public UnityEvent OnFinished;
    public OperatingMode Mode;
    public Season SeasonMode;
    public float PassageTime{get; private set;}
    public bool Finised = false;
    public bool Crased = false;
    private Rider _rider;
    private Finish _finish;
    private void Start()
    {
        _rider = GameObject.FindFirstObjectByType<Rider>();
        _finish = GameObject.FindFirstObjectByType<Finish>();

        if(_rider != null)
        {
        _rider.OnCrush.AddListener(Crash);
        }
        if(_finish != null)
        {
        _finish.OnFinished.AddListener(CheckAvaiilabil);
        }
    }

    private void Update()
    {
        if (Finised == false)
        {
            PassageTime += Time.deltaTime;

            if(Input.GetKeyDown(KeyCode.R) && Crased == true)
            {
                if(Finised == false)
                {
                    SceenController.Restart();
                }
            }
        }
    }
    private void CheckAvaiilabil()
    {
        switch (Mode)
        {
            case OperatingMode.StaySaddle:
            if (_rider.IsCrashed == false)
                {
                    if (_finish.riderCheck && _finish.bikeCheck)
                    {
                        FinishLvl();
                    }
                }
            break;
            case OperatingMode.OnlyRider:
            if(_finish.riderCheck == true)
                {
                    FinishLvl();
                }

            break;
            case OperatingMode.OnlyBike:
            if(_finish.bikeCheck == true)
                {
                    FinishLvl();    
                }

            break;
        }
    }
    private void Crash()
    {
        if ( Crased == false)
        {
            Crased = true;
            if (Mode == OperatingMode.StaySaddle)
            {
                OcCrashed.Invoke();
            }
        }   
    }
    private void FinishLvl()
    {        if (Finised == false)
        {
            Finised = true;
            OnFinished.Invoke();
        }
    }

}

public enum OperatingMode
    {
        StaySaddle,
        OnlyRider,
        OnlyBike
    }
public enum Season
{
    Winter,
    Spring,
    Summer,
    Autumn,
}