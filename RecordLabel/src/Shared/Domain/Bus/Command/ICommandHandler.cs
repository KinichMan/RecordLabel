
namespace RecordLabel.src.Shared.Domain.Bus.Command
{
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
}
