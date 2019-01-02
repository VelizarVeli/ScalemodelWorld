using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Scalemodel.Data.Models;
using ScalemodelWorld.Common;
using ScalemodelWorld.Common.Exceptions;
using ScalemodelWorld.Data;

namespace ScalemodelWorld.Services
{
   public abstract class BaseService
    {
        protected BaseService(
            ScalemodelWorldContext dbContext,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
            this.UserManager = userManager;
        }

        protected ScalemodelWorldContext DbContext { get; private set; }

        protected IMapper Mapper { get; private set; }

        protected UserManager<ScalemodelWorldUser> UserManager { get; private set; }

        protected async Task<ScalemodelWorldUser> GetUserByNamedAsync(string name)
        {
            var user = await this.UserManager.FindByNameAsync(name);

            CoreValidator.ThrowIfNull(user, new InvalidUserException());

            return user;
        }
    }
}
