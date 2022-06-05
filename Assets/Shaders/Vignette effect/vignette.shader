Shader "Hidden/vignette"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _dmgTex("dmgTexture", 2D) = "white" {}
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

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 dmgTexture = tex2D(_dmgTex, i.uv);
                // just invert the colors
            if (dmgTexture.r < 0.2 && dmgTexture.g < 0.2 && dmgTexture.b < 0.2)
            {
                col = fixed4(dmgTexture.r * 2, 0, 0, 1);
            }
                return col;
            }
            ENDCG
        }
    }
}
