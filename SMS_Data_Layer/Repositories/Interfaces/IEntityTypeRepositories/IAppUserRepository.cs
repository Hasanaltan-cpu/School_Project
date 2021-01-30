using SMS_Data_Layer.Repositories.Interfaces.Base;
using SMS_Entity_Layer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Data_Layer.Repositories.Interfaces.IEntityTypeRepositories
{
    public interface IAppUserRepository : IKernelRepository<AppUser> { }
  
}
