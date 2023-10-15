namespace TestCaseRestApi.Mappers.DTO_Model
{
    public interface IMapperDM<TModel, TModelDTO>
    {
        TModel ToModel(TModelDTO modelDTO);
        TModelDTO ToModelDTO(TModel model);
    }
}
