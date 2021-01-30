﻿using SMS_Data_Layer.ProjectContext;
using SMS_Data_Layer.Repositories.Concrete.Base;
using SMS_Data_Layer.Repositories.Interfaces.IEntityTypeRepositories;
using SMS_Entity_Layer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Data_Layer.Repositories.Concrete.EntityTypeRepositories
{
    public class LessonRepository : KernelRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}