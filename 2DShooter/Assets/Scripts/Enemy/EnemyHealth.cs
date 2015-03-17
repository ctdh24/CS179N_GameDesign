using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    bool isDead;
	
    void Awake ()
    {
        currentHealth = startingHealth;
    }



    public void TakeDamage (int amount)
    {
        if(isDead)
            return;

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
		
    }

}
