using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float xDir = Random.value < 0.5f ? -1f : 1f;
        float yDir = Random.Range(-0.5f, 0.5f);
        Vector3 direction = new Vector3(xDir, yDir, 0).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Reflect the velocity for classic Pong bounce
        Vector3 normal = collision.contacts[0].normal;
        Vector3 newVel = Vector3.Reflect(rb.linearVelocity, normal).normalized * speed;
        // Prevent vertical-only bouncing: ensure X velocity is always above a minimum
        float minX = 0.5f;
        if (Mathf.Abs(newVel.x) < minX)
        {
            newVel.x = minX * Mathf.Sign(newVel.x == 0 ? Random.value - 0.5f : newVel.x);
            newVel = newVel.normalized * speed;
        }
        rb.linearVelocity = newVel;
    }
}