using ApiSiram.Models;

namespace ApiSiram.ViewModels
{
    public class ActivityVM
    {
        public Activity activiy { get; set; }
        public List<DetailActivity> details_activity { get; set; }
    }
}
