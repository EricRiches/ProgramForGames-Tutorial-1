using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public string nameCollectible;

    public int score;

    public int restoreHp;

    public Collectibles(string name, int scoreValue, int restoreHPvalue)
    {
        this.nameCollectible = name;
        this.score = score = scoreValue;
        this.restoreHp = restoreHPvalue;
    }

    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(score);
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
