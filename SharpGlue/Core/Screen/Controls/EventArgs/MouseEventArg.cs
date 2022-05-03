namespace SharpGlue.Core.Screen.Controls.EventArgs
{
    public class MouseEventArg
    {
        Vector2 _position;

        /// <summary>
        /// Gets the position of the mouse.
        /// </summary>
        public Vector2 Position => _position;

        /// <summary>
        /// Initialize a new instance of <see cref="MouseEventArg"/>
        /// </summary>
        /// <param name="position"></param>
        public MouseEventArg(Vector2 position) => _position = position;
    }
}