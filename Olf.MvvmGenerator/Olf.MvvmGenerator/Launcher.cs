namespace Olf.MvvmGenerator
{
    public class Launcher
    {
        public static void Launch(object applicationObject = null)
        {
            App app;

            app = applicationObject == null ? new App() : new App(applicationObject);

            app.Run();
        }
    }
}