using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public List<GameObject> options = new List<GameObject>();
    int optionsCount;
    Animator animator;
    public GameObject DialogueBox;
    bool timerCount;
    float timer;
    public float timerAnimation;
    public GameObject Enemy;
    public GameManager gm;
    IA IAScript;
    // Use this for initialization
    void Start () {

        for(int i = 1; i < options.Count; i++)
        {
            options[i].SetActive(false);
        }
        optionsCount = 0;
        animator = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        IAScript = GameObject.Find("IA").GetComponent<IA>();
	}
	
	// Update is called once per frame
	void Update () {

        if (timerCount)
        {
            timer += Time.deltaTime;
            if (timer >= timerAnimation)
            {
                gm.setPlayerResults(optionsCount);
                
                gm.setEnemyResults(Enemy.GetComponent<EnemyController>().getEnemyOption());
                gm.checkResults();

                timerCount = false;
                timer = 0;
                resetAnimations();
                DialogueBox.SetActive(true);

            }
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeOption();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inverseChangeOption();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //o termina el tiempo del cronometro
            //llamar a la funcion
            checkOption();
            //aqui le paso a la IA la opcion que ha elegido el jugador
            IAScript.IApredictions(optionsCount);
            //enemigo juega random
            Enemy.GetComponent<EnemyController>().checkOption();
            //enemigo juega con IA
            //Enemy.GetComponent<EnemyController>().checkOptionWithIA();


        }


    }

    public void resetAnimations()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Papel", false);
        animator.SetBool("Tijera", false);
        animator.SetBool("Piedra", false);
    }


    public void checkOption()
    {
        DialogueBox.SetActive(false);
        animator.SetBool("Idle", false);
        //0 papel   1 tijera   2 piedra
        if (optionsCount == 0)
        {
            animator.SetBool("Papel", true);
            
        }

        else if (optionsCount == 1)
        {
            animator.SetBool("Tijera", true);
        }

        else if (optionsCount == 2)
        {
            animator.SetBool("Piedra", true);
        }

        timerCount = true;

    }

    public void changeOption()
    {

        options[optionsCount].SetActive(false);
        optionsCount++;
        if (optionsCount >= options.Count)
        {
            optionsCount = 0;
        }
        options[optionsCount].SetActive(true);


    }

    public void inverseChangeOption()
    {

        options[optionsCount].SetActive(false);
        
        if (optionsCount <=0 )
        {
            optionsCount = options.Count-1;
        }
        else
        {
            optionsCount--;
        }
        options[optionsCount].SetActive(true);


    }
}
