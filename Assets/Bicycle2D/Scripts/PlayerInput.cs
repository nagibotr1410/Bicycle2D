using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static float Horizontal;
    public static float Vertical;
    public static bool Brake;
    public static bool invertHorizontal = true;
    public static bool invertVertical = false;
    [SerializeField]private Joystick _joystick;
    private void Update()
    {
#if PLATFORM_STANDALONE
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Brake = Input.GetButton("Jump");
//
//
#elif PLATFORM_ANDROID || PLATDORM_IOS
        if (_joystick != null)
        {
            Horizontal = _joystick.Horizontal;
            Vertical = _joystick.Vertical;
        }
//
//-
#endif 
        if (invertHorizontal)
        {
            Horizontal *= -1;
        }
        if (invertVertical)
        {
            Vertical *= -1;
        }
    }


}
