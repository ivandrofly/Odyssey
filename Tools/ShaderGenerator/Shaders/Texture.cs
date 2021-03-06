﻿using Odyssey.Tools.ShaderGenerator.Shaders;
using Odyssey.Tools.ShaderGenerator.Shaders.Nodes;
using Odyssey.Tools.ShaderGenerator.Shaders.Yaml;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Tools.ShaderGenerator.Shaders
{
    [YamlMapping(typeof(YamlTexture))]
    [DataContract]
    public partial class Texture : Variable
    {
        [DataMember]
        [SupportedType(Type.Texture2D)]
        [SupportedType(Type.Texture3D)]
        [SupportedType(Type.TextureCube)]
        public override Type Type
        {
            get
            {
                return base.Type;
            }
            set
            {
                var attributes = this.GetType().GetProperty("Type").GetCustomAttributes(true).OfType<SupportedTypeAttribute>();
                if (!attributes.Any(att => att.SupportedType == value))
                    throw new InvalidOperationException("Cannot assign a non-Texture type to this variable.");
                base.Type = value;
            }
        }

        public Texture()
        {
        }

    }
}
