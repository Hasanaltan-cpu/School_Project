using Microsoft.AspNetCore.Mvc;

using SMS_Data_Layer.Repositories.Interfaces.IEntityTypeRepositories;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Entity_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Web_Layer.Models.Components
{
    public class MainMenuViewComponent:ViewComponent
    {


        private readonly IPageRepository _pageRepo;

        public MainMenuViewComponent(IPageRepository pageRepository) => _pageRepo = pageRepository;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await GetPagesAsync();
            return View(pages);
        }

        private async Task<List<Page>> GetPagesAsync() => await _pageRepo.Get(x => x.Status != Status.Passived);
    }
}
