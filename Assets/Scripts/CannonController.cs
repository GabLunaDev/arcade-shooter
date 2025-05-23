using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private Transform Pivot;
    [SerializeField] private Transform ShootOrigin;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float ShootForce;


    private Pool<CannonBall> Pool;
    private const int POOL_INITIAL_SIZE = 10;

    private void Start()
    {
        GameManager.Instance.InputManager.OnShoot += OnShoot;
        Pool = new Pool<CannonBall>(Paths.CannonBallPrefab, POOL_INITIAL_SIZE);
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector2 movement = GameManager.Instance.InputManager.Movement;
        float speed = RotationSpeed * Time.deltaTime;
        Pivot.Rotate(movement.y * speed, 0, 0, Space.Self);
        Pivot.Rotate(0, movement.x * speed, 0, Space.World);
    }

    private void OnShoot()
    {
        CannonBall cannonBall = Pool.Rent();
        cannonBall.transform.SetPositionAndRotation(ShootOrigin.position, Quaternion.identity);
        cannonBall.Shoot(ShootForce * ShootOrigin.forward, CannonBallCallback);
    }

    private void CannonBallCallback(CannonBall cannonBall)
    {
        Pool.Return(cannonBall);
    }

    private void OnDestroy()
    {
        GameManager.Instance.InputManager.OnShoot -= OnShoot;
    }
}
