using UnityEngine;

public class AttackSkillFactory : MonoBehaviour
{
    [SerializeField] private Boss_AttackSkill Boss1, Boss2, normal1, normal2,normal3;

    public Boss_AttackSkill GetSkill(string name)
        => name switch
        {
            "Boss1" => Boss1,
             "Boss2"=> Boss2,
            "Normal1" => normal1,
            "Normal2" => normal2,
            "Normal3" => normal3,
        };

}
