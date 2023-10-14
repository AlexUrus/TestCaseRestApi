namespace TestCaseRestApi.Mappers
{
    public interface IMapper<TModel, TObject>
    {
        TModel ToModel(TObject obj);
        TObject ToObject(TModel model);
    }
}
