using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCollectable : MonoBehaviour
{
    private Animator animator;

    private bool chestOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenChest()
    {
        animator.SetBool("ChestOpen", true);
        chestOpened = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!chestOpened && collision.GetComponent<PlayerController>().tag == "Player")
        {
            GameManager.Instance.TriggerQuestion(this);
            OpenChest();
        }
    }
}
