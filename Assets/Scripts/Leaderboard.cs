using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Leaderboard
{
    public string usernameText;
    public string score;
    public string time;
    public string assignment_id;

    public Leaderboard(string usernameText, string score, string time, string assignment_id)
    {
        this.usernameText = usernameText;
        this.score = score;
        this.time = time;
        this.assignment_id = assignment_id;
    }
}