using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzyGo.Model.Card
{
    public class ViewCardViewModel : BaseViewModel
    {
        public String Name { get; set; }
        public Int64 CardID { get; set; }
        public List<BuzzyGo.Repository.CardSquare> CardSquareInfo { get; set; }
    }
}
