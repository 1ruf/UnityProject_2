using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : State
{
    [SerializeField] private Transform _bulletPrefab;

  

    protected override void EnterState()
    {
        print("프린트 어택");
        BulletFire();
    }

    private void BulletFire()
    {

        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _agent.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Transform bullet = Instantiate(_bulletPrefab, transform.parent.position, Quaternion.Euler(0, 0, angle));
        bullet.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (_agent._previousState)
        {
            _agent.TransitionState(_agent._previousState);
        }
        else
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }



}
