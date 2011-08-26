using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzyGo.Model.Buzz
{
    public class ListBuzzwordsViewModel : BaseViewModel
    {
        public List<BuzzyGo.Repository.Buzzword> Buzzwords { get; set; }
    }
}
