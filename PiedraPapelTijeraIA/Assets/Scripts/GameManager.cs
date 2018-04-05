using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    int playerScore;
    int enemyScore;
    public Text score;
    public GameObject scoreGb;
    public GameObject yeah;
    public GameObject ouch;
    public int playerResults;
    public int enemyResults;
    float timer;
    public GameObject winImage;
    IA IAscript;

	// Use this for initialization
	void Start () {

        playerScore = 0;
        enemyScore = 0;

        yeah.SetActive(false);
        ouch.SetActive(false);
        winImage.SetActive(false);
        IAscript = GameObject.Find("IA").GetComponent<IA>();
		
	}
	
    public void setPlayerResults(int _value)
    {
        playerResults = _value;
    }

    public void setEnemyResults(int _value)
    {
        enemyResults = _value;
    }

    public void checkResults()
    {
        // 0 papel 1 tijera  2 piedra
        if (playerResults == enemyResults)
        {
            //empate
            //playerScore++;
            //enemyScore++;
        }

        //si player saca papel y enemigo piedra
        else if(playerResults==0 && enemyResults == 2)
        {
            playerScore++;
            yeah.SetActive(true);
        }
        //si el player saca tijera y enemigo papel
        else if(playerResults==1 && enemyResults == 0)
        {
            playerScore++;
            yeah.SetActive(true);
        }
        //si el player saca piedra y enemigo tijera
        else if(playerResults==2 && enemyResults == 1)
        {
            playerScore++;
            yeah.SetActive(true);
        }
        //resto de casos gana el enemigo
        else
        {
            enemyScore++;
            ouch.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {

		score.text= "PLAYER :  " + playerScore + "  ----  "+ enemyScore +"  : ENEMY ";

        if (yeah.activeSelf || ouch.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                yeah.SetActive(false);
                ouch.SetActive(false);
                //aqui desactivo los textos de la IA
                //IAscript.desactivateTexts();
                timer = 0;
            }
        }

        /*
        if (playerScore == 3)
        {
            yeah.SetActive(false);
            ouch.SetActive(false);
            scoreGb.SetActive(false);   
            winImage.SetActive(true);
        }*/
            
    }
}
