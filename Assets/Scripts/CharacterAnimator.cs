using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public QuestionPanel questionPanel;

    public void FailQuestion()
    {
        questionPanel.ReturnToGame(false);
    }

    public void PassQuestion()
    {
        questionPanel.ReturnToGame(true);
    }
}

