﻿using Odyssey.Engine;
using Odyssey.Graphics.Materials;
using ShaderGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Tools.ShaderGenerator.Shaders.Structs
{
    public partial class Struct
    {

        public static Struct VertexPositionTexture
        {
            get
            {
                Struct vpt = new Struct()
                {
                    Name = "input",
                    CustomType = CustomType.VSIn,
                };
                vpt.Add(Vector.ObjectPosition);
                vpt.Add(Vector.TextureUV);
                return vpt;
            }
        }

        public static Struct VertexPositionNormalTexture
        {
            get
            {
                Struct vpt = new Struct()
                {
                    Name = "input",
                    CustomType = CustomType.VSIn,
                };
                vpt.Add(Vector.ObjectPosition);
                vpt.Add(Vector.Normal);
                vpt.Add(Vector.TextureUV);
                return vpt;
            }
        }

        public static Struct VertexPositionNormalTextureUVW
        {
            get
            {
                Struct vpt = new Struct()
                {
                    Name = "input",
                    CustomType = CustomType.VSIn,
                };
                vpt.Add(Vector.ObjectPosition);
                vpt.Add(Vector.Normal);
                vpt.Add(Vector.TextureUVW);
                return vpt;
            }
        }

        public static Struct VertexPositionTextureOut
        {
            get
            {
                Struct vpt = new Struct()
                {
                    CustomType = CustomType.VSOut,
                    Name = "output",
                };
                vpt.Add(Vector.ClipPosition);
                vpt.Add(Vector.TextureUV);
                return vpt;
            }
        }



        public static Struct VertexPositionColor 
        {
            get
            {
                Struct vpc = new Struct()
                {
                    Name = "input",
                };
                vpc.Add(Vector.ObjectPosition);
                vpc.Add(Vector.Color);
                return vpc;
            }
        }

        public static Struct VertexPositionNormalTextureOut
        {
            get
            {
                Struct vpnt = new Struct()
                {
                    CustomType = CustomType.VSOut,
                    Name = "input",
                };

                vpnt.Add(Vector.ClipPosition);
                vpnt.Add(Vector.Normal);
                vpnt.Add(Vector.TextureUV);
                vpnt.Add(Vector.WorldPosition);

                return vpnt;
            }
        }

        public static Struct PixelShaderOutput
        {
            get
            {
                Struct psOut = new Struct()
                {
                    CustomType = CustomType.PSOut,
                    Name = "output"
                };
                psOut.Add(Vector.ColorPSOut);
                return psOut;
            }
        }

        public static Struct Material
        {
            get
            {
                Struct material = new Struct()
                {
                    CustomType = Shaders.CustomType.Material,
                    Name = "material",
                    ShaderReference = new ShaderReference(EngineReference.Material)
                };

                material.Add(new Vector { Name = Param.Material.kA, Type = Type.Float });
                material.Add(new Vector { Name = Param.Material.kD, Type = Type.Float });
                material.Add(new Vector { Name = Param.Material.kS, Type = Type.Float });
                material.Add(new Vector { Name = Param.Material.SpecularPower, Type = Type.Float });
                material.Add(new Vector { Name = Param.Material.Ambient, Type = Type.Float4 });
                material.Add(new Vector { Name = Param.Material.Diffuse, Type = Type.Float4 });
                material.Add(new Vector { Name = Param.Material.Specular, Type = Type.Float4 });

                return material;

            }
        }

        public static Struct PointLight0
        {
            get
            {
                Struct lPoint = new Struct
                {
                    CustomType = Shaders.CustomType.PointLight,
                    Name = "lPoint",
                    ShaderReference = new ShaderReference(EngineReference.LightPoint0PS)
                };

                lPoint.Add(new Vector { Name = Param.Light.Intensity, Type = Type.Float });
                lPoint.Add(new Vector { Name = Param.Light.Radius, Type = Type.Float });
                lPoint.Add(new Vector { Name = Param.Light.Diffuse, Type = Type.Float4 });
                lPoint.Add(new Vector { Name = Param.Light.Position, Type = Type.Float3 });
                //lPoint.Add(new Vector { Name = Param.Light.Direction, Type = Type.Float4 });

                return lPoint;
            }
        }

        public static Struct PointLightVS
        {
            get
            {
                Struct lPoint = new Struct
                {
                    CustomType = CustomType.PointLight,
                    Name = "lPoint",
                    ShaderReference = new ShaderReference(EngineReference.LightPoint0VS)
                };
                lPoint.Add(Matrix.LightView);
                lPoint.Add(Matrix.LightProjection);
                return lPoint;
            }
        }   
    }
}
