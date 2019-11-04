using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;

    [SyncVar (hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    public RectTransform healthbar;
    public bool destroyOnDeath;

    public void TakeDamage(int amount)
    {
        // if this object is not active on an active server, TakeDamage method will end
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHealth = maxHealth;
                RpcRespawn();
            }
        }
    }

    void OnChangeHealth(int health)
    {
        healthbar.sizeDelta = new Vector2(health * 2, healthbar.sizeDelta.y);
        currentHealth = health;
    }

    // ClientRpc Attribute: allow the method to be invoked on clients from a server
    // ClientRpcs tell the clients what the server has decided to do.
    // when the server calls a ClientRPC methhod RpcRespawn on the object accociated with Player2, 
    // this method is called on all clients on the Player2 object.
    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            transform.position = Vector3.zero;
            //Destroy(gameObject);
        }
    }
}
