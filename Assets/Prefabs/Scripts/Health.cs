using UnityEngine;
using UnityEngine.Rendering;

public class Health : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 100;
    private float CurrentHealth = 0;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void CheckHealth()
    {
        if (CurrentHealth > MaxHealth) 
        {
            CurrentHealth = MaxHealth;
        }
        else if (CurrentHealth <= 0)
        {
            //call Function
        }
    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
        CheckHealth();
    }
    public void Heal(float HealAmount)
    {
        CurrentHealth += HealAmount;
        CheckHealth();
    }
}
