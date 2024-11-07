using UnityEngine;

public class Boss_Animator : MonoBehaviour
{
    private Animator animator;



    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void Boss_PlayAnimaton(Boss_AnimationType type)
    {
        switch (type)
        {
            case Boss_AnimationType.Attack1:
                Play("Boss_Attack1");
                break;
            case Boss_AnimationType.Attack2:
                Play("Boss_Attack2");
                break;
            case Boss_AnimationType.Attack3:
                Play("Boss_Attack3");
                break;
            case Boss_AnimationType.Attack4:
                Play("Boss_Attack4");
                break;
            case Boss_AnimationType.Run:
                Play("Boss_Run");
                break;
            case Boss_AnimationType.Idle:
                Play("Boss_Idle");
                break;
            case Boss_AnimationType.Death:
                Play("Boss_Death");
                break;

        }
    }
    private void Play(string name)
    {
        animator.Play(name);
    }
}

public enum Boss_AnimationType
{
    Attack1,
    Attack2,
    Attack3,
    Attack4,
    Run,
    Idle,
    Death,

}
