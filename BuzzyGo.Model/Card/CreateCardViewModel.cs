using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzyGo.Model.Card
{
    [Serializable]
    public class CardBuzzWord
    {
        public Int64 BuzzWordID { get; set; }
        public String BuzzWord { get; set; }
    }

    [Serializable]
    public class CreateCardViewModel : BaseViewModel
    {
        public Repository.Card CardHeader { get; set; }
        public List<CardBuzzWord> CardBuzzWords { get; set; }
    }
}
