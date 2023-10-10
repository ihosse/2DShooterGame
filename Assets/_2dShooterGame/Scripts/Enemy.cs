using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float life = 3;

    private Weapon[] weapons;

    private void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
    }

    private void Update()
    {
        Move();
        Shot();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void Shot()
    {
        if (weapons == null)
            return;

        foreach (var weapon in weapons)
        {
            weapon.FireWhenReady();
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if(life <= 0)
            Destroy(gameObject);
    }
}
