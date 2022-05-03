namespace SharpGlue.Core.Screen.Controls.EventArgs
{
    public class SizeChangedEventArgs
    {
        Size _size;

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value></value>
        public Size Size {
            get => _size;
        }
        /// <summary>
        /// Initialize a new instance of <see cref="SizeChangedEventArgs"/>
        /// </summary>
        /// <param name="size"></param>
        public SizeChangedEventArgs(Size size) => _size = size;
    }
}