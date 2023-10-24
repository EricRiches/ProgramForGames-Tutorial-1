using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    Collectibles ammo;

    private void Awake()
    {
        ammo = new Collectibles("ammo", 0, 0, 30);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Player>().AmmoBag < 120)
            {
                ammo.UpdateAmmo();
                Destroy(gameObject);
            }

        }
    }
}
