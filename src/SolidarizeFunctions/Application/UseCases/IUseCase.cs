namespace Solidarize.Application.UseCases;

public interface IUseCase<T>
{
    void Execute(T request);
}
