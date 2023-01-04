using Gunluk.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gunluk.Components
{
    public class KategorilerViewComponent:ViewComponent
    {
        private readonly UygulamaDbContext _db;

        public KategorilerViewComponent(UygulamaDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult>InvokeAsync()
        {
            return View(_db.Kategoriler.ToList());
        }
    }
}
