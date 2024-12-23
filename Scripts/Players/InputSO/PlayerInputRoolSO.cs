using System;
using UnityEngine;

namespace BIS
{
    public class PlayerInputRoolSO : ScriptableObject
    {
        public Vector2 InputDirection { get; set; }
        public Action AttackUpEvent { get; set; }
        public Action AttackDownEvent { get; set; }
        public Action JumpEvent { get; set; }
    }
}
