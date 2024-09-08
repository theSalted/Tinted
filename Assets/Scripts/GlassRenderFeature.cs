using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlassRenderFeature : ScriptableRendererFeature
{
    class CustomRenderPass : ScriptableRenderPass
    {
        public RenderTargetIdentifier source;
        public RenderTargetIdentifier destination;
        private RenderTargetHandle temporaryColorTexture;
        private Material material;

        public CustomRenderPass(Material material)
        {
            this.material = material;
            temporaryColorTexture.Init("_TemporaryColorTexture");
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get("Glass Wall Effect");
            RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
            cmd.GetTemporaryRT(temporaryColorTexture.id, opaqueDesc);
            
            // Blit with the material for the glass effect
            Blit(cmd, source, destination, material);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(temporaryColorTexture.id);
        }
    }

    [System.Serializable]
    public class Settings
    {
        public Material glassWallMaterial;
    }

    public Settings settings = new Settings();
    private CustomRenderPass customRenderPass;

    public override void Create()
    {
        customRenderPass = new CustomRenderPass(settings.glassWallMaterial)
        {
            renderPassEvent = RenderPassEvent.AfterRenderingTransparents
        };
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        customRenderPass.source = renderer.cameraColorTarget;
        customRenderPass.destination = renderer.cameraColorTarget;
        renderer.EnqueuePass(customRenderPass);
    }
}