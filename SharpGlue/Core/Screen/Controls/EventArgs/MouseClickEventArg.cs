using   SharpGlue.Core.Input.States.Mouse;
namespace SharpGlue.Core.Screen.Controls.EventArgs
{
    public class MouseClickEventArg : MouseEventArg
    {
      MouseButtons mouseButton;

      /// <summary>
      /// Gets the mouse button.
      /// </summary>
      /// <value></value>
      public MouseButtons Button {
          get => mouseButton;
      }

      /// <summary>
      /// Initalize a new instance of <see cref="MouseClickEventArg"/>
      /// </summary>
      /// <param name="button"></param>
      /// <param name="position"></param>
      /// <returns></returns>
      public MouseClickEventArg(MouseButtons button, Vector2 position) : base(position) {
          mouseButton = button;
      }
    }
}