
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Debris debris;
    public int totalDebris = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadly"))
            OnExplode();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Deadly"))
            OnExplode();
    }

    public void OnExplode()
    {
        Transform t = transform;

        for (int i = 0; i < totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            Debris clone = Instantiate(debris, t.position, Quaternion.identity);
            Rigidbody2D body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-1000, 1000));
            body2D.AddForce(Vector3.up * Random.Range(500, 2000));
        }

        Destroy(gameObject);
    }
}
