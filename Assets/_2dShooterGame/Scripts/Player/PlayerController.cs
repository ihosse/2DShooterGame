using System;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
public class PlayerController : MonoBehaviour, ITakeDamage
{
    public event Action OnKilled;

    public InputHandler InputHandler { get { return inputHandler; } }

    [SerializeField]
    private InputHandler inputHandler;

    private Explosion explosion;

    public bool IsInControl { get; private set; }

    private void Start()
    {
        IsInControl = true;
        explosion = GetComponent<Explosion>();
    }

    public void ActivateControl(bool value)
    {
        IsInControl = value;
    }

    public void TakeDamage(int damage)
    {
        KillMe();
    }

    private void KillMe()
    {
        gameObject.SetActive(false);
        OnKilled?.Invoke();
        explosion.Activate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            KillMe();
        }
    }
}