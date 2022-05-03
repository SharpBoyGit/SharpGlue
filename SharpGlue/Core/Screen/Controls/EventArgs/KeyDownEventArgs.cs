using SharpGlue.Core.Input.States.Keyboard;

namespace SharpGlue.Core.Screen.Controls.EventArgs
{
    public class KeyDownEventArgs
    {
        Keys _keyCode;

        /// <summary>
        /// Gets the key code.
        /// </summary>
        public Keys KeyCode => _keyCode;

        /// <summary>
        /// Initialize a new instance of <see cref="KeyDownEventArgs"/>
        /// </summary>
        /// <param name="keyCode"></param>
        public KeyDownEventArgs(Keys keyCode) => this._keyCode =keyCode;
    }
}