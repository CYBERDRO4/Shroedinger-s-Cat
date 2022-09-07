namespace Game.Utils
{
    /**
     * Класс для паттерна "Одиночка" для доступа к экземпляру класса из любого скрипта
     */
    public sealed class Singletone<T> where T: UnityEngine.MonoBehaviour
    {
        private static T _instance;
        public static T instance
        {
            get { return _instance; }
            set
            {
                if (_instance == null)
                    _instance = value;
                else if (value == null)
                    _instance = null;
                else
                    throw new Exeptions.SingletoneAlreadyInitializedExeption($"instance of {_instance.GetType().Name} already initialized as singletone");
            }
        }
        
    }
}
