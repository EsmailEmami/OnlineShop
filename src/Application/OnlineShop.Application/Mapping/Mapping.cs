using AutoMapper;
using OnlineShop.Application.Core;

namespace OnlineShop.Application.Mapping
{
    public interface IMapping
    {
        TTarget Map<TSource, TTarget>(TSource value) where TSource : class where TTarget : class;
        TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class;
        TTarget Map<TSource, TTarget>(object source);
        IQueryable<TTarget> ProjectTo<TSource, TTarget>(IQueryable<TSource> source) where TSource : class where TTarget : class;
    }

    public class Mapping : IMapping
    {
        public TTarget Map<TSource, TTarget>(TSource value) where TSource : class where TTarget : class
        {
            var mapper = new Mapper(GetConfig<TSource, TTarget>());
            var result = mapper.Map<TSource, TTarget>(value);

            return result;
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class
        {
            var mapper = new Mapper(GetConfig<TSource, TTarget>());
            var result = mapper.Map(source, target);

            return result;
        }

        public TTarget Map<TSource, TTarget>(object source)
        {
            var mapper = new Mapper(GetConfig<TSource, TTarget>());
            var result = mapper.Map<TTarget>(source);

            return result;
        }

        public IQueryable<TTarget> ProjectTo<TSource, TTarget>(IQueryable<TSource> source) where TSource : class where TTarget : class
        {
            var mapper = new Mapper(GetConfig<TSource, TTarget>());
            var result = mapper.ProjectTo<TTarget>(source,"");

            return result;
        }

        private MapperConfiguration GetConfig<TSource, TTarget>()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(IApplicationService<,,,,,>));
                cfg.CreateMap<TSource, TTarget>();
            });

            return config;
        }
    }
}
