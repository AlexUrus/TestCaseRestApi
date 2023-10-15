namespace TestCaseRestApi.Mappers.Object_Model
{
    public interface IMapperOM<TModel, TObject>
    {
        TModel ToModel(TObject obj);
        TObject ToObject(TModel model);
    }
}
