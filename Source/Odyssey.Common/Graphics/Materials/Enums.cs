﻿using System;

namespace Odyssey.Graphics.Materials
{
    [Flags]
    public enum VertexShaderFlags
    {
        None = 0,
        Position = 1 << 0,
        Normal = 1 << 1,
        TextureUV = 1<<2,
        TextureUVW = 1 << 3,
        ShadowProjection = 1 << 4,
        Instancing = 1 << 5,
    }

    [Flags]
    public enum PixelShaderFlags
    {
        None = 0,
        Diffuse = 1 << 0,
        DiffuseMap = 1<< 1,
        Specular = 1<<2,
        SpecularMap = 1<<3,
        Shadows = 1<<4,
        ShadowMap = 1<<5,
        CubeMap = 1<<6
    }

    public enum ShaderModel
    {
        SM_2_0,
        SM_2_A,
        SM_2_B,
        SM_3_0,
        SM_4_0_Level_9_1,
        SM_4_0_Level_9_3,
        SM_4_0,
        SM_4_1,
        SM_5_0,
    }

    public enum FeatureLevel
    {
        PS_2_0,
        PS_2_A,
        PS_2_B,
        PS_3_0,
        PS_4_0_Level_9_1,
        PS_4_0_Level_9_3,
        PS_4_0,
        PS_4_1,
        PS_5_0,
        VS_2_0,
        VS_2_A,
        VS_3_0,
        VS_4_0_Level_9_1,
        VS_4_0_Level_9_3,
        VS_4_0,
        VS_4_1,
        VS_5_0,
    }

    public enum FeatureType
    {
        None,
        VertexShader,
        PixelShader,
        Shadows,
        TextureMaps
    }

    public enum UpdateFrequency
    {
        None, 
        Static,
        PerFrame,
        PerInstance,
    }

    public enum ShaderConfiguration
    {
        Debug,
        Release
    }
}
