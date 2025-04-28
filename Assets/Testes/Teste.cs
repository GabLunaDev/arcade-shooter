using UnityEngine;

public class Teste : MonoBehaviour
{
    private InputManager InputManager;
    void Start()
    {
        InputManager = new InputManager();
        InputManager.OnShoot += Shoot;
    }

    private void Shoot()
    {
        Debug.Log("SHOOT");
    }

    void Update()
    {
        Debug.Log(InputManager.Movement);
    }
}
