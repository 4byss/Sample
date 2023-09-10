using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToonCheckenAnimation : MonoBehaviour
{
    Animator anim; 
    string [] functionArray = {"WalkingAnimation", "RunningAnimation", "EatingAnimation", "TurnHeadAnimation"};

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(ChickenAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChickenAnimation() {
        while(true) {
            yield return new WaitForSeconds(4f);
            int function = Random.Range(0,5);
            switch(function) {
                case 0: WalkingAnimation();
                Invoke("IdleAnimation", 1f);
                break;
                case 1: RunningAnimation();
                Invoke("IdleAnimation", 1f);
                break;
                case 2: EatingAnimation();
                Invoke("IdleAnimation", 1f);
                break;
                case 3: TurnHeadAnimation();
                Invoke("IdleAnimation", 1f);
                break;
                case 4: IdleAnimation();
                break;
                default: Debug.Log("ERROR");
                break;
            }
        }
    }

    void IdleAnimation() {
        anim.SetBool("Idle", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Eat", false);
        anim.SetBool("Turn Head", false);
    }
    void WalkingAnimation() {
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", true);
        anim.SetBool("Run", false);
        anim.SetBool("Eat", false);
        anim.SetBool("Turn Head", false);
    }
    void RunningAnimation() {
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", true);
        anim.SetBool("Eat", false);
        anim.SetBool("Turn Head", false);
    }
    void EatingAnimation() {
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Eat", true);
        anim.SetBool("Turn Head", false);
    }
    void TurnHeadAnimation() {
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Eat", false);
        anim.SetBool("Turn Head", true);
    }
}
