using OpenGLRayMarching.Graphics.OpenGLBindings.Texture;
using OpenTK.Graphics.OpenGL;
using SkiaSharp;
using GenerateMipmapTarget = OpenTK.Graphics.OpenGL.GenerateMipmapTarget;
using GL = OpenTK.Graphics.OpenGL.GL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;
using PixelInternalFormat = OpenTK.Graphics.OpenGL.PixelInternalFormat;
using PixelStoreParameter = OpenTK.Graphics.OpenGL.PixelStoreParameter;
using PixelType = OpenTK.Graphics.OpenGL.PixelType;
using TextureMinFilter = OpenTK.Graphics.OpenGL4.TextureMinFilter;
using TextureTarget = OpenTK.Graphics.OpenGL.TextureTarget;
using TextureWrapMode = OpenTK.Graphics.OpenGL4.TextureWrapMode;

namespace OpenGLRayMarching.Graphics;

public class Texture : TextureBase
{
    public int UnpackAlignment
    {
        get => _unpackAlignment;
        set => _unpackAlignment = value;
    }
    public bool AutoDispose
    {
        get => _autoDispose;
        set => _autoDispose = value;
    }
    public SKBitmap Map
    {
        get => _map;
        set => _map = value;
    }
    public float Aspect => _aspect;
    private float _aspect;

    private int? _height;
    private int? _width;

    private int _unpackAlignment = 4;
    private bool _autoDispose = false;

    private SKBitmap _map;

    public Texture(SKBitmap map, TextureMinFilter filter = TextureMinFilter.Linear, TextureWrapMode wrapMode = TextureWrapMode.Repeat)
    {
        _map = map;
        _aspect = (float)map.Width / map.Height;
        
        Filter = filter;
        WrapMode = wrapMode;
    }

    public override void Compile()
    {
        base.Compile();
        _id = GenerateTexture(_map, Filter, WrapMode, _autoDispose, _unpackAlignment);
    }

    public override void Dispose()
    {
        base.Dispose();
        GL.DeleteTexture(this);
    }

    public static int GenerateTexture(SKBitmap map, TextureMinFilter filter, TextureWrapMode wrapMode,
        bool dispose = false, int unpackAlignment = 4)
    {

        var id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);
        
        IntPtr pixelPointer = map.GetPixels();
        bool transparency = map.Info.AlphaType != SKAlphaType.Opaque;
        
        GL.TexImage2D(TextureTarget.Texture2D, 0,
             transparency ? PixelInternalFormat.Rgba : PixelInternalFormat.Rgb,
             map.Width, map.Height, 0,
             PixelFormat.Bgra,
             PixelType.UnsignedByte, pixelPointer);
        
        GL.TexParameter(TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureMinFilter, (int) filter);
        GL.TexParameter(TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureMagFilter, (int) filter);
        GL.TexParameter(TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureWrapS, (int) wrapMode);
        GL.TexParameter(TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureWrapT, (int) wrapMode);
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        
        GL.BindTexture(TextureTarget.Texture2D, 0);
        
        if (dispose) map.Dispose();
        return id;
    }
}