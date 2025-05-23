using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    public event Action OnShoot;
    public Vector2 Movement => Controls.Gameplay.Movement.ReadValue<Vector2>();
    private Controls Controls;

    public InputManager()
    {
        Controls = new Controls();
        Controls.Gameplay.Enable();
        Controls.Gameplay.Shoot.performed += ShootPerformed;
    }

    private void ShootPerformed(InputAction.CallbackContext context)
    {
        OnShoot?.Invoke();
    }
}
