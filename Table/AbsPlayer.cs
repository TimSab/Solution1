using System.Collections.Generic;

namespace Table
{
    public abstract class AbsPlayer
    {
        public string Name { get; protected set; }
        public List<Card> Hand { get; set; }
        public abstract int Score { get; }
        public int Money { get; set; }
        public abstract bool IsStand { get; set; }


        public abstract void Take(AbsPlayer playerFrom);
        public abstract void Take(AbsPlayer playerFrom, int count);
        public abstract void Give(AbsPlayer playerTo);
        public abstract void Give(AbsPlayer playerTo, int count);

        public override string ToString() => Name;
    }
}
