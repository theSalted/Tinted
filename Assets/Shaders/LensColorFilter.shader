Shader "Custom/LensColorFilter"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {} // Base texture (not actually used for the lens effect).
        _FilterColor ("Filter Color", Color) = (1, 0, 0, 1) // The color filter to apply.
        _BlendAmount ("Blend Amount", Range(0, 1)) = 0.0 // The amount to blend between original and filter colors.
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" } // Ensure the shader renders in the transparent queue.
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // Alpha blending for transparency.
            ZWrite Off // Disable depth writing for proper transparency sorting.
            Cull Off // Disable face culling to render both sides of the lens.
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _FilterColor;
            float _BlendAmount;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the base color (we use a solid color instead of the texture).
                fixed4 baseColor = float4(1.0, 1.0, 1.0, 1.0); // Default white color.

                // Calculate the blended color based on the blend amount.
                fixed4 blendedColor = lerp(baseColor, _FilterColor, _BlendAmount);

                // Set the output alpha to the blend amount to control transparency.
                blendedColor.a = _BlendAmount;

                return blendedColor;
            }
            ENDCG
        }
    }
}