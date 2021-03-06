﻿using Odyssey.Content.Shaders;
using Odyssey.Tools.ShaderGenerator.Model;
using Odyssey.Tools.ShaderGenerator.Shaders;
using Odyssey.Tools.ShaderGenerator.ViewModel;
using Odyssey.Utils.Logging;
using SharpDX;
using SharpDX.D3DCompiler;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using Odyssey.Tools.ShaderGenerator.Properties;
using Odyssey.Graphics.Materials;

namespace Odyssey.Tools.ShaderGenerator
{
    public class ShaderCompiler
    {
        List<ErrorModel> errorList;

        public IEnumerable<ErrorModel> CompilationErrors { get { return errorList; } }

        public ShaderCompiler()
        {}

        CompilationResult Compile(IShaderViewModel shader, out List<ErrorModel> errors)
        {
            CompilationResult result = null;
            errorList = new List<ErrorModel>();
            try
            {
                IncludeHandler includeHandler = new IncludeHandler();
                result = ShaderBytecode.Compile(shader.SourceCode, shader.Name, shader.FeatureLevel.ToString().ToLowerInvariant(),
                    FromShaderConfiguration(), EffectFlags.None, null, includeHandler);
                includeHandler.Dispose();
                
                // In case compilation information could be needed - i.e. number of instructions
                //using (ShaderReflection sReflection = new ShaderReflection(result.Bytecode))
                //    Log.Daedalus.Info(sReflection.ToString());
                errors = null;
                return result;
            }
            catch (InvalidOperationException exIO)
            {
                Log.Daedalus.Error(exIO.ToString());
                errorList.Add(new ErrorModel(shader.Name, exIO.Message, false));
                errors = errorList;
                return null;
            }
            catch (CompilationException exComp)
            {
                Log.Daedalus.Error(exComp.ToString());
                string[] errorMessages = exComp.Message.Split('\n');
                foreach (string error in errorMessages)
                {
                    if (!string.IsNullOrEmpty(error))
                        errorList.Add(new ErrorModel(shader.Name, error));
                }
                errors = errorList;
                return null;
            }
        }

        public bool CompileShader(string techniqueName, ShaderDescriptionViewModel vmShader,out ShaderObject shaderObject, out IEnumerable<ErrorViewModel> errors)
        {
            List<ErrorModel> errorList;
            CompilationResult compilationResult = Compile(vmShader, out errorList);
            bool result = compilationResult != null && !compilationResult.HasErrors;
            vmShader.CompilationStatus = result ? CompilationStatus.Successful : CompilationStatus.Failed;
            if (!result)
            {
                errors = errorList.Select(e => new ErrorViewModel { ErrorModel = e });
                shaderObject = null;
            }
            else
            {
                var references = vmShader.ShaderDescriptionModel.Shader.References;
                var textureReferences = vmShader.ShaderDescriptionModel.Shader.TextureReferences;
                var samplerReferences = vmShader.ShaderDescriptionModel.Shader.SamplerReferences;
                shaderObject = new ShaderObject(vmShader.Name, vmShader.Type, vmShader.FeatureLevel,
                    compilationResult.Bytecode, references, textureReferences, samplerReferences);
                errors = null;
            }
            return result;
        }

        public bool CompileShader(ShaderCodeViewModel vmShader, out IEnumerable<ErrorViewModel> errors)
        {
            List<ErrorModel> errorList;
            CompilationResult compilationResult = Compile(vmShader, out errorList);
            bool result = compilationResult != null && !compilationResult.HasErrors;
            vmShader.CompilationStatus = result ? CompilationStatus.Successful : CompilationStatus.Failed;
            if (!result)
                errors = errorList.Select(e => new ErrorViewModel { ErrorModel = e });
            else
            {
                compilationResult.Bytecode.Save(Path.Combine(Settings.Default.OutputPath, string.Format("{0}.fxo", vmShader.Name)));
                errors = null;
            }

            return result;
        }

        static ShaderFlags FromShaderConfiguration()
        {
            ShaderConfiguration configuration = Settings.Default.DefaultShaderConfiguration;
            switch (configuration)
            {
                case ShaderConfiguration.Debug:
                    return ShaderFlags.Debug;

                default:
                case ShaderConfiguration.Release:
                    return ShaderFlags.None;
            }
        }

    }

    public class IncludeHandler : CallbackBase ,Include
    {
        internal static string BaseDirectory {get; set;}

        public void Close(Stream stream)
        {
            stream.Close();
        }


        public Stream Open(IncludeType type, string fileName, Stream parentStream)
        {
            return new FileStream(Path.Combine(BaseDirectory, fileName), FileMode.Open, FileAccess.Read);
        }

       
    }
}
