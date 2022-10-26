using Units;

namespace Core
{
    public interface IInputController
    {
        void Init(Player player);
        void Enable();
        void Disable();
    }
}