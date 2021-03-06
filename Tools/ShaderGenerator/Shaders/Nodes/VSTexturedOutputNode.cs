﻿using Odyssey.Content.Shaders;
using Odyssey.Engine;
using Odyssey.Tools.ShaderGenerator.Shaders.Structs;
using Odyssey.Tools.ShaderGenerator.Shaders.Yaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Odyssey.Tools.ShaderGenerator.Shaders.Nodes
{
    [YamlMapping(typeof(YamlVSTexturedOutputNode))]
    [DataContract]
    public class VSTexturedOutputNode : VSOutputNodeBase
    {
        [DataMember]
        [SupportedType(Type.Float2)]
        [SupportedType(Type.Float3)]
        public INode Texture { get; set; }

        public override IEnumerable<INode> DescendantNodes
        {
            get
            {
                foreach (var node in base.DescendantNodes)
                    yield return node;

                yield return Texture;
                foreach (var node in Texture.DescendantNodes)
                    yield return node;
            }
        }

        public override string Operation()
        {
            Struct vsOutput = (Struct)Output;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("\t{0} {1};", vsOutput.CustomType, vsOutput.Name));
            sb.AppendLine(string.Format("\t{0} = {1};", vsOutput[Param.SemanticVariables.Position].FullName, Position.Reference));
            sb.AppendLine(string.Format("\t{0} = {1};", vsOutput[Param.SemanticVariables.Texture].FullName, Texture.Reference));
            sb.AppendLine(string.Format("\treturn {0};", vsOutput.Name));

            return sb.ToString();
        }

    }
}
