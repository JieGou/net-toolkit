﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

namespace NET.Tools.WPF.CodeComplex
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;
    using System.Diagnostics;

    /// \addtogroup effects 
    /// @{

    /// <summary>
    /// This is the implementation of an extensible framework ShaderEffect which loads
    /// a shader model 2 pixel shader. Dependecy properties declared in this class are mapped
    /// to registers as defined in the *.ps file being loaded below.
    /// </summary>
    public class ColorKeyAlphaEffect : ShaderEffect
    {
        #region Dependency Properties
        
        /// <summary>
        /// The explict input for this pixel shader.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ColorKeyAlphaEffect), 0);

        public static readonly DependencyProperty LimitProperty =
            DependencyProperty.Register(
                   "Limit",
                   typeof(float),
                   typeof(ColorShiftEffect),
                   new UIPropertyMetadata(0.3f, PixelShaderConstantCallback(0)));

        #endregion

        #region Member Data

        /// <summary>
        /// A refernce to the pixel shader used.
        /// </summary>
        private static PixelShader pixelShader;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of the shader from the included pixel shader.
        /// </summary>
        static ColorKeyAlphaEffect()
        {
            pixelShader = new PixelShader();
            pixelShader.UriSource = Global.GetPackageUri("CodeComplex/Shader/ColorKeyAlpha.ps");
        }

        /// <summary>
        /// Creates an instance and updates the shader's variables to the default values.
        /// </summary>
        public ColorKeyAlphaEffect()
        {
            this.PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
        }

        #endregion

        /// <summary>
        /// Gets or sets the Input of shader.
        /// </summary>
		[System.ComponentModel.BrowsableAttribute(false)]
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        /// <summary>
        /// Gets or sets the limit for alpha
        /// </summary>
        public float Limit
        {
            get { return (float) GetValue(LimitProperty); }
            set { SetValue(LimitProperty, value);}
        }
    }
    /// @}
}