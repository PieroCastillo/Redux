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

- Has the Avalonia/WPF model or be an AvaloniaControl(more possible this)
 
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
- Supports Non-FPS-dependent Animation System
```c#
public class CustomComp : Component
{
  protected override void Loaded()
  {
    base.Loaded();
    var anim = new Animation();
    anim.Clock = ReduxLocator.Current.GetService<IReduxGlobalClock>();
    anim.Duration = new TimeSpan(hours: 0, minutes: 0, seconds: 30);
    var points = this.AsModel().GetPoints(); //returns Redux.Points
    var topP = points.TryGetPointRelativeFrom(x: 30,y: 20,z: 30); //get a point if that exist, if not, creates a new point.
    anim.Frames = new AnimationFrames()
    {
      new AnimationFrame(cue: 0) { topP.X = 30, topP.Y = 20, topP.Z  = 30  },
      new AnimationFrame(cue: 100) { topP.X = 130, topP.Y = 120, topP.Z  = 130  }
    }
    this.Animations.Insert(0, anim);
  }
  
  protected override void OnPointerEnter(ReduxEventsArgs e)
  {
    var anim = this.Animations[0];
    
    anim.Starts();
  }
}
```
