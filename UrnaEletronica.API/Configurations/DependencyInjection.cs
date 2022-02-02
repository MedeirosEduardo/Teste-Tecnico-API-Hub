using Microsoft.Extensions.DependencyInjection;
using UrnaEletronica.Domain;
using UrnaEletronica.Interface;
using UrnaEletronica.Repository;

namespace UrnaEletronica.API
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<ICandidateRepository, CandidateRepository>();
            serviceProvider.AddScoped<IVoteRepository, VoteRepository>();
        }
    }
}
