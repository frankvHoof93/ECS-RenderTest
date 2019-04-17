using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Assets
{
    public class RotateSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            ForEach((ref RotateComp rot, ref Rotation rotation) =>
            {
                quaternion val = rotation.Value;
                val = Quaternion.Euler(new Vector3(0, rot.Value, 0)) * val;
                rotation = new Rotation { Value = val };
            });
        }
    }
}
