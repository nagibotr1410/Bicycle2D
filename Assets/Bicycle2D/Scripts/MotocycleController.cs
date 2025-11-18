using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Video;

public class MotocycleControler : MonoBehaviour
{
    [SerializeField]private float acceleration = 1000f;
    [SerializeField]private float rotationPower = 5f;
    private Rigidbody2D motocycleRB;
    [SerializeField]private WheelJoint2D rearWheel;
    [SerializeField]private WheelJoint2D frontWheel;
    private JointMotor2D motor;

    private void Awake()
    {
        motocycleRB = GetComponent<Rigidbody2D>();
        motor = rearWheel.motor;
    }
    private void Update()
    {
        if (PlayerInput.Brake == true)
        {
            Brake(rearWheel);
            Brake(frontWheel);
        }
        else if (PlayerInput.Horizontal != 0) 
        {
            Debug.Log($"попали в код Horizontal");
            if (frontWheel != null)
            {
                frontWheel.useMotor = false;
                Debug.Log($"Мотор переднего колеса отключили");
            }
            if (rearWheel != null)
            {
                rearWheel.useMotor = true;
                Debug.Log($"задний мотор работает ");
                float direction = PlayerInput.Horizontal;
                Debug.Log($"направление горизонталь");
                float speed = acceleration * direction;
                Debug.Log($"скорость работает ");
                motor.motorSpeed = rearWheel.jointSpeed;
                Debug.Log($" motorSpeed = rearWheel");
                motor.motorSpeed += speed * Time.fixedDeltaTime;
                Debug.Log($"добавление скорости");
                rearWheel.motor = motor;
                Debug.Log($"всё выполнено");
            }


        }
        else
        {
            if (frontWheel != null)
            {
                frontWheel.useMotor = false;
            }
            if (rearWheel != null)
            {
                rearWheel.useMotor = false;
            }
        }
        if (PlayerInput.Vertical != 0)
        {
            float vertical = PlayerInput.Vertical;
            motocycleRB.MoveRotation(motocycleRB.rotation += vertical * rotationPower * Time.fixedDeltaTime);

        }
    }
    private void Brake(WheelJoint2D wheel)
    {
        // if (frontWheel != null&&rearWheel != null)
        // {
        // frontWheel.useMotor = true;
        // rearWheel.useMotor = true;
        // motorRear.motorSpeed = 0;
        // motorFront.motorSpeed = 0;
        // }
        if (wheel == null)
        {
            return;
        }
        wheel.useMotor = true;
        motor.motorSpeed = 0;
        wheel.motor = motor;
    }
        
    
}
