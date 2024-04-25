namespace Solidarize.Application.UseCases;

public abstract class Handler<T>
{
    protected Handler<T>? sucessor;
    public dynamic SetSucessor(Handler<T> sucessor)
    {
        this.sucessor = sucessor;
        return this;
    }
    public abstract Task ProcessRequest(T request);
}
