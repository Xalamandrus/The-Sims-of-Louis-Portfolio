using UnityEngine;

[CreateAssetMenu(fileName = "Routine", menuName = "ScriptableObjects/Routine", order = 1)]

public class Routine : ScriptableObject
{
    [SerializeField] private Needs[] _needsList;

    [System.Serializable]
    public struct Needs
    {
        [Header("Value Options")]
        [Space]

        [SerializeField] private string _needsName;
        [SerializeField] private int _maxValue;
        [SerializeField] private int _startValue;
        [SerializeField] private int _reduceValue;
        [SerializeField] private int _replenishmentDuration;

        [Header("Target Options")]
        [Space]

        [SerializeField] private Vector3 _target;
        [SerializeField] private Quaternion _lookIn;
        [SerializeField] private AnimationList _animation;

        [Header("Loop Count")]
        [Space]

        [SerializeField] private bool _isLoopCount;
        [SerializeField] private int _loopCount;

        // Get_Value_Options

        public string Get_NeedsName => _needsName;

        public int Get_MaxValue => _maxValue;

        public int Get_StartValue => _startValue;

        public int Get_ReduceValue => _reduceValue;

        public int Get_ReplenishmentDuration => _replenishmentDuration;

        public int CurrentValue { get; set; }

        // Get_Target_Options

        public Vector3 Get_Target => _target;

        public Quaternion Get_LookIn => _lookIn;

        public AnimationList Get_Animation => _animation;

        // Get_Loop_Count

        public bool Get_isLoopCount => _isLoopCount;

        public int Get_LoopCount => _loopCount;
    }

    public Needs[] GetNeedsList()
    {
        return _needsList;
    }
}