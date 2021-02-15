# Redux
A 3D game engine, full C# based.

# Objectives:

- Use Vulkan only.
- Be easy to use.
- The objects control the Render, a sample:
```C#
public class CustomComponent : Component
{
  public void Render(RenderContext context)
  {
    context.DrawEsphere(bounds: this.Hitbox, radius: 30d, texture: new ImageTexture(@"Assets/Image.png"));
  }
}
```

- Has the Avalonia/WPF or be an AvaloniaControl(more possible this)
 
With Avalonia/WPF model:
```c#
public class MainWindow : Redux.Window
{
  protected override void Loaded()
  {
    Content = new MainView();
  }
}
```
As Avalonia Control
```c#
//GameView inherits Avalonia.Control
public class MainGameView : Redux.Avalonia.GameView
{
  // something
}
```

- Can import OBJ/FBX files
```c#
public class CustomComp : Component
{
  readonly Redux3DModel model = new Redux3DModel(@"assets/model.obj");
  
  protected override Size Measure(Size availableSize) => model.Measure(avaiableSize);
  
  public override void Render(RenderContext context)
  {
    context.DrawModel(bounds: this.HitBox, model: model, texture: model.Texture);
  }
}
```
