using SharpGlue.Core.Input;
using SharpGlue.Core.Input.Methods;
using SharpGlue.Core.Input.States.Keyboard;
using SharpGlue.Core.Input.States.Mouse;

namespace SharpGlue.Core.Screen.Controls
{
    public delegate void ControlEventHandler<T>(object sender, T e);

    /// <summary>
    /// Represents a control base.
    /// </summary>
    public abstract class ControlBase : GameObject
    {
        public event ControlEventHandler<EventArgs.KeyDownEventArgs> KeyDown;
        public event ControlEventHandler<EventArgs.KeyDownEventArgs> KeyUp;

        public event ControlEventHandler<EventArgs.MouseEventArg> MouseMove;
        public event ControlEventHandler<EventArgs.MouseClickEventArg> MouseDown;
        public event ControlEventHandler<EventArgs.MouseClickEventArg> MouseUp;
        public event ControlEventHandler<EventArgs.MouseEventArg> MouseHover;

        public event ControlEventHandler<EventArgs.SizeChangedEventArgs> SizeChanged;

        Vector2 _position;
        Size _size;

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value></value>
        public new Vector2 Position {
            get => _position;
            set => _position = value;
        }

        /// <summary>
        /// Gets or sets the size of this control.
        /// </summary>
        /// <value></value>
        public new Size Size {
            get => _size;

            set {
                _size = value;
                SizeChanged?.Invoke(this, new EventArgs.SizeChangedEventArgs(
                    value
                ));
            }
        }

        /// <summary>
        /// Gets the bounds of this control.
        /// </summary>
        /// <value></value>
        public Rectangle Bounds {
            get{
                int x = (int)_position.X;
                int y = (int)_position.Y;
                return new(x, y, _size.Width, _size.Height);
            }
        }

        #region lets rap the input up.
        internal void _doInputCheck(InputSystem inputSystem) {
            var keyboard = inputSystem?.GetInput<KeyboardInput>();
            var mouse = inputSystem?.GetInput<MouseInput>();

            string[] _keys = (string[])System.Enum.GetNames(typeof(Keys));
            string[] _mouseButtons = (string[])System.Enum.GetNames(typeof(MouseButtons));

            if(keyboard != null) {
                foreach(var key in _keys) { 
                    // now we parse the key.

                    var newKey = (Keys)System.Enum.Parse(typeof(Keys), key);
                    if(keyboard.IsKeyDown(newKey)) KeyDown?.Invoke(this, new EventArgs.KeyDownEventArgs(newKey));
                    if(keyboard.IsKeyUp(newKey)) KeyUp?.Invoke(this, new EventArgs.KeyDownEventArgs(newKey));
                }
            }
            if(mouse != null) {
                if(mouse.CurrentPosition.X > mouse.LastPosition.X || mouse.CurrentPosition.Y > mouse.LastPosition.Y) {
                    MouseMove?.Invoke(this, new EventArgs.MouseEventArg(
                        mouse.CurrentPosition
                    ));
                }

                foreach(var button in _mouseButtons) {
                    //and parse :(

                    MouseButtons b = (MouseButtons)System.Enum.Parse(typeof(MouseButtons), button);
                    if(mouse.IsButtonDown(b)) 
                        MouseDown?.Invoke(this, new EventArgs.MouseClickEventArg(
                            b, 
                            mouse.CurrentPosition
                        ));
                    if(mouse.IsButtonUp(b))
                        MouseUp?.Invoke(this, new EventArgs.MouseClickEventArg(
                            b,
                            mouse.CurrentPosition
                        ));
                }

                var mouseBounds = new Rectangle(
                    (int)mouse.CurrentPosition.X,
                    (int)mouse.CurrentPosition.Y,
                    5,5
                );

                if(mouseBounds.Interact(Bounds)) MouseHover?.Invoke(this, new EventArgs.MouseEventArg(mouse.CurrentPosition));
            }
        }
        #endregion

        /// <summary>
        /// Load all this controls content.
        /// </summary>
        /// <param name="content"></param>
        public abstract void LoadContent(Content.ContentManager content);

        /// <summary>
        /// Update all this controls logics.
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws this controls content.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(GameTime gameTime, Graphics.SpriteBatch spriteBatch);
    }
}