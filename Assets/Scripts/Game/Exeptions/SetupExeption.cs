/**
 * Класс исключения предварительных настроек игровых объектов
 */
namespace Game.Exeptions
{
    public class SetupExeption : System.Exception
    {

        public SetupExeption() : base()
        {

        }
        public SetupExeption(string message) : base(message)
        {

        }
    }
}
