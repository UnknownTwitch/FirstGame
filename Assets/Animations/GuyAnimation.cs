using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyAnimation : MonoBehaviour
{
    private Animator myAnimator;
    private bool isShooting = false;
    public float noButtonPress = 0.0f;
    private float buttonReset = 0.0f;


    private void Start()
    {
       myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isShooting == false)
        {
            if(noButtonPress >= 6)
            {
                noButtonPress = buttonReset;
                myAnimator.SetFloat("noButtonPress", buttonReset);
            }
            else
            {
                noButtonPress = noButtonPress + 1 * Time.deltaTime;
                myAnimator.SetFloat("noButtonPress", noButtonPress);
            }
           
            
        }
        else if (isShooting == true)
        {
            noButtonPress = buttonReset;
            myAnimator.SetFloat("noButtonPress", buttonReset);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            myAnimator.SetBool("isShooting", true);
            isShooting = true;
        }

        else if (Input.GetKeyUp(KeyCode.Space) && isShooting)
        {
            myAnimator.SetBool("isShooting", false);
            isShooting = false;
        }
    }

}
