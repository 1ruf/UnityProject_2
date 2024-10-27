using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : State
{
    [SerializeField] private Transform _bulletPrefab;

  

    protected override void EnterState()
    {
        _agent.AnimCompo.PlayAnimaton(AnimatonType.attack);
        BulletFire();
    }

    private void BulletFire()
    {

        Vector3 direction = ((Vector3)_agent.InputCompo.MousePos - _agent.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Transform bullet = Instantiate(_bulletPrefab, transform.parent.position, Quaternion.Euler(0, 0, angle));
        bullet.LookAt(_agent.InputCompo.MousePos);

        if (_agent._previousState && _agent._previousState != _agent.StateCompo.GetState(StateType.Attack))
        {
            _agent.TransitionState(_agent._previousState);
        }
        else
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }



}
