using Unity;

namespace ControlWork.StrFinderConsole
{
    public static class UnityConfig
    {
        static UnityConfig() {
            var container = new UnityContainer();

            // Установка зависимостей.

            var fileLogger = new FileLogger("log.txt");
            container.RegisterInstance<ILogger>(fileLogger, InstanceLifetime.Singleton);

            Container = container;
        }  

        public static UnityContainer Container { get; }
    }
}
