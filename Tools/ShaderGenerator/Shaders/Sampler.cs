﻿using Odyssey.Engine;
using Odyssey.Tools.ShaderGenerator.Shaders.Structs;
using Odyssey.Tools.ShaderGenerator.Shaders.Yaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Odyssey.Tools.ShaderGenerator.Shaders
{
    [YamlMapping(typeof(YamlSampler))]
    [DataContract]
    public partial class Sampler : Variable
    {
        public Sampler()
        {
        }


    }
}
