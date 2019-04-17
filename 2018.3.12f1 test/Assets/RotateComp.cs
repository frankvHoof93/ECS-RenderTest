using System;
using Unity.Entities;

namespace Assets
{
    [Serializable]
    public struct RotateComp : IComponentData
    {
        public float Value;
    }

}
