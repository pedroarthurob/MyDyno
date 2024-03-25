using UnityEngine;

public class DynoAnimation : MonoBehaviour
{
    private Dyno dyno;
    private Animator anim;

    private void Awake()
    {
        dyno = GetComponent<Dyno>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (dyno.onGround)
        {
            anim.SetBool("isOnGround", true);
        }
        else
        {
            anim.SetBool("isOnGround", false);
        }
    }


}

