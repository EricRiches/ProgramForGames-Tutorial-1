using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>().UpdateScore();
        }
    }
}
