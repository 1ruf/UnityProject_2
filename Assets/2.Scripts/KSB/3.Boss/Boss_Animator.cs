using UnityEngine;

public class Boss_Animator : MonoBehaviour
{
    private Animator animator;



    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

    }

    public void Boss_PlayAnimaton(Boss_AnimationType type)
    {
        switch (type)
        {
            case Boss_AnimationType.Attack1_L:
                Play("Boss_Attack1(L)");
                break;
            case Boss_AnimationType.Attack1_R:
                Play("Boss_Attack1(R)");
                break;
            case Boss_AnimationType.Attack2:
                Play("Boss_Attack2");
                break;
            case Boss_AnimationType.Attack3:
                Play("Boss_Attack3");
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
            case Boss_AnimationType.Hit:
                Play("Boss_Hit");
                break;
            case Boss_AnimationType.Spawn:
                Play("Boss_Spawn");
                break;

        }
    }
    public void Play(string name)
    {
        animator.Play(name);
    }
}
public enum Boss_AnimationType
{
    Attack1_R,
    Attack1_L,
    Attack2,
    Attack3,
    Attack4,
    Run,
    Idle,
    Death,
    Hit,
    Spawn

}
