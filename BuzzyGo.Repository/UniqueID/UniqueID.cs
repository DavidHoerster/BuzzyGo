using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzyGo.Repository.UniqueID
{
    public struct UniqueID
    {
        public Int64 SequenceID;
        public Guid UniqueIdentifier;
    }

    public static class UniqueIDUtility
    {
        public static Guid GetGuidForSequenceID(Int64 seqVal)
        {
            Int64? theSeq = seqVal;
            Guid? theGuid = Guid.Empty;

            using (Repository.BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                ctx.GetGuidForSequence(theSeq, ref theGuid);
            }

            if (theGuid.HasValue)
            {
                return theGuid.Value;
            }
            return Guid.Empty;
        }

        public static UniqueID GenerateNewUniqueID()
        {
            Int64? newSeq = null;
            Guid? newGuid = Guid.NewGuid();
            UniqueID newID;

            using (Repository.BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                ctx.GetNewSequence(newGuid, ref newSeq);
            }

            if (newSeq.HasValue && newGuid.HasValue)
            {
                newID = new UniqueID() { SequenceID = newSeq.Value, UniqueIdentifier = newGuid.Value };
            }
            else
            {
                newID = new UniqueID();
            }

            return newID;
        }
    }

}
