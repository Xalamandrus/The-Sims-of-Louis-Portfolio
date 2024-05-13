using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimsManager : MonoBehaviour
{
    private Routine.Needs[] _needsList;

    [SerializeField] private Routine _routine;

    private MoveTo _moveTo;
    private SliderBarNPC _sliderBarNPC;

    private void Start()
    {
        _needsList = _routine.GetNeedsList();

        _moveTo = GetComponent<MoveTo>();
        _sliderBarNPC = GetComponent<SliderBarNPC>();

        for (int i = 0; i < _needsList.Length; i++)
        {
            _needsList[i].CurrentValue = _needsList[i].Get_StartValue;

            _sliderBarNPC.SliderBarMaxValue(_needsList[i].Get_MaxValue);
        }

        InvokeRepeating("ReducedNeedsInTime", 0, 1f);
    }

    private void ReducedNeedsInTime()
    {
        for (int i = 0; i < _needsList.Length; i++)
        {
            if (_needsList[i].CurrentValue == 0) { return; }

            _needsList[i].CurrentValue -= _needsList[i].Get_ReduceValue;

            Debug.Log(_needsList[i].CurrentValue);
        }
    }

    private void Update()
    {
        MoveTo();
        SliderBarUpdate();
    }

    private void MoveTo()
    {
        for (int i = 0; i < _needsList.Length; i++)
        {
            Vector3 target = _needsList[i].Get_Target;
            AnimationList animationName = _needsList[i].Get_Animation;

            if (_needsList[i].CurrentValue <= 10)
            {
                _moveTo.MoveToObject(target);

                bool isTarget = _moveTo.IsTarget(target);
                Animator animator = _moveTo.Get_Animator();

                if (isTarget)
                {
                    Quaternion lookIn = _needsList[i].Get_LookIn;

                    if (transform.rotation != lookIn)
                    {
                        _moveTo.RotateNPC(lookIn);

                        animator.Play(AnimationList.Idle.ToString());
                    }
                    else
                    {
                        _needsList[i].CurrentValue = _needsList[i].Get_MaxValue;

                        animator.Play(animationName.ToString());
                    }
                }
                else
                {
                    animator.Play(AnimationList.Walk.ToString());
                }
            }
        }
    }

    private void SliderBarUpdate()
    {
        for (int i = 0; i < _needsList.Length; i++)
        {
            _sliderBarNPC.SliderBarValue(_needsList[i].Get_NeedsName, _needsList[i].Get_MaxValue, _needsList[i].CurrentValue);
        }
    }
}