using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzyGo.Model.Card
{
    public class ListCardsViewModel : BaseViewModel
    {
        public List<BuzzyGo.Repository.Card> Cards { get; set; } 
    }
}
