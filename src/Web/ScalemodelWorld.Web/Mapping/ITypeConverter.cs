using AutoMapper;

namespace ScalemodelWorld.Web.Mapping
{
    public interface ITypeConverter<in TSource, TDestination>
    {
        TDestination Convert(TSource source, TDestination destination, ResolutionContext context);
    }
}
