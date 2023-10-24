using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public string nameCollectible;

    public int score;

    public int restoreHp;

    public int restoreAmmo;

    public Collectibles(string name, int scoreValue, int restoreHPvalue, int ammoRestore)
    {
        this.nameCollectible = name;
        this.score = score = scoreValue;
        this.restoreHp = restoreHPvalue;
        this.restoreAmmo = ammoRestore;
    }

    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(score);
    }

    public void UpdateAmmo()
    {
        Player.player.UpdateAmmo(restoreAmmo);
    }

    public void UpdateHealth()
    {

    }


    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>().UpdateScore();
        }
    }*/
}
