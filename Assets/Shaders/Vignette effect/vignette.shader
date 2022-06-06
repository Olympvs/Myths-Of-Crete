Shader "Hidden/vignette"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _dmgTex("dmgTexture", 2D) = "white" {}
        _slider ("display name", Range(0, 1)) = 0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _dmgTex;
            float _slider;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 dmgTexture = tex2D(_dmgTex, i.uv);
                // just invert the colors
            if (dmgTexture.r < _slider && dmgTexture.g < _slider && dmgTexture.b < _slider)
            {
                if (_slider > 0.5 && dmgTexture.r >0.4 && dmgTexture.g > 0.4 && dmgTexture.b >0.4)
                {
                    col = col + fixed4(1, 0, 0, 1);
                }
                else
                {
                    col = fixed4(dmgTexture.r * 2, 0, 0, 1);
                }
                
            }
                return col;
            }
            ENDCG
        }
    }
}
