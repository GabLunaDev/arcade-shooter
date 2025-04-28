using System;
using System.Security.Cryptography;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float Duration;
    private Rigidbody Rigidbody;
    private Action<CannonBall> Callback;
    private bool IsShooting = false;
    private float CurrentDuration;

    //Awake
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 force, Action<CannonBall> callback)
    {
        gameObject.SetActive(true);
        Callback = callback;
        Rigidbody.AddForce(force, ForceMode.Impulse);
        CurrentDuration = 0;
        IsShooting = true;
    }

    void Update()
    {
        if (!IsShooting) return;

        CurrentDuration += Time.deltaTime;

        if (CurrentDuration >= Duration)
        {
            IsShooting = false;
            Callback?.Invoke(this);
        }
    }
}
