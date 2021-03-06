﻿using Odyssey.Graphics.Materials;
using System;
using System.Runtime.Serialization;

namespace Odyssey.Tools.ShaderGenerator.Shaders
{
    [DataContract]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public class VertexShaderAttribute : Attribute
    {
        [DataMember]
        public VertexShaderFlags Features { get; private set; }

        public VertexShaderAttribute(VertexShaderFlags vsFeatures)
        {
            Features = vsFeatures;
        }
    }
}
