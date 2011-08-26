using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzyGo.Model.Buzz
{
    public class CreateBuzzViewModel : BaseViewModel
    {
        public List<BuzzyGo.Repository.BuzzCategory> BuzzwordCategories { get; set; }
        public BuzzyGo.Repository.Buzzword TheBuzzword { get; set; }
    }
}
