using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, ITakeDamage
{
    public event Action OnKilled;

    public InputHandler InputHandler { get { return inputHandler; } }

    [SerializeField]
    private InputHandler inputHandler;

    public bool IsInControl { get; private set; }

    public void ActivateControl(bool value)
    {
        IsInControl = value;
    }

    private void Start()
    {
        IsInControl = true;
    }

    public void TakeDamage(int damage)
    {
        gameObject.SetActive(false);
        OnKilled?.Invoke();
    }
}