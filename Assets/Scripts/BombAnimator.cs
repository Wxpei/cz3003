using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnimator : MonoBehaviour
{
    public Animator playerAnimator;

    public void BombExplode()
    {
        playerAnimator.SetBool("Dead", true);
    }

    public void SuccessQuestion()
    {
        playerAnimator.SetBool("Happy", true);
    }
}
