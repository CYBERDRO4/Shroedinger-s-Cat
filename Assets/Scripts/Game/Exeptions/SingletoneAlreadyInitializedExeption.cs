namespace Game.Exeptions
{
    public class SingletoneAlreadyInitializedExeption : System.Exception
    {

        public SingletoneAlreadyInitializedExeption() : base()
        {

        }
        public SingletoneAlreadyInitializedExeption(string message) : base(message)
        {

        }
    }
}
