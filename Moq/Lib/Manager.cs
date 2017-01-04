namespace Lib
{
    public class Manager
    {
        private IController _controller;
        public IController Controller
        {
            get { return _controller ?? (_controller = new Controller()); }
            set { _controller = value; }
        }

        public int Add(int a, int b)
        {
            return Controller.Sub(a, b);
        }

        public string IntToString(int a)
        {
            return Controller.IntToString(a);
        }
    }
}
