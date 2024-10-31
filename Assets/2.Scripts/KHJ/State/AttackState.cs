using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : State
{
    [SerializeField] private Transform _bulletPrefab;

  

    protected override void EnterState()
    {
        BulletFire();
    }

    private void BulletFire()
    {
        _agent.RbCompo.velocity = Vector2.zero;
        Vector3 direction = ((Vector3)_agent.InputCompo.MousePos - _agent.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Transform bullet = Instantiate(_bulletPrefab, transform.parent.position, Quaternion.Euler(0, 0, angle));
        bullet.LookAt(_agent.InputCompo.MousePos);
        StartCoroutine(A());
        
    }


    IEnumerator A()
    {
        yield return new WaitForSeconds(1f);
        if (_agent.InputCompo.InputVector.magnitude > 0)
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Move));
        }
        else
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }
}
