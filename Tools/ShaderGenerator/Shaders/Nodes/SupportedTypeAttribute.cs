﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Odyssey.Tools.ShaderGenerator.Shaders.Nodes
{
    [DataContract]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SupportedTypeAttribute : Attribute
    {
        [DataMember]
        Type supportedType;

        public Type SupportedType { get { return supportedType; } }

        public SupportedTypeAttribute(Type supportedType, bool isRequired = true)
        {
            this.supportedType = supportedType;
        }
    }
}
