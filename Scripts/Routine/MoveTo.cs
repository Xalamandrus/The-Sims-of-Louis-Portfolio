using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    private NavMeshAgent _NPC;
    private Animator _animator;

    private void Start()
    {
        _NPC = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public void MoveToObject(Vector3 p_target)
    {
        _NPC.SetDestination(p_target);
    }

    public bool IsTarget(Vector3 p_target)
    {
        if (Vector3.Distance(_NPC.transform.position, p_target) < 1f)
        {
            return true;
        }

        return false;
    }

    public Animator Get_Animator()
    {
        return _animator;
    }

    public void RotateNPC(Quaternion p_targetRotation)
    {
        Quaternion p_currentRotation = _NPC.transform.rotation;

        Quaternion p_newRotation = Quaternion.RotateTowards(p_currentRotation, p_targetRotation, 180f * Time.deltaTime);

        transform.rotation = p_newRotation;
    }
}