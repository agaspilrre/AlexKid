using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    Animator animator;
    int rand;
    bool timerCount;
    float timer;
    public float timerAnimation;
    IA IAscript;
    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        IAscript = GameObject.Find("IA").GetComponent<IA>();
	}
	
	// Update is called once per frame
	void Update () {

        if (timerCount)
        {
            timer += Time.deltaTime;
            if (timer >= timerAnimation)
            {
                resetAnimations();
                timerCount = false;
                timer = 0;
            }
        }


	}

    public void resetAnimations()
    {
        animator.SetBool("IdleE", true);
        animator.SetBool("PapelE", false);
        animator.SetBool("TijeraE", false);
        animator.SetBool("PiedraE", false);
    }

    public void checkOption()
    {
        rand = Random.Range(0, 3);
        
        animator.SetBool("IdleE", false);
        //0 papel   1 tijera   2 piedra
        if (rand == 0)
        {
            animator.SetBool("PapelE", true);

        }

        else if (rand == 1)
        {
            animator.SetBool("TijeraE", true);
        }

        else if (rand == 2)
        {
            animator.SetBool("PiedraE", true);
        }

        timerCount = true;

    }

    public void checkOptionWithIA()
    {
        string opcion=IAscript.getPrediccion();

        if (opcion == "r")
        {
            animator.SetBool("PapelE", true);
            rand = 0;
        }

        else if (opcion == "p")
        {
            animator.SetBool("TijeraE", true);
            rand = 1;
        }

        else if (opcion == "s")
        {
            animator.SetBool("PiedraE", true);
            rand = 2;
        }

        timerCount = true;

    }

    public int getEnemyOption()
    {
        return rand;
    }
}
