
namespace Assets.Scripts.Builds
{
    internal class Cafe:Build
    {
        private void Start()
        {
            Initialize();
            TypeName = GetType().Name;
        }
    }
}
