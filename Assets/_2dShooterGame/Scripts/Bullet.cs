using UnityEngine;

public class Bullet:MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float timeToAutoDestroy = 1;

    private void Start()
    {
        Destroy(gameObject, timeToAutoDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        ITakeDamage element = collision.GetComponent<ITakeDamage>();

        if (element != null)
            element.TakeDamage(damage);
    }
}